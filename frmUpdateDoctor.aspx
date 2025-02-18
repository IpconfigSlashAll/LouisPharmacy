<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="frmUpdateDoctor.aspx.cs" Inherits="Project.frmUpdateDoctor" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Louis Pharmacy - Update Doctor
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <link rel="stylesheet" type="text/css" href="Styles.css" />
   
    <form ID="frm" runat="server">
        <div class="mx-auto p-2 card" style="width:75%">
            <h5 class="card-header">Update Doctor</h5>
            <div class="card-body">

        <table style="align-items:center">

        <tr>
            <th>
                <asp:Label ID="lblMessage" runat="server" Text="" CssClass="RED"></asp:Label>
            </th>
        </tr>

            <tr>
                <th>
                    <div class="form-floating mb-3">
                        <asp:TextBox ID="txtDoctor" runat="server" CssClass="form-control" placeholder="S0000"></asp:TextBox>
                        <label for="txtDoctor">Doctor ID</label>
                    </div>
                </th>
            </tr>
            <tr>
                <th>
                    <div class="form-floating mb-3">
                        <asp:TextBox ID="txtFName" runat="server" CssClass="form-control" placeholder="John"></asp:TextBox>
                        <label for="txtFName">First name</label>
                    </div>
                </th>
            </tr>
            <tr>
                <th>
                    <div class="form-floating mb-3">
                        <asp:TextBox ID="txtLName" runat="server" CssClass="form-control" placeholder="Doe"></asp:TextBox>
                        <label for="txtLName">Last name</label>
                    </div>
                </th>
            </tr>
            <tr>
                <th>
                    <div class="form-floating mb-3">
                        <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control" placeholder="0000000"></asp:TextBox>
                        <label for="txtPhone">Phone number</label>
                    </div>
                </th>
            </tr>
            <tr>
                <th>
                    <div class="form-floating mb-3">
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="test@example.com"></asp:TextBox>
                        <label for="txtEmail">Email</label>
                    </div>
                </th>
            </tr>
            <tr>
                <th>
                    <asp:Button ID="btnUpdate" class="btn btn-primary" Text="Update" runat="server" OnClick="btnUpdate_Click" />
                    <asp:Button ID="btnCancel" class="btn btn-secondary" Text="Cancel" runat="server" OnClick="btnCancel_Click" />
                </th>
            </tr>
        </table>
            </div>
        </div>
       </form>
</asp:Content>

