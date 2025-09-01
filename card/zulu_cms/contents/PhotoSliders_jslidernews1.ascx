<%@ Control Language="VB" AutoEventWireup="false" CodeFile="PhotoSliders_jslidernews1.ascx.vb" Inherits="zulu_cms_contents_SlideCalendar" %>
<%@ Register Assembly="Zulu" Namespace="Zulu.UI" TagPrefix="cc1" %>

<%@ Register src="../StartEditorToolbox.ascx" tagname="StartEditorToolbox" tagprefix="uc1" %>
<%@ Register src="../EndEditorToolbox.ascx" tagname="EndEditorToolbox" tagprefix="uc2" %>
<%@ Register src="../StartEditorToolbox.ascx" tagname="StartEditorToolbox" tagprefix="uc2" %>
<%@ Register src="../EndEditorToolbox.ascx" tagname="editortoolbox" tagprefix="uc1" %>
<script type="text/javascript">
    $(document).ready(function () {
        // buttons for next and previous item						 
        var buttons = { previous: $('#jslidernews1 .button-previous'),
            next: $('#jslidernews1 .button-next')
        };
        $obj = $('#jslidernews1').lofJSidernews({ interval: 4000,
            easing: 'easeInOutQuad',
            duration: 1200,
            auto: true,
            maxItemDisplay: 3,
            startItem: 0,
            navPosition: 'horizontal', // horizontal
            navigatorHeight: null,
            navigatorWidth: null,
            mainWidth: 300,
            buttons: buttons
        });
    });
</script>
<uc2:StartEditorToolbox ID="StartEditorToolbox1" runat="server" />

  <cc1:DirectRender ID="PhotoSlider" runat="server" />
                                            
                                           
                                        
                    
<uc1:editortoolbox ID="EndEditorToolbox1" runat="server" 
    EditorPage="HtmlEditor" />