using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Product : System.Web.UI.Page
{
    SqlConnection sqlcon = new SqlConnection(@"Data Source =NALINI-LAPTOP;Initial Catalog=InventoryMangement;Integrated Security=true");
    int i = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        else if (!IsPostBack)
        {
            btndelete.Enabled = false;
            FillGridView();
        }
    }

    protected void btnclear_Click(object sender, EventArgs e)
    {
        this.clear();
    }
   
    public void clear()
    {
        hfProductId.Value = "";
       txtproname.Text = txtprodes.Text = "";
        TextBox1.SelectedItem.Text = "";
        lblerrormessage.Text = lblsuccessmassage.Text = "";
        btnsave.Text = "Save";
        btndelete.Enabled = true;
        
    }

    //protected void btnsave_Click(object sender, EventArgs e)
    //{

    //    if (sqlcon.State == ConnectionState.Closed)
    //    sqlcon.Open();
    //    SqlCommand sqlcmd = new SqlCommand("ProductCreateOrUpdate",sqlcon);
    //    sqlcmd.CommandType = CommandType.StoredProcedure;
    //    sqlcmd.Parameters.AddWithValue("@ProductId",hfProductId.Value==""? 0 : Convert.ToInt32(hfProductId.Value));
    //    sqlcmd.Parameters.AddWithValue("@ProductName",txtproname.Text.Trim());
    //    sqlcmd.Parameters.AddWithValue("@ProductDescription",txtprodes.Text.Trim());
    //    sqlcmd.ExecuteNonQuery();
    //    sqlcon.Close();
    //    string ProductId = hfProductId.Value;
    //    clear();

    //    if (ProductId == "")
    //        lblsuccessmassage.Text = "Saved Successfully";
    //    else
    //        lblsuccessmassage.Text = "Updated Successfully";
    //    FillGridView();
    //}
    //protected void btnsave_Click(object sender, EventArgs e)
    //{
    //    if (sqlcon.State == ConnectionState.Closed)
    //    sqlcon.Open();
    //    SqlCommand cmd = new SqlCommand("Insert into Product values(@ProductId,@ProductName,@ProductDescription)", sqlcon);
    //    cmd.Parameters.AddWithValue("@ProductId", hfProductId.Value == "" ? 0 : Convert.ToInt32(hfProductId.Value));
    //    cmd.Parameters.AddWithValue("@ProductName", txtproname.Text.Trim());
    //    cmd.Parameters.AddWithValue("@ProductDescription", txtprodes.Text.Trim());
    //    cmd.ExecuteNonQuery();
    //    sqlcon.Close();
    //    string ProductId = hfProductId.Value;
    //    clear();
    //    if (ProductId == "")
    //        lblsuccessmassage.Text = "Saved Successfully";
    //    else
    //        lblsuccessmassage.Text = "Updated Successfully";
    //    FillGridView();

    //}

    void FillGridView()
    {
        if (sqlcon.State == ConnectionState.Closed)
            sqlcon.Open();
        string pronamequery = "Select * from Product";
        SqlCommand scmd = new SqlCommand(pronamequery, sqlcon);
        SqlDataAdapter sda = new SqlDataAdapter(scmd);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        sqlcon.Close();
        productGrid.DataSource = dt;
        productGrid.DataBind();
    }
    private void generateautonumber()
    {
        if (sqlcon.State == ConnectionState.Closed)
            sqlcon.Open();

        SqlCommand cmd = new SqlCommand("proc_prod", sqlcon);
        cmd.CommandType = CommandType.StoredProcedure;
        string value = cmd.ExecuteScalar().ToString();
        i++;
        int rv = Int32.Parse(value) + 1;
        TextBox1.Text = rv.ToString();

    }

    protected void lnk_onClick(object sender, EventArgs e)
    {
        GridViewRow rw = productGrid.SelectedRow;

       
        int ProductId = Convert.ToInt32((sender as LinkButton).CommandArgument);
        if (sqlcon.State == ConnectionState.Closed)
            sqlcon.Open();
        SqlDataAdapter sqlDa = new SqlDataAdapter("ProductViewById", sqlcon);
        sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
        sqlDa.SelectCommand.Parameters.AddWithValue("@ProductId", ProductId);
        DataTable dtbl = new DataTable();
        sqlDa.Fill(dtbl);
        sqlcon.Close();
        hfProductId.Value = ProductId.ToString();
        txtproname.Text = dtbl.Rows[0]["ProductName"].ToString();
        TextBox1.Items.Clear();
        TextBox1.Items.Add(dtbl.Rows[0]["ProductId"].ToString());
        txtprodes.Text = dtbl.Rows[0]["ProductDescription"].ToString();
        btnsave.Text = "Update";
        btndelete.Enabled = true;


    }

    protected void btndelete_Click(object sender, EventArgs e)
    {
        using (SqlCommand sqlcmd = new SqlCommand("DELETE FROM table WHERE ProductId=@ProductId", sqlcon))
        {
            sqlcmd.Parameters.AddWithValue("@ProductId", TextBox1.SelectedItem.Text);
            sqlcmd.ExecuteNonQuery();

            //if (sqlcon.State == ConnectionState.Closed)
            //    sqlcon.Open();
            //SqlCommand sqlcmd = new SqlCommand("ProductDeleteById",sqlcon);
            //sqlcmd.CommandType = CommandType.StoredProcedure;
            //sqlcmd.Parameters.AddWithValue("@ProductId",Convert.ToInt32(hfProductId.Value));
            sqlcmd.ExecuteNonQuery();
            sqlcon.Close();
            clear();
            FillGridView();
            lblsuccessmassage.Text = "Deleted Successfully";
        }
    }

    protected void btnsave_Click(object sender, EventArgs e)
    {
        if (sqlcon.State == ConnectionState.Closed)
            sqlcon.Open();

        SqlCommand cmd = new SqlCommand("Insert into Product values(@ProductId,@ProductName,@ProductDescription)", sqlcon);
        cmd.Parameters.AddWithValue("@ProductId", SqlDbType.Int).Value = TextBox1.Text;
        cmd.Parameters.AddWithValue("@ProductName", txtproname.Text.Trim());
        cmd.Parameters.AddWithValue("@ProductDescription", txtprodes.Text.Trim());
        //cmd.Parameters.AddWithValue("@MobileNo", txtMobileNo.Text.Trim());
        //cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());


        int i = cmd.ExecuteNonQuery();
        sqlcon.Close();
        if (i > 0)
        {
            lblsuccessmassage.Text = "Saved Successfully";
        }
        else
        {
            lblsuccessmassage.Text = "Updated Successfully";

            FillGridView();

        }
    }
   
}