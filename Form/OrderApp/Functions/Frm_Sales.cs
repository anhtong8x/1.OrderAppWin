using DevExpress.XtraReports.UI;
using OrderApp.Extention;
using OrderApp.Model;
using OrderApp.Reports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderApp.Functions
{
    public partial class Frm_Sales : Form
    {
        public UserInfoModel _UserInfoModel { get; set; }

        private float _sumMoney = 0;
        private BillModel billModel;
		private List<TableModel> lstTableModel;
		private List<BillDetailModel> lstBillDetail;
		private int posDetailBill = -1;
		private int posTable = -1;
		
        #region "common"
        private void reset_Control()
        {
            // set default
            txtHoaDon.Text = "";
            txtSumMoney.Text = "";
            lbl_Id_Bill_1.Text = "BÀN SỐ 000 HÓA ĐƠN 00000";
            txtKhachTra.Text = "";
            txtKhuyenMai.Text = "";
            txtTongCong.Text = "";
            txtTraLai.Text = "";
            lblMsg.Text = "";
            lblMsg1.Text = "";
            txtTienKM.Text = "";
			txtTenMon.Text = "";
			txtSoLuongMon.Text = "";

            dtGrid_Bill.Rows.Clear();
            _sumMoney = 0;
        }

        // tao du lieu do vao grid ban
        private async void load_Grid_Table()
        {
            dtGrid_Table.Rows.Clear();
			lstTableModel = await HttpClientBase<TableModel>.Gets(AppSettings.ListOrderTableUrl);
			if (lstTableModel.Count > 0) {
				BindingGrid_Table(lstTableModel);
			}
					   
		}

        // tao du lieu de do vao grid detailbill
		private async void BindingGrid_Bill(int idBill) {
			string url = string.Format(AppSettings.BillByIdTableUrl, idBill);
			billModel = await HttpClientBase<BillModel>.Get(url);
			if (billModel != null) {				
				url = string.Format(AppSettings.DetailBillByIdBillUrl, billModel.Id);
				var lstBillDetail = await HttpClientBase<BillDetailModel>.Gets(url);
				if (lstBillDetail.Count > 0) {
                    _sumMoney = 0;
                    lbl_Id_Bill_1.Text = string.Format("BÀN SỐ {0} HÓA ĐƠN {1}", idBill, billModel.Id);
                    BindingGrid_Bill(lstBillDetail);

                    string _str = string.Format("{0:0,0 vnđ}", _sumMoney);
                    txtSumMoney.Text = _str.Replace(",", ".");
                    txtHoaDon.Text = string.Format("{0:0,0}", _sumMoney).Replace(",", ".");
                }
			}

		}

        // cap nhat hoa don bill 1 da thanh toan. tong tien, paid = true
        private async void Update_Bill(BillModel _billModel)
        {
			var dl = await HttpClientBase<BillModel>.Put(AppSettings.UpdateQuanityBillUrl, _billModel, _UserInfoModel.Token);
            if(dl == 1)
            {
                lblMsg.Text = "Lưu hóa đơn thành công";
            }
            else
            {
                lblMsg.Text = "Lưu hóa đơn thất bại";
            }
        }

        // cap nhat ban da thanh toan status = 1
        private async void Update_Table(TableModel _tableModel)
        {
			var dl = await HttpClientBase<TableModel>.Put(AppSettings.UpdateStatusTableUrl, _tableModel, _UserInfoModel.Token);

			if (dl == 1)
            {
                lblMsg.Text = "Cập nhật bàn thành công";
            }
            else
            {
                lblMsg.Text = "Cập nhật bàn thất bại";
            }
        }

        // do du lieu vao grid detailbill
        private void BindingGrid_Bill(List<BillDetailModel> lst)
        {
            try
            {
                dtGrid_Bill.Rows.Clear();
                int pos = 1;
                float _tt = 0;
                int _sl = 0;
                float _dg = 0;
                foreach (BillDetailModel item in lst)
                {
                    DataGridViewRow row = (DataGridViewRow)dtGrid_Bill.RowTemplate.Clone();
                    _sl = Int32.Parse(item.Quanity.ToString());
                    _dg = float.Parse(item.Price.ToString()) * 1000;
                    _tt = _sl * _dg;

                    _sumMoney += _tt;
                    row.CreateCells(dtGrid_Bill,
                        pos,
                        item.BillId,
                        item.Id,                        
                        item.UserId,
                        item.UseName,
                        item.DishId,
                        item.DishName,
                        _sl,
                        string.Format("{0:0,0}", _dg),                        
                        string.Format("{0:0,0}", _tt)
                        );
                    dtGrid_Bill.Rows.Add(row);
                    pos++;
                }
            }
            catch (Exception)
            {
            }
        }

        // do du lieu vao grid ban
        private void BindingGrid_Table(List<TableModel> lst)
        {
            try
            {
                int pos = 1;
                foreach (TableModel item in lst)
                {
                    DataGridViewRow row = (DataGridViewRow)dtGrid_Table.RowTemplate.Clone();
                    row.CreateCells(dtGrid_Table,
                        pos,
                        item.Id,
                        item.Name,
                        item.Status,
                        item.Note);

                    dtGrid_Table.Rows.Add(row);

					if (item.Status == 1)
					{
						row.Cells[0].Style.BackColor = Color.Green;
						row.Cells[1].Style.BackColor = Color.Green;
					}
					else if (item.Status == 2)
					{
						row.Cells[0].Style.BackColor = Color.Yellow;
						row.Cells[1].Style.BackColor = Color.Yellow;
					}
					else if (item.Status == 3)
					{
						row.Cells[0].Style.BackColor = Color.Red;
						row.Cells[1].Style.BackColor = Color.Red;
					}

					pos++;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
		#endregion

		#region "event"
		public Frm_Sales()
        {
            InitializeComponent();
        }

        #region "chinhapso"
        private void txtKhuyenMai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;

            if (txtKhuyenMai.Text.ToString().Length > 1)
            {
                e.Handled = true;
            }
        }

        private void txtKhachTra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
            
        }
        
        private void txtSoLuongMon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;

            if (txtSoLuongMon.Text.ToString().Length > 5)
            {
                e.Handled = true;
            }
        }
		#endregion

		// load form
		private void Frm_Sales_Load(object sender, EventArgs e)
		{
			reset_Control();

			load_Grid_Table();

		}

		// click grid table chon ban thanh toan
		private void dtGrid_Table_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			posTable = dtGrid_Table.Rows[e.RowIndex].Index;

			// neu dang co khach thi cho thanh toan
			if (lstTableModel[posTable].Status == 2)
			{
				reset_Control();
				BindingGrid_Bill(lstTableModel[posTable].Id);
			}
			else
			{
				reset_Control(); // xoa neu cho dong k co khach co du lieu cu
			}

		}

		// chon grid detail bill de sua so luong
		private void dtGrid_Bill_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				posDetailBill = dtGrid_Table.Rows[e.RowIndex].Index;
				var detailBill = lstBillDetail[posDetailBill];
				txtTenMon.Text = detailBill.DishName;
				txtSoLuongMon.Text = "" + detailBill.Quanity;
			}
			catch (Exception)
			{
			}

		}
		
		// tinh nham
		private void btnTamTinh_Click(object sender, EventArgs e)
        {
            try
            {
                txtTraLai.Text = "";
                txtTienKM.Text = "";

                string _hdon = (txtHoaDon.Text.ToString().Trim()).Replace(".", "");            
                if(_hdon.Length <= 0) { return; }

                string _kmai = txtKhuyenMai.Text.ToString().Trim();
                string _ktra = (txtKhachTra.Text.ToString().Trim()).Replace(".", "");
                if (_kmai.Length == 0) { _kmai = "0"; }
                if (_ktra.Length == 0) { _ktra = "0"; }

                double _HDon = Double.Parse(_hdon);
                double _KMai = _HDon * (Double.Parse(_kmai) / 100);
                double _TCong = _HDon - _KMai;

                double _KTra = Double.Parse(_ktra);
                double _TLai = _KTra - _TCong;

                txtTienKM.Text = string.Format("{0:0,0}", _KMai).Replace(",", ".");
                txtTongCong.Text = string.Format("{0:0,0}", _TCong).Replace(",", ".");
                txtKhachTra.Text = string.Format("{0:0,0}", _KTra).Replace(",", ".");
                if (_TLai > 0)
                { txtTraLai.Text = string.Format("{0:0,0}", _TLai).Replace(",", "."); }

                lblMsg.Text = "Bạn đang tính nhẩm !";

            }
            catch (Exception)
            {
                throw;
            }
        }

        // luu hoa don
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            // tinh nham
            btnTamTinh_Click( sender,  e);
            lblMsg.Text = "";

            try
            {
                string _hdon = (txtHoaDon.Text.ToString().Trim()).Replace(".", "");
                if (_hdon.Length <= 0) { return; }

                // cap nhat bill_1 da thanh toan
                if(billModel != null)
                {
                    billModel.Paid = true;
                    billModel.Money = _sumMoney;
                    billModel.CashierId = _UserInfoModel.Id;
                    billModel.CashierName = _UserInfoModel.DisplayName;

                    Update_Bill(billModel);
                }                
                
                // dua ban ve trang thai doi don ban
                if(posTable != -1)
                {
                    lstTableModel[posTable].Status = 1;
                    Update_Table(lstTableModel[posTable]);
                }

                // print report

                //order_bill_2 _order_bill_2 = new order_bill_2();
                //list<modelrow> lstrowrpt = new list<modelrow>();
                //list<order_bill_2> lst = _order_bill_2.getbill_byid_bill_1_isstatus(_id_bill_1);
                //int i = 1;
                //double _dg = 0;

                //foreach (order_bill_2 r in lst)
                //{
                //    _dg = double.parse(r.dish_value.tostring()) * 1000;

                //    lstrowrpt.add(new modelrow()
                //    {
                //        stt = "" + i,
                //        tenmon = r.name_dish,
                //        sl = "" + r.quanity,
                //        gia = string.format("{0:0,0}", _dg).replace(",", "."),
                //        tt = string.format("{0:0,0}", r.quanity * _dg).replace(",", ".")
                //    });
                //    i += 1;
                //}

                //modelbill_1 modelbill_1 = new modelbill_1()
                //{
                //    hd = "" + _id_bill_1,
                //    ngay = datetime.now + "",
                //    ban = "" + _id_table,
                //    thungan = "hanh",
                //    rowdetail = lstrowrpt,
                //    tonghd = txthoadon.text,
                //    km = string.format("{0} %", txtkhuyenmai.text),
                //    thanhtoan = txttongcong.text
                //};

                //rptbill_1 rpt = new rptbill_1(modelbill_1);
                //rpt.showreport();

                // refresh form
                reset_Control();
				load_Grid_Table();
			}
            catch (Exception)
            {
            }
        }

        // load lai du lieu bang
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            load_Grid_Table();
        }

		#endregion

		

		private async void btnCapNhatMon_Click(object sender, EventArgs e)
		{
			try
			{
				// check input edit
				int sl = Int32.Parse(txtSoLuongMon.Text.ToString().Trim());


				// da click sua so luong
				if (posDetailBill != -1) {
					var detailBill = lstBillDetail[posDetailBill];
					int slOld = detailBill.Quanity;

					if (sl != slOld) {
						detailBill.Quanity = sl;

						var dl = await HttpClientBase<BillDetailModel>.Put(AppSettings.UpdateQuanityBillDetailUrl, detailBill, _UserInfoModel.Token);
						if (dl != 0)
						{
							lblMsg1.Text = "Cập nhật số lượng món thành công";
							//BindingGrid_Bill(lstBillDetail);
							BindingGrid_Bill(detailBill.BillId);
						}
						else {
							lblMsg1.Text = "Cập nhật số lượng món thất bại";
						}
					}
					
				}
			}
			catch (Exception)
			{

				throw;
			}
		}
	}
}
