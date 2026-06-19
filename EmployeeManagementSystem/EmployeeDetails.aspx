<%@ Page Language="C#" AutoEventWireup="true"
CodeBehind="EmployeeDetails.aspx.cs"
Inherits="EmployeeManagementSystem.EmployeeDetails" %>

<!DOCTYPE html>
<html>
<head runat="server">

<title>Employee Details</title>

<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" />

<style>

body{
background:#f5f7fa;
}

.avatar{
width:140px;
height:140px;
border-radius:50%;
border:4px solid #dee2e6;
box-shadow:0 4px 10px rgba(0,0,0,0.15);
object-fit:cover;
}

.card{
border-radius:12px;
}

</style>

</head>

<body>

<form id="form1" runat="server">

<div class="container mt-5">

<div class="card shadow mx-auto p-4" style="max-width:650px">

<h3 class="text-center mb-4">Employee Details</h3>

<!-- Avatar -->
<div class="text-center mb-4">

<asp:Image ID="imgEmployee"
runat="server"
CssClass="avatar"
AlternateText="Employee Avatar" />

</div>

<!-- Employee Details Table -->
<table class="table table-bordered table-striped">

<tr>
<th style="width:40%">Department ID</th>
<td>
<asp:Label ID="lblDeptId" runat="server"></asp:Label>
</td>
</tr>

<tr>
<th>Department Name</th>
<td>
<asp:Label ID="lblDeptName" runat="server"></asp:Label>
</td>
</tr>

<tr>
<th>Employee Name</th>
<td>
<asp:Label ID="lblEmpName" runat="server"></asp:Label>
</td>
</tr>

<tr>
<th>Salary</th>
<td>
<asp:Label ID="lblSalary" runat="server"></asp:Label>
</td>
</tr>

<tr>
<th>Position</th>
<td>
<asp:Label ID="lblPosition" runat="server"></asp:Label>
</td>
</tr>

<tr>
<th>Contact</th>
<td>
<asp:Label ID="lblContact" runat="server"></asp:Label>
</td>
</tr>

<tr>
<th>Email</th>
<td>
<asp:Label ID="lblEmail" runat="server"></asp:Label>
</td>
</tr>

</table>

<!-- Back Button -->
<div class="text-center mt-3">

<asp:Button ID="btnBack"
runat="server"
Text="Back to Employees"
CssClass="btn btn-primary"
PostBackUrl="Default.aspx" />

</div>

</div>

</div>

</form>

</body>
</html>