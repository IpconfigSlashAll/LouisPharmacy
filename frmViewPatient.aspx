<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="frmViewPatient.aspx.cs" Inherits="Project.frmViewPatient" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Louis Pharmacy - View Patient
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <link rel="stylesheet" type="text/css" href="Styles.css" />

   <script type="text/javascript">

       function SelectAll(id) {
           //get reference of GridView control
           var grid = document.getElementById("<%= dgvPatient.ClientID %>");
           //variable to contain the cell of the grid
           var cell;

           if (grid.rows.length > 0) {
               //alert("jon");
               //loop starts from 1. rows[0] points to the header.
               for (i = 1; i < grid.rows.length; i++) {
                   //get the reference of first column
                   cell = grid.rows[i].cells[8];
                  // alert("jon1");


                   //loop according to the number of childNodes in the cell
                   for (j = 0; j < cell.childNodes.length; j++) {
                    
                       //if childNode type is CheckBox                 
                       if (cell.childNodes[j].type == "checkbox") {
                           //alert("jon3");

                           //assign the status of the Select All checkbox to the cell checkbox within the grid
                           cell.childNodes[j].checked = document.getElementById(id).checked;
                       }
                   }
               }
           }
       }
   </script>
   
    <form ID="frm" runat="server">
        <div class="mx-auto p-2 card" style="width:75%">
            <h5 class="card-header">View Patient</h5>
            <div class="card-body">
        <table>
            <tr>
                <th>
                    <div class="form-floating mb-3">
            <asp:TextBox ID="txtPatient" runat="server" CssClass="form-control" placeholder="S0000"></asp:TextBox>
                        <label for="txtPatient">Patient name</label>
                    </div>
                 </th>
             </tr>

        <tr>
            <th>
        <asp:Button ID="btnSearch" class="btn btn-primary" Text="Search" runat="server" OnClick="btnSearch_Click" />
        <asp:Button ID="btnCancel" class="btn btn-secondary" Text="Cancel" runat="server" OnClick="btnCancel_Click" />
            </th>
        </tr>

        <tr >
        <td colspan="2" align="center">
            <asp:GridView ID="dgvPatient" AutoGenerateColumns="False" runat="server" AllowPaging="True" 
                AllowSorting="True" OnSelectedIndexChanged="dgvPatient_SelectedIndexChanged">
                <AlternatingRowStyle BackColor="#656565" />
                <RowStyle BackColor="#23272A" ForeColor="White" />

        <Columns>

            <asp:BoundField DataField="PATIENTID" HeaderText="Patient ID" SortExpression="PATIENTID" />
            <asp:BoundField DataField="FNAME" HeaderText="First Name" SortExpression="FNAME" />
            <asp:BoundField DataField="M_I" HeaderText="Middle Initial" SortExpression="M_I" />
            <asp:BoundField DataField="LNAME" HeaderText="Last Name" SortExpression="LNAME" />
            <asp:BoundField DataField="DOB" HeaderText="D.O.B" SortExpression="DOB" />
            <asp:BoundField DataField="GENDER" HeaderText="Gender" SortExpression="GENDER" />
            <asp:BoundField DataField="COUNTRY" HeaderText="Country"  SortExpression="COUNTRY"/>
            <asp:BoundField DataField="INSURANCE" HeaderText="Insurance"  SortExpression="INSURANCE"/>

        <asp:TemplateField HeaderText="Patient ID" >
        <HeaderTemplate>
             <asp:LinkButton ID="lbtnDelete" runat="server" OnCommand="Delete_Click" 
                CommandName="lbtnDelete" CommandArgument='<%#Eval("PATIENTID") %>'>Delete</asp:LinkButton> <br />
             <asp:CheckBox ID="cbSelectAll" runat="server" />
             <PagerSettings Mode="NumericFirstLast" FirstPageText="Go To First Page" LastPageText="Go To Last Page" Position="Top" />
        </HeaderTemplate>
        <ItemTemplate>
            <asp:CheckBox ID="chkPatID"  runat="server" AutoPostBack="false" />
            <asp:Label ID="hidPatID" runat="server" Text='<%#Eval("PATIENTID") %>' Visible="false"></asp:Label> 
        </ItemTemplate>
        </asp:TemplateField>

        <asp:HyperLinkField DataNavigateUrlFields="PATIENTID" DataNavigateUrlFormatString="frmUpdatePatient.aspx?ID={0} &type=View"           
           HeaderText="View" Text="View" runat="server" Target="_blank" >  
            <HeaderStyle HorizontalAlign="left" />
        </asp:HyperLinkField>
        <asp:TemplateField HeaderText="Edit">
        <ItemTemplate>
        <asp:LinkButton ID="lbtnEdit" runat="server" OnCommand="lbtnEdit_Click" CommandName="lbtnEdit"
            CommandArgument='<% # Eval  ("PATIENTID") %>'>Edit</asp:LinkButton>&nbsp;&nbsp;
        <asp:ImageButton ID="imgDelete" runat="server" CommandArgument='<% # Eval  ("PATIENTID") %>' OnCommand="Delete_Click"   
            CommandName="lbtnDelete" ImageUrl="~/images/delete.jpg" Height ="30"  Width ="30" />||
        <asp:ImageButton ID="imgEdit" runat="server" CommandArgument='<% # Eval  ("PATIENTID") %>' OnCommand="lbtnEdit_Click"   
            CommandName="lbtnEdit" ImageUrl="~/images/edit.jpg" Height ="30"  Width ="30" />
        </ItemTemplate>

        <ItemTemplate>
            <asp:ImageButton ID="imgDelete" runat="server" CommandArgument='<% # Eval  ("PATIENTID") %>' OnCommand="Delete_Click"   
              CommandName="lbtnDelete" ImageUrl="~/images/delete.jpg" Height ="30"  Width ="30" />||
            <asp:ImageButton ID="imgEdit" runat="server" CommandArgument='<% # Eval  ("PATIENTID") %>' OnCommand="lbtnEdit_Click"   
              CommandName="lbtnEdit" ImageUrl="~/images/edit.jpg" Height ="30"  Width ="30" />
         </ItemTemplate>

         <HeaderStyle HorizontalAlign="Left" />
        </asp:TemplateField>
        </Columns>
    
         <EmptyDataTemplate>No Records Found Matching Your Search!</EmptyDataTemplate>
    
        </asp:GridView>
        </td>  
        </tr>

        </table>
        </div>
        </div>
       </form>
</asp:Content>
