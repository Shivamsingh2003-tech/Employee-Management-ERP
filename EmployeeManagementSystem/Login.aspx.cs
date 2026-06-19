using System;
using System.Configuration;
using System.Data.SqlClient;

namespace EmployeeManagementSystem
{
	public partial class Login : System.Web.UI.Page
	{
		string cs = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

		protected void btnLogin_Click(object sender, EventArgs e)
		{
			using (SqlConnection con = new SqlConnection(cs))
			{
				string query = "SELECT COUNT(*) FROM AdminLogin WHERE Username=@Username AND Password=@Password";

				SqlCommand cmd = new SqlCommand(query, con);

				cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
				cmd.Parameters.AddWithValue("@Password", txtPassword.Text);

				con.Open();

				int result = (int)cmd.ExecuteScalar();

				if (result == 1)
				{
					Session["user"] = txtUsername.Text;
					Response.Redirect("Default.aspx");
				}
				else
				{
					Response.Write("<script>alert('Invalid Username or Password')</script>");
				}
			}
		}
	}
}