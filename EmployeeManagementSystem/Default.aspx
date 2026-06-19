<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master"
AutoEventWireup="true" CodeBehind="Default.aspx.cs"
Inherits="EmployeeManagementSystem._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

<style>
table td, table th{
    text-align:center;
    vertical-align:middle;
    word-break:break-word;
}
table{
    table-layout:fixed;
}
</style>

<div class="container">

<h2 class="text-center mb-4">Employee Management System</h2>

<div class="text-end mb-3">
<asp:Button ID="btnLogout" runat="server"
Text="Logout"
CssClass="btn btn-danger"
CausesValidation="False"
OnClick="btnLogout_Click" />
</div>

<!-- DASHBOARD -->
<div class="row text-center mb-4">

<div class="col-md-3">
<div class="card bg-primary text-white shadow">
<div class="card-body">
<h6>Total Employees</h6>
<h3><asp:Label ID="lblTotalEmp" runat="server"></asp:Label></h3>
</div>
</div>
</div>

<div class="col-md-3">
<div class="card bg-success text-white shadow">
<div class="card-body">
<h6>IT Department</h6>
<h3><asp:Label ID="lblIT" runat="server"></asp:Label></h3>
</div>
</div>
</div>

<div class="col-md-3">
<div class="card bg-warning text-white shadow">
<div class="card-body">
<h6>HR Department</h6>
<h3><asp:Label ID="lblHR" runat="server"></asp:Label></h3>
</div>
</div>
</div>

<div class="col-md-3">
<div class="card bg-info text-white shadow">
<div class="card-body">
<h6>Finance</h6>
<h3><asp:Label ID="lblFinance" runat="server"></asp:Label></h3>
</div>
</div>
</div>

<div class="col-md-3 mt-3">
<div class="card bg-dark text-white shadow">
<div class="card-body">
<h6>Marketing</h6>
<h3><asp:Label ID="lblMarketing" runat="server"></asp:Label></h3>
</div>
</div>
</div>

</div>

<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>

<!-- Employee Form -->
<div class="card p-4 mx-auto shadow" style="max-width:600px;">

<asp:ValidationSummary
ID="ValidationSummary1"
runat="server"
ValidationGroup="emp"
ForeColor="Red" />

<div class="mb-3">
<label>Department ID</label>

<asp:TextBox ID="txtDeptId"
runat="server"
CssClass="form-control"></asp:TextBox>

<asp:RequiredFieldValidator
ID="rfvDeptId"
runat="server"
ControlToValidate="txtDeptId"
ValidationGroup="emp"
ErrorMessage="Department ID Required"
ForeColor="Red" />
</div>

<div class="mb-3">
<label>Department Name</label>

<asp:DropDownList ID="ddlDepartment"
runat="server"
CssClass="form-control">

<asp:ListItem Text="Select Department" Value=""></asp:ListItem>
<asp:ListItem Text="IT" Value="IT"></asp:ListItem>
<asp:ListItem Text="HR" Value="HR"></asp:ListItem>
<asp:ListItem Text="Finance" Value="Finance"></asp:ListItem>
<asp:ListItem Text="Marketing" Value="Marketing"></asp:ListItem>

</asp:DropDownList>
</div>

<div class="mb-3">
<label>Employee Name</label>

<asp:TextBox ID="txtEmpName"
runat="server"
CssClass="form-control"></asp:TextBox>

<asp:RequiredFieldValidator
ID="rfvEmp"
runat="server"
ControlToValidate="txtEmpName"
ValidationGroup="emp"
ErrorMessage="Employee Name Required"
ForeColor="Red" />
</div>

<div class="mb-3">
<label>Salary</label>

<asp:TextBox ID="txtSalary"
runat="server"
CssClass="form-control"></asp:TextBox>
</div>

<div class="mb-3">
<label>Position</label>

<asp:TextBox ID="txtPosition"
runat="server"
CssClass="form-control"></asp:TextBox>
</div>

<div class="mb-3">
<label>Contact Number</label>

<asp:TextBox ID="txtContact"
runat="server"
CssClass="form-control"></asp:TextBox>

<asp:RegularExpressionValidator
ID="revContact"
runat="server"
ControlToValidate="txtContact"
ValidationGroup="emp"
ValidationExpression="^[0-9]{10}$"
ErrorMessage="Enter valid 10 digit number"
ForeColor="Red" />
</div>

<div class="mb-3">
<label>Email</label>

<asp:TextBox ID="txtEmail"
runat="server"
CssClass="form-control"></asp:TextBox>

<asp:RegularExpressionValidator
ID="revEmail"
runat="server"
ControlToValidate="txtEmail"
ValidationGroup="emp"
ValidationExpression="^\w+([-.+']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$"
ErrorMessage="Enter valid Email"
ForeColor="Red" />
</div>

<div class="text-center mt-3">

<asp:Button ID="btnInsert"
runat="server"
Text="Insert"
CssClass="btn btn-success me-2"
ValidationGroup="emp"
OnClick="btnInsert_Click" />

<asp:Button ID="btnUpdate"
runat="server"
Text="Update Salary"
CssClass="btn btn-warning me-2"
ValidationGroup="emp"
OnClick="btnUpdate_Click" />

<asp:Button ID="btnDelete"
runat="server"
Text="Delete"
CssClass="btn btn-danger me-2"
CausesValidation="False"
OnClientClick="return confirm('Are you sure you want to delete this employee?');"
OnClick="btnDelete_Click" />

<asp:Button ID="btnView"
runat="server"
Text="View Employee"
CssClass="btn btn-primary"
CausesValidation="False"
OnClick="btnView_Click" />

</div>

</div>

<br/>

<!-- Search -->
<div class="container mb-4" style="max-width:400px;">

<asp:TextBox ID="txtSearch"
runat="server"
CssClass="form-control"
placeholder="Search Employee Name"></asp:TextBox>

<br/>

<asp:Button ID="btnSearch"
runat="server"
Text="Search"
CssClass="btn btn-info w-100"
CausesValidation="False"
OnClick="btnSearch_Click" />

</div>

<!-- Employee Table -->
<div class="container">
<div class="table-responsive">

<asp:GridView
ID="GridView1"
runat="server"
CssClass="table table-bordered table-striped table-hover"
AutoGenerateColumns="False"
DataKeyNames="DeptId"
OnRowEditing="GridView1_RowEditing"
OnRowCancelingEdit="GridView1_RowCancelingEdit"
OnRowUpdating="GridView1_RowUpdating"
OnRowDeleting="GridView1_RowDeleting"
OnRowDataBound="GridView1_RowDataBound">

<Columns>

<asp:BoundField DataField="DeptId" HeaderText="Dept ID" ReadOnly="True" />
<asp:BoundField DataField="DeptName" HeaderText="Department" />
<asp:BoundField DataField="EmpName" HeaderText="Employee Name" />
<asp:BoundField DataField="Salary" HeaderText="Salary" />
<asp:BoundField DataField="Position" HeaderText="Position" />
<asp:BoundField DataField="ContactNumber" HeaderText="Contact" />
<asp:BoundField DataField="Email" HeaderText="Email" />

<asp:TemplateField HeaderText="Profile">
<ItemTemplate>
<a href='EmployeeDetails.aspx?id=<%# Eval("DeptId") %>'
class="btn btn-info btn-sm">
View
</a>
</ItemTemplate>
</asp:TemplateField>

<asp:CommandField
ShowEditButton="True"
ShowDeleteButton="True"
DeleteText="Delete" />

</Columns>

</asp:GridView>

</div>
</div>

</ContentTemplate>
</asp:UpdatePanel>

</div>

</asp:Content>