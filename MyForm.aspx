<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyForm.aspx.cs" Inherits="Ashish_Google_Signing.MyForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>My Sign Form</title>
    <style>
table {
  font-family: arial, sans-serif;
  border-collapse: collapse;
  width: 100%;
}

td, th {
  border: 1px solid #dddddd;
  text-align: left;
  padding: 8px;
}

tr:nth-child(even) {
  background-color: #dddddd;
}

</style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <th>Account ID</th>
                    <th>Name</th>
                    <th>Email Address</th>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblAC_ID" runat="server"></asp:Label></td>
                    <td>
                        <asp:Label ID="lblName" runat="server"></asp:Label></td>
                    <td>
                        <asp:Label ID="lblAdd" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnLogin" runat="server" Text="Sign in with Google" OnClick="btnLogin_Click" BackColor="SkyBlue"></asp:Button></td>
                    <td></td> <td><asp:Button ID="btnLogout" runat="server" Text="Sign Out" OnClick="btnLogout_Click" BackColor="SkyBlue"/></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
