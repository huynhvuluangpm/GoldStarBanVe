﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Root.master" AutoEventWireup="true" CodeBehind="QuanLyNhomHangHoa.aspx.cs" Inherits="BanHang.QuanLyNhomHangHoa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <dx:ASPxGridView ID="gridDanhSach" runat="server" AutoGenerateColumns="False" KeyFieldName="ID" Width="100%" OnRowDeleting="gridDanhSach_RowDeleting" OnRowInserting="gridDanhSach_RowInserting" OnRowUpdating="gridDanhSach_RowUpdating" OnInitNewRow="gridDanhSach_InitNewRow">
        <SettingsEditing Mode="PopupEditForm">
        </SettingsEditing>
        <Settings AutoFilterCondition="Contains" ShowFilterRow="True" ShowTitlePanel="True" />
        <SettingsBehavior ConfirmDelete="True" />
        <SettingsCommandButton RenderMode="Image">
            <ShowAdaptiveDetailButton ButtonType="Image">
            </ShowAdaptiveDetailButton>
            <HideAdaptiveDetailButton ButtonType="Image">
            </HideAdaptiveDetailButton>
            <NewButton>
                <Image IconID="actions_add_16x16" ToolTip="Thêm">
                </Image>
            </NewButton>
            <UpdateButton ButtonType="Image" RenderMode="Image">
                <Image IconID="save_save_32x32office2013" ToolTip="Lưu">
                </Image>
            </UpdateButton>
            <CancelButton ButtonType="Image" RenderMode="Image">
                <Image IconID="actions_close_32x32" ToolTip="Hủy thao tác">
                </Image>
            </CancelButton>
            <EditButton ButtonType="Image" RenderMode="Image">
                <Image IconID="actions_edit_16x16devav" ToolTip="Sửa">
                </Image>
            </EditButton>
            <DeleteButton ButtonType="Image" RenderMode="Image">
                <Image IconID="actions_cancel_16x16" ToolTip="Xóa">
                </Image>
            </DeleteButton>
        </SettingsCommandButton>
        <SettingsPopup>
            <EditForm HorizontalAlign="WindowCenter" Modal="True" VerticalAlign="WindowCenter" />
        </SettingsPopup>
        <SettingsSearchPanel Visible="True" />
        <SettingsText CommandDelete="Xóa" CommandEdit="Sửa" CommandNew="Thêm" ConfirmDelete="Bạn có chắc chắn muốn xóa không?" PopupEditFormCaption="Thông tin đơn vị tính" Title="DANH SÁCH NHÓM HÀNG HÓA" />
        <EditFormLayoutProperties>
            <Items>
                <dx:GridViewColumnLayoutItem ColumnName="Mã Nhóm">
                </dx:GridViewColumnLayoutItem>
                <dx:GridViewColumnLayoutItem ColumnName="Tên Nhóm" Name="TenDonViTinh">
                </dx:GridViewColumnLayoutItem>
                <dx:GridViewColumnLayoutItem ColumnName="Ghi Chú">
                </dx:GridViewColumnLayoutItem>
                <dx:EditModeCommandLayoutItem HorizontalAlign="Right">
                </dx:EditModeCommandLayoutItem>
            </Items>
        </EditFormLayoutProperties>
        <Columns>
            <dx:GridViewCommandColumn ShowClearFilterButton="True" ShowDeleteButton="True" ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="6" Name="iconaction">
            </dx:GridViewCommandColumn>
            <dx:GridViewDataTextColumn Caption="Mã Nhóm" FieldName="MaNhom" VisibleIndex="0" ReadOnly="True">
                <PropertiesTextEdit>
                    <ValidationSettings SetFocusOnError="True">
                        <RequiredField IsRequired="True" />
                    </ValidationSettings>
                </PropertiesTextEdit>
                <Settings AutoFilterCondition="Contains" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="Tên Nhóm" FieldName="TenNhom" VisibleIndex="1">
                <PropertiesTextEdit>
                    
                    <ValidationSettings SetFocusOnError="True">
                        
                        <RequiredField IsRequired="True" />
                        
                    </ValidationSettings>
                    
                </PropertiesTextEdit>
                <Settings AutoFilterCondition="Contains" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataDateColumn Caption="Ngày Cập Nhật" FieldName="NgayCapNhat" VisibleIndex="5">
                <propertiesdateedit displayformatstring="dd/MM/yyyy"></propertiesdateedit>
                <settings autofiltercondition="Contains" />
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataTextColumn Caption="Ghi Chú" FieldName="GhiChu" VisibleIndex="4">
            </dx:GridViewDataTextColumn>
        </Columns>
        <Styles>
            <Header Font-Bold="True" HorizontalAlign="Center">
            </Header>
            <AlternatingRow Enabled="True">
            </AlternatingRow>
            <TitlePanel Font-Bold="True" HorizontalAlign="Left">
            </TitlePanel>
        </Styles>
    </dx:ASPxGridView>
</asp:Content>
