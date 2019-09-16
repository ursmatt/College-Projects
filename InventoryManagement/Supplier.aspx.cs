using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;

public partial class Supplier : System.Web.UI.Page
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
    void FillGridView()
    {
        if (sqlcon.State == ConnectionState.Closed)
            sqlcon.Open();
        string pronamequery = "Select * from supplier";
        SqlCommand scmd = new SqlCommand(pronamequery, sqlcon);
        SqlDataAdapter sda = new SqlDataAdapter(scmd);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        sqlcon.Close();
        supplierGrid.DataSource = dt;
        supplierGrid.DataBind();
        //if (sqlcon.State == ConnectionState.Closed)
        //    sqlcon.Open();
        //SqlDataAdapter sqlDa = new SqlDataAdapter("SupplierViewAll", sqlcon);
        //sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
        //DataTable dtbl = new DataTable();
        //sqlDa.Fill(dtbl);
        //sqlcon.Close();
        //supplierGrid.DataSource = dtbl;
        //supplierGrid.DataBind();

    }
   
    private void generateautonumber()
    {
        if (sqlcon.State == ConnectionState.Closed)
                    sqlcon.Open();

            SqlCommand cmd = new SqlCommand("proc_AutoId", sqlcon);
        cmd.CommandType = CommandType.StoredProcedure;
        string value = cmd.ExecuteScalar().ToString();
        i++;
        int rv = Int32.Parse(value) + 1;
        lblSupplierId.Text = rv.ToString();

    }
    protected void btnsave_Click(object sender, EventArgs e)
    {


        if (sqlcon.State == ConnectionState.Closed)
            sqlcon.Open();

        SqlCommand cmd = new SqlCommand("Insert into Supplier values(@SupplierId,@CompanyName,@TradeNo,@Gstno,@MobileNo,@Address)", sqlcon);
        cmd.Parameters.AddWithValue("@SupplierId", SqlDbType.Int).Value = lblSupplierId.Text;
        cmd.Parameters.AddWithValue("@CompanyName", txtComName.Text.Trim());
        cmd.Parameters.AddWithValue("@TradeNo", txtTradeLiNo.Text.Trim());
        cmd.Parameters.AddWithValue("@Gstno", txtgst.Text.Trim());
        cmd.Parameters.AddWithValue("@MobileNo", txtMobileNo.Text.Trim());
        cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
       
     
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


//protected void btnsave_Click(object sender, EventArgs e)
//{
//    if (sqlcon.State == ConnectionState.Closed)
//        sqlcon.Open();
//    SqlCommand sqlcmd = new SqlCommand("SupplierCreateOrUpdate", sqlcon);
//    sqlcmd.CommandType = CommandType.StoredProcedure;
//    sqlcmd.Parameters.AddWithValue("@SupplierId", hfSupplierId.Value == "" ? 0 : Convert.ToInt32(hfSupplierId.Value));
//    sqlcmd.Parameters.AddWithValue("@CompanyName", txtComName.Text.Trim());
//    sqlcmd.Parameters.AddWithValue("@TradeNo", txtTradeLiNo.Text.Trim());
//    sqlcmd.Parameters.AddWithValue("@MobileNo", txtMobileNo.Text.Trim());
//    sqlcmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
//    sqlcmd.ExecuteNonQuery();
//    sqlcon.Close();
//    string SupplierId = hfSupplierId.Value;
//    clear();

//    if (SupplierId == "")
//        lblsuccessmassage.Text = "Saved Successfully";
//    else
//        lblsuccessmassage.Text = "Updated Successfully";
//    FillGridView();
//}

//protected void btnsave_Click(object sender, EventArgs e)
//{
//    if (sqlcon.State == ConnectionState.Closed)
//      sqlcon.Open();
//    SqlCommand cmd = new SqlCommand("Insert into Supplier values(@SupplierId,@CompanyName,@TradeNo,@MobileNo,@Address)", sqlcon);
//    cmd.Parameters.AddWithValue("@SupplierId", hfSupplierId.Value == "" ? 0 : Convert.ToInt32(hfSupplierId.Value));
//    cmd.Parameters.AddWithValue("@CompanyName", txtComName.Text.Trim());
//    cmd.Parameters.AddWithValue("@TradeNo", txtTradeLiNo.Text.Trim());
//    cmd.Parameters.AddWithValue("@MobileNo", txtMobileNo.Text.Trim());
//    cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
//    cmd.ExecuteNonQuery();
//    sqlcon.Close();
//    string SupplierId = hfSupplierId.Value;
//    clear();

//    if (SupplierId == "")
//        lblsuccessmassage.Text = "Saved Successfully";
//    else
//        lblsuccessmassage.Text = "Updated Successfully";
//    FillGridView();

//}

protected void lnk_onClick(object sender, EventArgs e)
    {
        
        int SupplierId = Convert.ToInt16((sender as LinkButton).CommandArgument);
        if (sqlcon.State == ConnectionState.Closed)
            sqlcon.Open();
        SqlDataAdapter sqlDa = new SqlDataAdapter("SupplierViewById", sqlcon);
        sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
        sqlDa.SelectCommand.Parameters.AddWithValue("@SupplierId", SupplierId);
        DataTable dtbl = new DataTable();
        sqlDa.Fill(dtbl);
        sqlcon.Close();
        hfSupplierId.Value = SupplierId.ToString();
        //lblSupplierId.Text = dtbl.Rows[0]["DepartmentId"].ToString();
        txtComName.Text = dtbl.Rows[0]["CompanyName"].ToString();
        lblSupplierId.Items.Clear();
        lblSupplierId.Items.Add(dtbl.Rows[0]["SupplierId"].ToString());
        txtTradeLiNo.Text = dtbl.Rows[0]["TradeNo"].ToString();
        txtgst.Text = dtbl.Rows[0]["Gstno"].ToString();
        txtMobileNo.Text = dtbl.Rows[0]["MobileNo"].ToString();
        txtAddress.Text = dtbl.Rows[0]["Address"].ToString();
        btnsave.Text = "Update";
        btndelete.Enabled = true;


    }

    protected void btnclear_Click(object sender, EventArgs e)
    {
        this.clear();
    }
    public void clear()
    {
        hfSupplierId.Value = "";
        txtComName.Text = txtAddress.Text=txtMobileNo.Text =txtTradeLiNo.Text= txtgst.Text="";
        lblSupplierId.SelectedItem.Text = "";
        lblerrormessage.Text = lblsuccessmassage.Text = "";
        btnsave.Text = "Save";
        btndelete.Enabled = true;

    }


    protected void btndelete_Click(object sender, EventArgs e)
    {
        if (sqlcon.State == ConnectionState.Closed)
            sqlcon.Open();
        SqlCommand sqlcmd = new SqlCommand("SupplierDeleteById", sqlcon);
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.Parameters.AddWithValue("@SupplierId", Convert.ToInt32(hfSupplierId.Value));
        sqlcmd.ExecuteNonQuery();
        sqlcon.Close();
        clear();
        FillGridView();
        lblsuccessmassage.Text = "Deleted Successfully";
    }

    protected void txtAddress_TextChanged(object sender, EventArgs e)
    {

    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        //required to avoid the runtime error "  
        //Control 'GridView1' of type 'GridView' must be placed inside a form tag with runat=server."  
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.ClearContent();
        Response.ClearHeaders();
        Response.Charset = "";
        string FileName = "supplier" + DateTime.Now + ".xls";
        StringWriter strwritter = new StringWriter();
        HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
        supplierGrid.GridLines = GridLines.Both;
        supplierGrid.HeaderStyle.Font.Bold = true;
        supplierGrid.RenderControl(htmltextwrtter);

        Response.Write(strwritter.ToString());
        Response.End();
    }
}