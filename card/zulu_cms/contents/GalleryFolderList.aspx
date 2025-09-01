<%@ Page Language="VB" AutoEventWireup="false" CodeFile="GalleryFolderList.aspx.vb" Inherits="zulu_cms_contents_GalleryFolderList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    		<script src="prettyPhoto/js/jquery-1.4.4.min.js" type="text/javascript"></script>
		<!--script src="js/jquery.lint.js" type="text/javascript" charset="utf-8"></script-->
		<link rel="stylesheet" href="prettyPhoto/css/prettyPhoto.css" type="text/css" media="screen" title="prettyPhoto main stylesheet" charset="utf-8" />
		<script src="prettyPhoto/js/jquery.prettyPhoto.js" type="text/javascript" charset="utf-8"></script>
		<style type="text/css" media="screen">
			* { margin: 0; padding: 0; }
			
			body {
			
				font: 62.5%/1.2 Arial, Verdana, Sans-Serif;
				padding: 10px 20px 20px 20px ;
			}
			
			h1 { font-family: Georgia; font-style: italic; margin-bottom: 10px; }
			
			h2 {
				font-family: Georgia;
				font-style: italic;
				margin: 0px  0 10px 0;
			}
			
			p { font-size: 1.2em; }
			
			ul li { display: inline; 
			        padding: 1px 1px 1px 1px ;
			        }
			
			.wide {
				border-bottom: 1px #000 solid;
				width: 4000px;
			}
			
			.fleft { float: left; margin: 0 20px 0 0; }
			
			.cboth { clear: both; }
			
			#main {
				background: #fff;
				margin: 0 auto;
				padding: 30px;
				display: inline; 
			}
		</style>
        </head>
   
        
<body>
    <form id="form1" runat="server">
    <div id="main">
    
    <a href="prettyPhoto/images/fullscreen/5.jpg" rel="xprettyPhoto[gallery1]"><img src="prettyPhoto/images/thumbnails/t_5.jpg" width="60" height="60" alt="Fly kite, fly!" /></a><a href="prettyPhoto/images/fullscreen/5.jpg" rel="prettyPhoto[gallery1]"><img src="prettyPhoto/images/thumbnails/t_5.jpg" width="60" height="60" alt="Fly kite, fly!" /></a><a href="prettyPhoto/images/fullscreen/5.jpg" rel="prettyPhoto[gallery1]"><img src="prettyPhoto/images/thumbnails/t_5.jpg" width="60" height="60" alt="Fly kite, fly!" /></a>
      <h2>Iframe</h2>
    <ul class="gallery clearfix">
		<li><a href="prettyPhoto/images/fullscreen/5.jpg" rel="prettyPhoto[gallery1]"><img src="prettyPhoto/images/thumbnails/t_5.jpg" width="60" height="60" alt="Fly kite, fly!" /></a></li><li><a href="prettyPhoto/images/fullscreen/5.jpg" rel="prettyPhoto[gallery1]"><img src="prettyPhoto/images/thumbnails/t_5.jpg" width="60" height="60" alt="Fly kite, fly!" /></a></li><li><a href="prettyPhoto/images/fullscreen/5.jpg" rel="prettyPhoto[gallery1]"><img src="prettyPhoto/images/thumbnails/t_5.jpg" width="60" height="60" alt="Fly kite, fly!" /></a></li><li><a href="prettyPhoto/images/fullscreen/5.jpg" rel="prettyPhoto[gallery1]"><img src="prettyPhoto/images/thumbnails/t_5.jpg" width="60" height="60" alt="Fly kite, fly!" /></a></li><li><a href="prettyPhoto/images/fullscreen/5.jpg" rel="prettyPhoto[gallery1]"><img src="prettyPhoto/images/thumbnails/t_5.jpg" width="60" height="60" alt="Fly kite, fly!" /></a></li><li><a href="prettyPhoto/images/fullscreen/5.jpg" rel="prettyPhoto[gallery1]"><img src="prettyPhoto/images/thumbnails/t_5.jpg" width="60" height="60" alt="Fly kite, fly!" /></a></li><li><a href="prettyPhoto/images/fullscreen/5.jpg" rel="prettyPhoto[gallery1]"><img src="prettyPhoto/images/thumbnails/t_5.jpg" width="60" height="60" alt="Fly kite, fly!" /></a></li><li><a href="prettyPhoto/images/fullscreen/5.jpg" rel="prettyPhoto[gallery1]"><img src="prettyPhoto/images/thumbnails/t_5.jpg" width="60" height="60" alt="Fly kite, fly!" /></a></li><li><a href="prettyPhoto/images/fullscreen/5.jpg" rel="prettyPhoto[gallery1]"><img src="prettyPhoto/images/thumbnails/t_5.jpg" width="60" height="60" alt="Fly kite, fly!" /></a></li><li><a href="prettyPhoto/images/fullscreen/5.jpg" rel="prettyPhoto[gallery1]"><img src="prettyPhoto/images/thumbnails/t_5.jpg" width="60" height="60" alt="Fly kite, fly!" /></a></li>
				
			</ul>

          
    </div>
   <script type="text/javascript" charset="utf-8">
       $(document).ready(function () {
           $(".gallery:first a[rel^='prettyPhoto']").prettyPhoto({ animation_speed: 'normal', theme: 'facebook', slideshow: 3000, autoplay_slideshow: true });
           $(".gallery:gt(0) a[rel^='prettyPhoto']").prettyPhoto({ animation_speed: 'fast', slideshow: 10000 });

           $("#custom_content a[rel^='prettyPhoto']:first").prettyPhoto({
               custom_markup: '<div id="map_canvas" style="width:260px; height:265px"></div>',
               changepicturecallback: function () { initialize(); }
           });

           $("#custom_content a[rel^='prettyPhoto']:last").prettyPhoto({
               custom_markup: '<div id="bsap_1237859" class="bsarocks bsap_d49a0984d0f377271ccbf01a33f2b6d6" style="height:260px"></div><div id="bsap_1251710" class="bsarocks bsap_d49a0984d0f377271ccbf01a33f2b6d6"></div>',
               changepicturecallback: function () { _bsap.exec(); }
           });
       });
			</script>

    </form>
</body>
</html>
