<%@ Control Language="VB" AutoEventWireup="false" CodeFile="INTRAService.ascx.vb" Inherits="zulu_cms_contents_NewsCard" %>
<%@ Register Assembly="Zulu" Namespace="Zulu.UI" TagPrefix="cc1" %>

<%@ Register src="../StartEditorToolbox.ascx" tagname="StartEditorToolbox" tagprefix="uc1" %>
<%@ Register src="../EndEditorToolbox.ascx" tagname="EndEditorToolbox" tagprefix="uc2" %>

<script type="text/javascript">
    $(document).ready(function () {
        $("#slider").easySlider({
            controlsBefore: '<p id="controls">',
            controlsAfter: '</p>',
            auto: false,
            continuous: true
        });
    });	
	</script>
	
	
<uc1:StartEditorToolbox ID="ServiceStart" runat="server" />
<cc1:DirectRender ID="Service" runat="server" />
<uc2:EndEditorToolbox ID="ServiceEnd" runat="server" 
    CustomAddPage="MixContent/ServiceForm" CustomEditPage="MixContent/ServiceEditor" />
<table style="width: 100px; margin-left: 40px;">
    <tr>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
</table>
