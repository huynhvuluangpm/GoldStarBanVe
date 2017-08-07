﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChiTietPhieuXuatKhac.aspx.cs" Inherits="BanHang.ChiTietPhieuXuatKhac" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <dx:ASPxGridView runat="server" AutoGenerateColumns="False" Width="100%" ID="gridChiTietPhieuXuatKhac" KeyFieldName="ID" OnRowDeleting="gridChiTietPhieuXuatKhac_RowDeleting" OnRowUpdating="gridChiTietPhieuXuatKhac_RowUpdating">
        <SettingsEditing Mode="PopupEditForm">
        </SettingsEditing>
<Settings ShowTitlePanel="True"></Settings>

        <SettingsBehavior ConfirmDelete="True" />

        <SettingsCommandButton>
        <ShowAdaptiveDetailButton ButtonType="Image"></ShowAdaptiveDetailButton>

        <HideAdaptiveDetailButton ButtonType="Image"></HideAdaptiveDetailButton>
            <NewButton ButtonType="Image" RenderMode="Image">
                <Image IconID="actions_add_16x16" ToolTip="Thêm mới">
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

<SettingsText Title="Thông tin chi tiết phiếu xuất khác" CommandDelete="Xóa" ConfirmDelete="Bạn chắc chắn muốn xóa?" CommandEdit="Sửa"></SettingsText>
        <EditFormLayoutProperties ColCount="2">
            <Items>
                <dx:GridViewColumnLayoutItem Caption="Hàng Hóa" ColumnName="Hàng Hóa" Name="IDHangHoa">
                </dx:GridViewColumnLayoutItem>
                <dx:GridViewColumnLayoutItem Caption="Số Lượng" ColumnName="Số Lượng" Name="SoLuong">
                </dx:GridViewColumnLayoutItem>
                <dx:EditModeCommandLayoutItem HorizontalAlign="Right" ColSpan="2">
                </dx:EditModeCommandLayoutItem>
            </Items>
        </EditFormLayoutProperties>
<Columns>
    <dx:GridViewCommandColumn VisibleIndex="8" ShowEditButton="True">
    </dx:GridViewCommandColumn>
    <dx:GridViewDataComboBoxColumn FieldName="IDHangHoa" Caption="H&#224;ng H&#243;a" VisibleIndex="0" ReadOnly="True">
    <PropertiesComboBox DataSourceID="sqlHangHoa" TextField="TenHangHoa" ValueField="ID"></PropertiesComboBox>
    </dx:GridViewDataComboBoxColumn>
    <dx:GridViewDataSpinEditColumn Caption="Thành Tiền" FieldName="ThanhTien" VisibleIndex="7" ReadOnly="True">
        <propertiesspinedit DisplayFormatString="N0"></propertiesspinedit>
    </dx:GridViewDataSpinEditColumn>
    <dx:GridViewDataSpinEditColumn Caption="Đơn Giá" FieldName="DonGia" VisibleIndex="4">
        <propertiesspinedit DisplayFormatString="N0"></propertiesspinedit>
    </dx:GridViewDataSpinEditColumn>
    <dx:GridViewDataSpinEditColumn Caption="Số Lượng" FieldName="SoLuong" VisibleIndex="2">
        <PropertiesSpinEdit DisplayFormatString="g">
        </PropertiesSpinEdit>
    </dx:GridViewDataSpinEditColumn>
    <dx:GridViewDataSpinEditColumn Caption="Số Lượng Tồn" FieldName="SoLuongCon" VisibleIndex="3" ReadOnly="True">
        <PropertiesSpinEdit DisplayFormatString="g">
        </PropertiesSpinEdit>
    </dx:GridViewDataSpinEditColumn>
    
</Columns>

<Styles>
<Header HorizontalAlign="Center" Font-Bold="True"></Header>

<AlternatingRow Enabled="True"></AlternatingRow>

<TitlePanel HorizontalAlign="Left" Font-Bold="True"></TitlePanel>
</Styles>
  
</dx:ASPxGridView>
        <asp:SqlDataSource ID="sqlHangHoa" runat="server" ConnectionString="<%$ ConnectionStrings:BanHangConnectionString %>" SelectCommand="SELECT [ID], [TenHangHoa] FROM [GPM_HangHoa] WHERE ([DaXoa] = @DaXoa)">
            <SelectParameters>
                <asp:Parameter DefaultValue="0" Name="DaXoa" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
    </div>
    </form>
</body>
</html>
