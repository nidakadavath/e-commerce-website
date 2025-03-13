<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="viewfeedback.aspx.cs" Inherits="WebApplication2.viewfeedback" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Feedback</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 20px;
            background-color: #f4f4f4;
        }
        .feedback-container {
            max-width: 800px;
            margin: 0 auto;
            background: white;
            padding: 20px;
            border-radius: 10px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
        }
        h1 {
            text-align: center;
            color: #333;
        }
        .grid-view {
            width: 100%;
            border-collapse: collapse;
            margin-top: 20px;
        }
        .grid-view th, .grid-view td {
            border: 1px solid #ddd;
            padding: 12px;
            text-align: left;
        }
        .grid-view th {
            background-color: #4CAF50;
            color: white;
        }
        .grid-view tr:nth-child(even) {
            background-color: #f9f9f9;
        }
        .grid-view tr:hover {
            background-color: #f1f1f1;
        }
       .reply-button {
    background-color: #007bff;
    color: white;
    border: none;
    padding: 5px 10px;
    border-radius: 5px;
    cursor: pointer;
}

.reply-button:hover {
    background-color: #0056b3;
}
        .auto-style1 {
            width: 100%;
        }
        .message-panel {
        background-color: #f8f9fa; /* Light gray background */
        border-radius: 10px; /* Rounded corners */
        padding: 20px;
        box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1); /* Soft shadow */
        max-width: 400px;
        margin: auto;
    }

    .message-panel label {
        font-weight: bold;
        color: #333;
    }

    .message-panel .form-control {
        width: 100%;
        padding: 8px;
        border-radius: 5px;
        border: 1px solid #ccc;
    }

    .message-panel .btn-primary {
        background-color: #007bff;
        border: none;
        padding: 8px 16px;
        font-size: 14px;
        color: white;
        cursor: pointer;
        border-radius: 5px;
        display: block;
        width: 100%;
    }

    .message-panel .btn-primary:hover {
        background-color: #0056b3;
    }
}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="feedback-container">
            <h1>Active Feedback</h1>
          <asp:GridView ID="FeedbackGridView" runat="server" CssClass="grid-view" AutoGenerateColumns="false" OnRowCommand="FeedbackGridView_RowCommand" DataKeyNames="user_id">
    <Columns>
        <asp:BoundField DataField="user_name" HeaderText="Username" />
        <asp:BoundField DataField="feedback_message" HeaderText="Feedback Message" />
        <asp:TemplateField HeaderText="Action">
            <ItemTemplate>
                <asp:Button ID="ReplyButton" runat="server" Text="Reply" CssClass="reply-button" CommandName="Reply" CommandArgument='<%# Eval("user_id") %>' />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <table class="auto-style1">
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
               <tr>
    <td>
       <asp:Panel ID="Panel1" runat="server" CssClass="message-panel" Visible="False">
    <div class="container">
        <div class="form-group">
            <label for="from">From:</label>
            <asp:TextBox ID="textbox1" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="form-group">
            <label for="to">To:</label>
            <asp:TextBox ID="textbox2" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="form-group">
            <label for="message">Message:</label>
            <asp:TextBox ID="textbox3" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
        </div>

        <!-- Label to display success or error messages -->
        <div class="form-group">
            <asp:Button ID="btnSend" runat="server" OnClick="btnSend_Click1" Text="Send" />
            <asp:Label ID="Label1" runat="server" CssClass="text-success" Visible="False"></asp:Label>
        </div>

        
    </div>
</asp:Panel>
        <div class="form-group">
    <asp:Button ID="btnHome" runat="server" Text="Home" CssClass="btn btn-success" OnClick="btnHome_Click"/>
</div>

    </td>
</tr>

                <tr>
                    <td>
                        &nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>