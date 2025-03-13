<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="userhome.aspx.cs" Inherits="WebApplication2.userhome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            width: 65px;
        }
        .auto-style3 {
            width: 86px;
        }
        .auto-style4 {
            width: 87%;
            height: 397px;
        }
        .auto-style5 {
            width: 1061px;
        }
        .auto-style7 {
            height: 47px;
            width: 594px;
        }
        .auto-style8 {
            width: 594px;
        }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="w-100">
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style5">
                 <asp:Panel ID="Panel1" runat="server" CssClass="panel panel-default" Style="padding: 20px; text-align: center;">
                     <table class="w-100">
                         <tr>
                             <td class="auto-style7">
                                 <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" Width="100%" Placeholder="Enter search term..." /></asp:TextBox>
                             </td>
                             <td class="auto-style11">
                                 <asp:Button ID="Button1" runat="server" CssClass="auto-style9" Height="50px" OnClick="Button1_Click" Text="Search" Width="112px" />
                             </td>
                             <td class="auto-style10"></td>
                         </tr>
                         <tr>
                             <td class="auto-style8">&nbsp;</td>
                             <td class="auto-style12">&nbsp;</td>
                             <td>&nbsp;</td>
                         </tr>
                     </table>
    </asp:Panel>
                <style type="text/css">
    .panel-custom {
        border: 1px solid #ddd;
        box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
    }
    .btn-primary {
        background-color: #007bff;
        border-color: #007bff;
    }
    .btn-primary:hover {
        background-color: #0056b3;
        border-color: #0056b3;
    }
    .form-control {
        height: 40px;
        font-size: 16px;
        padding: 10px;
    }
    .search-button {
        height: 40px;
        padding: 5px 15px;
        font-size: 16px;
        background-color: #007bff;
        color: white;
        border: none;
        border-radius: 5px;
        cursor: pointer;
        white-space: nowrap; /* Prevents button text from wrapping */
    }
                    .auto-style9 {
                        border-style: none;
                        border-color: inherit;
                        border-width: medium;
                        padding: 5px 15px;
                        font-size: 16px;
                        background-color: #007bff;
                        color: white;
                        border-radius: 5px;
                        cursor: pointer;
                        white-space: nowrap;
                        margin-left: 0;
                    }
                    .auto-style10 {
                        height: 47px;
                    }
                    .auto-style11 {
                        height: 47px;
                        width: 100px;
                    }
                    .auto-style12 {
                        width: 100px;
                    }
                </style>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style5">
                &nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style5">
                <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Category"></asp:Label>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style5">
                <asp:DataList ID="DataList1" runat="server" RepeatColumns="5" DataKeyField="category_id">
    <ItemTemplate>
        <table class="auto-style4">
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:ImageButton ID="ImageButton1" 
                                     runat="server" 
                                     CommandArgument='<%# Eval("category_id") %>' 
                                     Height="197px" 
                                     ImageUrl='<%# Eval("category_image") %>' 
                                     OnCommand="ImageButton1_Command" 
                                     Width="177px" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("category_name") %>'></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("category_description") %>'></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </ItemTemplate>
</asp:DataList>

            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
