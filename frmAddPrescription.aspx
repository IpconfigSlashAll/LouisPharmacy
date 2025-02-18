<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="frmAddPrescription.aspx.cs" Inherits="Project.frmAddPrescription" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Louis Pharmacy - Add Prescription
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <link rel="stylesheet" type="text/css" href="Styles.css" />
   
    <form ID="frm" runat="server">
        <div class="mx-auto p-2 card" style="width:75%">
            <h5 class="card-header">Add Prescription</h5>
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
                        <asp:TextBox ID="txtPatient" runat="server" TabIndex="1" CssClass="form-control" placeholder="S0000"></asp:TextBox>
                        <label for="txtPatient">Patient ID</label>
                    </div>
                </th>
                <th>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPatient"
                        class="Required" ErrorMessage="RequiredFieldValidator" Width="10px" ToolTip="Required Field">*</asp:RequiredFieldValidator>
                </th>
            </tr>
            <tr>
                <th>
                    <div class="form-floating mb-3">
                        <asp:TextBox ID="txtDoctor" runat="server" TabIndex="2" CssClass="form-control" placeholder="S0000"></asp:TextBox>
                        <label for="txtDoctor">Doctor ID</label>
                    </div>
                </th>
                <th>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDoctor"
                        class="Required" ErrorMessage="RequiredFieldValidator" Width="10px" ToolTip="Required Field">*</asp:RequiredFieldValidator>
                </th>
            </tr>
            <tr>
                <th>
                    <div class="form-floating mb-3">
                        <asp:TextBox ID="txtMed" runat="server" TabIndex="3" CssClass="form-control" placeholder="Asprin"></asp:TextBox>
                        <label for="txtMed">Medication name</label>
                    </div>
                </th>
                <th>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtMed"
                        class="Required" ErrorMessage="RequiredFieldValidator" Width="10px" ToolTip="Required Field">*</asp:RequiredFieldValidator>
                </th>
            </tr>
            <tr>
                <th>
                    <div class="form-floating mb-3">
                        <asp:TextBox ID="txtDosage" runat="server" TabIndex="4" CssClass="form-control" placeholder="1"></asp:TextBox>
                        <label for="txtDosage">Dosage</label>
                    </div>
                </th>
                <th>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtDosage"
                        class="Required" ErrorMessage="RequiredFieldValidator" Width="10px" ToolTip="Required Field">*</asp:RequiredFieldValidator>
                </th>
            </tr>
            <tr>
                <th>
                    <div class="form-floating mb-3">
                        <asp:TextBox ID="txtInt" runat="server" TabIndex="5" CssClass="form-control" placeholder="Mouth"></asp:TextBox>
                        <label for="txtInt">Intake method</label>
                    </div>
                </th>
                <th>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtInt"
                        class="Required" ErrorMessage="RequiredFieldValidator" Width="10px" ToolTip="Required Field">*</asp:RequiredFieldValidator>
                </th>
            </tr>
            <tr>
                <th>
                    <div class="form-floating mb-3">
                        <asp:TextBox ID="txtRefill" runat="server" TabIndex="6" CssClass="form-control" placeholder="0"></asp:TextBox>
                        <label for="txtRefill">Refills</label>
                    </div>
                </th>
                <th>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtRefill"
                        class="Required" ErrorMessage="RequiredFieldValidator" Width="10px" ToolTip="Required Field">*</asp:RequiredFieldValidator>
                </th>
            </tr>
            <tr>
                <th>
                    <asp:Button ID="btnAdd" class="btn btn-primary" Text="Add" runat="server" OnClick="btnAdd_Click" TabIndex="7" />
                    <asp:Button ID="btnCancel" class="btn btn-secondary" Text="Cancel" runat="server" OnClick="btnCancel_Click" CausesValidation="false" TabIndex="8" />
                </th>
            </tr>
        </table>
            </div>
        </div>
       </form>
</asp:Content>
