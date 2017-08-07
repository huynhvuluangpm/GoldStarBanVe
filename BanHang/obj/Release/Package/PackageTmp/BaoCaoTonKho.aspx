﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Root.master" AutoEventWireup="true" CodeBehind="BaoCaoTonKho.aspx.cs" Inherits="BanHang.BaoCaoTonKho" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <dx:ASPxFormLayout ID="ASPxFormLayout1" runat="server" Width="100%">
        <Items>
            <dx:LayoutGroup Caption="Thời gian báo cáo" ColCount="2" HorizontalAlign="Center">
                <Items>
                    <dx:LayoutItem Caption="Ngành Hàng" Name="txtNganhHang">
                        <LayoutItemNestedControlCollection>
                            <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer2" runat="server">
                                <dx:ASPxComboBox ID="cmbNganhHang" runat="server" OnSelectedIndexChanged="cmbNganhHang_SelectedIndexChanged" AutoPostBack="True">
                                </dx:ASPxComboBox>
                            </dx:LayoutItemNestedControlContainer>
                        </LayoutItemNestedControlCollection>
                    </dx:LayoutItem>
                    <dx:LayoutItem Caption="Nhóm hàng" Name="cmbNhomHang">
                        <LayoutItemNestedControlCollection>
                            <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer3" runat="server">
                                <dx:ASPxComboBox ID="cmbNhomHang" runat="server">
                                </dx:ASPxComboBox>
                            </dx:LayoutItemNestedControlContainer>
                        </LayoutItemNestedControlCollection>
                    </dx:LayoutItem>
                    <dx:LayoutItem Caption="Cửa hàng - kho" Name="cmbCuaHangKHo">
                        <LayoutItemNestedControlCollection>
                            <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer1" runat="server">
                                <dx:ASPxComboBox ID="cmbCuaHangKho" runat="server">
                                </dx:ASPxComboBox>
                            </dx:LayoutItemNestedControlContainer>
                        </LayoutItemNestedControlCollection>
                    </dx:LayoutItem>
                    <dx:LayoutItem Caption="" HorizontalAlign="Right">
                        <LayoutItemNestedControlCollection>
                            <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer6" runat="server">
                                <dx:ASPxButton ID="btnIn" runat="server"  Text="In" OnClick="btnIn_Click">
                                    <Image IconID="print_defaultprinternetwork_16x16">
                                    </Image>
                                </dx:ASPxButton>
                            </dx:LayoutItemNestedControlContainer>
                        </LayoutItemNestedControlCollection>
                    </dx:LayoutItem>
                </Items>
            </dx:LayoutGroup>
        </Items>
    </dx:ASPxFormLayout>
    <%--popup chi tiet don hang--%>
     <dx:ASPxPopupControl ID="popup" runat="server" AllowDragging="True" AllowResize="True" 
         PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter"  Width="1000px"
         Height="550px" FooterText="Thông tin kho hàng"
        HeaderText="Thông tin chi tiết tồn kho" ClientInstanceName="popup" EnableHierarchyRecreation="True">
    </dx:ASPxPopupControl>
</asp:Content>
