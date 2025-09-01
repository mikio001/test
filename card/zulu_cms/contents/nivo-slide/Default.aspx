<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="style/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="SlideDownBoxMenu/style.css" type="text/css" media="screen" />
    <link href="jquery.featureList-1.0.0/style.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="nivo-slider/nivo-slider.css" type="text/css" media="screen" />
    
    
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.2/jquery.min.js"></script>
    <script type="text/javascript" src="SlideDownBoxMenu/jquery.easing.1.3.js"></script>
    <script src="jquery.featureList-1.0.0/jquery.featureList-1.0.0.js" type="text/javascript"></script>
    
     <script type="text/javascript">
        /* $(function () {
             $('.nivoSlider').mouseover(function () {
                 $('.nivo-caption').append('title');
             });
         });
         */
     </script>

    <!--script src="gallery/js/jquery-1.4.4.min.js" type="text/javascript"></script-->	
	<link rel="stylesheet" href="Gallery/css/prettyPhoto.css" type="text/css" media="screen" title="prettyPhoto main stylesheet" charset="utf-8" />
	<script src="Gallery/js/jquery.prettyPhoto.js" type="text/javascript" charset="utf-8"></script>
</head>
<body>
    <form id="form1" runat="server">
    <table cellpadding="0" cellspacing="0" id="mainContainer">
    <tr><td><p>&nbsp;</p></td></tr>
        <tr style="background-image:url('images/bg-top.png')">
            <td id="topContainer">
            <a href="default.aspx"><img src="images/logo-up4.png" alt="University of Phayao" border="0" /></a>
                <ul id="sdt_menu" class="sdt_menu">
                    <li><a href="about.aspx">
                        <img src="SlideDownBoxMenu/images/about.jpg" alt=""/>
                        <span class="sdt_active"></span><span class="sdt_wrap"><span class="sdt_link">About
                            Up</span> <span class="sdt_descr">history & future</span> </span></a>
                            <div class="sdt_box"><a href="vision.aspx">Vision</a>
                            <a href="mission.aspx">Mission</a><a href="purposes.aspx">Purposes</a><a href="core_values.aspx">Core Values</a><a href="document/structure.pdf">Structure</a><a href="Map.aspx">Map</a>
                            </div>
                            </li>
                    <li><a href="school.aspx">
                        <img src="SlideDownBoxMenu/images/school.jpg" alt="" />
                        <span class="sdt_active"></span><span class="sdt_wrap"><span class="sdt_link">Schools</span>
                            <span class="sdt_descr">schools & departments</span> </span></a></li>
                    <li><a href="#">
                        <img src="SlideDownBoxMenu/images/program.jpg" alt="" />
                        <span class="sdt_active"></span><span class="sdt_wrap"><span class="sdt_link">program</span>
                            <span class="sdt_descr">degree & program</span> </span></a>
                            <div class="sdt_box">
                            <a href="bachelor.aspx">Bachelor’s Degree</a><a href="master.aspx">Master’s Degree</a>
                            <a href="doctoral.aspx">Doctoral’s Degree</a>
                            </div>
                    </li>
                    <li><a href="research.aspx">
                        <img src="SlideDownBoxMenu/images/research.jpg" alt="" />
                        <span class="sdt_active"></span><span class="sdt_wrap"><span class="sdt_link">Research</span> 
                        <span class="sdt_descr">Research</span> </span></a>                        
                    </li>
                </ul>
                <script type="text/javascript">
                    $(function () {
                        $('#sdt_menu > li').bind('mouseenter', function () {
                            var $elem = $(this);
                            $elem.find('img')
						 .stop(true)
						 .animate({
						     'width': '170px',
						     'height': '105px',
						     'left': '0px'
						 }, 400, 'easeOutBack')
						 .andSelf()
						 .find('.sdt_wrap')
					     .stop(true)
						 .animate({ 'top': '115px' }, 500, 'easeOutBack')
						 .andSelf()
						 .find('.sdt_active')
					     .stop(true)
						 .animate({ 'height': '105px' }, 300, function () {
						     var $sub_menu = $elem.find('.sdt_box');
						     if ($sub_menu.length) {
						         var left = '170px';
						         if ($elem.parent().children().length == $elem.index() + 1)
						             left = '-170px';
						         $sub_menu.show().animate({ 'left': left }, 200);
						     }
						 });
                        }).bind('mouseleave', function () {
                            var $elem = $(this);
                            var $sub_menu = $elem.find('.sdt_box');
                            if ($sub_menu.length)
                                $sub_menu.hide().css('left', '0px');

                            $elem.find('.sdt_active')
						 .stop(true)
						 .animate({ 'height': '0px' }, 300)
						 .andSelf().find('img')
						 .stop(true)
						 .animate({
						     'width': '0px',
						     'height': '0px',
						     'left': '85px'
						 }, 400)
						 .andSelf()
						 .find('.sdt_wrap')
						 .stop(true)
						 .animate({ 'top': '35px' }, 500);
                        });
                    });
                </script>
            </td>
        </tr>
        <tr>
            <td id="slideShow">
               
                
                <div id="slider-wrapper">    
                    <div id="slider" class="nivoSlider">
                        <img src="slider/Princess6.jpg" alt="" title="Classroom Building 2 and Library" />
                        <img src="slider/science.jpg" alt="" title="Hospitals UP." />
                        <a href="http://www.google.com"><img src="slider/prc1.png" alt="" title="Phayao Research" /></a>
                    </div>
                    <div id="htmlcaption" class="nivo-html-caption">
                        <strong>This</strong> is an example of a <em>HTML</em> caption with <a href="#">a link</a>.
                    </div>        
                 </div>
                           
                <script type="text/javascript" src="nivo-slider/jquery.nivo.slider.js"></script>
    <script type="text/javascript">
        $(window).load(function () {
            $('#slider').nivoSlider();
        });
    </script>
    
            </td>
        </tr>
        <tr>
            <td id="wisdom">
             <!--div id="cat-1" class="categorytop"><span class="cat_title"><a href="ContentShow.aspx?itemID=342">ADMISSION</a></span>
<p><a href="ContentShow.aspx?itemID=342"><img alt="" width="165" src="Images/b_admis.jpg" /></a></p>
</div>
<div id="cat-2" class="categorytop"><span class="cat_title"><a href="newsstudent.aspx">STUDENT</a></span>
<p><a href="newsstudent.aspx"><img alt="" src="Images/b_std.jpg" /></a></p>
</div>
<div id="cat-3" class="categorytop"><span class="cat_title"><a href="ContentShow.aspx?itemID=344">PERSONAL</a></span>
<p><a href="ContentShow.aspx?itemID=344"><img alt="" src="Images/b_person.jpg" /></a></p>
</div>
<div id="cat-4" class="categorytop"><span class="cat_title"><a href="under_cons.php">ALUMNI</a></span>
<p><a href="#"><img alt="" src="Images/b_alumni.jpg" /></a></p>
</div>
<div id="cat-5" class="categorytop"><span class="cat_title"><a href="newsActivity.aspx">NEWS</a></span>
<p><a href="newsActivity.aspx"><img alt="" src="Images/b_guest.jpg" /></a></p>
</div-->
<img src="images/wisdom.png" />
            </td>
        </tr>
        <tr>
            <td id="homeContentContainer" valign="top">
                <table cellpadding="0" cellspacing="0" style="width: 100%; background-color: #FFFFFF;">
                    <tr>
                        <td valign="top" style="width: 70%; padding-right: 2px; border-right-style:solid;
                            border-right-width: 1px; border-right-color: #c9b738;">
                            <table cellpadding="0" cellspacing="5" style="width: 100%">
                                <tr>
                                    <td class="blockTitle">
                                        UNIVERSITY OF PHAYAO</td>
                                </tr>
                                <tr>
                                    <td>
                                        <table cellpadding="0" cellspacing="0" style="width: 100%" class="BodyContent">
                                            <tr>
                                                <td valign="top" style="padding-right: 2px; width: 50%">
                                                    <img src="images/history.png" class="ImageContentLeft" /><p>University of Phayao has its origin in the proposal of Naresuan University for an IT campus in Phayao province.  
                                                    The proposal was approved by the cabinet on 20 June 1995.  
                                                    According to the cabinet resolution dated 8 October 1996, 
                                                    the campus would be called “Phayao IT Campus”.  Instructions and learning started in 1995.  
                                                    In 2007, President of Naresuan University (Associate Professor Dr. Mondhon Sanguansermsri) 
                                                    put forward the proposal to promote the campus into an independent university 
                                                    together with a proposal for the Royal Decree for University of Phayao.  
                                                    These were approved and declared in the Royal Gazette on 16 July 2010.  
                                                    The Royal Decree for University of Phayao, officially delivering “University of Phayao”, 
                                                    took effect from 17 July 2010 onwards.  In 2010, University of Phayao offered 62 Bachelor’s degree programs and 15 Master’s degree programs with the total of 11,363 undergraduate students, 
                                                    582 postgraduate students and 1,027 university staff.  
                                                    In 2011, the total number of students is around 20,000.</p>
                                                    
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                            <table cellpadding="0" cellspacing="5" style="width: 100%">
                                <tr>
                                    <td class="blockTitle">
                                        Bachelor’s Degree Programs</td>
                                </tr>
                                <tr>
                                    <td>
                                       <table cellpadding="0" cellspacing="0" width="100%" class="ListSchool"><tr>
                                       <td style="width:33%; vertical-align:top;"><ul>
                                       <li><a href="san.aspx">School of Agriculture and Natural Resources</a></li>
                                        <li><a href="ict.aspx">School of Information and Communication Technology</a></li>
                                        <li><a href="phar.aspx">School of Pharmaceutical Sciences</a></li>
                                        <li><a href="med.aspx">School of Medicine</a></li>
                                        <li><a href="law.aspx">School of Law</a></li>                                       
                                       </ul></td>
                                       <td style="width:33%; vertical-align:top;"><ul>
                                       <li><a href="son.aspx">School of Nursing</a></li>
                                        <li><a href="mis.aspx">School of Management and Information Sciences</a></li>
                                        <li><a href="sct.aspx">School of Science</a></li>
                                        <li><a href="medsci.aspx">School of Medical Sciences</a></li>
                                        <li><a href="eng.aspx">School of Engineering</a></li>                                       
                                       </ul></td>
                                       <td style="width:33%; vertical-align:top;"><ul>
                                       <li><a href="lib.aspx">School of Liberal Arts</a></li>
                                        <li><a href="safa.aspx">School of Architecture and Fine Arts</a></li>
                                        <li><a href="ahs.aspx">School of Allied Health Sciences</a></li>
                                        <li><a href="cce.aspx">College of Continuing Education</a></li>  
                                       <li><a href="seen.aspx">School of Energy and Environment</a></li>
                                                                       
                                       </ul></td>
                                       </tr></table> 
                                    </td>
                                </tr>
                                <tr>
                                <td class="blockTitle">
                                        Master’s Degree Programs</td>
                                </tr>
                                <tr>
                                <td>
                                    <table width="100%" cellpadding="0" cellspacing="0" class="ListSchool">
                                    <tr>
                                    <td style="width:50%; vertical-align:top;"><h4>Bi-semester System : Plan A Type A (2)</h4>
                                    <ul>
                                    <a href="master.aspx"><li>Master of Science (M.Sc.)</li></a>
                                    <a href="master.aspx"><li>Master of Engineering (M.Eng.)</li></a>
                                    <a href="master.aspx"><li>Master of Arts (M.A.)</li></a>                                    
                                    </ul>
                                    </td>
                                    <td style="width:50%; vertical-align:top;"><h4>Bi-semester System : Plan B</h4>
                                    <ul>
                                    <a href="master.aspx"><li>Master of Education (M.Ed.)</li></a>
                                    <a href="master.aspx"><li>Master of Business Administration (M.B.A.)</li></a>
                                    <a href="master.aspx"><li>Master of Public Administration (M.P.A.)</li></a>   
                                    <a href="master.aspx"><li>Master of Science (M.Sc.)</li></a>
                                    <a href="master.aspx"><li>Master of Engineering (M.Eng.)</li></a>
                                    <a href="master.aspx"><li>Master of Arts (M.A.)</li></a>
                                    <a href="master.aspx"><li>Master of Public Health (M.P.H.)</li></a>                                 
                                    </ul>
                                    </td>
                                    </tr>
                                    </table>
                                </td>
                                </tr>
                                <tr>
                                <td class="blockTitle">
                                        Doctoral’s Degree Programs</td>
                                </tr>
                                <tr>
                                <td>
                                    <table width="100%" cellpadding="0" cellspacing="0" class="ListSchool">
                                    <tr>
                                    <td style="width:50%; vertical-align:top;"><h4>Bi-semester System : Type 1.1</h4>
                                    <ul>
                                    <a href="doctoral.aspx"><li>Doctor of Education (Ed.D.)</li></a>
                                                                    
                                    </ul>
                                    </td>
                                    <td style="width:50%; vertical-align:top;"><h4>Bi-semester System : Type 1.2</h4>
                                    <ul>
                                    <a href="doctoral.aspx"><li>Doctor of Philosophy (Ph.D.)</li></a>
                                                                 
                                    </ul>
                                    </td>
                                    </tr>
                                    </table>
                                </td>
                                </tr>
                            </table>
                        <p>&nbsp;</p>
                        <p>&nbsp;</p>
                        <p>&nbsp;</p>
                        </td>
                        <td style="width: 30%; padding-left: 2px;" valign="top">
                            <table cellpadding="0" cellspacing="5" style="width: 100%">
                                <tr>
                                    <td class="blockTitle">
                                        SYMBOLS
                                    </td>
                                </tr>
                                <tr>
                                    <td id="contentRight">
                                        <div style="background-image: url('images/pic-long-back.jpg'); width: 277px; height: 80px">
                                            <img src="images/symbol-color.jpg" style="margin-left: 10px; margin-top: 10px;" width="256"
                                                height="58" />                                        
                                        </div>
                                        <p>The university colors are <strong>purple</strong> and <strong>gold</strong>.<br />
                                            <strong>Purple</strong> is the combination of red symbolizing the Nation and blue symbolizing the King.
                                        <br /><strong>Gold</strong> symbolizes Religion and the prosperity of the university.
                                        </p>                                
                                        
                                    </td>
                                </tr>
                                <tr><td id="contentRight">
                                <div class="SideBoxTop">&nbsp;</div>
                                <div class="SideBoxMid">
                                <img src="images/symbol-tree.jpg" height="200" style="width: 256px" />                                                 
                                 </div>
                                 <div class="SideBoxBott">&nbsp;</div>
                                 <p>The tree symbolizing University of Phayao is <strong>Fah Mui</strong>. </p>                                        
                                </td>
                                </tr>
                            </table>
                            <table cellpadding="0" cellspacing="5" style="width: 100%">
                                <tr>
                                    <td class="blockTitle">
                                        PERSPECTIVE</td>
                                </tr>
                                <tr>
                                    <td>
                                        <table cellpadding="2" cellspacing="1" width="100%">
                                            <tr><td class="photo">
                                                <ul class="gallery clearfix">
				                                    <li><a href="gallery/images/fullscreen/p1.jpg" rel="prettyPhoto[gallery2]" title="Perspective University of Phayao">
                                                    <img src="gallery/images/thumbnails/t_p1.jpg" width="60" height="60" alt="Perspective University of Phayao" /></a></li>
				                                    <li><a href="gallery/images/fullscreen/p2.jpg" rel="prettyPhoto[gallery2]"><img src="gallery/images/thumbnails/t_p2.jpg" width="60" height="60" alt="" /></a></li>
				                                    <li><a href="gallery/images/fullscreen/p3.jpg" rel="prettyPhoto[gallery2]"><img src="gallery/images/thumbnails/t_p3.jpg" width="60" height="60" alt="" /></a></li>
				                                    <li><a href="gallery/images/fullscreen/p4.jpg" rel="prettyPhoto[gallery2]"><img src="gallery/images/thumbnails/t_p4.jpg" width="60" height="60" alt="" /></a></li>
				                                    <li><a href="gallery/images/fullscreen/p5.jpg" rel="prettyPhoto[gallery2]"><img src="gallery/images/thumbnails/t_p5.jpg" width="60" height="60" alt="" /></a></li>
			                                    </ul>
                                                <script type="text/javascript" charset="utf-8">
                                                    $(document).ready(function () {
                                                        $(".gallery:first a[rel^='prettyPhoto']").prettyPhoto({ animation_speed: 'normal', theme: 'facebook', slideshow: 3000, autoplay_slideshow: true });
                                                        $(".gallery:gt(0) a[rel^='prettyPhoto']").prettyPhoto({ animation_speed: 'slow', slideshow: 10000 });

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
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                            
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td valign="middle" id="footerContainer">
                <a href="contact.aspx">Contact us</a>&nbsp; |&nbsp; <a href="sitemap.aspx">Site Map</a>&nbsp; |&nbsp;
                <a href="http://www.up.ac.th">For Thai</a>&nbsp;&nbsp;&nbsp; &copy;2011 University of Phayao, Thailand
            </td>
        </tr>
    </table>
    &nbsp;
    
    </form>
</body>
</html>
