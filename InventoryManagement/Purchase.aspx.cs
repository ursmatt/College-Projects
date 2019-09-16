using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.IO;

public partial class Store : System.Web.UI.Page

{
    SqlConnection sqlcon = new SqlConnection(@"Data Source =NALINI-LAPTOP;Initial Catalog=InventoryMangement;Integrated Security=true");
    int i = 0;
    SqlCommand cmd;
    SqlDataAdapter da;
    DataSet ds;
    protected void purchaseGrid1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        purchaseGrid1.PageIndex = e.NewPageIndex;
         //bindgridview will get the data source and bind it again
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        else if (!IsPostBack)
        {
            filldropdownlist();
          
            FillGridView();
            //generateautonumber();
        }


    }



    void FillGridView()
    {
        if (sqlcon.State == ConnectionState.Closed)
            sqlcon.Open();
        string pronamequery = "Select * from Purchase";
        SqlCommand scmd = new SqlCommand(pronamequery, sqlcon);
        SqlDataAdapter sda = new SqlDataAdapter(scmd);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        sqlcon.Close();
        purchaseGrid1.DataSource = dt;
        purchaseGrid1.DataBind();
    }
    private void generateautonumber()
    {
        if (sqlcon.State == ConnectionState.Closed)
            sqlcon.Open();

        SqlCommand cmd = new SqlCommand("proc_purchs", sqlcon);
        cmd.CommandType = CommandType.StoredProcedure;
        string value = cmd.ExecuteScalar().ToString();
        i++;
        int rv = Int32.Parse(value) + 1;
        DropDownDepartment.Text= rv.ToString();

    }
    
    protected void filldropdownlist()
    {
        if (sqlcon.State == ConnectionState.Closed)
            sqlcon.Open();
        //for product dropdown

        string productquery = "SELECT ProductId,ProductName FROM Product";
        cmd = new SqlCommand(productquery, sqlcon);
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds, "product");
        DropDownProduct.DataSource = ds.Tables["product"];
        DropDownProduct.DataTextField = "ProductName";
        DropDownProduct.DataValueField = "ProductId";
        DropDownProduct.DataBind();

        //for supplier dropdownlist

        string supplierquery = "SELECT SupplierId,CompanyName FROM Supplier";
        cmd = new SqlCommand(supplierquery, sqlcon);
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds, "supplier");
        DropDownSupplier.DataSource = ds.Tables["supplier"];
        DropDownSupplier.DataTextField = "CompanyName";
        DropDownSupplier.DataValueField = "SupplierId";
        DropDownSupplier.DataBind();

        //department

        string departmentquery = "SELECT DepartmentId,DepartmentName FROM Department";
        cmd = new SqlCommand(departmentquery, sqlcon);
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds, "department");
        DropDownSupplier.DataSource = ds.Tables["department"];
        DropDownSupplier.DataTextField = "DepartmentName";
        DropDownSupplier.DataValueField = "DepartmentId";
        DropDownSupplier.DataBind();
        sqlcon.Close();


    }



    protected void btnsave_Click(object sender, EventArgs e)
    {
        //Console.Write(DropDownProduct.SelectedValue);
        //Console.Write(DropDownProduct.SelectedItem.Text);
        //Console.WriteLine(DropDownSupplier.SelectedValue);
        //Console.WriteLine(DropDownSupplier.SelectedItem.Text);


        if (sqlcon.State == ConnectionState.Closed)
            sqlcon.Open();
        //SqlCommand sqlcmd = new SqlCommand("PurchaseCreateOrUpdate", sqlcon);
        //sqlcmd.CommandType = CommandType.StoredProcedure;
        //sqlcmd.Parameters.AddWithValue("@PurchaseId", hfPurchaseId.Value == "" ? 0 : Convert.ToInt32(hfPurchaseId.Value));
        //sqlcmd.Parameters.AddWithValue("@ProductId", Convert.ToInt32(DropDownProduct.SelectedValue));
        //sqlcmd.Parameters.AddWithValue("@SupplierId", Convert.ToInt32(DropDownSupplier.SelectedValue));
        //sqlcmd.Parameters.AddWithValue("@Quantity", Convert.ToInt32(txtQuantity.Text.Trim()));
        //sqlcmd.Parameters.AddWithValue("@DateOfPurchase", Convert.ToInt32(txtDate.Text.Trim()));
        //sqlcmd.Parameters.AddWithValue("@Others", txtOthers.Text);
        //sqlcmd.ExecuteNonQuery();
        //sqlcon.Close();
        //string PurchaseId = hfPurchaseId.Value;

        ///here productId is DepartmentId


        SqlCommand cmd = new SqlCommand("Insert into Purchase values(@PurchaseId,@ProductId,@SupplierId,@Quantity,@TotalAmount,@DateOfPurchase,@Others)", sqlcon);
        cmd.Parameters.AddWithValue("@PurchaseId", DropDownDepartment.SelectedValue);
        cmd.Parameters.AddWithValue("@ProductId", DropDownProduct.SelectedItem.Text);
        cmd.Parameters.AddWithValue("@SupplierId", DropDownSupplier.SelectedItem.Text);
        cmd.Parameters.AddWithValue("@Quantity", txtQuantity.Text.Trim());
        cmd.Parameters.AddWithValue("@TotalAmount", txtAmount.Text.Trim());
        cmd.Parameters.AddWithValue("@DateOfPurchase", txtDate.Text.Trim());
        cmd.Parameters.AddWithValue("@Others", txtOthers.Text.Trim());

        int i = cmd.ExecuteNonQuery();
        sqlcon.Close();
        string PurchaseId = hfPurchaseId.Value;

        if (i > 0)
        {
            lblsuccessmassage.Text = "Saved Successfully";
        }
        else
        {
            lblsuccessmassage.Text = "Updated Successfully";

            FillGridView();


            clear();
        DropDownProduct.ClearSelection();
        DropDownSupplier.ClearSelection();
        DropDownDepartment.ClearSelection();
      


    }
    //void FillGridView()
    //{
    //    if (sqlcon.State == ConnectionState.Closed)
    //        sqlcon.Open();
    //    string pronamequery = "Select Purchase.PurchaseID,Product.ProductName,Supplier.CompanyName,Purchase.Quantity,Purchase.Others from purchase INNER JOIN Product on Product.ProductId = Purchase.PurchaseId INNER JOIN Supplier on Supplier.SupplierId = Purchase.PurchaseId";
    //    SqlCommand scmd = new SqlCommand(pronamequery, sqlcon);
    //    SqlDataAdapter sda = new SqlDataAdapter(scmd);
    //    DataTable dt = new DataTable();
    //    sda.Fill(dt);
    //    sqlcon.Close();
    //    purchaseGrid.DataSource = dt;
    //    purchaseGrid.DataBind();

        //SqlDataAdapter sqlDa = new SqlDataAdapter("ViewPurchaseGrid", sqlcon);
        //sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
        //DataTable dtbl = new DataTable();
        //sqlDa.Fill(dtbl);
        //sqlcon.Close();
        //purchaseGrid.DataSource = dtbl;
        //purchaseGrid.DataBind();

    }

    protected void btndelete_Click(object sender, EventArgs e)
    {
        //if (sqlcon.State == ConnectionState.Closed)
        //    sqlcon.Open();
        //SqlCommand cmd = new SqlCommand("PurchaseDeleteById", sqlcon);
        //cmd.CommandType = CommandType.StoredProcedure;
        //cmd.Parameters.AddWithValue("@PurchaseId", Convert.ToInt32(hfPurchaseId.Value));
        //cmd.ExecuteNonQuery();
        //sqlcon.Close();
        //hfPurchaseId.Value = "";
        //txtQuantity.Text = txtOthers.Text = "";
        //DropDownProduct.ClearSelection();
        //DropDownSupplier.ClearSelection();
        //DropDownDepartment.ClearSelection();
        //////////
        //FillGridView();
        //lblsuccessmassage.Text = ("Delete Successfully!");
        if (sqlcon.State == ConnectionState.Closed)
            sqlcon.Open();
       SqlCommand cmd = new SqlCommand("Delete from Purchase where Id="+TextBox1.Text+"", sqlcon);
        cmd.ExecuteNonQuery();
        Response.Write("deleted sucessfully");


    }

    protected void btnclear_Click(object sender, EventArgs e)
    {
        this.clear();
    }
    public void clear()
    {
        hfPurchaseId.Value = "";
        txtQuantity.Text = txtOthers.Text =txtDate.Text=txtAmount.Text=TextBox1.Text= "";
        DropDownProduct.ClearSelection();
        DropDownSupplier.ClearSelection();
        DropDownDepartment.ClearSelection();
        
        lblerrormessage.Text = lblsuccessmassage.Text = "";
        btnsave.Text = "Save";
        btndelete.Enabled = true;

    }
    //protected void lnk_onClick(object sender, EventArgs e)
    //{
    //    int PurchaseId = Convert.ToInt32((sender as LinkButton).CommandArgument);
    //    if (sqlcon.State == ConnectionState.Closed)
    //        sqlcon.Open();
    //    SqlDataAdapter sqlDa = new SqlDataAdapter("PurchaseViewById", sqlcon);
    //    sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
    //    sqlDa.SelectCommand.Parameters.AddWithValue("@PurchaseId", PurchaseId);
    //    DataTable dtbl = new DataTable();
    //    sqlDa.Fill(dtbl);
    //    sqlcon.Close();
    //    hfPurchaseId.Value = PurchaseId.ToString();
    //    DropDownProduct.SelectedItem.Text = dtbl.Rows[0]["ProductName"].ToString();
    //    DropDownSupplier.SelectedItem.Text = dtbl.Rows[0]["CompanyName"].ToString();
    //    txtQuantity.Text = dtbl.Rows[0]["Quantity"].ToString();
    //    txtOthers.Text = dtbl.Rows[0]["Others"].ToString();
    //    btnsave.Text = "Update";
    //    btndelete.Enabled = true;


    //}


    protected void btnupload_Click(object sender, EventArgs e)
    {
        if(FileUpload1.HasFile)
    {
        try
        {
            if(FileUpload1.PostedFile.ContentType == "image/jpeg")
            {
                if(FileUpload1.PostedFile.ContentLength < 10240000)
                {
                    string filename = Path.GetFileName(FileUpload1.FileName);
                    FileUpload1.SaveAs(Server.MapPath("~/Files/") + filename);
                    Label3.Text = "Upload status: File uploaded!";
                        Image1.ImageUrl = "~/Files/" + Path.GetFileName(FileUpload1.FileName);
                    }
                else
                    Label3.Text = "Upload status: The file has to be less than 100 kb!";
            }
            else
                Label3.Text = "Upload status: Only JPEG files are accepted!";
        }
        catch(Exception ex)
        {
            Label3.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
        }
    }
        }
    public override void VerifyRenderingInServerForm(Control control)
    {
        //required to avoid the runtime error "  
        //Control 'GridView1' of type 'GridView' must be placed inside a form tag with runat=server."  
    }


    


    //protected void purchaseGrid_SelectedIndexChanged(object sender, GridViewPageEventArgs e)
    //{
    //    //int PurchaseId = Convert.ToInt32((sender as LinkButton).CommandArgument);
    //    //if (sqlcon.State == ConnectionState.Closed)
    //    //    sqlcon.Open();
    //    //SqlDataAdapter sqlDa = new SqlDataAdapter("PurchaseViewById", sqlcon);
    //    //sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
    //    //sqlDa.SelectCommand.Parameters.AddWithValue("@PurchaseId", PurchaseId);
    //    //DataTable dtbl = new DataTable();
    //    //sqlDa.Fill(dtbl);
    //    //sqlcon.Close();
    //    //hfPurchaseId.Value = PurchaseId.ToString();
    //    //DropDownProduct.SelectedItem.Text = dtbl.Rows[0]["ProductName"].ToString();
    //    //DropDownSupplier.SelectedItem.Text = dtbl.Rows[0]["CompanyName"].ToString();
    //    //txtQuantity.Text = dtbl.Rows[0]["Quantity"].ToString();
    //    //txtOthers.Text = dtbl.Rows[0]["Others"].ToString();
    //    //btnsave.Text = "Update";
    //    //btndelete.Enabled = true;
    //    GridViewRow rw = purchaseGrid1.SelectedRow;
    //    Label5.Visible = true;
    //    TextBox1.Visible = true;
    //    TextBox1.Text = rw.Cells[1].Text;
    //    DropDownProduct.Items.Clear();
    //    DropDownProduct.Items.Add(rw.Cells[3].Text);
    //    DropDownSupplier.Items.Clear();
    //    DropDownSupplier.Items.Add(rw.Cells[4].Text);
    //    txtQuantity.Text = rw.Cells[5].Text;
    //    txtDate.Text = rw.Cells[6].Text;
    //    txtOthers.Text = rw.Cells[7].Text;
    //    txtAmount.Text = rw.Cells[8].Text;

    //    purchaseGrid1.DataBind();
    //    btnsave.Text = "Update";
    //    btndelete.Enabled = true;
    //}

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.ClearContent();
        Response.ClearHeaders();
        Response.Charset = "";
        string FileName = "purchase" + DateTime.Now + ".xls";
        StringWriter strwritter = new StringWriter();
        HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
        purchaseGrid1.GridLines = GridLines.Both;
        purchaseGrid1.HeaderStyle.Font.Bold = true;
        purchaseGrid1.RenderControl(htmltextwrtter);
       
        Response.Write(strwritter.ToString());
        Response.End();
    }

    

    protected void purchaseGrid1_SelectedIndexChanged1(object sender, EventArgs e)
    {
        GridViewRow rw = purchaseGrid1.SelectedRow;
        Label5.Visible = true;
        TextBox1.Visible = true;
        TextBox1.Text = rw.Cells[1].Text;
        DropDownProduct.Items.Clear();
        DropDownProduct.Items.Add(rw.Cells[3].Text);
        DropDownSupplier.Items.Clear();
        DropDownSupplier.Items.Add(rw.Cells[4].Text);
        txtQuantity.Text = rw.Cells[5].Text;
        txtDate.Text = rw.Cells[7].Text;
        txtOthers.Text = rw.Cells[8].Text;
        txtAmount.Text = rw.Cells[6].Text;

        purchaseGrid1.DataBind();
        btnsave.Text = "Update";
        btndelete.Enabled = true;
    }
} 
     