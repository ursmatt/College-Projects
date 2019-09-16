using System;
using System.Data;
using System.Data.SqlClient;

public partial class Login : System.Web.UI.Page
{
    static SqlConnection sqlcon = new SqlConnection(@"Data Source =NALINI-LAPTOP;Initial Catalog=InventoryMangement;Integrated Security=true");

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //protected void btnLogin_Click(object sender, EventArgs e)
    //{
    //    sqlcon.Open();
    //    string checkquery = "Select count(1) from Login where Username='" + txtUserName.Text + "' and Password='" + txtPassword.Text.Trim() + "'";
    //    SqlCommand cmd = new SqlCommand(checkquery, sqlcon);
    //    int count = Convert.ToInt32(cmd.ExecuteScalar());
    //    sqlcon.Close();
    //    if (count == 1)
    //    {
    //        //lblerror.Text = "login Successful!";

    //        Session["user"] = txtUserName.Text.Trim();
    //        Response.Redirect("Home.aspx");

    //    }
    //    else
    //    {
    //        lblerror.Text = "Login Fasdvfiled. Incorrect Username or Password!";
    //    }

    //}

    protected void btnLogin_Click(Object sender, EventArgs e)
    {
        SqlConnection sqlcon = new SqlConnection(@"Data Source =NALINI-LAPTOP;Initial Catalog=InventoryMangement;Integrated Security=true");

        int companyId;

        {
            sqlcon.Open();

            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Login WHERE UserName=@UserName AND Password=@Password", sqlcon))
            {
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@UserName", txtUserName.Text);
                cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                sda.Fill(dt);
                sqlcon.Close();
                if (dt.Rows.Count > 0)
                {
                    companyId = int.Parse(dt.Rows[0]["CompanyId"].ToString());
                    switch (companyId)
                    {
                        case 1:
                            Session["user"] = txtUserName.Text;
                            Response.Redirect("Home.aspx");

                            break;
                        case 2:
                            Session["user"] = txtUserName.Text;
                             Response.Redirect("DeptHome.aspx");
                            break;

                    }
                }
            }
        }
    }
    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        txtUserName.Text = "";
        txtPassword.Text = "";
    }
}