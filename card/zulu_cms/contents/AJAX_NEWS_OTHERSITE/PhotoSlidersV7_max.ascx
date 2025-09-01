<%@ Control Language="VB" AutoEventWireup="false" CodeFile="PhotoSlidersV7_max.ascx.vb" Inherits="zulu_cms_contents_SlideCalendar" %>
<%@ Register Assembly="Zulu" Namespace="Zulu.UI" TagPrefix="cc1" %>

<%@ Register src="../StartEditorToolbox.ascx" tagname="StartEditorToolbox" tagprefix="uc1" %>
<%@ Register src="../EndEditorToolbox.ascx" tagname="EndEditorToolbox" tagprefix="uc2" %>
<%@ Register src="../StartEditorToolbox.ascx" tagname="StartEditorToolbox" tagprefix="uc2" %>
<%@ Register src="../EndEditorToolbox.ascx" tagname="editortoolbox" tagprefix="uc1" %>
<uc2:StartEditorToolbox ID="StartEditorToolbox1" runat="server" />
<cc1:DirectRender ID="PhotoSlider" runat="server" />
<%--<div id="myCarousel" class="carousel slide">
                                    <ol class="carousel-indicators">
                                        <li data-target="#myCarousel" data-slide-to="0" class=""></li>
                                        <li data-target="#myCarousel" data-slide-to="1" class="active"></li>
                                        <li data-target="#myCarousel" data-slide-to="2" class=""></li>
                                    </ol>
                                    <div class="carousel-inner">
                                        <div class="item">
                                            <a href="#">
                                                <img src="http://www.up.ac.th//zulu_store/FileStorage.aspx?fileID=14771" alt="">

                                            </a>
                                            <div class="carousel-caption">
                                                <h4>อธิการบดี ม.พะเยา พร้อมคณะผู้บริหาร</h4>
                                                <p>ลงพื้นที่ชุมชน จ.พะเยา ตรวจเยี่ยมการดำเนินโครงการ 1 คณะ 1 โมเดล </p>
                                            </div>
                                        </div>
                                        <div class="item active">
                                            <img src="http://www.up.ac.th//zulu_store/FileStorage.aspx?fileID=14723" alt="">
                                            <div class="carousel-caption">
                                                <h4>มหาวิทยาลัยพะเยา</h4>
                                                <p>จัดทอดกฐินสามัคคีวัดหนองแก้ว จ.พะเยา วันที่ 14 ต.ค.56</p>
                                            </div>
                                        </div>
                                        <div class="item">
                                            <img src="http://www.up.ac.th//zulu_store/FileStorage.aspx?fileID=14755" alt="">
                                            <div class="carousel-caption">
                                                <h4>ม.พะเยา จัดโครงการคลินิกเทคโนโลยี</h4>
                                                <p>เน้นให้ความรู้ลดปัญหาหมอกควันในภาคเหนือ</p>
                                            </div>
                                        </div>
                                    </div>
                                    <a class="left carousel-control" href="#myCarousel" data-slide="prev">‹</a>
                                    <a class="right carousel-control" href="#myCarousel" data-slide="next">›</a>
                                </div>--%>
<uc1:editortoolbox ID="EndEditorToolbox1" runat="server" 
    EditorPage="HtmlEditor" />