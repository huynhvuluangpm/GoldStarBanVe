<%@ Page Title="" Language="C#" MasterPageFile="~/Root.master" AutoEventWireup="true" CodeBehind="QuanLyBan.aspx.cs" Inherits="BanHang.QuanLyBan" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <dx:ASPxFormLayout ID="ASPxFormLayout1" runat="server">
        <Items>
            <dx:LayoutItem Caption="">
                <LayoutItemNestedControlCollection>
                    <dx:LayoutItemNestedControlContainer runat="server">
                        <dx:ASPxButton ID="ASPxFormLayout1_E2" runat="server" OnClick="ASPxFormLayout1_E2_Click" Text="Tạo Bàn Nhanh">
                            <Image IconID="actions_add_32x32">
                            </Image>
                        </dx:ASPxButton>
                    </dx:LayoutItemNestedControlContainer>
                </LayoutItemNestedControlCollection>
            </dx:LayoutItem>
        </Items>
    </dx:ASPxFormLayout>
    
    <dx:ASPxGridView ID="gridDanhSach" runat="server" AutoGenerateColumns="False" KeyFieldName="ID" Width="100%" OnRowDeleting="gridDanhSach_RowDeleting" OnRowInserting="gridDanhSach_RowInserting" OnRowUpdating="gridDanhSach_RowUpdating">
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
        <SettingsText CommandDelete="Xóa" CommandEdit="Sửa" CommandNew="Thêm" ConfirmDelete="Bạn có chắc chắn muốn xóa không?" PopupEditFormCaption="Thông tin đơn vị tính" Title="DANH SÁCH BÀN" />
        <EditFormLayoutProperties>
            <Items>
                <dx:GridViewColumnLayoutItem ColumnName="Tên Bàn" Name="TenDonViTinh">
                </dx:GridViewColumnLayoutItem>
                <dx:GridViewColumnLayoutItem ColumnName="Khu Vực">
                </dx:GridViewColumnLayoutItem>
                <dx:EditModeCommandLayoutItem HorizontalAlign="Right">
                </dx:EditModeCommandLayoutItem>
            </Items>
        </EditFormLayoutProperties>
        <Columns>
            <dx:GridViewCommandColumn ShowClearFilterButton="True" ShowDeleteButton="True" ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="6" Name="iconaction">
            </dx:GridViewCommandColumn>
            <dx:GridViewDataTextColumn Caption="Mã Bàn" FieldName="MaBan" VisibleIndex="0" ReadOnly="True">
                <PropertiesTextEdit>
                    <ValidationSettings>
                        <RequiredField IsRequired="True" />
                    </ValidationSettings>
                </PropertiesTextEdit>
                <Settings AutoFilterCondition="Contains" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataDateColumn Caption="Ngày Cập Nhật" FieldName="NgayCapNhat" VisibleIndex="5">
                <propertiesdateedit displayformatstring="dd/MM/yyyy"></propertiesdateedit>
                <settings autofiltercondition="Contains" />
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataComboBoxColumn Caption="Khu Vực" FieldName="IDKhuVuc" VisibleIndex="2">
                <PropertiesComboBox DataSourceID="SqlKhuVuc" TextField="TenChiNhanh" ValueField="ID">
                    <ValidationSettings SetFocusOnError="True">
                        <RequiredField IsRequired="True" />
                    </ValidationSettings>
                </PropertiesComboBox>
            </dx:GridViewDataComboBoxColumn>
            <dx:GridViewDataSpinEditColumn Caption="Tên Bàn" FieldName="TenBan" VisibleIndex="1">
                <PropertiesSpinEdit DisplayFormatString="g">
                    <ValidationSettings SetFocusOnError="True">
                        <RequiredField IsRequired="True" />
                    </ValidationSettings>
                </PropertiesSpinEdit>
                <Settings AutoFilterCondition="Contains" />
            </dx:GridViewDataSpinEditColumn>
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
       <asp:SqlDataSource ID="SqlKhuVuc" runat="server" ConnectionString="<%$ ConnectionStrings:BanHangConnectionString %>" SelectCommand="SELECT [CF_KhuVuc].ID, [CF_KhuVuc].TenKhuVuc +' - ' +[CF_ChiNhanh].TenChiNhanh as TenChiNhanh FROM [CF_KhuVuc],[CF_ChiNhanh] WHERE ([CF_KhuVuc].[DaXoa] = @DaXoa) AND [CF_KhuVuc].IDChiNhanh = [CF_ChiNhanh].ID">
           <SelectParameters>
               <asp:Parameter DefaultValue="0" Name="DaXoa" Type="Int32" />
           </SelectParameters>
       </asp:SqlDataSource>

    <dx:ASPxPopupControl ID="popupThemKhachHang" runat="server" AllowDragging="True" AllowResize="True" 
         PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter"  Width="600px"
         Height="200px"
        HeaderText="Thêm Bàn Nhanh" ClientInstanceName="popupThemKhachHang" CloseAction="CloseButton">
         <ContentCollection>
    <dx:PopupControlContentControl ID="PopupControlContentControl1" runat="server">
    <dx:ASPxFormLayout ID="ASPxFormLayout2" runat="server" ColCount="2" Width="100%">
        <Items>
            <dx:LayoutItem Caption="Bàn Số">
                <LayoutItemNestedControlCollection>
                    <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer7" runat="server">
                        <dx:ASPxSpinEdit ID="txtTuSo" runat="server"  Width="100%">
                            <ValidationSettings SetFocusOnError="True">
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                        </dx:ASPxSpinEdit>
                    </dx:LayoutItemNestedControlContainer>
                </LayoutItemNestedControlCollection>
            </dx:LayoutItem>
            <dx:LayoutItem Caption="Đến số">
                <LayoutItemNestedControlCollection>
                    <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer8" runat="server">
                        <dx:ASPxSpinEdit ID="txtDenSo" runat="server"  Width="100%">
                            <ValidationSettings SetFocusOnError="True">
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                        </dx:ASPxSpinEdit>
                    </dx:LayoutItemNestedControlContainer>
                </LayoutItemNestedControlCollection>
            </dx:LayoutItem>
            <dx:LayoutItem Caption="Khu Vực" ColSpan="2">
                <LayoutItemNestedControlCollection>
                    <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer9" runat="server">
                        <dx:ASPxComboBox ID="cmbKhuVuc" runat="server" Width="100%" DataSourceID="SqlKhuVuc" TextField="TenChiNhanh" ValueField="ID" >
                            <ValidationSettings SetFocusOnError="True">
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                        </dx:ASPxComboBox>
                    </dx:LayoutItemNestedControlContainer>
                </LayoutItemNestedControlCollection>
            </dx:LayoutItem>
            <dx:LayoutItem Caption="" HorizontalAlign="Right">
                <LayoutItemNestedControlCollection>
                    <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer16" runat="server">
                        <dx:ASPxButton ID="btnSave" runat="server" OnClick="btnSave_Click">
                            <Image IconID="save_saveto_32x32">
                            </Image>
                        </dx:ASPxButton>
                    </dx:LayoutItemNestedControlContainer>
                </LayoutItemNestedControlCollection>
            </dx:LayoutItem>
            <dx:LayoutItem Caption="">
                <LayoutItemNestedControlCollection>
                    <dx:LayoutItemNestedControlContainer ID="LayoutItemNestedControlContainer17" runat="server">
                        <dx:ASPxButton ID="btnClose" runat="server" OnClick="btnClose_Click">
                            <Image IconID="save_saveandclose_32x32">
                            </Image>
                        </dx:ASPxButton>
                    </dx:LayoutItemNestedControlContainer>
                </LayoutItemNestedControlCollection>
            </dx:LayoutItem>
        </Items>
    </dx:ASPxFormLayout>
  </dx:PopupControlContentControl>
</ContentCollection>
    </dx:ASPxPopupControl>
</asp:Content>
