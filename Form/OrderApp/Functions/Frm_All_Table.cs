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
    public partial class Frm_All_Table : Form
    {
        public Frm_All_Table()
        {
            InitializeComponent();
        }

        public order_employee Employee { get; set; }
        List<order_table> _lstCombo;        

        // combo
        private void SetDataSourceComboTable(List<order_table> lst)
        {
            var item = new order_table() { id = -1, name_table = "Chọn bàn" };
            List<order_table> _data = new List<order_table>();
            _data.Add(item);
            foreach (order_table i in lst)
            {
                item = new order_table() { id = i.id, name_table = i.name_table };
                _data.Add(item);
            }
            comboBox1.DataSource = _data;
            comboBox1.DisplayMember = "name_table";
            comboBox1.ValueMember = "id";
        }

        // grid
        private void FillData(List<order_table> lst)
        {
            dtGrid.Rows.Clear();

            #region "format_grid"
            int wdtg = dtGrid.Width;
            dtGrid.Columns[0].Width = (wdtg * 10) / 100;
            dtGrid.Columns[2].Width = (wdtg * 40) / 100;
            dtGrid.Columns[4].Width = (wdtg * 20) / 100;
            dtGrid.Columns[5].Width = wdtg - (
                dtGrid.Columns[0].Width +
                dtGrid.Columns[2].Width +
                dtGrid.Columns[4].Width +
                dtGrid.Columns[5].Width
                );

            #endregion

            #region "fill_data"
            int pos = 1;
            foreach (order_table item in lst)
            {
                DataGridViewRow row = (DataGridViewRow)dtGrid.RowTemplate.Clone();
                row.CreateCells(dtGrid,
                    pos,
                    item.id,
                    item.name_table,
                    item.is_status,
                    item.status_name,
                    item.id_bill_1);
                dtGrid.Rows.Add(row);
                pos++;
            }
            #endregion

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            Frm_Pay_Detail frm = new Frm_Pay_Detail();
            frm.ShowDialog();
        }

        private void Frm_All_Table_Load(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            // combo
            Order_Table _Order_Table = new Order_Table();
            _lstCombo = _Order_Table.GetByIsStatus();
            if (_lstCombo.Count <= 0)
            {
                lblMsg.Text = "";
                return;
            }
            SetDataSourceComboTable(_lstCombo);

            // grid
            FillData(_Order_Table.GetByIsStatus());
        }

        private void dtGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
          
            int index = dtGrid.Rows[e.RowIndex].Index;
            DataGridViewRow _dataRow = dtGrid.Rows[index];
            int _id_bill_1 = Int32.Parse(_dataRow.Cells[5].Value.ToString());
            int _id_table = Int32.Parse(_dataRow.Cells[1].Value.ToString());

            Frm_Pay_Detail _frm = new Frm_Pay_Detail();
            _frm.Employee = Employee;
            _frm.Id_Bill_1 = _id_bill_1;
            _frm.Id_Table = _id_table;
            _frm.ShowDialog();
        }
    }
}
