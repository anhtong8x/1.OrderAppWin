using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp.Reports
{
    public class RptBill_1
    {
         
        private ModelBill_1 _modelBill_1;
        public RptBill_1(ModelBill_1 modelBill_1) {
            _modelBill_1 = modelBill_1;
        }

        public void showReport()
        {
            // format report
            #region "create_band"            
            TopMarginBand TopMargin = new TopMarginBand();
            BottomMarginBand BottomMargin = new BottomMarginBand();
            DetailBand Detail = new DetailBand(); // noi dung lap lai
            ReportHeaderBand ReportHeader = new ReportHeaderBand(); // khong lap lai lam ten report
            PageHeaderBand PageHeader = new PageHeaderBand(); // lap lai tieu de
            ReportFooterBand ReportFooter = new ReportFooterBand(); // khong lap lai de lay chu ky

            //
            XRLabel lbl_ThuNgan = new XRLabel();
            XRLabel lbl_Khach = new XRLabel();
            XRLabel lbl_Date = new XRLabel();
            XRLabel lbl_HD = new XRLabel();
            XRLabel xrLabel3 = new XRLabel();
            XRLabel xrLabel8 = new XRLabel();
            XRLabel xrLabel2 = new XRLabel();

            XRTable xrTable_Title = new XRTable();
            XRTableRow xrTableRow1 = new XRTableRow();
            XRTableCell xrTableCell1 = new XRTableCell();
            XRTableCell xrTableCell2 = new XRTableCell();
            XRTableCell xrTableCell3 = new XRTableCell();
            XRTableCell xrTableCell4 = new XRTableCell();
            XRTableCell xrTableCell6 = new XRTableCell();

            XRTable xrTable_ThanhToan = new XRTable();
            XRTableRow xrTableRow5 = new XRTableRow();
            XRTableCell xrTableCell14 = new XRTableCell();
            XRTableCell xrTableCell_ThanhTien = new XRTableCell();
            XRTable xrTable_KhuyenMai = new XRTable();
            XRTableRow xrTableRow4 = new XRTableRow();
            XRTableCell xrTableCell12 = new XRTableCell();
            XRTableCell xrTableCell_KM = new XRTableCell();
            XRTable xrTable_TongHD = new XRTable();
            XRTableRow xrTableRow3 = new XRTableRow();
            XRTableCell xrTableCell11 = new XRTableCell();
            XRTableCell xrTableCell_TongHD = new XRTableCell();
            XRLabel xrLabel1 = new XRLabel();
            XRTableCell xrTableCell19 = new XRTableCell();
            XRTableCell xrTableCell18 = new XRTableCell();
            XRTableCell xrTableCell17 = new XRTableCell();

            #endregion

            #region "1"
            // 
            // TopMargin
            // 
            TopMargin.HeightF = 21F;
            TopMargin.Name = "TopMargin";
            TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            BottomMargin.HeightF = 164F;
            BottomMargin.Name = "BottomMargin";
            BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // ReportHeader
            // 
            ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            lbl_ThuNgan,
            lbl_Khach,
            lbl_Date,
            lbl_HD,
            xrLabel3,
            xrLabel8,
            xrLabel2});
            ReportHeader.HeightF = 130.9786F;
            ReportHeader.Name = "ReportHeader";
            // 
            // PageHeader
            // 
            PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            xrTable_Title});
            PageHeader.HeightF = 25.92234F;
            PageHeader.Name = "PageHeader";
            // 
            // xrLabel2
            // 
            xrLabel2.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            xrLabel2.Multiline = true;
            xrLabel2.Name = "xrLabel2";
            xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            xrLabel2.SizeF = new System.Drawing.SizeF(300.1243F, 23F);
            xrLabel2.StylePriority.UseFont = false;
            xrLabel2.StylePriority.UseTextAlignment = false;
            xrLabel2.Text = "Hải Sản Bốn Mùa Hà Nội";
            xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel8
            // 
            xrLabel8.Font = new System.Drawing.Font("Times New Roman", 11F);
            xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(0F, 23F);
            xrLabel8.Multiline = true;
            xrLabel8.Name = "xrLabel8";
            xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            xrLabel8.SizeF = new System.Drawing.SizeF(300.1243F, 30.29165F);
            xrLabel8.StylePriority.UseFont = false;
            xrLabel8.StylePriority.UseTextAlignment = false;
            xrLabel8.Text = "Địa chỉ: Ngã tư Tô Hiệu ";
            xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleJustify;
            // 
            // xrLabel3
            // 
            xrLabel3.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 53.29166F);
            xrLabel3.Multiline = true;
            xrLabel3.Name = "xrLabel3";
            xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            xrLabel3.SizeF = new System.Drawing.SizeF(651F, 24.10332F);
            xrLabel3.StylePriority.UseFont = false;
            xrLabel3.StylePriority.UseTextAlignment = false;
            xrLabel3.Text = "HÓA ĐƠN THANH TOÁN";
            xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // lbl_HD
            // 
            lbl_HD.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            lbl_HD.LocationFloat = new DevExpress.Utils.PointFloat(0F, 77.39498F);
            lbl_HD.Multiline = true;
            lbl_HD.Name = "lbl_HD";
            lbl_HD.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            lbl_HD.SizeF = new System.Drawing.SizeF(300.1243F, 22.99998F);
            lbl_HD.StylePriority.UseFont = false;
            lbl_HD.StylePriority.UseTextAlignment = false;
            //----------
            lbl_HD.Text = string.Format("HD: {0}", _modelBill_1.HD);
            lbl_HD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleJustify;
            // 
            // lbl_Date
            // 
            lbl_Date.Font = new System.Drawing.Font("Times New Roman", 11F);
            lbl_Date.LocationFloat = new DevExpress.Utils.PointFloat(350.8758F, 77.39498F);
            lbl_Date.Multiline = true;
            lbl_Date.Name = "lbl_Date";
            lbl_Date.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            lbl_Date.SizeF = new System.Drawing.SizeF(300.1242F, 22.99998F);
            lbl_Date.StylePriority.UseFont = false;
            lbl_Date.StylePriority.UseTextAlignment = false;
            //----------
            lbl_Date.Text = string.Format("Ngày:{0}", _modelBill_1.NGAY);
            lbl_Date.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleJustify;
            // 
            // lbl_Khach
            // 
            lbl_Khach.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            lbl_Khach.LocationFloat = new DevExpress.Utils.PointFloat(0F, 100.395F);
            lbl_Khach.Multiline = true;
            lbl_Khach.Name = "lbl_Khach";
            lbl_Khach.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            lbl_Khach.SizeF = new System.Drawing.SizeF(300.1243F, 27.33337F);
            lbl_Khach.StylePriority.UseFont = false;
            lbl_Khach.StylePriority.UseTextAlignment = false;

            //----------
            lbl_Khach.Text = string.Format("Khách hàng: Bàn {0}", _modelBill_1.BAN);
            lbl_Khach.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lbl_ThuNgan
            // 
            lbl_ThuNgan.Font = new System.Drawing.Font("Times New Roman", 11F);
            lbl_ThuNgan.LocationFloat = new DevExpress.Utils.PointFloat(350.8758F, 100.395F);
            lbl_ThuNgan.Multiline = true;
            lbl_ThuNgan.Name = "lbl_ThuNgan";
            lbl_ThuNgan.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            lbl_ThuNgan.SizeF = new System.Drawing.SizeF(300.1242F, 27.33337F);
            lbl_ThuNgan.StylePriority.UseFont = false;
            lbl_ThuNgan.StylePriority.UseTextAlignment = false;

            //----------
            lbl_ThuNgan.Text = string.Format("Nhân viên: {0}", _modelBill_1.THUNGAN);
            lbl_ThuNgan.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrTable_Title
            // 
            xrTable_Title.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
            | DevExpress.XtraPrinting.BorderSide.Right)
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            xrTable_Title.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            xrTable_Title.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            xrTable_Title.Name = "xrTable_Title";
            xrTable_Title.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            xrTableRow1});
            xrTable_Title.SizeF = new System.Drawing.SizeF(651F, 25.92234F);
            xrTable_Title.StylePriority.UseBorders = false;
            xrTable_Title.StylePriority.UseFont = false;
            xrTable_Title.StylePriority.UseTextAlignment = false;
            xrTable_Title.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableRow1
            // 
            xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            xrTableCell1,
            xrTableCell2,
            xrTableCell3,
            xrTableCell4,
            xrTableCell6});
            xrTableRow1.Name = "xrTableRow1";
            xrTableRow1.Weight = 1D;
            // 
            // xrTableCell1
            // 
            xrTableCell1.Name = "xrTableCell1";
            xrTableCell1.Text = "TT";
            xrTableCell1.Weight = 0.5145630264282226D;
            // 
            // xrTableCell2
            // 
            xrTableCell2.Name = "xrTableCell2";
            xrTableCell2.Text = "Tên món";
            xrTableCell2.Weight = 2.4575161237046457D;
            // 
            // xrTableCell3
            // 
            xrTableCell3.Name = "xrTableCell3";
            xrTableCell3.Text = "Sl";
            xrTableCell3.Weight = 0.78105495391029256D;
            // 
            // xrTableCell4
            // 
            xrTableCell4.Name = "xrTableCell4";
            xrTableCell4.Text = "Giá";
            xrTableCell4.Weight = 1.2525252407920633D;
            // 
            // xrTableCell6
            // 
            xrTableCell6.Multiline = true;
            xrTableCell6.Name = "xrTableCell6";
            xrTableCell6.Text = "Thành tiền\r\n";
            xrTableCell6.Weight = 1.5043400662950788D;
            #endregion

            #region "detail"
            // 
            // xrTable_Detail
            // 
            XRTable xrTable_Detail = new XRTable();
            XRTableRow xrTableRow2;// = new XRTableRow();
            XRTableCell xrTableCell_TT;
            XRTableCell xrTableCell_TenMon;
            XRTableCell xrTableCell_SL;
            XRTableCell xrTableCell_Gia;
            XRTableCell xrTableCell_TienRow;

            xrTable_Detail.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            xrTable_Detail.Font = new System.Drawing.Font("Times New Roman", 9F);
            xrTable_Detail.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            xrTable_Detail.Name = "xrTable_Detail";
                   
            foreach(ModelRow row in _modelBill_1.ROWDETAIL)
            {
                xrTableCell_TT = new XRTableCell();
                xrTableCell_TenMon = new XRTableCell();
                xrTableCell_SL = new XRTableCell();
                xrTableCell_Gia = new XRTableCell();
                xrTableCell_TienRow = new XRTableCell();
                // 
                // xrTableCell_TT
                // 
                xrTableCell_TT.Name = "xrTableCell_TT";
                xrTableCell_TT.Text = row.STT;
                xrTableCell_TT.Weight = 0.5145630264282226D;
                // 
                // xrTableCell_TenMon
                // 
                xrTableCell_TenMon.Name = "xrTableCell_TenMon";
                xrTableCell_TenMon.Text = "    " + row.TENMON;
                xrTableCell_TenMon.Weight = 2.4575161237046457D;
                xrTableCell_TenMon.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
                // 
                // xrTableCell_SL
                // 
                xrTableCell_SL.Name = "xrTableCell_SL";
                xrTableCell_SL.Text = row.SL;
                xrTableCell_SL.Weight = 0.78105495391029256D;
                // 
                // xrTableCell_Gia
                // 
                xrTableCell_Gia.Name = "xrTableCell_Gia";
                xrTableCell_Gia.Text = row.GIA;
                xrTableCell_Gia.Weight = 1.2525252407920633D;
                // 
                // xrTableCell_TienRow
                // 
                xrTableCell_TienRow.Multiline = true;
                xrTableCell_TienRow.Name = "xrTableCell_TienRow";
                xrTableCell_TienRow.Text = row.TT;
                xrTableCell_TienRow.Weight = 1.5043400662950788D;

                // 
                // xrTableRow2
                // 
                xrTableRow2 = new XRTableRow();
                xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            xrTableCell_TT,
            xrTableCell_TenMon,
            xrTableCell_SL,
            xrTableCell_Gia,
            xrTableCell_TienRow});
                xrTableRow2.Name = "xrTableRow2";
                xrTableRow2.Weight = 1D;

                xrTable_Detail.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {xrTableRow2});
                xrTable_Detail.SizeF = new System.Drawing.SizeF(651F, 22.70832F);
                xrTable_Detail.StylePriority.UseBorders = false;
                xrTable_Detail.StylePriority.UseFont = false;
                xrTable_Detail.StylePriority.UseTextAlignment = false;
                xrTable_Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;

            }

            //
            // 
            // Detail
            // 
            Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            xrTable_Detail});
            Detail.HeightF = 22.70832F;
            Detail.Name = "Detail";
            Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;

            #endregion

            #region "2"
            // 
            // ReportFooter
            // 
            ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            xrLabel1,
            xrTable_ThanhToan,
            xrTable_KhuyenMai,
            xrTable_TongHD});
            ReportFooter.HeightF = 113.5557F;
            ReportFooter.Name = "ReportFooter";
            ReportFooter.StylePriority.UseTextAlignment = false;
            ReportFooter.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrTableCell_TongHD
            // 
            xrTableCell_TongHD.Multiline = true;
            xrTableCell_TongHD.Name = "xrTableCell_TongHD";
//----------
            xrTableCell_TongHD.Text = _modelBill_1.TONGHD;
            xrTableCell_TongHD.Weight = 1.5043403652919267D;
            // 
            // xrTableCell11
            // 
            xrTableCell11.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));

            xrTableCell11.Name = "xrTableCell11";
            xrTableCell11.StylePriority.UseBorders = false;
            xrTableCell11.StylePriority.UseTextAlignment = false;
            xrTableCell11.Text = "Tổng tiền hóa đơn";
            xrTableCell11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            xrTableCell11.Weight = 4.4910961034873234D;
            // 
            // xrTableCell17
            // 
            xrTableCell17.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left )
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            xrTableCell17.Name = "xrTableCell17";
            xrTableCell17.StylePriority.UseBorders = false;
            xrTableCell17.StylePriority.UseTextAlignment = false;
            xrTableCell17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            xrTableCell17.Weight = 0.51456295013428432D;

            // 
            // xrTableRow3
            // 
            xrTableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            xrTableCell17,
            xrTableCell11,
            xrTableCell_TongHD});
            xrTableRow3.Name = "xrTableRow3";
            xrTableRow3.Weight = 1D;
            // 
            // xrTable_TongHD
            // 
            xrTable_TongHD.Borders = ((DevExpress.XtraPrinting.BorderSide)(
                ((
                (DevExpress.XtraPrinting.BorderSide.Left)
            | DevExpress.XtraPrinting.BorderSide.Right)
            | DevExpress.XtraPrinting.BorderSide.Bottom)
            ));
            xrTable_TongHD.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            xrTable_TongHD.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            xrTable_TongHD.Name = "xrTable_TongHD";
            xrTable_TongHD.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            xrTableRow3});
            xrTable_TongHD.SizeF = new System.Drawing.SizeF(651F, 20.16603F);
            xrTable_TongHD.StylePriority.UseBorders = false;
            xrTable_TongHD.StylePriority.UseFont = false;
            xrTable_TongHD.StylePriority.UseTextAlignment = false;
            xrTable_TongHD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;

            // 
            // xrTable_KhuyenMai
            // 
            xrTable_KhuyenMai.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
            | DevExpress.XtraPrinting.BorderSide.Right)
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            xrTable_KhuyenMai.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            xrTable_KhuyenMai.LocationFloat = new DevExpress.Utils.PointFloat(0F, 20.16603F);
            xrTable_KhuyenMai.Name = "xrTable_KhuyenMai";
            xrTable_KhuyenMai.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            xrTableRow4});
            xrTable_KhuyenMai.SizeF = new System.Drawing.SizeF(651.0001F, 25.41813F);
            xrTable_KhuyenMai.StylePriority.UseBorders = false;
            xrTable_KhuyenMai.StylePriority.UseFont = false;
            xrTable_KhuyenMai.StylePriority.UseTextAlignment = false;
            xrTable_KhuyenMai.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableRow4
            // 
            xrTableRow4.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            xrTableCell18,
            xrTableCell12,
            xrTableCell_KM});
            xrTableRow4.Name = "xrTableRow4";
            xrTableRow4.Weight = 1D;
            // 
            // xrTableCell12
            // 
            xrTableCell12.Borders = DevExpress.XtraPrinting.BorderSide.Right;
            xrTableCell12.Name = "xrTableCell12";
            xrTableCell12.StylePriority.UseBorders = false;
            xrTableCell12.StylePriority.UseTextAlignment = false;
            xrTableCell12.Text = String.Format("Khuyến mại {0} %", _modelBill_1.PHANTRAM);
            xrTableCell12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            xrTableCell12.Weight = 4.4910961007481767D;
            // 
            // xrTableCell_KM
            // 
            xrTableCell_KM.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)));
            xrTableCell_KM.Multiline = true;
            xrTableCell_KM.Name = "xrTableCell_KM";
            xrTableCell_KM.StylePriority.UseBorders = false;
//----------
            xrTableCell_KM.Text = _modelBill_1.KM;
            xrTableCell_KM.Weight = 1.5043409824956149D;
            // 
            // xrTable_ThanhToan
            // 
            xrTable_ThanhToan.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
            | DevExpress.XtraPrinting.BorderSide.Right)
            | DevExpress.XtraPrinting.BorderSide.Bottom)));

            xrTable_ThanhToan.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            xrTable_ThanhToan.LocationFloat = new DevExpress.Utils.PointFloat(0F, 45.58416F);
            xrTable_ThanhToan.Name = "xrTable_ThanhToan";
            xrTable_ThanhToan.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            xrTableRow5});
            xrTable_ThanhToan.SizeF = new System.Drawing.SizeF(651.0001F, 27.51897F);
            xrTable_ThanhToan.StylePriority.UseBorders = false;
            xrTable_ThanhToan.StylePriority.UseFont = false;
            xrTable_ThanhToan.StylePriority.UseTextAlignment = false;
            xrTable_ThanhToan.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableRow5
            // 
            xrTableRow5.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            xrTableCell19,
            xrTableCell14,
            xrTableCell_ThanhTien});
            xrTableRow5.Name = "xrTableRow5";
            xrTableRow5.Weight = 1D;
            // 
            // xrTableCell14
            // 
            xrTableCell14.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            xrTableCell14.Name = "xrTableCell14";
            xrTableCell14.StylePriority.UseBorders = false;
            xrTableCell14.StylePriority.UseTextAlignment = false;
            xrTableCell14.Text = "Tổng tiền khách phải thanh toán";
            xrTableCell14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            xrTableCell14.Weight = 4.4910962502874057D;
            // 
            // xrTableCell_ThanhTien
            // 
            xrTableCell_ThanhTien.Multiline = true;
            xrTableCell_ThanhTien.Name = "xrTableCell_ThanhTien";
            xrTableCell_ThanhTien.Text = _modelBill_1.THANHTOAN;
            xrTableCell_ThanhTien.Weight = 1.5043410829626436D;
            // 
            // xrLabel1
            // 
            xrLabel1.Font = new System.Drawing.Font("Times New Roman", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 90.55566F);
            xrLabel1.Multiline = true;
            xrLabel1.Name = "xrLabel1";
            xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            xrLabel1.SizeF = new System.Drawing.SizeF(651F, 23F);
            xrLabel1.StylePriority.UseFont = false;
            xrLabel1.StylePriority.UseTextAlignment = false;
            xrLabel1.Text = "Quý khách vui lòng kiểm tra lại hóa đơn đã thanh toán. Xin cám ơn !";
            xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            
            // 
            // xrTableCell18
            // 
            xrTableCell18.Borders = DevExpress.XtraPrinting.BorderSide.Left;
            xrTableCell18.Name = "xrTableCell18";
            xrTableCell18.StylePriority.UseBorders = false;
            xrTableCell18.StylePriority.UseTextAlignment = false;
            xrTableCell18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            xrTableCell18.Weight = 0.51456294687415438D;
            // 
            // xrTableCell19
            // 
            xrTableCell19.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            xrTableCell19.Name = "xrTableCell19";
            xrTableCell19.StylePriority.UseBorders = false;
            xrTableCell19.StylePriority.UseTextAlignment = false;
            xrTableCell19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            xrTableCell19.Weight = 0.51456285017824233D;
            #endregion

            XtraReport rpt = new XtraReport();
            rpt.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            Detail,
            TopMargin,
            BottomMargin,
            ReportHeader,
            PageHeader,
            ReportFooter});
            rpt.Margins = new System.Drawing.Printing.Margins(35, 4, 21, 164);
            rpt.PageHeight = 984;
            rpt.PageWidth = 693;
            rpt.PaperKind = System.Drawing.Printing.PaperKind.B5;
            rpt.Version = "17.1";


            // body report
            ReportPrintTool reportPrintTool = new ReportPrintTool(rpt);
            reportPrintTool.ShowPreviewDialog();

        }


    }

    public class ModelBill_1
    {
        public string HD { get; set; }
        public string NGAY { get; set; }
        public string BAN { get; set; }
        public string THUNGAN { get; set; }
        public List<ModelRow> ROWDETAIL { get; set; }
        public string TONGHD { get; set; }
        public string PHANTRAM { get; set; }
        public string KM { get; set; }
        public string THANHTOAN{ get; set; }
    }

    public class ModelRow
    {
        public string STT { get; set; }
        public string TENMON { get; set; }
        public string SL { get; set; }
        public string GIA { get; set; }
        public string TT { get; set; }
    }

}
