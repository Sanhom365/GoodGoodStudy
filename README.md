# GoodGoodStudy
好好学习，天天向上！这是一个定时自动截屏的软件。原因，受疫情影响，孩子们要上网课，而我们家长要上班，那么如何能知道孩子用电脑是在上课还是在干什么呢？通过这个软件，可以定时截屏记录，并可以按要求截多少张图片后发送到指定的 E-Mail 地址，这样，就算家长在上班，也能实时了解孩子上网课的动态了。
## 设置参数说明
<table>
  <tr>
    <td>
      <b>名称</b>
    </td>
    <td>
      <b>类型</b>
    </td>
    <td>
      <b>功能</b>
    </td>
  </td>
  <tr>
    <td>
      <b>picpath</b>
    </td>
    <td>
      String
    </td>
    <td>
      图片存储路径
    </td>
  </td>
  <tr>
    <td>
      <b>interval</b>
    </td>
    <td>
      Byte
    </td>
    <td>
      间隔时间（分钟）
    </td>
  </td>
  <tr>
    <td>
      <b>method</b>
    </td>
    <td>
      Boolean
    </td>
    <td>
      是否发送邮件
    </td>
  </td>
  <tr>
    <td>
      <b>times</b>
    </td>
    <td>
     Byte
    </td>
    <td>
      截图几张打包一次邮件（仅在 <b>method</b> 为 True 时起作用）
    </td>
  </td>
  <tr>
    <td>
      <b>email</b>
    </td>
    <td>
      String
    </td>
    <td>
      设置你的 E-Mail 地址
    </td>
  </td>
  <tr>
    <td>
      <b>password</b>
    </td>
    <td>
      String
    </td>
    <td>
      设置为你的 E-Mail 密码，某些邮箱用授权码而非登录密码
    </td>
  </td>
  <tr>
    <td>
      <b>smtp</b>
    </td>
    <td>
      String
    </td>
    <td>
      SMTP 服务器地址
    </td>
  </td>
</table>