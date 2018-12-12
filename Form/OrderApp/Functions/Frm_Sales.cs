using DataBaseOrder.DAO;
using DataBaseOrder.EF;
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
        public order_employee Employee { get; set; }
        private double _sumMoney = 0;
        private int _Id_Bill_1 = 0;
        private int _Id_Table = 0;

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
            dtGrid_Bill.Rows.Clear();

            _Id_Table = 0;
            _Id_Bill_1 = 0;
            _sumMoney = 0;
        }

        private async void load_Grid_Table()
        {
            dtGrid_Table.Rows.Clear();
			//Order_Table _Order_Table = new Order_Table();
			//List<order_table> _lstTable = _Order_Table.GetByIsStatus();
			//if (_lstTable.Count > 0)
			//{
			//    BindingGrid_Table(_lstTable);
			//}

			var dl = await DALContext.GetAllOrderTable();
			if (dl.Count > 0) {
				BindingGrid_Table(dl);
			}
					   
		}

		private void BindingGrid_Bill(List<order_bill_2> lst)
        {
            try
            {
                dtGrid_Bill.Rows.Clear();
                int pos = 1;
                double _tt = 0;
                int _sl = 0;
                double _dg = 0;
                foreach (order_bill_2 item in lst)
                {
                    DataGridViewRow row = (DataGridViewRow)dtGrid_Bill.RowTemplate.Clone();
                    _sl = Int32.Parse(item.quanity.ToString());
                    _dg = Double.Parse(item.dish_value.ToString()) * 1000;
                    _tt = _sl * _dg;

                    _sumMoney += _tt;
                    row.CreateCells(dtGrid_Bill,
                        pos,
                        item.id,
                        item.id_bill_1,
                        item.id_waiter,
                        item.name_waiter,
                        item.id_dish,
                        item.name_dish,
                        string.Format("{0:0,0}", _dg),
                        _sl,
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

            if (txtKhachTra.Text.ToString().Length > 12)
            {
                e.Handled = true;
            }            
        }

        private void btnTamTinh_Click(object sender, EventArgs e)
        {
            try
            {
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

                txtTongCong.Text = string.Format("{0:0,0}", _TCong).Replace(",", ".");
                txtKhachTra.Text = string.Format("{0:0,0}", _KTra).Replace(",", ".");
                txtTraLai.Text = string.Format("{0:0,0}", _TLai).Replace(",", ".");

                lblMsg.Text = "Bạn đang tính nhẩm !";

            }
            catch (Exception)
            {
                throw;
            }
        }

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
                order_bill_1 _order_bill_1 = new order_bill_1()
                {
                    id = _Id_Bill_1,
                    is_paid = true,
                    total_money = Decimal.Parse(_sumMoney.ToString()),
                    id_cashier = Employee.id,
                    name_cashier = Employee.display_name,
                    create_date = DateTime.Now,
                };

                Order_Bill_1 _obj = new Order_Bill_1();
                if (_obj.Update(_order_bill_1))
                {
                    lblMsg.Text = "Bạn đã thanh toán xong !";
                }

                // dua ban ve trang thai doi don ban
                Order_Table _Order_table = new Order_Table();
                var _order_table = new order_table() { id_bill_1 = 0, is_status = 5, id = _Id_Table };
                _Order_table.Update_Id_Bill_1(_order_table);

                // print report
               
                Order_Bill_2 _Order_Bill_2 = new Order_Bill_2();
                List<ModelRow> lstRowRpt = new List<ModelRow>();
                List<order_bill_2> lst = _Order_Bill_2.GetBill_ById_Bill_1_IsStatus(_Id_Bill_1);
                int i = 1;
                double _dg = 0;
                
                foreach(order_bill_2 r in lst)
                {
                    _dg = Double.Parse(r.dish_value.ToString()) * 1000;                    

                    lstRowRpt.Add(new ModelRow() {
                        STT = "" + i,
                        TENMON = r.name_dish,
                        SL = "" + r.quanity,
                        GIA = string.Format("{0:0,0}", _dg).Replace(",", "."),
                        TT = string.Format("{0:0,0}", r.quanity * _dg).Replace(",", ".")
                    });
                    i += 1;
                }

                ModelBill_1 modelBill_1 = new ModelBill_1() {
                    HD = "" + _Id_Bill_1,
                    NGAY = DateTime.Now + "",
                    BAN = "" + _Id_Table,
                    THUNGAN = "Hanh",
                    ROWDETAIL = lstRowRpt,
                    TONGHD = txtHoaDon.Text,
                    KM = string.Format("{0} %", txtKhuyenMai.Text),
                    THANHTOAN = txtTongCong.Text
                };

                RptBill_1 rpt = new RptBill_1(modelBill_1);
                rpt.showReport();

                // refresh form
                load_Grid_Table();
                reset_Control();
            }
            catch (Exception)
            {
            }
        }

        private void Frm_Sales_Load(object sender, EventArgs e)
        {            
            // 
            //reset_Control();

            // grid_table
            load_Grid_Table();

        }

        private void dtGrid_Table_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // reset defaul
                reset_Control();

                // get id_bill_1
                int index = dtGrid_Table.Rows[e.RowIndex].Index;
                DataGridViewRow _dataRow = dtGrid_Table.Rows[index];
                _Id_Bill_1 = Int32.Parse(_dataRow.Cells[5].Value.ToString());
                _Id_Table = Int32.Parse(_dataRow.Cells[1].Value.ToString());

                string _name_table = _dataRow.Cells[2].Value.ToString();
                lbl_Id_Bill_1.Text = string.Format("{0} HÓA ĐƠN {1}", _name_table.ToUpper(), _Id_Bill_1);

                Order_Bill_2 _Order_Bill_2 = new Order_Bill_2();
                BindingGrid_Bill(_Order_Bill_2.GetBill_ById_Bill_1_IsStatus(_Id_Bill_1));

                string _str = string.Format("{0:0,0 vnđ}", _sumMoney);
                txtSumMoney.Text = _str.Replace(",", ".");
                txtHoaDon.Text = string.Format("{0:0,0}", _sumMoney).Replace(",", ".");
            }
            catch (Exception)
            {
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
			load_Grid_Table();
			//Frm_Sales_Load(sender, e);
        }

		#endregion
	}
}
