using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

public partial class EmployeeForm : Form
{
    private const string ConnectionString = "Data Source=(local);Initial Catalog=YourDatabaseName;Integrated Security=True";

    public EmployeeForm()
    {
        InitializeComponent();
        LoadDataGrid();
    }

    private void LoadDataGrid()
    {
        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            connection.Open();
            using (SqlCommand command = new SqlCommand("SELECT * FROM Employee", connection))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView.DataSource = dataTable;
            }
        }
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        // Validation logic here

        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            connection.Open();
            using (SqlCommand command = new SqlCommand("InsertEmployee", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                // Add parameters to the stored procedure
                command.Parameters.AddWithValue("@Id", Convert.ToInt32(txtId.Text));
                command.Parameters.AddWithValue("@Name", txtName.Text);
                command.Parameters.AddWithValue("@Age", Convert.ToInt32(txtAge.Text));
                command.Parameters.AddWithValue("@Salary", Convert.ToDecimal(txtSalary.Text));

                command.ExecuteNonQuery();
            }
        }

        LoadDataGrid(); // Refresh data grid after saving
    }

    private void btnUpdate_Click(object sender, EventArgs e)
    {
        // Validation logic here

        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            connection.Open();
            using (SqlCommand command = new SqlCommand("UpdateEmployee", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                // Add parameters to the stored procedure
                command.Parameters.AddWithValue("@Id", Convert.ToInt32(txtId.Text));
                command.Parameters.AddWithValue("@Name", txtName.Text);
                command.Parameters.AddWithValue("@Age", Convert.ToInt32(txtAge.Text));
                command.Parameters.AddWithValue("@Salary", Convert.ToDecimal(txtSalary.Text));

                command.ExecuteNonQuery();
            }
        }

        LoadDataGrid(); // Refresh data grid after updating
    }
}
