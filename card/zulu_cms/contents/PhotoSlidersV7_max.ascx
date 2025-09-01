<%@ Control Language="VB" AutoEventWireup="false" CodeFile="PhotoSlidersV7_max.ascx.vb" Inherits="zulu_cms_contents_SlideCalendar" %>
<%@ Register Assembly="Zulu" Namespace="Zulu.UI" TagPrefix="cc1" %>

<%@ Register src="../StartEditorToolbox.ascx" tagname="StartEditorToolbox" tagprefix="uc1" %>
<%@ Register src="../EndEditorToolbox.ascx" tagname="EndEditorToolbox" tagprefix="uc2" %>
<%@ Register src="../StartEditorToolbox.ascx" tagname="StartEditorToolbox" tagprefix="uc2" %>
<%@ Register src="../EndEditorToolbox.ascx" tagname="editortoolbox" tagprefix="uc1" %>
<uc2:StartEditorToolbox ID="StartEditorToolbox1" runat="server" />
  <div class="col-md-3">
                    <h3>ภาพกิจกรรม</h3>
                   <%-- <p>Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas.</p>--%>
                  <div class="btn-group">
                        <a class="btn btn-danger" href="#<%=ContentID %>" data-slide="prev"><i class="icon-angle-left"></i></a>
                        <a class="btn btn-danger" href="#<%=ContentID %>" data-slide="next"><i class="icon-angle-right"></i></a>
                    </div>
                    <p class="gap"></p>
                </div>
                <div class="col-md-9">
                  <div id="<%=ContentID %>" class="carousel slide">
                        <div class="carousel-inner">
                            <cc1:DirectRender ID="PhotoSlider" runat="server" />
                            <%--<div class="item active">
                                <div class="row">
                                    <div class="col-xs-4">
                                        <div class="portfolio-item">
                                            <div class="item-inner">
                                                <img class="img-responsive" src="images/portfolio/recent/item1.png" alt="">
                                                <h5>
                                                    Perspective 1
                                                </h5>
                                                <div class="overlay">
                                                    <a class="preview btn btn-danger" title="Malesuada fames ac turpis egestas" href="images/portfolio/full/item3.jpg" rel="prettyPhoto"><i class="icon-eye-open"></i></a>
                                                </div>
                                            </div>
                                        </div>
                                    </div>                            
                                    <div class="col-xs-4">
                                        <div class="portfolio-item">
                                            <div class="item-inner">
                                                <img class="img-responsive" src="images/portfolio/recent/item3.png" alt="">
                                                <h5>
                                                    Perspective 2
                                                </h5>
                                                <div class="overlay">
                                                    <a class="preview btn btn-danger" title="Malesuada fames ac turpis egestas" href="images/portfolio/full/item2.jpg" rel="prettyPhoto"><i class="icon-eye-open"></i></a>
                                                </div>
                                            </div>
                                        </div>
                                    </div>                            
                                    <div class="col-xs-4">
                                        <div class="portfolio-item">
                                            <div class="item-inner">
                                                <img class="img-responsive" src="images/portfolio/recent/item2.png" alt="">
                                                <h5>
                                                    Perspective 3
                                                </h5>
                                                <div class="overlay">
                                                    <a class="preview btn btn-danger" title="Malesuada fames ac turpis egestas" href="images/portfolio/full/item3.jpg" rel="prettyPhoto"><i class="icon-eye-open"></i></a>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div><!--/.row-->
                            </div>--%><!--/.item-->
                        
                            
                        </div>
                         <div class="col-md-12 text-right"><button type="button" class="btn btn-primary">ภาพกิจกรรมทั้งหมด</button></div>
                    </div>
                </div>


<uc1:editortoolbox ID="EndEditorToolbox1" runat="server" 
    EditorPage="HtmlEditor" />