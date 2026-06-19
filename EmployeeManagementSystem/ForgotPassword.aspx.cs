using System;
using System.Configuration;
using System.Data.SqlClient;

namespace EmployeeManagementSystem
{
	public partial class ForgotPassword : System.Web.UI.Page
	{
		string cs = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

		protected void btnReset_Click(object sender, EventArgs e)
		{
			using (SqlConnection con = new SqlConnection(cs))
			{
				string query = "UPDATE AdminLogin SET Password=@Password WHERE Username=@Username";

				SqlCommand cmd = new SqlCommand(query, con);

				cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
				cmd.Parameters.AddWithValue("@Password", txtPassword.Text);

				con.Open();

				int result = cmd.ExecuteNonQuery();

				if (result > 0)
				{
					Response.Write("<script>alert('Password Updated Successfully')</script>");
				}
				else
				{
					Response.Write("<script>alert('Username Not Found')</script>");
				}
			}
		}
	}
}