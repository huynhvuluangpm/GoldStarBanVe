﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Root.master" AutoEventWireup="true" CodeBehind="TonKhoBanDau.aspx.cs" Inherits="BanHang.TonKhoBanDau" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
      <dx:ASPxGridView ID="gridDanhSach" runat="server" AutoGenerateColumns="False" KeyFieldName="ID" Width="100%">
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
        <SettingsText CommandDelete="Xóa" CommandEdit="Sửa" CommandNew="Thêm" ConfirmDelete="Bạn có chắc chắn muốn xóa không?" PopupEditFormCaption="Thông tin đơn vị tính" Title="DANH SÁCH NGUYÊN LIỆU TỒN KHO" />
        <Columns>
            <dx:GridViewDataTextColumn Caption="Mã Nguyên Liệu" FieldName="MaNguyenLieu" VisibleIndex="0">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataComboBoxColumn Caption="Tên Nguyên Liệu" FieldName="IDNguyenLieu" VisibleIndex="1">
                <PropertiesComboBox DataSourceID="SqlNguyenLieu" TextField="TenNguyenLieu" ValueField="ID">
                </PropertiesComboBox>
            </dx:GridViewDataComboBoxColumn>
            <dx:GridViewDataComboBoxColumn Caption="ĐVT" FieldName="IDDonViTinh" VisibleIndex="2">
                <PropertiesComboBox DataSourceID="SqlDVT" TextField="TenDonViTinh" ValueField="ID">
                </PropertiesComboBox>
            </dx:GridViewDataComboBoxColumn>
            <dx:GridViewDataSpinEditColumn Caption="Trọng Lượng (g)" FieldName="TrongLuong" VisibleIndex="3">
                <PropertiesSpinEdit DisplayFormatString="g">
                </PropertiesSpinEdit>
            </dx:GridViewDataSpinEditColumn>
            <dx:GridViewDataComboBoxColumn Caption="Chi Nhánh" FieldName="IDChiNhanh" VisibleIndex="4">
                <PropertiesComboBox DataSourceID="SqlChiNhanh" TextField="TenChiNhanh" ValueField="ID">
                </PropertiesComboBox>
            </dx:GridViewDataComboBoxColumn>
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
      <asp:SqlDataSource ID="SqlChiNhanh" runat="server" ConnectionString="<%$ ConnectionStrings:BanHangConnectionString %>" SelectCommand="SELECT [ID], [TenChiNhanh] FROM [CF_ChiNhanh] WHERE ([DaXoa] = @DaXoa)">
          <SelectParameters>
              <asp:Parameter DefaultValue="0" Name="DaXoa" Type="Int32" />
          </SelectParameters>
      </asp:SqlDataSource>
      <asp:SqlDataSource ID="SqlNguyenLieu" runat="server" ConnectionString="<%$ ConnectionStrings:BanHangConnectionString %>" SelectCommand="SELECT [ID], [TenNguyenLieu] FROM [CF_NguyenLieu] WHERE ([DaXoa] = @DaXoa)">
          <SelectParameters>
              <asp:Parameter DefaultValue="0" Name="DaXoa" Type="Int32" />
          </SelectParameters>
      </asp:SqlDataSource>
      <asp:SqlDataSource ID="SqlDVT" runat="server" ConnectionString="<%$ ConnectionStrings:BanHangConnectionString %>" SelectCommand="SELECT [ID], [TenDonViTinh] FROM [CF_DonViTinh] WHERE ([DaXoa] = @DaXoa)">
          <SelectParameters>
              <asp:Parameter DefaultValue="0" Name="DaXoa" Type="Int32" />
          </SelectParameters>
      </asp:SqlDataSource>
</asp:Content>
