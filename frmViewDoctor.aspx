<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="frmViewDoctor.aspx.cs" Inherits="Project.frmViewDoctor" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Louis Pharmacy - View Doctor
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <link rel="stylesheet" type="text/css" href="Styles.css" />
   
   <script type="text/javascript">

       function SelectAll(id) {
           //get reference of GridView control
           var grid = document.getElementById("<%= dgvDoctor.ClientID %>");
           //variable to contain the cell of the grid
           var cell;

           if (grid.rows.length > 0) {
               //loop starts from 1. rows[0] points to the header.
               for (i = 1; i < grid.rows.length; i++) {
                   //get the reference of first column
                   cell = grid.rows[i].cells[5];

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
            <h5 class="card-header">View Doctor</h5>
            <div class="card-body">
        <table style="align-items:center">
        <tr>
            <th>
                <div class="form-floating mb-3">
            <asp:TextBox ID="txtDoctor" runat="server" CssClass="form-control" placeholder="McFarlane"></asp:TextBox>
                <label for="txtDoctor">Doctor name</label>
                    </div>
            </th>
        </tr>

        <tr>
        <td>
            <asp:Button ID="btnSearch" class="btn btn-primary" Text="Search" runat="server" OnClick="btnSearch_Click" />
            <asp:Button ID="btnCancel" class="btn btn-secondary" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
        </td>
        </tr>

        <tr class="gridview">
        <td colspan="2" align="center">
            <asp:GridView ID="dgvDoctor" AutoGenerateColumns="False" runat="server" AllowPaging="True"
                AllowSorting="True" OnSelectedIndexChanged="dgvDoctor_SelectedIndexChanged">
                <AlternatingRowStyle BackColor="#656565" />
                <RowStyle BackColor="#23272A" ForeColor="White" />

        <Columns>
            <asp:BoundField HeaderStyle-CssClass="heading" DataField="PhysicianID" HeaderText="Doctor ID" SortExpression="PhysicianID" />
            <asp:BoundField HeaderStyle-CssClass="header" DataField="FNAME" HeaderText="First Name" SortExpression="FNAME" />
            <asp:BoundField HeaderStyle-CssClass="header" DataField="LNAME" HeaderText="Last Name" SortExpression="LNAME" />
<%--            <asp:BoundField DataField="EMAIL" HeaderText="Email" SortExpression="EMAIL" />--%>
            <asp:BoundField HeaderStyle-CssClass="header" DataField="PHONE" HeaderText="Phone" SortExpression="PHONE" />

        <asp:TemplateField HeaderText="PhysicianID" >
        <HeaderTemplate>
            &nbsp;
            <asp:LinkButton ID="lbtnDelete" runat="server" OnCommand="Delete_Click" CssClass="header"
                CommandName="lbtnDelete" CommandArgument='<%#Eval("PhysicianID") %>'>Delete</asp:LinkButton> <br />
                        <asp:CheckBox ID="cbSelectAll" runat="server"  />
            <PagerSettings Mode="NumericFirstLast" FirstPageText="Go To First Page" LastPageText="Go To Last Page" Position="Top" />
        </HeaderTemplate>
        <ItemTemplate>
        <asp:CheckBox ID="chkDoctorID" runat="server" AutoPostBack="false" />
           <asp:Label ID="hidDoctorID" runat="server" Text='<%#Eval("PhysicianID") %>' Visible="false"></asp:Label> 
        </ItemTemplate>
        </asp:TemplateField>

        <asp:HyperLinkField DataNavigateUrlFields="PhysicianID" DataNavigateUrlFormatString="frmUpdateDoctor.aspx?ID={0} &type=view"           
          HeaderText="View" Text="View" runat="server" Target="_blank" ControlStyle-CssClass="header" >  
            <HeaderStyle HorizontalAlign="left" />
        </asp:HyperLinkField>
        <asp:TemplateField HeaderText="Edit">
<%--        <ItemTemplate>
        <asp:LinkButton ID="lbtnEdit" runat="server" OnCommand="lbtnEdit_Click" CommandName="lbtnEdit" CssClass="header"
            CommandArgument='<% # Eval  ("PhysicianID") %>'>Edit</asp:LinkButton>&nbsp;&nbsp;
        <asp:ImageButton ID="imgDelete" runat="server" CommandArgument='<% # Eval  ("PhysicianID") %>' OnCommand="Delete_Click"   
            CommandName="lbtnDelete" ImageUrl="~/images/delete.jpg" Height ="30"  Width ="30" />||
        <asp:ImageButton ID="imgEdit" runat="server" CommandArgument='<% # Eval  ("PhysicianID") %>' OnCommand="lbtnEdit_Click"   
            CommandName="lbtnEdit" ImageUrl="~/images/edit.jpg" Height ="30"  Width ="30" />
        </ItemTemplate>--%>

        <ItemTemplate>
            <asp:ImageButton ID="imgDelete" runat="server" CommandArgument='<% # Eval  ("PhysicianID") %>' OnCommand="Delete_Click"   
              CommandName="lbtnDelete" ImageUrl="~/images/delete.jpg" Height ="30"  Width ="30" />||
            <asp:ImageButton ID="imgEdit" runat="server" CommandArgument='<% # Eval  ("PhysicianID") %>' OnCommand="lbtnEdit_Click"   
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