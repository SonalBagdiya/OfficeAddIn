<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="OfficeTaskPaneWeb.Pages.WebForm1" %>

<!DOCTYPE html>
<html>
<head>
    <link href="../App/App.css" rel="stylesheet" type="text/css" />
    <script src="../App/App.js" type="text/javascript"></script>
     <link href="../App/Home/Home.js" rel="stylesheet" type="text/css" />
    <script src="../App/Home/Home.css" type="text/javascript"></script>
    <script type="text/javascript">

        function GetDetails()
        {
            var hostType;
          //  app.showNotification("testt");
            PageMethods.GetData(function (value)
            {
                app.showNotification(value);
                
            });
    }
</script>
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=Edge" />
    <title></title>
       <script src="https://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.9.1.min.js" type="text/javascript"></script>
    <script src="https://ajax.aspnetcdn.com/ajax/bootstrap/3.3.4/bootstrap.min.js"></script>
    <link href="https://ajax.aspnetcdn.com/ajax/bootstrap/3.3.4/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/Office.css" rel="stylesheet" type="text/css" />
      <script src="../../Scripts/jquery-1.9.1.js" type="text/javascript"></script>
     <link href="https://ajax.aspnetcdn.com/ajax/bootstrap/3.3.4/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../../Content/Office.css" rel="stylesheet" type="text/css" />
    <script src="https://appsforoffice.microsoft.com/lib/1/hosted/office.js" type="text/javascript"></script>

    <!-- To enable offline debugging using a local reference to Office.js, use:                        -->
    <!-- <script src="../../Scripts/Office/MicrosoftAjax.js" type="text/javascript"></script>  -->
    <!-- <script src="../../Scripts/Office/1/office.js" type="text/javascript"></script>  -->

    <link href="../App/App.css" rel="stylesheet" type="text/css" />
    <script src="../App/App.js" type="text/javascript"></script>

    <link href="../App/Home.css" rel="stylesheet" type="text/css" />
    <script src="../App/Home.js" type="text/javascript"></script>
</head>
<body>
     <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptMgr" runat="server" EnablePageMethods="true"></asp:ScriptManager>
    </form>
    <div id="content-header">
        <div class="padding">
            <h1>Welcome</h1>
        </div>
    </div>
    <div id="content-main">
        <div class="padding">
            <p><strong>Add home screen content here.</strong></p>
            <p>For example:</p>
            <button id="get-data-from-selection">Get data from selection</button>
            <button id="Button1" onclick="GetDetails()" runat="server">
    Click me!
</button>

             <p style="margin-top: 50px;">
                <a target="_blank" href="https://go.microsoft.com/fwlink/?LinkId=276812">Find more samples online...</a>
            </p>
        </div>
    </div>
</body>
</html>

