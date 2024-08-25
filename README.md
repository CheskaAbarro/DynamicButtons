# Display data from database as dynamic buttons
**This is an improved viewing for your data. This is just an improved CRUD functions using WinForms and MS SQL Server using SQL parameters and configuration management. Created with .NET 8 and MSSQL v20. This includes a simple error try and catch and does not include dependency injection and does not use MVVM format. This is just for beginner's practice guide!**
**This dynamic buttons is useful in creating buttons for POS or anyh ordering systems. 

Please check out my [simple-crud-winform-mssql](https://github.com/CheskaAbarro/simple-crud-winform-mssqql/tree/master) repository for a much simpler CRUD operations and [improved-crud-winform-mssql](https://github.com/CheskaAbarro/improved-crud-winform-mssql) repository for app.config setup and sql injection prevention tutorial.
I suggest you run and study the given link before studying this improvements. 

### Setting up and important parts 
**Step 1: Set up your database in MS SQL Server**
Database details: 
```
Database: CRUDWinForms
Table: tbl_Sensor
Table contents: ID(int, Identity Specification:Yes), SensorName(varchar 50), SensorType(varchar 50)
```
Note: You can decide if you want to create this database with query or not.


**Step 2: Create a configuration**
Right click on your project solution and click "Add new item". Then, under C# itemns, click "Data" and choose an XML file. Rename the XML file to "App.config" (not App.config.xml)
![image](https://github.com/user-attachments/assets/ba5399d7-c4b4-4d01-8dd3-cdc3567f1e06)

In App.config, contains the following:
```
<?xml version="1.0" encoding="utf-8" ?>
<configuration>

	<connectionStrings>
		<add name="SensorConnectionString" connectionString="Data Source=SERVERNAME;Initial Catalog=CRUDWinForms;Integrated Security=True;TrustServerCertificate=True"
			 providerName="System.Data.SqlClient"/>
	</connectionStrings>
	
</configuration>
```
Instead of directly coding the connection string on each behind-code, you can set up a configuration where the connection string can be accessible anywhere in the project.


**Step 3: Establish connection in your code**
Install a NuGet package: ***Microsoft.Data.SqlClient***.
Then, establish connection between visual studio and MS SQL. 
In your behind-code, you can call your connection string using the following:
```
 string connectionString = ConfigurationManager.ConnectionStrings["SensorConnectionString"].ConnectionString;
```
Setting up application configuration also make maintenance easier, and the following:
- Code organization: It can also organize your code where all of the connection strings can be added and be used anywhere in the project.
- Source Code Security: By not embedding sensitive information like connection strings directly in the code, you minimize the risk of exposing this information in source code repositories.
- Shared Settings: If you have multiple projects in a solution, you can have shared configurations, reducing duplication and potential for mismatched settings.
- Deployment Simplicity:  App.config can be modified without changing the application itself, allowing you to adapt to new environments or settings quickly.
- Best practice: Using App.config is a best practice in .NET development for managing application settings, promoting a standard approach across different projects and teams.


**Step 4: SQL Parameters**
Implementing SQL queries directly in your codes can be be prone to SQL injection. SQL injection is a code injection technique that exploits vulnerabilities in an application's software by inserting malicious SQL statements into an input field for execution by the backend database. This can allow attackers to perform unauthorized actions, such as accessing, modifying, or deleting data from the database.

Sample of direct query in codes:
```
string sqlQuery = "INSERT INTO tbl_Sensor (SensorName, SensorType) VALUES (" + "'" + txtSensorName.Text + "'" + "," + "'" + txtSensorType.Text + "'" + ")";
```
Thus, using SQL injection helps avoid SQL injection in your future applications. Please see the codes in Form.cs for the full codes. 

Snipet of SQL parameters use:
```
string sqlQuery = "INSERT INTO tbl_Sensor (SensorName, SensorType) VALUES (@sensorname, @sensortype)";

var sensorNameParameter = new SqlParameter("sensorname", System.Data.SqlDbType.VarChar);
sensorNameParameter.Value = txtSensorName.Text;
cmd.Parameters.Add(sensorNameParameter);

var sensorTypeParameter = new SqlParameter("sensortype", System.Data.SqlDbType.VarChar);
sensorTypeParameter.Value = txtSensorType.Text;
cmd.Parameters.Add(sensorTypeParameter);
```

**Step 5: Creating dynamic buttons**
Creating dynamic buttons is just like viewing data from datagrid view except, we use flowlayout panel for the dynamic buttons. 
Just like viewing in datagrid view, you start on a SELECT query. Once, you already have your data, assign them as object as shown below
```
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

```
You can also add a click event for the button you had created. In this case, I assign the sensor details to the textboxes. 
```
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
```
You use this code as a method and call it every time you load your form and it will get all the data from MS SQL Server and it will be displayed as buttons with click events. 

![image](https://github.com/user-attachments/assets/1cb77427-c697-47a6-9e3e-6f66f196719d)


**Tip: Read all the comments and try to debug line by line in order to study it better.**

### If you encounter an error, please leave a comment of your error and I will try to answer as soon as possible. 
### Happy learning!
