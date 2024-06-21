using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace electronic_scale
{
    public partial class FormProduct : Form
    {
        SqlConnection connection;
        SqlCommand command;
        string str = "Data Source=DESKTOP-O6OP19G\\WINCCPLUSMIG2014;Initial Catalog=saleManager;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        void loadData()
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from product";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }
        public FormProduct()
        {
            InitializeComponent();
        }



        private void FormProduct_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            loadData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                command = connection.CreateCommand();
                command.CommandText = "insert into product values('"
                    + tbBarCode.Text + "', '"
                    + tbName.Text + "', '"
                    + tbUnit.Text + "', '"
                    + tbPrice.Text + "') ";
                command.ExecuteNonQuery();
                loadData();
            }
            catch 
            {
                MessageBox.Show("Can't add this Product");
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult question = MessageBox.Show("Are you sure want to delete this product?", "Delete Product", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            // Ctrl + K + D
            if (question == DialogResult.Yes)
            {
                command = connection.CreateCommand();
                command.CommandText = "delete from product where BarCode='" + tbBarCode.Text + "'";
                command.ExecuteNonQuery();
                loadData();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                command = connection.CreateCommand();
                command.CommandText = "update product set Name = '"
                    + tbName.Text + "', Unit = '"
                    + tbUnit.Text + "', Price = '"
                    + tbPrice.Text + "' where BarCode = '"
                    + tbBarCode.Text + "'";
                command.ExecuteNonQuery();
                loadData();
            }
            catch
            {
                MessageBox.Show("Can't update this Product");
            }

        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM product WHERE Name LIKE '%' + @Name + '%'";
            command.Parameters.AddWithValue("@Name", tbName.Text);
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataGridView1.CurrentRow.Index;
            tbBarCode.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            tbName.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            tbUnit.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            tbPrice.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
        }


    }
}
