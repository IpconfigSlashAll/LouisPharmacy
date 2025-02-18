<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="frmAddPatient.aspx.cs" Inherits="Project.frmAddPatient" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Louis Pharmacy - Add patient
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <link rel="stylesheet" type="text/css" href="Styles.css" />
    <form ID="frm" runat="server">
        <div class="mx-auto p-2 card" style="width:75%">
            <h5 class="card-header">Add Patient</h5>
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
                    <asp:TextBox ID="txtFName" runat="server" TabIndex="1" CssClass="form-control" placeholder="John"></asp:TextBox>
                    <label for="txtFName">First name</label>
                </div>
            </th>
            <th>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFName"
                    class="Required" ErrorMessage="RequiredFieldValidator" ToolTip="Required Field." Width="10px">*</asp:RequiredFieldValidator>
            </th>
        </tr>
        <tr>
            <th>
                <div class="form-floating mb-3">
                    <asp:TextBox ID="txtMI" runat="server" TabIndex="2" CssClass="form-control" placeholder="A" MaxLength="1"></asp:TextBox>
                    <label for="txtMI">Middle initial</label>
                </div>
           </th>
        </tr>
        <tr>
            <th>
                <div class="form-floating mb-3">
                    <asp:TextBox ID="txtLName" runat="server" TabIndex="3" CssClass="form-control" placeholder="Smith"></asp:TextBox>
                    <label for="txtLName">Last name</label>
                </div>
            </th>
            <th>
                <div class="form-floating mb-3">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtLName" 
                        class="Required" ErrorMessage="RequiredFieldValidator" Width="10px" ToolTip="Required Field.">*</asp:RequiredFieldValidator>
                </div>
            </th>
        </tr>
        <tr>
            <th>
                <asp:DropDownList ID="ddlGender" runat="server" TabIndex="4" CssClass="form-select mb-3" aria-label="Default select example">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Male</asp:ListItem>
                    <asp:ListItem>Female</asp:ListItem>
                </asp:DropDownList>
            </th>
            <th>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlGender"
                    class="Required"  ErrorMessage="RequiredFieldValidator" Width="10px" ToolTip="Please select a gender.">*</asp:RequiredFieldValidator>
            </th>
        </tr>
        <tr>
            <th>
                <div class="form-floating mb-3">
                    <asp:TextBox ID="txtDOB" runat="server" TabIndex="5" CssClass="form-control" placeholder="12/31/1969"></asp:TextBox>
                    <label for="txtDOB">Date of birth</label>
                </div>
                
            </th>
            <th>
                 <asp:RangeValidator ID="valrDate" runat="server" ControlToValidate="txtDOB" class="Required"
                     MinimumValue="12/31/1950" MaximumValue="1/1/9999" Type="Date" Display="Dynamic" Width="10px">*</asp:RangeValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtDOB"
                    class="Required" ErrorMessage="RequiredFieldValidator" ToolTip="D.O.B. must be in DD/MM/YYYY format." Width="10px">*</asp:RequiredFieldValidator>
            </th>
        </tr>
        <tr>
            <th>
                <div class="form-floating mb-3">
                    <asp:TextBox ID="txtPhone" runat="server" TabIndex="6" CssClass="form-control" placeholder="0000000"></asp:TextBox>
                    <label for="txtPhone">Phone number</label>
                </div>
            </th>
        </tr>
        <tr>
            <th>
                <div class="form-floating mb-3">
                    <asp:TextBox ID="txtAddress" runat="server" TabIndex="7" CssClass="form-control" placeholder="123 Stevens Way"></asp:TextBox>
                    <label for="txtAddress">Street</label>
                </div>
            </th>
        </tr>
        <tr>
            <th>
                <div class="form-floating mb-3">
                    <asp:TextBox ID="txtCity" runat="server" TabIndex="8" CssClass="form-control" placeholder="Lancaster"></asp:TextBox>
                    <label for="txtCity">City</label>
                </div>
            </th>
        </tr>
        <tr>
            <th>
                <div class="form-floating mb-3">
                    <asp:TextBox ID="txtZip" runat="server" TabIndex="9" CssClass="form-control" placeholder="17603" MaxLength="5"></asp:TextBox>
                    <label for="txtZip">ZIP code</label>
                </div>
            </th>
        </tr>
        <tr>
            <th>
                <asp:DropDownList ID="ddlState" runat="server" TabIndex="10" CssClass="form-select mb-3" aria-label="Default select example"></asp:DropDownList>
            </th>
        </tr>
        <tr>
            <th>
                <div class="form-floating mb-3">
                    <asp:TextBox ID="txtIns" runat="server" TabIndex="11" CssClass="form-control" placeholder="No"></asp:TextBox>
                    <label for="txtIns">Insurance</label>
                </div>
            </th>
            <th>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtIns" 
                    class="Required" ErrorMessage="RequiredFieldValidator" Width="10px" ToolTip="Insert Yes, No, Y or N">*</asp:RequiredFieldValidator>
            </th>
        </tr>
        <tr>
            <th>
                 <asp:DropDownList ID="ddlCountry" runat="server" TabIndex="12" CssClass="form-select mb-3" aria-label="Default select example">
                    <asp:ListItem>USA</asp:ListItem>
                </asp:DropDownList>
            </th>
        </tr>
        <tr>
            <th>
                <asp:Button ID="btnAdd" class="btn btn-primary" Text="Add" runat="server" OnClick="btnAdd_Click" TabIndex="13" />
                <asp:Button ID="btnClear" class="btn btn-outline-secondary" runat="server" Text="clear" TabIndex="14" OnClick="btnClear_Click" CausesValidation="false" />
                <asp:Button ID="btnCancel" class="btn btn-secondary" Text="Cancel" runat="server" OnClick="btnCancel_Click" CausesValidation="false" TabIndex="15" />
            </th>
        </tr>
        </table>
                </div>
            </div>
       </form>
</asp:Content>
