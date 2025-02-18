<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="frmUpdatePatient.aspx.cs" Inherits="Project.frmUpdatePatient" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Louis Pharmacy - Patient
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <link rel="stylesheet" type="text/css" href="Styles.css" />
    <form ID="frm" runat="server">
        <div class="mx-auto p-2 card" style="width:75%">
            <h5 class="card-header">Update Patient</h5>
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
                        <asp:TextBox ID="txtPatient" runat="server" CssClass="form-control" placeholder="S0000"></asp:TextBox>
                        <label for="txtPatient">Patient ID</label>
                    </div>
                </th>
            </tr>
            <tr>
                <th>
                    <div class="form-floating mb-3">
                        <asp:TextBox ID="txtGender" runat="server" CssClass="form-control" placeholder="Gen"></asp:TextBox>
                        <label for="txtGender">Gender</label>
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
                        <asp:TextBox ID="txtMI" runat="server" CssClass="form-control" placeholder="Initial"></asp:TextBox>
                        <label for="txtFName">M.I.</label>
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
                        <asp:TextBox ID="txtDOB" runat="server" CssClass="form-control" placeholder="12/31/1969"></asp:TextBox>
                        <label for="txtDOB">Date of birth</label>
                    </div>
                </th>
            </tr>
            <tr>
                <th>
                    <div class="form-floating mb-3">
                        <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" placeholder="123 Stevens Way"></asp:TextBox>
                        <label for="txtAddress">Street</label>
                    </div>
                </th>
            </tr>
            <tr>
                <th>
                    <div class="form-floating mb-3">
                        <asp:TextBox ID="txtCity" runat="server" CssClass="form-control" placeholder="Lancaster"></asp:TextBox>
                        <label for="txtCity">City</label>
                    </div>
                </th>
            </tr>
            <tr>
                <th>
                    <div class="form-floating mb-3">
                        <asp:TextBox ID="txtZip" runat="server" CssClass="form-control" placeholder="17603"></asp:TextBox>
                        <label for="txtZip">ZIP code</label>
                    </div>
                </th>
            </tr>
            <tr>
                <th>
                    <div class="form-floating mb-3">
                        <asp:TextBox ID="txtIns" runat="server" CssClass="form-control" placeholder="No"></asp:TextBox>
                        <label for="txtIns">Insurance</label>
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
                    <asp:DropDownList ID="ddlState" runat="server" CssClass="form-select mb-3" aria-label="Default select example"></asp:DropDownList>
                </th>
            </tr>
            <tr>
                <th>
                    <asp:DropDownList ID="ddlCountry" runat="server" CssClass="form-select mb-3" aria-label="Default select example">
                        <asp:ListItem>USA</asp:ListItem>
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
