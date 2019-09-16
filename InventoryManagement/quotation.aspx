<%@ Page Title="Quotations" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="quotation.aspx.cs" Inherits="Sales" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
    <style type="text/css">
    .auto-style41 {
        text-align: center;
    }
    .auto-style42 {
        width: 100%;
    }
    .auto-style44 {
        text-align: left;
    }
        .auto-style51 {
            text-align: center;
        }
        .auto-style52 {
            color: #003399;
            font-weight: normal;
        }
           .auto-style54 {
            text-align: left;
            text-decoration: none;
        }
        .auto-style55 {
            color: #003399;
            text-align: center;
        }
        .auto-style56 {
            width: 100%;
            height: 140px;
        }
        .auto-style59 {
            width: 65%;
        }
         .auto-style77 {
            width: 5%;
        }
           .auto-style79 {
            width: 5%;
        }
          .auto-style78 {
            height: 30px;
        }
        
        .auto-style60 {
            width: 173px;
            text-align: center;
        }
        .auto-style65 {
            width: 10%;
            height: 30px;
        }
        .auto-style68 {
            width: 173px;
            color: #0033CC;
            height: 26px;
            text-align: right;
        }
        .auto-style69 {
            width: 28px;
            height: 30px;
        }
        .auto-style71 {
            color: #0033CC;
            text-align: center;
        }
        .auto-style72 {
            width: 65%;
            height: 26px;
            text-align: center;
            color: #003399;
        }
        .auto-style73 {
            width: 15%;
            color: #0033CC;
            text-align: right;
        }
        .auto-style74 {
            color: #0033CC;
            text-align: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>
   <div class="auto-style54">
    <h3 class="auto-style55">Quotation</h3>
       <div class="auto-style44">
           
           <table class="auto-style56">
               <tr>
                   <td class="auto-style78">&nbsp;</td>
                   <td class="auto-style65">
                       &nbsp;</td>
                   <td class="auto-style65">
                       &nbsp;</td>
                   <td class="auto-style72" colspan="2"><strong>Quotation Result</strong></td>
                   <td class="auto-style79">
                       &nbsp;</td>
               </tr>
               <tr>
                   <td class="auto-style74">
                       Qutations Id&nbsp; </td>
                   <td class="auto-style71">
                       <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                       <%-- <asp:ButtonField CommandName="Select" Text="select" />--%>
                   </td>
                   <td class="auto-style77" rowspan="9">&nbsp;
                        
                   </td>
                   <td class="auto-style59" rowspan="9" style="border:thin solid #003300">
                       <h4 class="auto-style51">
            <br />
        </h4>
            
                   </td>
                   <td class="auto-style79" rowspan="9">
                       &nbsp;</td>
               </tr>
               <tr>
                   <td class="auto-style73">Supplier Id :</td>
                   <td class="auto-style65">
                       <asp:DropDownList ID="TextBox3" runat="server" DataSourceID="SqlDataSource1" DataTextField="id" DataValueField="id" Height="16px" Width="121px">
                       </asp:DropDownList>
                       <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:InventoryMangementConnectionString %>" SelectCommand="SELECT [id] FROM [Supplier]"></asp:SqlDataSource>
                   </td>
               </tr>
               <tr>
                   <td class="auto-style68">Product name</td>
                   <td class="auto-style69">
                       <asp:DropDownList ID="TextBox4" runat="server" DataSourceID="SqlDataSource3" DataTextField="ProductName" DataValueField="ProductName" Width="128px">
                       </asp:DropDownList>
                       <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:InventoryMangementConnectionString %>" SelectCommand="SELECT [ProductName] FROM [Product]"></asp:SqlDataSource>
                   </td>
               </tr>
               <tr>
                   <td class="auto-style68">Available Quantity (Packet)</td>
                   <td class="auto-style69">
                <asp:TextBox ID="txtQuantity1" runat="server" Width="128px" onkeydown="return (!(event.keyCode>=65) && event.keyCode!=32);"></asp:TextBox>
                   </td>
               </tr>
               <tr>
                   <td class="auto-style73">Price :</td>
                   <td class="auto-style65">
                <asp:TextBox ID="txtQuantity2" runat="server" Width="128px" onkeydown="return (!(event.keyCode>=65) && event.keyCode!=32);"></asp:TextBox>
                   </td>
               </tr>
               <tr>
                   <td class="auto-style73">Department Id</td>
                   <td class="auto-style65">
                       <asp:DropDownList ID="txtQuantity3" runat="server" DataSourceID="SqlDataSource2" DataTextField="id" DataValueField="id" Height="16px" Width="132px">
                       </asp:DropDownList>
                       <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:InventoryMangementConnectionString %>" SelectCommand="SELECT [id] FROM [Department]"></asp:SqlDataSource>
                   </td>
               </tr>
               <tr>
                   <td class="auto-style51" colspan="2">
                <asp:Button ID="btnsell" runat="server" Text="Send " Font-Bold="True" Width="55px" OnClick="btnsell_Click1" />
                <asp:Button ID="btnclear" runat="server" Text="Clear" Font-Bold="True" OnClick="btnclear_Click" Width="56px" />
                   </td>
               </tr>
               <tr>
                   <td class="auto-style60" colspan="2" rowspan="2">
                <asp:Label ID="lblsuccessmassage" runat="server" Text="" ForeColor="Green"></asp:Label>
                       <br />
                <asp:Label ID="lblerrormessage" runat="server" Text="" ForeColor="Red"></asp:Label>
                   </td>
                  
               </tr>
              
           </table>
       </div>
    <table class="auto-style42">
        <tr>
            <td class="auto-style44">
                &nbsp;</td>
        </tr>
    </table>
        <h4 class="auto-style51">
            <br />
            <span class="auto-style52"><strong>Quotation List</strong></span><br />
        </h4>
       <p class="auto-style51">
            
        <asp:GridView ID="SalesGrid" runat="server" AutoGenerateColumns="False" AutoPostBack="true" HorizontalAlign="Center" OnSelectedIndexChanged="searchGrid_SelectedIndexChanged">
                <columns>
                    <asp:BoundField Datafield="productname" HeaderText="Product Name" />
                    <asp:BoundField Datafield="Supplierid" HeaderText="Supplier Id" />
                    <asp:BoundField Datafield="Quantity" HeaderText="Quantity (Packet)" />
                     <asp:BoundField Datafield="Price" HeaderText="Price" />
                                       
                   <%-- <asp:ButtonField CommandName="Select" Text="select" />--%>
                   
                </columns>
            </asp:GridView>
           </p>
        <div class="auto-style51">
            <br />
        </div>
</div>
</asp:Content>

