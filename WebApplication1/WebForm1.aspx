<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <input type="button" value="upload" onclick="upload()"/>
        </div>
    </form>
<script>

    function upload() {
        window.showModalDialog("upload.aspx", "dialogWidth=1000px;dialogHeight=700px;");
    }
</script>
</body>
</html>
