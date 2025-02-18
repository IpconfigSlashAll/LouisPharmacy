<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="frmAddDoctor.aspx.cs" Inherits="Project.frmAddDoctor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Louis Pharmacy - Add Doctor
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <link rel="stylesheet" type="text/css" href="Styles.css" />
   
    <form ID="frm" runat="server" submitdisabledcontrols="False">
        <div class="mx-auto p-2 card" style="width:75%">
            <h5 class="card-header">Add Doctor</h5>
            <div class="card-body">

        <tr>
            <th>
                <asp:Label ID="lblMessage" runat="server" Text="" CssClass="RED"></asp:Label>
            </th>
        </tr>

        <table style="align-items:center">
        <tr>
            <th>
                <div class="form-floating mb-3">
                    <asp:TextBox ID="txtFname" runat="server" TabIndex="1" CssClass="form-control" placeholder="John"></asp:TextBox>
                    <label for="txtFname">First name</label>
                </div>
            </th>
            <th>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Required Field" 
                    class="Required" ControlToValidate="txtFName" ToolTip="Required Field" Width="10px">*</asp:RequiredFieldValidator>
            </th>
        </tr>
        <tr>
            <th>
                <div class="form-floating mb-3">
                    <asp:TextBox ID="txtLName" runat="server" TabIndex="2" CssClass="form-control" placeholder="Smith"></asp:TextBox>
                    <label for="txtLName">Last name</label>
                </div>
                
            </th>
            <th>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Required Field" 
                    class="Required" ControlToValidate="txtLName" ToolTip="Required Field">*</asp:RequiredFieldValidator>
            </th>
        </tr>
        <tr>
            <th>
                <div class="form-floating mb-3">
                    <asp:TextBox ID="txtPhone" runat="server" TabIndex="3" CssClass="form-control" placeholder="0000000"></asp:TextBox>
                    <label for="txtPhone">Phone number</label>
                </div>
            </th>
        </tr>
        <tr>
            <th>
                <div class="form-floating mb-3">
                    <asp:TextBox ID="txtEmail" runat="server" type="Email" TabIndex="4" CssClass="form-control" placeholder="test@example.com"></asp:TextBox>
                    <label for="txtEmail">Email address</label>
                </div>
            </th>
        </tr>
        <tr>
            <th>
                <asp:Button ID="btnAdd" class="btn btn-primary" Text="Add" runat="server" OnClick="btnAdd_Click" TabIndex="5" />
                <asp:Button ID="btnCancel" class="btn btn-secondary" Text="Cancel" runat="server" href="main.aspx" OnClick="btnCancel_Click" CausesValidation="false" TabIndex="6" />
            </th>
        </tr>
        </table>
        </div>
        </div>
       </form>
</asp:Content>
