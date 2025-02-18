<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="frmLogin.aspx.cs" Inherits="Project.frmLogin" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Louis Pharmacy - Login
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <link rel="stylesheet" type="text/css" href="Styles.css" />
   

    <form ID="frm" runat="server">
        <div class="mx-auto p-2 card" style="width:75%">
            <h5 class="card-header">Employee Login</h5>
            <div class="card-body">
        <table style="align-items:center">
        <tr>
            <th>
                <div class="form-floating mb-3">
                    <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" type="Password" TabIndex="1"></asp:TextBox>
                <label for="lblUsername">Employee ID</label>
                    </div>
            </th>
        </tr>

        <tr>
            <th>
                <div class="form-floating mb-3">
                    <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" type="Password" TabIndex="2"></asp:TextBox>
                <label for="lblPassword">Password</label>
                    </div>
            </th>
        </tr>

        <tr>
            <td>
            <asp:Label ID="lblMessage" runat="server" Text="Incorrect Username or Password!!!" style="color:red"></asp:Label>
            </td>
        </tr>

        <tr>
        <td>
            <asp:Button ID="btnLogin" class="btn btn-primary" Text="Login" runat="server" OnClick="btnLogin_Click" TabIndex="3" />
            <br />
        </td>
        </tr>

        </table>
        </div>
        </div>
       </form>
</asp:Content>