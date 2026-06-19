<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="EmployeeManagementSystem.ForgotPassword" %>

<!DOCTYPE html>
<html>
<head runat="server">
<title>Reset Password</title>

<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet"/>

</head>

<body>

<form id="form1" runat="server">

<div class="container mt-5" style="max-width:400px">

<h3 class="text-center">Reset Password</h3>

<label>Username</label>
<asp:TextBox ID="txtUsername" runat="server" CssClass="form-control"></asp:TextBox>

<br/>

<label>New Password</label>
<asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>

<br/>

<asp:Button ID="btnReset"
runat="server"
Text="Reset Password"
CssClass="btn btn-primary w-100"
OnClick="btnReset_Click" />

</div>

</form>

</body>
</html>