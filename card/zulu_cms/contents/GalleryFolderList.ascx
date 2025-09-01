<%@ Control Language="VB" AutoEventWireup="false" CodeFile="GalleryFolderList.ascx.vb" Inherits="zulu_cms_contents_Gallery" %>
<%@ Register Assembly="Zulu" Namespace="Zulu.UI" TagPrefix="cc1" %>



       <%-- <script type="text/javascript" charset="utf-8">
            $(document).ready(function () {
                $("a[rel^='prettyPhoto']").prettyPhoto();
            });
        </script>
         <script type="text/javascript" charset="utf-8">
             $(document).ready(function () {
                 $(".gallery:first a[rel^='prettyPhoto']").prettyPhoto({ animation_speed: 'normal', theme: 'facebook', slideshow: 3000, autoplay_slideshow: true });
                 $(".gallery:gt(0) a[rel^='prettyPhoto']").prettyPhoto({ animation_speed: 'fast', slideshow: 10000 });
             });
			</script>--%>

<cc1:DirectRender ID="Gallery" runat="server" />


   
    
   

    

   