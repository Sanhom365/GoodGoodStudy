Imports System.Drawing
Imports System.Windows.Forms
Imports System.Threading
Imports System.IO
Imports System.IO.Compression
Imports System.Net.Mail

Module ModuleMain
	Dim picpath As String = My.Settings.picpath

	Sub Main()
		'Console.WriteLine(vbCrLf)
		Dim times As Byte = 0
		Dim i As Short
		Dim namestring(My.Settings.times - 1) As String
		If picpath.Substring(picpath.Length - 1) <> "\" Then
			' 判断路径的最后一个字符有没有“\”，没有就加上
			picpath &= "\"
		End If
		Do While True
			' 暂停的秒数
			For i = 0 To My.Settings.interval * 60
				' 每次暂停1秒
				Thread.Sleep(1000)
				Application.DoEvents()
			Next
			namestring(times) = picpath & Now.ToString("yyyyMMddHHmmss") & ".png"
			GetScreenshot(namestring(times))
			If times = My.Settings.times Then
				If My.Settings.method Then
					' 压缩图片，并发 E-mail 给自己
					SendMail(ZipCompression(namestring))

				End If
				times = 0
			Else
				times += 1
			End If
		Loop
	End Sub

	Private Sub GetScreenshot(ByVal filename As String)
		' 创建一个 Bitmap 对象，该对象的大小与当前屏幕大小相同
		Dim sbmp As New Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height)
		' 创建一个 Graphics 对象，该对象可以用于将屏幕复制到 Bitmap 中
		Dim gimg As Graphics = Graphics.FromImage(sbmp)
		' 使用 CopyFromScreen 方法将整个屏幕复制到 Bitmap 中
		gimg.CopyFromScreen(New Point(0, 0), New Point(0, 0), sbmp.Size)
		' 保存截屏到文件
		sbmp.Save(filename, Imaging.ImageFormat.Png)
	End Sub

	Private Function ZipCompression(ByVal namestring As String()) As String
		Dim j As Byte
		' 定义压缩后文件的文件路径
		Dim zipPath As String = picpath & "Screen.zip"
		' 创建 .zip 文件
		Using zip As ZipArchive = ZipFile.Open(zipPath, ZipArchiveMode.Create)
			' 遍历 namestring 里的所有图片文件
			For j = 0 To namestring.Length - 1
				' 添加文件到 .zip 文件中
				zip.CreateEntryFromFile(namestring(j), Path.GetFileName(namestring(j)))
			Next
		End Using
		For j = 0 To namestring.Length - 1
			' 删除原文件以节省本地空间
			File.Delete(namestring(j))
		Next
		Return zipPath
	End Function

	Private Sub SendMail(ByVal zipfile As String)
		Dim email As New MailMessage
		' 设置收件人、收件人地址和主题
		email.From = New MailAddress(My.Settings.email)
		email.To.Add(My.Settings.email)
		email.Subject = Environment.MachineName & "最新的" & My.Settings.times.ToString & "张屏幕截图"
		' 设置正文
		email.Body = ""
		' 添加 .zip 附件
		email.Attachments.Add(New Attachment(zipfile))
		' 创建 SMTP 客户端
		Dim smtp As New SmtpClient
		' 设置服务器地址
		smtp.Host = My.Settings.smtp
		' 设置用户名和密码
		smtp.Credentials = New Net.NetworkCredential(My.Settings.email, My.Settings.password)
		' 发送电子邮件
		smtp.Send(email)
	End Sub
End Module