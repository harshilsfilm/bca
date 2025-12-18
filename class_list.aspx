<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="class_list.aspx.cs" Inherits="class_list.class_list" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Enter ID: <asp:TextBox ID="txtid" runat="server"></asp:TextBox>
            <br />
            Enter Name: <asp:TextBox ID="txtname" runat="server"></asp:TextBox>
            <br />
            Enter Salary: <asp:TextBox ID="txtsalary" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Btn_sub" runat="server" Text="Submit" OnClick="Btn_sub_Click" />

            <br />
            <asp:Label ID="lstLabel" runat="server" Text=""></asp:Label>

            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtname" runat="server" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
        </div>
    </form>
</body>
</html>
