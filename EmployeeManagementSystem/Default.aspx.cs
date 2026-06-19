using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeeManagementSystem
{
	public partial class _Default : Page
	{
		string cs = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

		protected void Page_Load(object sender, EventArgs e)
		{
			if (Session["user"] == null)
			{
				Response.Redirect("Login.aspx");
			}

			if (!IsPostBack)
			{
				GridView1.Visible = false;
				LoadDashboard();
			}
		}

		// Dashboard
		private void LoadDashboard()
		{
			using (SqlConnection con = new SqlConnection(cs))
			{
				con.Open();

				lblTotalEmp.Text = ExecuteCount(con, "SELECT COUNT(*) FROM Department");
				lblIT.Text = ExecuteCount(con, "SELECT COUNT(*) FROM Department WHERE DeptName='IT'");
				lblHR.Text = ExecuteCount(con, "SELECT COUNT(*) FROM Department WHERE DeptName='HR'");
				lblFinance.Text = ExecuteCount(con, "SELECT COUNT(*) FROM Department WHERE DeptName='Finance'");
				lblMarketing.Text = ExecuteCount(con, "SELECT COUNT(*) FROM Department WHERE DeptName='Marketing'");
			}
		}

		private string ExecuteCount(SqlConnection con, string query)
		{
			SqlCommand cmd = new SqlCommand(query, con);
			object result = cmd.ExecuteScalar();
			return result != null ? result.ToString() : "0";
		}

		// Load Grid
		private void LoadData()
		{
			using (SqlConnection con = new SqlConnection(cs))
			{
				SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Department", con);
				DataTable dt = new DataTable();
				da.Fill(dt);

				GridView1.DataSource = dt;
				GridView1.DataBind();
				GridView1.Visible = true;
			}
		}

		// Insert
		protected void btnInsert_Click(object sender, EventArgs e)
		{
			try
			{
				using (SqlConnection con = new SqlConnection(cs))
				{
					string query = @"INSERT INTO Department
                    (DeptId,DeptName,EmpName,Salary,Position,ContactNumber,Email)
                    VALUES
                    (@DeptId,@DeptName,@EmpName,@Salary,@Position,@Contact,@Email)";

					SqlCommand cmd = new SqlCommand(query, con);

					cmd.Parameters.AddWithValue("@DeptId", Convert.ToInt32(txtDeptId.Text.Trim()));
					cmd.Parameters.AddWithValue("@DeptName", ddlDepartment.SelectedValue);
					cmd.Parameters.AddWithValue("@EmpName", txtEmpName.Text.Trim());
					cmd.Parameters.AddWithValue("@Salary", Convert.ToDecimal(txtSalary.Text.Trim()));
					cmd.Parameters.AddWithValue("@Position", txtPosition.Text.Trim());
					cmd.Parameters.AddWithValue("@Contact", txtContact.Text.Trim());
					cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());

					con.Open();
					cmd.ExecuteNonQuery();
				}

				ShowMessage("Employee inserted successfully");
				LoadData();
				LoadDashboard();
				ClearFields();
			}
			catch (Exception ex)
			{
				ShowMessage("Error: " + ex.Message);
			}
		}

		// View
		protected void btnView_Click(object sender, EventArgs e)
		{
			LoadData();
		}

		// Delete (Form)
		protected void btnDelete_Click(object sender, EventArgs e)
		{
			try
			{
				using (SqlConnection con = new SqlConnection(cs))
				{
					string query = "DELETE FROM Department WHERE DeptId=@DeptId";

					SqlCommand cmd = new SqlCommand(query, con);
					cmd.Parameters.AddWithValue("@DeptId", Convert.ToInt32(txtDeptId.Text.Trim()));

					con.Open();
					cmd.ExecuteNonQuery();
				}

				ShowMessage("Employee deleted successfully");
				LoadData();
				LoadDashboard();
				ClearFields();
			}
			catch (Exception ex)
			{
				ShowMessage("Error: " + ex.Message);
			}
		}

		// Update Salary
		protected void btnUpdate_Click(object sender, EventArgs e)
		{
			try
			{
				using (SqlConnection con = new SqlConnection(cs))
				{
					string query = "UPDATE Department SET Salary=@Salary WHERE DeptId=@DeptId";

					SqlCommand cmd = new SqlCommand(query, con);

					cmd.Parameters.AddWithValue("@DeptId", Convert.ToInt32(txtDeptId.Text.Trim()));
					cmd.Parameters.AddWithValue("@Salary", Convert.ToDecimal(txtSalary.Text.Trim()));

					con.Open();
					cmd.ExecuteNonQuery();
				}

				ShowMessage("Salary updated successfully");
				LoadData();
				LoadDashboard();
				ClearFields();
			}
			catch (Exception ex)
			{
				ShowMessage("Error: " + ex.Message);
			}
		}

		// Search
		protected void btnSearch_Click(object sender, EventArgs e)
		{
			using (SqlConnection con = new SqlConnection(cs))
			{
				SqlDataAdapter da = new SqlDataAdapter(
					"SELECT * FROM Department WHERE EmpName LIKE '%' + @EmpName + '%'", con);

				da.SelectCommand.Parameters.AddWithValue("@EmpName", txtSearch.Text.Trim());

				DataTable dt = new DataTable();
				da.Fill(dt);

				GridView1.DataSource = dt;
				GridView1.DataBind();
				GridView1.Visible = true;
			}
		}

		// Grid Edit
		protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
		{
			GridView1.EditIndex = e.NewEditIndex;
			LoadData();
		}

		// Cancel Edit
		protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
		{
			GridView1.EditIndex = -1;
			LoadData();
		}

		// Grid Update
		protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
		{
			int deptId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
			GridViewRow row = GridView1.Rows[e.RowIndex];

			string deptName = ((TextBox)row.Cells[1].Controls[0]).Text;
			string empName = ((TextBox)row.Cells[2].Controls[0]).Text;
			string salary = ((TextBox)row.Cells[3].Controls[0]).Text;
			string position = ((TextBox)row.Cells[4].Controls[0]).Text;
			string contact = ((TextBox)row.Cells[5].Controls[0]).Text;
			string email = ((TextBox)row.Cells[6].Controls[0]).Text;

			using (SqlConnection con = new SqlConnection(cs))
			{
				string query = @"UPDATE Department SET
                DeptName=@DeptName,
                EmpName=@EmpName,
                Salary=@Salary,
                Position=@Position,
                ContactNumber=@Contact,
                Email=@Email
                WHERE DeptId=@DeptId";

				SqlCommand cmd = new SqlCommand(query, con);

				cmd.Parameters.AddWithValue("@DeptId", deptId);
				cmd.Parameters.AddWithValue("@DeptName", deptName);
				cmd.Parameters.AddWithValue("@EmpName", empName);
				cmd.Parameters.AddWithValue("@Salary", Convert.ToDecimal(salary));
				cmd.Parameters.AddWithValue("@Position", position);
				cmd.Parameters.AddWithValue("@Contact", contact);
				cmd.Parameters.AddWithValue("@Email", email);

				con.Open();
				cmd.ExecuteNonQuery();
			}

			GridView1.EditIndex = -1;
			LoadData();
			LoadDashboard();
			ShowMessage("Employee updated successfully");
		}

		// Grid Delete
		protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
		{
			int deptId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);

			using (SqlConnection con = new SqlConnection(cs))
			{
				SqlCommand cmd = new SqlCommand(
					"DELETE FROM Department WHERE DeptId=@DeptId", con);

				cmd.Parameters.AddWithValue("@DeptId", deptId);

				con.Open();
				cmd.ExecuteNonQuery();
			}

			LoadData();
			LoadDashboard();
			ShowMessage("Employee deleted successfully");
		}

		// Delete confirmation popup
		protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
		{
			if (e.Row.RowType == DataControlRowType.DataRow)
			{
				foreach (Control ctrl in e.Row.Cells[e.Row.Cells.Count - 1].Controls)
				{
					if (ctrl is LinkButton btn && btn.CommandName == "Delete")
					{
						btn.Attributes.Add("onclick", "return confirm('Are you sure you want to delete this employee?');");
					}
				}
			}
		}

		// Logout
		protected void btnLogout_Click(object sender, EventArgs e)
		{
			Session.Abandon();
			Response.Redirect("Login.aspx");
		}

		// Alert
		private void ShowMessage(string message)
		{
			ClientScript.RegisterStartupScript(
				this.GetType(),
				"alert",
				"alert('" + message + "');",
				true);
		}

		// Clear Fields
		private void ClearFields()
		{
			txtDeptId.Text = "";
			ddlDepartment.SelectedIndex = 0;
			txtEmpName.Text = "";
			txtSalary.Text = "";
			txtPosition.Text = "";
			txtContact.Text = "";
			txtEmail.Text = "";
		}
	}
}