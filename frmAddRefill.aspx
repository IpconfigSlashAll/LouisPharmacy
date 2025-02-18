<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="frmAddRefill.aspx.cs" Inherits="Project.frmAddRefill" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Louis Pharmacy - Add Refill
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <link rel="stylesheet" type="text/css" href="Styles.css" />
   
    <form ID="frm" runat="server">
        <div class="mx-auto p-2 card" style="width:75%">
            <h5 class="card-header">Add Refill</h5>
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
                        <asp:TextBox ID="txtPresc" runat="server" TabIndex="1" CssClass="form-control" placeholder="S0000"></asp:TextBox>
                        <label for="txtPresc">Prescription ID</label>
                    </div>
                </th>
                <th>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPresc"
                        class="Required" ErrorMessage="RequiredFieldValidator" Width="10px">*</asp:RequiredFieldValidator>
                </th>
            </tr>
            <tr>
                <th>
                    <div class="form-floating mb-3">
                        <asp:TextBox ID="txtRefill" runat="server" TabIndex="2" CssClass="form-control" placeholder="0"></asp:TextBox>
                        <label for="txtRefill">Refill amount</label>
                    </div>
                </th>
            </tr>
            <tr>
                <th>
                    <asp:Button ID="btnAdd" class="btn btn-primary" Text="Add" runat="server" OnClick="btnAdd_Click" TabIndex="3" />
                    <asp:Button ID="btnCancel" class="btn btn-secondary" Text="Cancel" runat="server" OnClick="btnCancel_Click" CausesValidation="false" TabIndex="4" />
                </th>
            </tr>
        </table>
        </div>
        </div>
       </form>
</asp:Content>
