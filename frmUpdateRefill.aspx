<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="frmUpdateRefill.aspx.cs" Inherits="Project.frmUpdateRefill" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Louis Pharmacy - Update Refill
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <link rel="stylesheet" type="text/css" href="Styles.css" />
   
    <form ID="frm" runat="server">
        <div class="mx-auto p-2 card" style="width:75%">
            <h5 class="card-header">Update Refill</h5>
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
                        <asp:TextBox ID="txtRX" runat="server" CssClass="form-control" placeholder="00000"></asp:TextBox>
                        <label for="txtRX">RX number</label>
                    </div>
                </th>
            </tr>
            <tr>
                <th>
                    <div class="form-floating mb-3">
                        <asp:TextBox ID="txtDate" runat="server" CssClass="form-control" placeholder="12/31/1969"></asp:TextBox>
                        <label for="txtDate">Refill date</label>
                    </div>
                </th>
            </tr>
            <tr>
                <th>
                    <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-select mb-3" aria-label="Default select example"> <%--Empty option?--%>
                        <asp:ListItem>COMPLETED</asp:ListItem>
                        <asp:ListItem>PENDING</asp:ListItem>
                    </asp:DropDownList>
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