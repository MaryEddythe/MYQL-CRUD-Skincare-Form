using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Bookstore
{
    public partial class Form1 : Form
    {
        public static Form1 instance;
        MySqlConnection conn;
        int i = 0;
        MySqlDataReader dr;

        public Form1()
        {
            InitializeComponent();
            instance = this;
            string connStr = "server=127.0.0.1; user=root; database=supermarket; password=";
            conn = new MySqlConnection(connStr);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataGridViewCheckBoxColumn colStatus = new DataGridViewCheckBoxColumn();
            LoadData();
        }

        private void Clear()
        {
            txt_id.Text = "";
            txt_item.Text = "";
            txt_price.Text = "";
            txt_categ.Text = "";
            dateTimePicker1.Value = DateTime.Now;
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_id.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txt_item.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txt_price.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txt_categ.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();

            txt_id.ReadOnly = true;
            btn_save.Enabled = false;
        }

        private void LoadData()
        {
            dataGridView1.Rows.Clear();
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM supermarket", conn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    dataGridView1.Rows.Add(dr["ProdNo"], dr["Item"], dr["Price"], dr["Category"], dr["Expiration"]);
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO `supermarket`(`ProdNo`, `Item`, `Price`, `Category`, `Expiration`) VALUES (@ProdNo, @Item, @Price, @Category, @Expiration)", conn);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ProdNo", txt_id.Text);
                cmd.Parameters.AddWithValue("@Item", txt_item.Text);
                cmd.Parameters.AddWithValue("@Price", decimal.Parse(txt_price.Text));
                cmd.Parameters.AddWithValue("@Category", txt_categ.Text);
                cmd.Parameters.AddWithValue("@Expiration", dateTimePicker1.Value);

                i = cmd.ExecuteNonQuery();

                if (i > 0)
                {
                    MessageBox.Show("Record Save Success", "supermarket", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed to save the record", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }

            Clear(); 
            LoadData(); 
        }
       // private string connectionString = "server=127.0.0.1; user=root; database=supermarket; password=";
        private void update()
        {
            try
            {
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("UPDATE `supermarket` SET `Item`=@Item,`Price`=@Price,`Category`=@Category,`Expiration`=@Expiration WHERE `ProdNo`=@ProdNo", conn);
                    cmd.Parameters.AddWithValue("@ProdNo", txt_id.Text);
                    cmd.Parameters.AddWithValue("@Item", txt_item.Text);
                    cmd.Parameters.AddWithValue("@Price", decimal.Parse(txt_price.Text));
                    cmd.Parameters.AddWithValue("@Category", txt_categ.Text);
                    cmd.Parameters.AddWithValue("@Expiration", dateTimePicker1.Value);

                    i = cmd.ExecuteNonQuery();

                    if (i > 0)
                    {
                        MessageBox.Show("Record Update Success", "supermarket", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Failed", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                
                Clear();
                LoadData();
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            update();
        }


        private void Delete()
        {
            if (MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM supermarket WHERE ProdNo = @ProdNo", conn);
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@ProdNo", txt_id.Text);
                    i = cmd.ExecuteNonQuery();

                    if (i > 0)
                    {
                        MessageBox.Show("Record Delete Success", "supermarket", MessageBoxButtons.OK, MessageBoxIcon.Information);


                        int rowIndex = dataGridView1.CurrentCell.RowIndex;
                        if (rowIndex >= 0)
                        {
                            dataGridView1.Rows.RemoveAt(rowIndex);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Failed", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
                Clear();
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM supermarket WHERE ProdNo LIKE @searchTerm OR Item LIKE @searchTerm", conn);
                cmd.Parameters.AddWithValue("@searchTerm", "%" + txt_search.Text + "%");
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    dataGridView1.Rows.Add(dr["ProdNo"], dr["Item"], dr["Price"], dr["Category"], dr["Expiration"]);
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        private void ClearFields()
        {
            txt_id.Text = string.Empty;
            txt_item.Text = string.Empty;
            txt_price.Text = string.Empty;
            txt_categ.Text = string.Empty;
            dateTimePicker1.Value = DateTime.Now;
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

    }
}


