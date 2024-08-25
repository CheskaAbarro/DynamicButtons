using System.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;

namespace DynamicButtons
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //varibles
        string connectionString = ConfigurationManager.ConnectionStrings["SensorConnectionString"].ConnectionString;

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadRecords();
            LoadDynamicButtons();
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }


        //Save
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtSensorName.Text) && !string.IsNullOrWhiteSpace(txtSensorType.Text))
                {
                    //SQL
                    string sqlQuery = "INSERT INTO tbl_Sensor (SensorName, SensorType) VALUES (@sensorname, @sensortype)";

                    //assigning SQL variables
                    SqlConnection conn = new SqlConnection(connectionString);
                    SqlCommand cmd = new SqlCommand(sqlQuery, conn);

                    //SQL parameters (to improve DB security)
                    //for Sensor Name
                    var sensorNameParameter = new SqlParameter("sensorname", System.Data.SqlDbType.VarChar);
                    sensorNameParameter.Value = txtSensorName.Text;
                    cmd.Parameters.Add(sensorNameParameter);
                    //for Sensor Type
                    var sensorTypeParameter = new SqlParameter("sensortype", System.Data.SqlDbType.VarChar);
                    sensorTypeParameter.Value = txtSensorType.Text;
                    cmd.Parameters.Add(sensorTypeParameter);

                    //Open conn, execute sql and close conn
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    //Reload records
                    MessageBox.Show("Data saved!");

                    LoadRecords();
                    LoadDynamicButtons();
                }
                else
                {
                    MessageBox.Show("Fill out all text box!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        //Cell click data bind
        private void dataGridSensor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    //select entire row
                    dataGridSensor.Rows[e.RowIndex].Selected = true;

                    //retrieve data of selected row
                    DataGridViewRow selectedRow = dataGridSensor.Rows[e.RowIndex];

                    //bind data to textboxes
                    lblID.Text = selectedRow.Cells["ID"].Value.ToString();
                    txtSensorName.Text = selectedRow.Cells["SensorName"].Value.ToString();
                    txtSensorType.Text = selectedRow.Cells["SensorType"].Value.ToString();

                    //enable buttons
                    btnUpdate.Enabled = true;
                    btnDelete.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Update
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridSensor.SelectedRows.Count > 0) 
                {
                    //retrieve ID from table
                    int selectedId = Convert.ToInt32(dataGridSensor.SelectedRows[0].Cells["ID"].Value);

                    //check if textbox is empty
                    if (!string.IsNullOrWhiteSpace(txtSensorName.Text) && !string.IsNullOrWhiteSpace(txtSensorType.Text))
                    {
                        //SQL
                        string sqlQuery = "UPDATE tbl_Sensor SET SensorName=@SensorName, SensorType=@SensorType WHERE ID = @ID";

                        //assign sql connection and query
                        SqlConnection conn = new SqlConnection(connectionString);
                        SqlCommand cmd = new SqlCommand(sqlQuery, conn);

                        //assign value from form to query 
                        cmd.Parameters.AddWithValue("@ID", lblID.Text);
                        cmd.Parameters.AddWithValue("@SensorName", txtSensorName.Text);
                        cmd.Parameters.AddWithValue("@SensorType", txtSensorType.Text);

                        //Open conn, execute sql and close conn
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();

                        MessageBox.Show("Record successfully updated!");

                        //clear out textbox
                        lblID.Text = string.Empty;
                        txtSensorName.Text = string.Empty;
                        txtSensorType.Text = string.Empty;

                        //enable buttons
                        btnDelete.Enabled = false;
                        btnUpdate.Enabled = false;

                        //reload records
                        LoadRecords();
                    }
                    else
                    {
                        MessageBox.Show("Fill out all boxes!");
                    }
                }
                
                else if(btnUpdate.Text == "Update")
                {
                    try
                    {
                        if (!string.IsNullOrWhiteSpace(txtSensorName.Text) && !string.IsNullOrWhiteSpace(txtSensorType.Text))
                        {
                            //Confirm saving
                            DialogResult resultConfirm = MessageBox.Show(
                                "Save this category?",
                                "Confirm Save", MessageBoxButtons.YesNo);

                            if (resultConfirm == DialogResult.Yes)
                            {
                                //sql query
                                string sqlQuery = "UPDATE tbl_Sensor SET SensorName=@sensorName, SensorType=@sensorType WHERE ID = @id";

                                //assign SQL variables
                                SqlConnection conn = new SqlConnection(connectionString);
                                SqlCommand cmd = new SqlCommand(sqlQuery, conn);

                                //SQL parameters
                                cmd.Parameters.AddWithValue("@id", lblID.Text);
                                cmd.Parameters.AddWithValue("@sensorName", txtSensorName.Text);
                                cmd.Parameters.AddWithValue("@sensorType", txtSensorType.Text);


                                //execute
                                conn.Open();
                                int status = cmd.ExecuteNonQuery();
                                conn.Close();

                                if (status > 0)
                                {
                                    txtSensorName.Text = string.Empty;
                                    txtSensorType.Text = string.Empty;
                                    MessageBox.Show("Category updated!");
                                    LoadRecords();
                                    LoadDynamicButtons();

                                    //clear out textbox
                                    lblID.Text = string.Empty;
                                    txtSensorName.Text = string.Empty;
                                    txtSensorType.Text = string.Empty;

                                    //enable buttons
                                    btnDelete.Enabled = false;
                                    btnUpdate.Enabled = false;
                                }
                                else
                                {
                                    MessageBox.Show("Someting went wrong.");
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Fill out all forms!");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                
                else
                {
                    MessageBox.Show("No selected data!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Delete
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridSensor.SelectedRows.Count > 0)
                {
                    //retrieve ID from records
                    int selectedId = Convert.ToInt32(dataGridSensor.SelectedRows[0].Cells["ID"].Value);

                    //Confirm deletion
                    DialogResult resultConfirm = MessageBox.Show(
                        "Are you sure you want to delete this record?",
                        "Confirm Deletion", MessageBoxButtons.YesNo);

                    //if user chose Yes
                    if (resultConfirm == DialogResult.Yes)
                    {
                        //SQL
                        string sqlQuery = "DELETE FROM tbl_Sensor WHERE ID = @ID";

                        //SQL connection and strings
                        SqlConnection conn = new SqlConnection(connectionString);
                        SqlCommand cmd = new SqlCommand(sqlQuery, conn);

                        //assign value from form to query 
                        cmd.Parameters.AddWithValue("@ID", lblID.Text);

                        //Open conn, execute sql and close conn
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();

                        MessageBox.Show("Record successfully deleted!");

                        //clear out textbox
                        lblID.Text = string.Empty;
                        txtSensorName.Text = string.Empty;
                        txtSensorType.Text = string.Empty;

                        //enable buttons
                        btnDelete.Enabled = false;
                        btnUpdate.Enabled = false;

                        //reload records
                        LoadRecords();
                        LoadDynamicButtons();

                    }
                }

                else if(btnDelete.Text == "Delete")
                {
                    //Confirm saving
                    DialogResult resultConfirm = MessageBox.Show(
                        "Are you sure to DELETE this sensor?",
                        "Confirm Save", MessageBoxButtons.YesNo);

                    if (resultConfirm == DialogResult.Yes)
                    {
                        string sqlQuery = "DELETE FROM tbl_Sensor WHERE ID = @id";

                        SqlConnection conn = new SqlConnection(connectionString);
                        SqlCommand cmd = new SqlCommand(sqlQuery, conn);

                        //assign ID value
                        cmd.Parameters.AddWithValue("@id", lblID.Text);

                        //Open conn, execute sql and close conn
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();

                        MessageBox.Show("Record successfully deleted!");

                        LoadRecords();
                        LoadDynamicButtons();

                        //clear out textbox
                        lblID.Text = string.Empty;
                        txtSensorName.Text = string.Empty;
                        txtSensorType.Text = string.Empty;

                        //enable buttons
                        btnDelete.Enabled = false;
                        btnUpdate.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        //Methods
        //retrieve all records
        private void LoadRecords()
        {
            try
            {
                //SQL
                string sqlQuery = "SELECT * FROM tbl_Sensor";

                //connection and execution
                SqlConnection conn = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(sqlQuery, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();

                //display data to datagrid
                adapter.Fill(dataTable);
                dataGridSensor.DataSource = dataTable;

                //datagrid design
                dataGridSensor.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridSensor.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridSensor.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadDynamicButtons()
        {
            try
            {
                string sqlQuery = "SELECT * from tbl_Sensor";

                SqlConnection conn = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(sqlQuery, conn);

                //open and read data
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                //clear existing first
                flowpanelSensor.Controls.Clear();

                while (reader.Read())
                {
                    //Get category name and id
                    string sensorId = reader["ID"].ToString();
                    string sensorName = reader["SensorName"].ToString();
                    string sensorType = reader["SensorType"].ToString();

                    //Create button for each category found
                    Button btnSensor = new Button();
                    btnSensor.Text = sensorName;
                    btnSensor.AutoSize = true;
                    btnSensor.Height = 40;
                    btnSensor.ForeColor = Color.Black;
                    btnSensor.Font = new Font("Verdana", 9, FontStyle.Bold);
                    btnSensor.BackColor = Color.FromArgb(255, 209, 103);


                    //add button to flow layout
                    flowpanelSensor.Controls.Add(btnSensor);

                    //click function
                    btnSensor.Click += (sender, e) =>
                    {
                        //MessageBox.Show("You clicked " + catName);
                        lblID.Text = sensorId;
                        txtSensorName.Text = sensorName;
                        txtSensorType.Text = sensorType;
                        btnSave.Enabled = false;
                        btnUpdate.Enabled = true;
                        btnDelete.Enabled = true;
                    };

                }

                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



    }
}
