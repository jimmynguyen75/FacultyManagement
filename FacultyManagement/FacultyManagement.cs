using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Group6_SE1322
{
    public partial class FacultyManagement : Form
    {
        DataControl cd = new DataControl();
        public FacultyManagement()
        {
            InitializeComponent();
        }


        public void LoadData()
        {
            string sql = "Select * from Data";
            dataGridView.DataSource = cd.createTable(sql);    
            txtTotal.Text = (dataGridView.Rows.Count - 1).ToString();
        }

        private void ID_Click(object sender, EventArgs e)
        {

        }

        private void FacultyManagement_Load(object sender, EventArgs e)
        {
            cd.connection();
            LoadData();
            btnCancel.Enabled = false;
            btnSave.Enabled = false;
          /*  DataGridViewRow row = this.dataGridView.Rows[0];
            txtIDD.Text = row.Cells[0].Value.ToString();
            txtName.Text = row.Cells[1].Value.ToString();*/
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            txtIDD.ResetText();
            txtName.ResetText();
            txtIDD.Enabled = true;
            txtIDD.Focus();
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            btnEdit.Enabled = true;
            btnAdd.Enabled = true;
            btnDelete.Enabled = true;
            LoadData();
        }
        int flag;
        private void btnAdd_Click(object sender, EventArgs e)
        {
            flag = 0;
            txtIDD.ResetText();
            txtName.ResetText();
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            btnEdit.Enabled = false;
            btnAdd.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            flag = 1;
            txtIDD.Enabled = false;
            btnDelete.Enabled = false;
            btnAdd.Enabled = false;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            btnEdit.Enabled = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string sql = "select * from Data where id='" + txtIDD.Text + "'";
            DataTable dt = new DataTable();
            dt = cd.createTable(sql);
            if (dt.Rows.Count != 0)
            {
                cd.delete(txtIDD.Text, txtName.Text);
                txtIDD.ResetText();
                txtName.ResetText();
            }
            else
            {
                MessageBox.Show("Nothing to delete!");
            }
            LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (flag == 0)
            {
                string sql = "select * from Data where id='" + txtIDD.Text + "'";
                DataTable dt = new DataTable();
                dt = cd.createTable(sql);
                if (txtIDD.Text == "" || txtName.Text == "")
                    MessageBox.Show("Please input data");
                else if (dt.Rows.Count != 0)
                {
                    MessageBox.Show("Data is exist!");
                }
                else
                {
                    cd.add(txtIDD.Text, txtName.Text);
                }
                txtIDD.ResetText();
                txtName.ResetText();
                btnSave.Enabled = false;
                btnCancel.Enabled = false;
                btnEdit.Enabled = true;
                btnAdd.Enabled = true;
                btnDelete.Enabled = true;
                LoadData();

            }
            else if (flag == 1)
            {
                string sql = "select * from Data where id='" + txtIDD.Text + "'";
                DataTable dt = new DataTable();
                dt = cd.createTable(sql);
                cd.edit(txtIDD.Text, txtName.Text);
                txtIDD.ResetText();
                txtName.ResetText();
                txtIDD.Enabled = true;
                btnSave.Enabled = false;
                btnCancel.Enabled = false;
                btnEdit.Enabled = true;
                btnAdd.Enabled = true;
                btnDelete.Enabled = true;
                LoadData();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to exit?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
            cd.closeConnection();
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
         
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView.Rows[e.RowIndex];
                txtIDD.Text = row.Cells[0].Value.ToString();
                txtName.Text = row.Cells[1].Value.ToString();
                
            }
        }
    }
}
