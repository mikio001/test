<%@ Control Language="VB" AutoEventWireup="false" CodeFile="NewsTopListOnline.ascx.vb" Inherits="zulu_cms_contents_NewsTopList" %>
<%@ Register Assembly="Zulu" Namespace="Zulu.UI" TagPrefix="cc1" %>

<%@ Register src="../StartEditorToolbox.ascx" tagname="StartEditorToolbox" tagprefix="uc1" %>
<%@ Register src="../EndEditorToolbox.ascx" tagname="EndEditorToolbox" tagprefix="uc2" %>
<uc1:StartEditorToolbox ID="StartEditorToolbox1" runat="server" />
<%--<div class="row">

                <div class="col-md-12">
                <div class="col-md-4 col-sm-6">
                    <div class="media">
                        <div class="pull-left">
                            <i class="icon-mail-forward icon-md"></i>
                        </div>
                        <div class="media-body">
                            <a href="http://www.outlook.com"><h3 class="media-heading">Live Mail</h3>
                            <p>บริการ e-Mail สำหรับนิสิต</p></a>
                        </div>
                    </div>
                </div>
               
               
         </div>
                </div>
             <div class="gap"></div>--%>
<cc1:DirectRender ID="NewsTopList" runat="server" />

<uc2:EndEditorToolbox ID="EndEditorToolbox1" runat="server" />