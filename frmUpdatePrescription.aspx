<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="frmUpdatePrescription.aspx.cs" Inherits="Project.frmUpdatePrescription" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Louis Pharmacy - Update Prescription
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <link rel="stylesheet" type="text/css" href="Styles.css" />
   
    <form ID="frm" runat="server">
        <div class="mx-auto p-2 card" style="width:75%">
            <h5 class="card-header">Update Prescription</h5>
            <div class="card-body">

        <table style="align-items:center">

        <tr>
            <th>
                <asp:Label ID="lblMessage" runat="server" Text="" CssClass="RED"></asp:Label>
            </th>
        </tr>

            <tr>
                <td>
                    <div class="form-floating mb-3">
                        <asp:TextBox ID="txtPresc" runat="server" CssClass="form-control" placeholder="S0000"></asp:TextBox>
                        <label for="txtPresc">Prescription ID</label>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div class="form-floating mb-3">
                        <asp:TextBox ID="txtPatient" runat="server" CssClass="form-control" placeholder="S0000"></asp:TextBox>
                        <label for="txtPatient">Patient ID</label>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div class="form-floating mb-3">
                        <asp:TextBox ID="txtDoctor" runat="server" CssClass="form-control" placeholder="S0000"></asp:TextBox>
                        <label for="txtDoctor">Doctor ID</label>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div class="form-floating mb-3">
                        <asp:TextBox ID="txtMed" runat="server" CssClass="form-control" placeholder="Asprin"></asp:TextBox>
                        <label for="txtMed">Medication name</label>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div class="form-floating mb-3">
                        <asp:TextBox ID="txtDosage" runat="server" CssClass="form-control" placeholder="Amount"></asp:TextBox>
                        <label for="txtMed">Dosage</label>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div class="form-floating mb-3">
                        <asp:TextBox ID="txtInt" runat="server" CssClass="form-control" placeholder="Mouth"></asp:TextBox>
                        <label for="txtInt">Intake method</label>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div class="form-floating mb-3">
                        <asp:TextBox ID="txtRefill" runat="server" CssClass="form-control" placeholder="0"></asp:TextBox>
                        <label for="txtRefill">Refills</label>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnUpdate" class="btn btn-primary" Text="Update" runat="server" OnClick="btnUpdate_Click" />
                    <asp:Button ID="btnCancel" class="btn btn-secondary" Text="Cancel" runat="server" OnClick="btnCancel_Click" />
                </td>
            </tr>
        </table>

            </div>
        </div>
       </form>
</asp:Content>