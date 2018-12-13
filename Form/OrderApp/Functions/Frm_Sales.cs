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
        private TableModel tableModel;

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
            dtGrid_Bill.Rows.Clear();

            tableModel = null;
            billModel = null;
            _sumMoney = 0;
        }

        // tao du lieu do vao grid ban
        private async void load_Grid_Table()
        {
            dtGrid_Table.Rows.Clear();

			var dl = await DALContext.GetAllOrderTable();
			if (dl.Count > 0) {
				BindingGrid_Table(dl);
			}
					   
		}

        // tao du lieu de do vao grid detailbill
		private async void BindingGrid_Bill(int idTable) {			
			var dl = await DALContext.GetBillByIdTable(idTable); // lay ve idBill
			if (dl != null) {                
				var dl2 = await DALContext.GetsDetailBillByIdBill(dl.Id); // lay ve DetailBill theo idBill
				if (dl2.Count > 0) {
                    _sumMoney = 0;
                    lbl_Id_Bill_1.Text = string.Format("BÀN SỐ {0} HÓA ĐƠN {1}", idTable, dl.Id);
                    BindingGrid_Bill(dl2);

                    string _str = string.Format("{0:0,0 vnđ}", _sumMoney);
                    txtSumMoney.Text = _str.Replace(",", ".");
                    txtHoaDon.Text = string.Format("{0:0,0}", _sumMoney).Replace(",", ".");
                }

                // luu lai bill de cap nhat hoa don khi thanh toan
                billModel = dl;
            }

		}

        // cap nhat hoa don bill 1 da thanh toan. tong tien, paid = true
        private async void Update_Bill(BillModel _billModel)
        {
            var dl = await DALContext.UpdateBill(_UserInfoModel.Token, _billModel);
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
            var dl = await DALContext.UpdateTable(_UserInfoModel.Token, _tableModel);
            if (dl == 1)
            {
                lblMsg.Text = "Cập nhật bản thành công";
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
                if(tableModel != null)
                {
                    tableModel.Status = 1;
                    Update_Table(tableModel);
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
                load_Grid_Table();
                reset_Control();
            }
            catch (Exception)
            {
            }
        }

		// load form
        private void Frm_Sales_Load(object sender, EventArgs e)
        {            
            reset_Control();

            // grid_table
            load_Grid_Table();

        }      

		private void dtGrid_Table_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			int index = dtGrid_Table.Rows[e.RowIndex].Index;
			DataGridViewRow _dataRow = dtGrid_Table.Rows[index];
			int _IdBill = Int32.Parse(_dataRow.Cells[1].Value.ToString());
            int _StatusTable = Int32.Parse(_dataRow.Cells[3].Value.ToString());

            // neu dang co khach thi cho thanh toan
            if(_StatusTable == 2)
            {
                reset_Control();
                BindingGrid_Bill(_IdBill);

                // phuc vu cho update ban khi thanh toan
                tableModel = new TableModel() {
                    Id = 1,
                    Name = "" + _dataRow.Cells[3].Value.ToString(),
                    Note = "" + _dataRow.Cells[4].Value.ToString(),
                    Status = _StatusTable,
                };
            }
            else
            {
                dtGrid_Bill.Rows.Clear();
            }
            			
		}

        // load lai du lieu bang
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            load_Grid_Table();
        }

        #endregion
    }
}
