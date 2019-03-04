<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cepubu.aspx.cs" Inherits="珠宝.Views.Home.cepubu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            text-align: center;
        }
        .auto-style3 {
            text-align: center;
            width: 355px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table align="center" class="auto-style1">
            <tr>
                <td class="auto-style3">订单号：</td>
                <td class="auto-style2">
                    <input id="Text1" type="text" /></td>
            </tr>
            <tr>
                <td class="auto-style3">珠宝描述：</td>
                <td class="auto-style2">
                    <input id="Text2" type="text" /></td>
            </tr>
            <tr>
                <td class="auto-style3">金额：</td>
                <td class="auto-style2">
                    <input id="Text3" type="text" /></td>
            </tr>
            <tr>
                <td class="auto-style3">金类型：</td>
                <td class="auto-style2">
                    <input id="Text4" type="text" /></td>
            </tr>
            <tr>
                <td class="auto-style3">备注：</td>
                <td class="auto-style2">
                    <input id="Text5" type="text" /></td>
            </tr>
            <tr>
                <td class="auto-style2" colspan="2">
                    <input id="Button1" type="button" value="下单" /></td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
