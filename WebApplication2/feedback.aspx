<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="feedback.aspx.cs" Inherits="WebApplication2.feedback" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Feedback</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
            background-image: url(https://img.freepik.com/free-photo/coffee-beans-dark-background-top-view-coffee-concept_1220-6299.jpg?t=st=1738381126~exp=1738384726~hmac=546990720c9b2e989af25f57455106d7ebf1f60faade172840de6bbbdef0af82&w=1480); /* Cafe-themed background */
            background-size: cover;
            background-position: center;
            background-repeat: no-repeat;
        }
        .feedback-container {
            background: rgba(255, 255, 255, 0.1); /* Semi-transparent light background */
            padding: 30px;
            border-radius: 10px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2);
            width: 400px;
            text-align: center;
            backdrop-filter: blur(10px); /* Adds a blur effect to the background */
            border: 1px solid rgba(255, 255, 255, 0.2); /* Light border */
        }
        .feedback-container h1 {
            font-size: 24px;
            color: #fff; /* White text for better contrast */
            margin-bottom: 20px;
        }
        .feedback-container textarea {
            width: 100%;
            height: 150px;
            padding: 10px;
            border: 1px solid rgba(255, 255, 255, 0.3); /* Light border */
            border-radius: 5px;
            font-size: 16px;
            margin-bottom: 20px;
            resize: none;
            background: rgba(255, 255, 255, 0.1); /* Semi-transparent background */
            color: #fff; /* White text */
        }
        .feedback-container textarea::placeholder {
            color: rgba(255, 255, 255, 0.7); /* Light placeholder text */
        }
        .feedback-container .button-container {
            display: flex;
            justify-content: space-between;
        }
        .feedback-container .button-container button {
            padding: 10px 20px;
            border: none;
            border-radius: 5px;
            font-size: 16px;
            cursor: pointer;
            transition: background-color 0.3s ease;
        }
        .feedback-container .button-container .send-button {
            background-color: #4CAF50; /* Green button */
            color: white;
        }
        .feedback-container .button-container .send-button:hover {
            background-color: #45a049; /* Darker green on hover */
        }
        .feedback-container .button-container .continue-button {
            background-color: #007bff; /* Blue button */
            color: white;
        }
        .feedback-container .button-container .continue-button:hover {
            background-color: #0056b3; /* Darker blue on hover */
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="feedback-container">
            <h1>We Value Your Feedback</h1>
            <asp:TextBox ID="FeedbackTextBox" runat="server" TextMode="MultiLine" placeholder="Enter your feedback here..."></asp:TextBox>
            <div class="button-container">
                <asp:Button ID="SendButton" runat="server" Text="Send" CssClass="send-button" OnClick="SendButton_Click" />
                <asp:Label ID="Label1" runat="server" ForeColor="White" Text="Label" Visible="False"></asp:Label>
                <asp:Button ID="ContinueButton" runat="server" Text="Continue Shopping" CssClass="continue-button" OnClick="ContinueButton_Click" />
            </div>
        </div>
    </form>
</body>
</html>