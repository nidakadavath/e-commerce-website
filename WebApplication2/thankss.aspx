<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="thankss.aspx.cs" Inherits="WebApplication2.thankss" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Thank You</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            text-align: center;
            margin: 0;
            padding: 0;
            background: #f4f4f4;
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
        }
        .thank-you-container {
            background: white;
            padding: 40px;
            border-radius: 10px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
        }
        .thank-you-message {
            font-size: 24px;
            color: #4CAF50;
            margin-bottom: 20px;
        }
        .animated-checkmark {
            font-size: 60px;
            color: #4CAF50;
            animation: bounce 1s infinite;
        }
        @keyframes bounce {
            0%, 20%, 50%, 80%, 100% {
                transform: translateY(0);
            }
            40% {
                transform: translateY(-20px);
            }
            60% {
                transform: translateY(-10px);
            }
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="thank-you-container">
            <div class="animated-checkmark">✓</div>
            <div class="thank-you-message">Thank you for your order!</div>
            <p>You will be redirected to the feedback page in <span id="countdown">5</span> seconds.</p>
        </div>
    </form>

    <script>
        let count = 5;
        const countdownElement = document.getElementById("countdown");

        const interval = setInterval(() => {
            count--;
            countdownElement.textContent = count;

            if (count === 0) {
                clearInterval(interval);
                window.location.href = "feedback.aspx"; // Redirect to feedback page
            }
        }, 1000);
    </script>
</body>
</html>
       