<%@ Page Title="" Language="C#" MasterPageFile="~/department.master" AutoEventWireup="true" CodeFile="Deptpage.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AutoGenerateSelectButton="True">
        <Columns>
            <asp:BoundField DataField="Supplierid" HeaderText="QuotationID" />
            <asp:BoundField DataField="Qutationid" HeaderText="SupplierID" />
            <asp:BoundField DataField="price" HeaderText="price" />
           
        </Columns>
        
       
    </asp:GridView>
</asp:Content>

