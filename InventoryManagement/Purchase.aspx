<%@ Page Title="Purchase" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Purchase.aspx.cs" Inherits="Store" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
       <style type="text/css">
    .auto-style41 {
        text-align: center;
    }
    .auto-style42 {
        width: 100%;
    }
    .auto-style43 {
            text-align: right;
            width: 608px;
        }
    .auto-style44 {
        text-align: left;
    }
        .auto-style46 {
        text-align: right;
        width: 571px;
               height: 30px;
           }
    .auto-style49 {
        text-align: right;
        width: 11px;
               height: 30px;
           }
    .auto-style50 {
        text-align: center;
        width: 73px;
               height: 30px;
           }
        .auto-style51 {
            text-align: center;
        }
        .auto-style52 {
            color: #003399;
        }
           .auto-style53 {
               margin-left: 0px;
           }
           .auto-style54 {
               text-align: left;
               height: 30px;
           }
           .auto-style55 {
               height: 23px;
           }
           .auto-style56 {
               text-align: right;
               width: 608px;
               height: 64px;
           }
           .auto-style57 {
               text-align: left;
               height: 64px;
           }
           .auto-style58 {
               text-align: right;
               width: 608px;
               height: 26px;
           }
           .auto-style59 {
               text-align: left;
               height: 26px;
           }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="auto-style41">
    <h3 class="auto-style52">Purchase</h3>
        <asp:HiddenField ID="hfPurchaseId" runat="server" />
    <table class="auto-style42">
        <tr>
            <td class="auto-style43" colspan="2">
                <asp:Label ID="Label5" runat="server" Text="Purchase Id" Visible="False"></asp:Label>
            </td>
            <td class="auto-style44" colspan="8">
                <asp:TextBox ID="TextBox1" runat="server" ReadOnly="True" Visible="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style43" colspan="2">Product Name:</td>
            <td class="auto-style44" colspan="8">
                <asp:DropDownList ID="DropDownProduct" runat="server" Height="26px" Width="128px" AppendDataBoundItems="True" AutoPostBack="True" >
                    <asp:ListItem>Select Product Name</asp:ListItem>
                    
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style58" colspan="2">Supplier Name :<br />
                <asp:Label ID="Label4" runat="server" Text="Department Id"></asp:Label>
            &nbsp;:</td>
            <td class="auto-style59" colspan="8">
                <asp:DropDownList ID="DropDownSupplier" runat="server" Height="26px" Width="128px" AppendDataBoundItems="True" AutoPostBack="True" >
                    <asp:ListItem>Select Supplier name</asp:ListItem>
                    
                </asp:DropDownList>
                <br />
                <asp:DropDownList ID="DropDownDepartment" runat="server"  Height="26px" Width="128px" AppendDataBoundItems="True" DataSourceID="SqlDataSource1" DataTextField="DepartmentId" DataValueField="DepartmentId" AutoPostBack="True" >
                    <asp:ListItem>Select Department id</asp:ListItem>
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:InventoryMangementConnectionString %>" SelectCommand="SELECT [DepartmentId] FROM [Department]"></asp:SqlDataSource>
                <br />
            </td>
        </tr>
        <tr>
            <td class="auto-style43" colspan="2">Quantity (Packet):</td>
            <td class="auto-style44" colspan="8">
                <asp:TextBox ID="txtQuantity" runat="server" Width="128px" onkeydown="return (!(event.keyCode>=65) && event.keyCode!=32);"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style43" colspan="2">
                Total Amount:<br />
                <asp:Label ID="Label2" runat="server" Text="Date:OfPurchase:"></asp:Label>
            </td>
            <td class="auto-style44" colspan="8">
                <asp:TextBox ID="txtAmount" runat="server"></asp:TextBox>
                <br />
                <asp:TextBox ID="txtDate" runat="server" TextMode="Date"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style43" colspan="2">Others :</td>
            <td class="auto-style44" colspan="8">
                <asp:TextBox ID="txtOthers" runat="server" TextMode="MultiLine" MaxLength="99" Width="128px" style="margin-right: 0px"></asp:TextBox>
            </td>
        </tr>

       
        <tr>
            <td class="auto-style56" colspan="2">
                <br />
                <br />
                <br />
                <asp:Label ID="Label1" runat="server" Text="Upload Invoice:"></asp:Label>
                <br />
                <br />
            </td>
            <td class="auto-style57" colspan="8">
                <asp:FileUpload ID="FileUpload1" runat="server" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Image ID="Image1" runat="server" Height="64px" Width="114px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnupload" runat="server" OnClick="btnupload_Click" Text="Upload" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <br />
&nbsp;<asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </td>
        </tr>

       
        <tr>
            <td class="auto-style43" colspan="2">&nbsp;
                <asp:Button ID="btnsave" runat="server" Text="Save" Font-Bold="True" OnClick="btnsave_Click" Width="55px" />
            </td>
            <td class="auto-style44">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btndelete" runat="server" Text="Delete" Width="56px" Font-Bold="True" OnClick="btndelete_Click" CssClass="auto-style53" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnclear" runat="server" Text="Clear" Font-Bold="True" OnClick="btnclear_Click" Width="56px" />
            </td>
            <td class="auto-style44">
                &nbsp;</td>
            <td class="auto-style44">
                &nbsp;</td>
            <td class="auto-style44">
                &nbsp;</td>
            <td class="auto-style44">
                &nbsp;</td>
            <td class="auto-style44">
                &nbsp;</td>
            <td class="auto-style44">
                &nbsp;</td>
            <td class="auto-style44">
                &nbsp;</td>
        </tr>

       
        <tr>
            <td class="auto-style46">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </td>
            <td class="auto-style49">
                &nbsp;</td>
            <td class="auto-style50" colspan="4">
                &nbsp;</td>
            <td class="auto-style54" colspan="4">
                </td>
        </tr>
        <tr>
            <td colspan="10" class="auto-style55">
                <asp:Label ID="lblsuccessmassage" runat="server" Text="" ForeColor="Green"></asp:Label>
                <asp:Label ID="lblerrormessage" runat="server" Text="" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
    </table>
        <h4>
            <br />
            <span class="auto-style52">Purchase List</span><br />
        <br />
        </h4>
        <div class="auto-style51">
       <%-- <asp:GridView ID="purchaseGrid" runat="server" AutoGenerateColumns="False" HorizontalAlign="Center" AllowPaging="True" PageSize="5" AllowSorting="True" OnSelectedIndexChanged="purchaseGrid_SelectedIndexChanged1"  >
            <columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="id"  HeaderText="Purchase Id" SortExpression="id" />
                <asp:BoundField Datafield="PurchaseId" HeaderText="DepartmentId" SortExpression="PurchaseId" />
                <asp:BoundField Datafield="ProductName" HeaderText="ProductName" SortExpression="ProductName" />
                <asp:BoundField Datafield="SupplierName" HeaderText="SupplierName" SortExpression="SupplierName" />
                <asp:BoundField Datafield="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
                <asp:BoundField Datafield="DateOfPurchase" HeaderText="DateOfPurchase" SortExpression="DateOfPurchase" />
                <asp:BoundField DataField="Others" HeaderText="Others" SortExpression="Others" />
                
            </columns>--%>
       <%-- </asp:GridView>--%>
            
            <center>
                        <asp:GridView ID="purchaseGrid1" runat="server"  AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="id"  PageSize="10" OnSelectedIndexChanged="purchaseGrid1_SelectedIndexChanged1">
                <Columns>
                     <asp:CommandField ShowSelectButton="True" />
                    <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                    <asp:BoundField DataField="PurchaseId" HeaderText="DepartmentId" SortExpression="PurchaseId" />
                    <asp:BoundField DataField="ProductName" HeaderText="ProductName" SortExpression="ProductName" />
                    <asp:BoundField DataField="SupplierName" HeaderText="SupplierName" SortExpression="SupplierName" />
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
                    <asp:BoundField DataField="TotalAmount" HeaderText="TotalAmount" SortExpression="TotalAmount" />
                    <asp:BoundField DataField="DateOfPurchase" HeaderText="DateOfPurchase" SortExpression="DateOfPurchase" />
                    <asp:BoundField DataField="Others" HeaderText="Others" SortExpression="Others" />
                </Columns>
            </asp:GridView>

                </center>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:InventoryMangementConnectionString %>" SelectCommand="SELECT * FROM [Purchase]"></asp:SqlDataSource>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Export To Excel" />
            <br />
        </div>
</div>
</asp:Content>

