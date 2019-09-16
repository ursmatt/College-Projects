﻿<%@ Page Title="Product" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Product.aspx.cs" Inherits="Product" %>

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
    }
    .auto-style49 {
        text-align: center;
        width: 8px;
    }
    .auto-style50 {
        text-align: center;
        width: 73px;
    }
        .auto-style51 {
            text-align: center;
        }
        .auto-style52 {
            color: #003399;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="auto-style41">
    <h3 class="auto-style52">Product Registration</h3>
        <asp:HiddenField ID="hfProductId" runat="server" />
    <table class="auto-style42">
        <tr>
            <td class="auto-style43" colspan="2">Product Name:<br />
                Department Id:</td>
            <td class="auto-style44" colspan="2">
                <asp:TextBox ID="txtproname" runat="server" Width="128px"></asp:TextBox>
                <br />
                <asp:DropDownList ID="TextBox1" runat="server" Height="16px" Width="128px" DataSourceID="SqlDataSource1" DataTextField="DepartmentId" DataValueField="DepartmentId" AutoPostBack="True">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:InventoryMangementConnectionString %>" SelectCommand="SELECT [DepartmentId] FROM [Department]"></asp:SqlDataSource>
                <br />
            </td>
        </tr>
        <tr>
            <td class="auto-style43" colspan="2">Product Description:</td>
            <td class="auto-style44" colspan="2">
                <asp:TextBox ID="txtprodes" runat="server" TextMode="MultiLine" MaxLength="99" Width="128px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style46">
                <asp:Button ID="btnsave" runat="server" Text="Save" Font-Bold="True" OnClick="btnsave_Click" Width="55px" />
            </td>
            <td class="auto-style49">
                <asp:Button ID="btndelete" runat="server" Text="Delete" Width="56px" Font-Bold="True" />
            </td>
            <td class="auto-style50">
                <asp:Button ID="btnclear" runat="server" Text="Clear" Font-Bold="True" OnClick="btnclear_Click" />
            </td>
            <td class="auto-style44">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:Label ID="lblsuccessmassage" runat="server" Text="" ForeColor="Green"></asp:Label>
                <asp:Label ID="lblerrormessage" runat="server" Text="" ForeColor="Red"></asp:Label>
            </td>
        </tr>
    </table>
        <h4>
            <br />
            <span class="auto-style52">Product List</span><br />
        <br />
        </h4>
        <div class="auto-style51">
        <asp:GridView ID="productGrid" runat="server" AutoGenerateColumns="false" HorizontalAlign="Center">
            <columns>
                <asp:BoundField Datafield="ProductId" HeaderText="Department Id" />
                <asp:BoundField Datafield="ProductName" HeaderText="Product Name" />
                
                <asp:BoundField DataField="ProductDescription" HeaderText="Product Description" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkView" runat="server" CommandArgument='<%# Eval("ProductId") %>' OnClick="lnk_onClick">Select</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </columns>
        </asp:GridView>
            <br />
        </div>
</div>
</asp:Content>

