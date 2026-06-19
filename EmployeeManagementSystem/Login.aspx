<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="EmployeeManagementSystem.Login" %>

<!DOCTYPE html>
<html>
<head runat="server">
<title>Admin Login</title>

<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet"/>

<style>
body{
background:#f4f6f9;
}

.login-card{
margin-top:100px;
padding:30px;
border-radius:10px;
box-shadow:0 0 10px rgba(0,0,0,0.2);
background:white;
}
</style>

</head>

<body>

<form id="form1" runat="server">

<div class="container">

<div class="login-card mx-auto" style="max-width:400px">

<h3 class="text-center mb-4">Admin Login</h3>

<!-- Username -->
<label>Username</label>
<asp:TextBox 
ID="txtUsername" 
runat="server" 
CssClass="form-control">
</asp:TextBox>

<br/>

<!-- Password -->
<label>Password</label>
<asp:TextBox 
ID="txtPassword" 
runat="server" 
TextMode="Password" 
CssClass="form-control">
</asp:TextBox>

<br/>

<!-- Login Button -->
<asp:Button 
ID="btnLogin" 
runat="server" 
Text="Login" 
CssClass="btn btn-primary w-100" 
OnClick="btnLogin_Click"/>

<br /><br />

<!-- Forgot Password -->
<div class="text-center">

<asp:HyperLink 
ID="lnkForgot" 
runat="server" 
NavigateUrl="ForgotPassword.aspx">

Forgot Password?

</asp:HyperLink>

</div>

</div>

</div>

</form>

</body>
</html>