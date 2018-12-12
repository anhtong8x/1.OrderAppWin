using DataBaseOrder.DAO;
using DataBaseOrder.EF;
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
    public partial class Frm_Pay_Detail : Form
    {
        public Frm_Pay_Detail()
        {
            InitializeComponent();
        }

        public order_employee Employee { get; set; }
        public int Id_Bill_1 { get; set; }
        public int Id_Table { get; set; }
        private double _sumMoney = 0;

        private void FillData(List<order_bill_2> lst)
        {
            dtGrid.Rows.Clear();

            #region "format_grid"
            int wdtg = dtGrid.Width;
            dtGrid.Columns[0].Width = (wdtg * 5) / 100;
            dtGrid.Columns[4].Width = (wdtg * 15) / 100;
            dtGrid.Columns[6].Width = (wdtg * 25) / 100;
            dtGrid.Columns[7].Width = (wdtg * 15) / 100;
            dtGrid.Columns[8].Width = (wdtg * 15) / 100;
            dtGrid.Columns[9].Width = wdtg - (
                dtGrid.Columns[0].Width +
                dtGrid.Columns[4].Width +
                dtGrid.Columns[6].Width +
                dtGrid.Columns[7].Width +
                dtGrid.Columns[8].Width +
                dtGrid.Columns[0].Width
                );

            #endregion

            #region "fill_data"
            int pos = 1;
            double _tt = 0;
            int _sl = 0;
            double _dg = 0;
            foreach (order_bill_2 item in lst)
            {
                DataGridViewRow row = (DataGridViewRow)dtGrid.RowTemplate.Clone();
                _sl = Int32.Parse(item.quanity.ToString());
                _dg = Double.Parse(item.dish_value.ToString()) * 1000;
                _tt = _sl * _dg;

                _sumMoney += _tt;
                row.CreateCells(dtGrid,
                    pos,
                    item.id,
                    item.id_bill_1,
                    item.id_waiter,
                    item.name_waiter,
                    item.id_dish,
                    item.name_dish,
                    string.Format("{0:0,0}",_dg),
                    _sl,
                    string.Format("{0:0,0}",_tt)
                    );
                dtGrid.Rows.Add(row);
                pos++;
            }
            #endregion

        }

        private void Frm_Pay_Detail_Load(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            lbl_Id_Bill_1.Text = string.Format("HÓA ĐƠN {0} BÀN SỐ {1}", Id_Bill_1, Id_Table);

            // grid
            Order_Bill_2 _Order_Bill_2 = new Order_Bill_2();
            FillData(_Order_Bill_2.GetBill_ById_Bill_1_IsStatus(Id_Bill_1));

            // sum
            string _str = string.Format("TỔNG TIỀN: {0:0,0 vnđ}", _sumMoney);
            lblSumMoney.Text = _str.Replace(",", ".");
            txtTongHD.Text = string.Format("{0:0,0}", _sumMoney).Replace(",",".");
            
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            try
            {
                // tt            
                double _km = 0;
                double _khachTra = Double.Parse(txtKhachTra.Text.Trim().ToString());
                double _traKhach = _khachTra - _sumMoney;
              
                //
                txtKhachTra.Text = string.Format("{0:0,0}", _khachTra).Replace(",", ".");
                txtTraKhach.Text = string.Format("{0:0,0}", _traKhach).Replace(",", ".");
            }
            catch (Exception)
            {

            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // cap nhat bang bill 1
            order_bill_1 _order_bill_1 = new order_bill_1() {
                id = Id_Bill_1,
                is_paid = true,
                total_money = Decimal.Parse(_sumMoney.ToString()),
                id_cashier = Employee.id,
                name_cashier = Employee.display_name
            };
            Order_Bill_1 _obj = new Order_Bill_1();
            if (_obj.Update(_order_bill_1)) {
                lblMsg.Text = "Lưu hóa đơn thành công";
            }
            // in hoa don

        }
    }
}
