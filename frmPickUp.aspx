<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="frmPickUp.aspx.cs" Inherits="Project.frmPickUp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Louis Pharmacy - Pickup Refills
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <link rel="stylesheet" type="text/css" href="Styles.css" />
   
    <form ID="frm" runat="server">
        <div class="mx-auto p-2 card" style="width:75%">
            <h5 class="card-header">Pickup Refill</h5>
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
                        <asp:TextBox ID="txtPresc" runat="server" CssClass="form-control" palaceholder="Asprin"></asp:TextBox>
                        <label for="txtPresc">Prescription ID</label>
                    </div>
                </th>
            </tr>
            <tr>
                <th>
                    <asp:DropDownList ID="ddlstatus" runat="server" CssClass="form-select mb-3" aria-label="Default select example"> <%--Empty option?--%>
                        <asp:ListItem>COMPLETED</asp:ListItem>
                        <asp:ListItem>PENDING</asp:ListItem>
                    </asp:DropDownList>
                </th>
            </tr>
            <tr>
                <th>
                    <asp:Button ID="btnSearch" class="btn btn-primary" Text="Pick Up" runat="server" OnClick="btnSearch_Click" /> 
                    <asp:Button ID="btnCancel" class="btn btn-secondary" Text="Cancel" runat="server" OnClick="btnCancel_Click" />
                </th>          
            </tr>
        </table> 
       </form>
</asp:Content>

