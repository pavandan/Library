using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace practice
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        
        
        DataSet ds = null;
        SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\DB_Server1.mdf;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
           
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "insert into [MyTable] (Book_Title, Author,ISBN_Number, Category, Publishing_Date, Publisher, Page_Count, Price) values ('" + txtBookTitle.Text + "','" + txtAuthor.Text + "','" + txtNumber.Text + "','" + ddCategory.SelectedItem.Text + "','" + txtDate.Text + "','" + ddPublisher.SelectedItem.Text + "','" + txtPageCount.Text + "','" + txtPrice.Text + "')";
            cmd.ExecuteNonQuery();
            connection.Close();
            display_data();
            txtBookTitle.Text = "";
            txtAuthor.Text = "";
            txtNumber.Text = "";
            txtSearch.Text = "";
            ddCategory.SelectedIndex = 0;
            txtDate.Text = "";
            ddPublisher.SelectedIndex = 0;
            txtPageCount.Text = "";
            txtPrice.Text = "";
            
        }


        public void display_data()
        {
            
            
            connection.Open();
            SqlCommand sqlcom = new SqlCommand();
            String query = "SELECT * FROM MyTable order by Book_Title";
            sqlcom.CommandText = query;
            sqlcom.Connection = connection;
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(sqlcom);
            sda.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            connection.Close();
        }

        protected void btnDisplay_Click(object sender, EventArgs e)
        {

            display_data();

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "delete from [MyTable] where Book_Title = '"+txtBookTitle.Text+"'";
            cmd.ExecuteNonQuery();
            connection.Close();
            display_data();
            txtBookTitle.Text = "";
            txtAuthor.Text = "";
            txtNumber.Text = "";
            txtSearch.Text = "";
            ddCategory.SelectedIndex = 0; 
            txtDate.Text = "";
            ddPublisher.SelectedIndex = 0;
            txtPageCount.Text = "";
            txtPrice.Text = "";
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "update [MyTable] set Author = '" + txtAuthor.Text + "',ISBN_Number = '" + txtNumber.Text+ "',Category = '"+ddCategory.SelectedItem.Text+ "',Publishing_Date = '" + txtDate.Text + "',Publisher = '" + ddPublisher.SelectedItem.Text + "',Page_Count = '" + txtPageCount.Text + "',Price = '" + txtPrice.Text + "'Where Book_Title = '" +txtBookTitle.Text+  "'";
            cmd.ExecuteNonQuery();
            connection.Close();
            display_data();
            txtBookTitle.Text = "";
            txtAuthor.Text = "";
            txtNumber.Text = "";
            txtSearch.Text = "";
            ddCategory.SelectedIndex = 0;
            txtDate.Text = "";
            ddPublisher.SelectedIndex = 0;
            txtPageCount.Text = "";
            txtPrice.Text = "";

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select * from [MyTable] where Book_title = '" + txtSearch.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            using (SqlDataAdapter da = new SqlDataAdapter(cmd)) 
            {
                da.Fill(dt);
            }
                
            GridView1.DataSource = dt;
            GridView1.DataBind();
            connection.Close();
            
            txtBookTitle.Text = "";
            txtAuthor.Text = "";
            txtNumber.Text = "";
            txtSearch.Text = "";
            ddCategory.SelectedIndex = 0;
            txtDate.Text = "";
            ddPublisher.SelectedIndex = 0;
            txtPageCount.Text = "";
            txtPrice.Text = "";

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtBookTitle.Text = GridView1.SelectedRow.Cells[1].Text;
            txtAuthor.Text = GridView1.SelectedRow.Cells[2].Text;
            txtNumber.Text = GridView1.SelectedRow.Cells[3].Text;
            ddCategory.SelectedItem.Text = GridView1.SelectedRow.Cells[4].Text;
            txtDate.Text = GridView1.SelectedRow.Cells[5].Text;
            ddPublisher.SelectedItem.Text = GridView1.SelectedRow.Cells[6].Text;
            txtPageCount.Text = GridView1.SelectedRow.Cells[7].Text;
            txtPrice.Text = GridView1.SelectedRow.Cells[8].Text;
        }

       

        protected void ddCategoryView_SelectedIndexChanged(object sender, EventArgs e)
        {
           

        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select * from [MyTable] where Category = '" + ddCategoryView.SelectedItem.Value + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                da.Fill(dt);
            }

            GridView1.DataSource = dt;
            GridView1.DataBind();
            connection.Close();

            txtBookTitle.Text = "";
            txtAuthor.Text = "";
            txtNumber.Text = "";
            txtSearch.Text = "";
            ddCategory.SelectedIndex = 0;
            txtDate.Text = "";
            ddPublisher.SelectedIndex = 0;
            txtPageCount.Text = "";
            txtPrice.Text = "";


        }

        protected void txtDate_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnAuthor_Click(object sender, EventArgs e)
        {
            
        }

     
        protected void CustomValidator1_ServerValidate1(object source, ServerValidateEventArgs args)
        {
            {
                DateTime minDate = DateTime.Parse("0000/01/01");
                DateTime maxDate = DateTime.Now;
                DateTime dt;
                

                cvDate.IsValid = (DateTime.TryParse(txtDate.Text, out dt)
                                && dt <= maxDate.Date
                                && dt >= minDate.Date);
            }
        }

        protected void sortPrice_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            if(sortBy.SelectedItem.Value== "Price ↑") 
                cmd.CommandText = "select * from [MyTable] order by Price ASC;";
            else if (sortBy.SelectedItem.Value== "Price ↓")
                cmd.CommandText = "select * from [MyTable] order by Price DESC;";
            else
                cmd.CommandText = "select * from [MyTable] order by Book_Title ASC;";

            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                da.Fill(dt);
            }

            GridView1.DataSource = dt;
            GridView1.DataBind();
            connection.Close();

            txtBookTitle.Text = "";
            txtAuthor.Text = "";
            txtNumber.Text = "";
            txtSearch.Text = "";
            ddCategory.SelectedIndex = 0; 
            txtDate.Text = "";
            ddPublisher.SelectedIndex = 0;
            txtPageCount.Text = "";
            txtPrice.Text = "";

        }

        protected void btnHigher_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            
            cmd.CommandText = "select * from [MyTable] where Price >= '" + txtHigher.Text +"'";
            
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                da.Fill(dt);
            }

            GridView1.DataSource = dt;
            GridView1.DataBind();
            connection.Close();

            txtBookTitle.Text = "";
            txtAuthor.Text = "";
            txtNumber.Text = "";
            txtSearch.Text = "";
            ddCategory.SelectedIndex = 0;
            txtDate.Text = "";
            ddPublisher.SelectedIndex = 0;
            txtPageCount.Text = "";
            txtPrice.Text = "";
        }

        protected void ddCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddPublisher_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}