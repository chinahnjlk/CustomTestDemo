<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="upload.aspx.cs" Inherits="WebApplication1.upload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <iframe name="hd" style="display: none;"></iframe>
   <%-- <form id="Form1" method="post" action="upload.ashx" enctype="multipart/form-data" target="hd">
       
       
        <div id="screenshot" style="display: block; background-color: #FFFF99; position: absolute; width: 350px; left: 8px; bottom: 137px; border: 1px; border-color: Gray; border-style: solid; z-index: 1;">
            <input type="file" id="file1" name="upfile" size="28" />
            <input type="button" value="发送" onclick="return checksn();" />
        </div>

    <form/>--%>
    
    <form id="Form1" method="post" action="upload.ashx" enctype="multipart/form-data" target="hd">
        <div id="screenshot" style="display: block; background-color: #FFFF99; position: absolute; width: 350px; left: 8px; bottom: 137px; border: 1px; border-color: Gray; border-style: solid; z-index: 1;">
            <input type="file" id="file1" name="upfile1" size="28" />
            <input type="file" id="file2" name="upfile2" size="28" />

            <input type="file" id="file3" name="upfile3" size="28" />

            <input type="button" value="发送" onclick="return checksn();" />
        </div>
    </form>

<script>

    function checksn() {
        var f = document.getElementById("file1");
        if (f.value == '') {
            alert('请选择文件！'); f.focus(); return false;
        }
        else {
            SendFile();
        }
    }
    //发送文件，手动提交表单
    function SendFile() {
        var fm = document.getElementById("Form1");
        fm.action = "";
        fm.action = "upload.ashx";
        fm.submit();
    }
</script>
</body>
</html>
