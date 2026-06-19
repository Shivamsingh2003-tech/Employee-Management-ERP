using System;
using System.Configuration;
using System.Data.SqlClient;

namespace EmployeeManagementSystem
{
	public partial class EmployeeDetails : System.Web.UI.Page
	{
		string cs = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				if (Request.QueryString["id"] != null)
				{
					int id;

					if (int.TryParse(Request.QueryString["id"], out id))
					{
						LoadEmployeeDetails(id);
					}
				}
			}
		}

		private void LoadEmployeeDetails(int id)
		{
			using (SqlConnection con = new SqlConnection(cs))
			{
				string query = "SELECT * FROM Department WHERE DeptId=@DeptId";

				SqlCommand cmd = new SqlCommand(query, con);
				cmd.Parameters.AddWithValue("@DeptId", id);

				con.Open();

				using (SqlDataReader dr = cmd.ExecuteReader())
				{
					if (dr.Read())
					{
						lblDeptId.Text = dr["DeptId"].ToString();
						lblDeptName.Text = dr["DeptName"].ToString();
						lblEmpName.Text = dr["EmpName"].ToString();
						lblSalary.Text = dr["Salary"].ToString();
						lblPosition.Text = dr["Position"].ToString();
						lblContact.Text = dr["ContactNumber"].ToString();
						lblEmail.Text = dr["Email"].ToString();

						// ⭐ Generate Professional Avatar (First 2 Letters)
						string name = lblEmpName.Text.Trim();

						string initials = name.Length >= 2
							? name.Substring(0, 2).ToUpper()
							: name.ToUpper();

						imgEmployee.ImageUrl =
							"https://ui-avatars.com/api/?name=" +
							initials +
							"&background=0D8ABC&color=fff&size=150&bold=true";
					}
				}
			}
		}
	}
}