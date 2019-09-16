using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    SqlConnection sqlcon = new SqlConnection(@"Data Source =NALINI-LAPTOP;Initial Catalog=InventoryMangement;Integrated Security=true");
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillgrid();
        }
    }
    void fillgrid()
    {
        sqlcon.Open();
        string pronamequery = "Select * from Qutation where isapproved='0'";
        SqlCommand scmd = new SqlCommand(pronamequery, sqlcon);
        SqlDataAdapter sda = new SqlDataAdapter(scmd);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        sqlcon.Close();
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

 

   

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        
            fillgrid();


            GridViewRow rw = GridView1.SelectedRow;
            String qid = rw.Cells[1].Text;
            SqlCommand com = new SqlCommand("update qutation set isapproved='1' where qutationid='" + qid + "' ", sqlcon);
            sqlcon.Open();
            com.ExecuteNonQuery();
            sqlcon.Close();
        
    }
}