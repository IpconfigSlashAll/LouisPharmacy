<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="frmViewRefill.aspx.cs" Inherits="Project.frmViewRefill" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Louis Pharmacy - View Refills
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <link rel="stylesheet" type="text/css" href="Styles.css" />
   
   <script type="text/javascript">

       function SelectAll(id) {
           //get reference of GridView control
           var grid = document.getElementById("<%= dgvRefill.ClientID %>");
           //variable to contain the cell of the grid
           var cell;

           if (grid.rows.length > 0) {
               //loop starts from 1. rows[0] points to the header.
               for (i = 1; i < grid.rows.length; i++) {
                   //get the reference of first column
                   cell = grid.rows[i].cells[4];

                   //loop according to the number of childNodes in the cell
                   for (j = 0; j < cell.childNodes.length; j++) {
                       //if childNode type is CheckBox                 
                       if (cell.childNodes[j].type == "checkbox") {
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
            <h5 class="card-header">View Refills History</h5>
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
            <asp:TextBox ID="txtPresc" runat="server" CssClass="form-control" placeholder="empty"></asp:TextBox>
                    <label for="txtPresc">Prescription ID</label>
                    </div>
        <asp:Button ID="btnSearch" class="btn btn-primary" Text="Search" runat="server" OnClick="btnSearch_Click" />
        <asp:Button ID="btnCancel" class="btn btn-secondary" Text="Cancel" runat="server" OnClick="btnCancel_Click" />
                 </th>
             </tr>

        <tr >
        <td colspan="2" align="center">
            <asp:GridView ID="dgvRefill" AutoGenerateColumns="False" runat="server" AllowPaging="True" style="text-decoration:none"
                AllowSorting="True" OnSelectedIndexChanged="dgvRefill_SelectedIndexChanged">
                <AlternatingRowStyle BackColor="#656565" />
                <RowStyle BackColor="#23272A" ForeColor="White" />

        <Columns>
            <asp:BoundField DataField="RX_NO" HeaderText="RX_NO" SortExpression="RX_NO" />
            <asp:BoundField DataField="PrescriptionID" HeaderText="Prescription ID" SortExpression="PrescriptionID" />
            <asp:BoundField DataField="RefillDate" HeaderText="Refill Date" SortExpression="RefillDate" />
            <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />

        <asp:TemplateField HeaderText="PhysicianID" >
        <HeaderTemplate>
            &nbsp;
            <asp:LinkButton ID="lbtnDelete" runat="server" OnCommand="Delete_Click" 
                CommandName="lbtnDelete" CommandArgument='<%#Eval("RX_NO") %>'>Delete</asp:LinkButton> <br />
                        <asp:CheckBox ID="cbSelectAll" runat="server"  />
                <PagerSettings Mode="NumericFirstLast" FirstPageText="Go To First Page" LastPageText="Go To Last Page" Position="Top" />
        </HeaderTemplate>
        <ItemTemplate>
        <asp:CheckBox ID="chkRXID" runat="server" AutoPostBack="false" />
           <asp:Label ID="hidRXID" runat="server" Text='<%#Eval("RX_NO") %>' Visible="false"></asp:Label>
           <asp:Label ID="hidPrescID" runat="server" Text='<%#Eval("PrescriptionID") %>' Visible="false"></asp:Label> 
        </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Edit">
        <ItemTemplate>
        <asp:LinkButton ID="lbtnEdit" runat="server" OnCommand="lbtnEdit_Click" CommandName="lbtnEdit"
            CommandArgument='<% # Eval  ("RX_NO") %>'>Edit</asp:LinkButton>&nbsp;&nbsp;
        <asp:ImageButton ID="imgDelete" runat="server" CommandArgument='<% # Eval  ("RX_NO") %>' OnCommand="Delete_Click"   
            CommandName="lbtnDelete" ImageUrl="~/images/delete.jpg" Height ="30"  Width ="30" />||
        <asp:ImageButton ID="imgEdit" runat="server" CommandArgument='<% # Eval  ("RX_NO") %>' OnCommand="lbtnEdit_Click"   
            CommandName="lbtnEdit" ImageUrl="~/images/edit.jpg" Height ="30"  Width ="30" />
        </ItemTemplate>

        <ItemTemplate>
            <asp:ImageButton ID="imgDelete" runat="server" CommandArgument='<% # Eval  ("RX_NO") %>' OnCommand="Delete_Click"   
              CommandName="lbtnDelete" ImageUrl="~/images/delete.jpg" Height ="30"  Width ="30" />||
            <asp:ImageButton ID="imgEdit" runat="server" CommandArgument='<% # Eval  ("RX_NO") %>' OnCommand="lbtnEdit_Click"   
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
