using System.Data.SqlClient;

namespace Sept3
{
    public partial class Main : Form
    {
        string connectionString = "Server=WIN-AQFCQ5LO69Q;Database=ABM;User Id=avery;Password=pass123;";
        public Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bool isConnected = DatabaseHelper.TestConnection(connectionString);
            if (isConnected)
            {
                toolStripStatusLabel1.Text = "Connected to SQL Server!";
            }
            else
            {
                toolStripStatusLabel1.Text = "Not connected to SQL Server!";
            }
        }

        private void openTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TestTable testTableForm = new TestTable();
            testTableForm.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string createTableQuery = @"
                    CREATE TABLE Students (
                        studentID BIGINT IDENTITY(1,1) PRIMARY KEY,
                        studentFirstName NVARCHAR(50),
                        studentLastName NVARCHAR(50),
                        studentEmail NVARCHAR(100),
                        studentDOB DATE,
                        isActive BIT
                    )";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(createTableQuery, connection);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    toolStripStatusLabel1.Text = "Table 'Students' created successfully!";
                }
                catch (Exception ex)
                {
                    toolStripStatusLabel1.Text = $"Error creating table: {ex.Message}";
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var skaters = new[]
            {
                new { FirstName = "Nyjah", LastName = "Huston", Email = "nyjah.huston@example.com", DOB = "1994-11-30", IsActive = 1 },
                new { FirstName = "Leticia", LastName = "Bufoni", Email = "leticia.bufoni@example.com", DOB = "1993-04-13", IsActive = 1 },
                new { FirstName = "Sky", LastName = "Brown", Email = "sky.brown@example.com", DOB = "2008-07-12", IsActive = 1 },
                new { FirstName = "Rayssa", LastName = "Leal", Email = "rayssa.leal@example.com", DOB = "2008-01-04", IsActive = 1 },
                new { FirstName = "Jagger", LastName = "Eaton", Email = "jagger.eaton@example.com", DOB = "2001-02-21", IsActive = 1 },
                new { FirstName = "Ryan", LastName = "Sheckler", Email = "ryan.sheckler@example.com", DOB = "1989-12-30", IsActive = 1 },
                new { FirstName = "Paul", LastName = "Rodriguez", Email = "paul.rodriguez@example.com", DOB = "1984-12-31", IsActive = 1 },
                new { FirstName = "Chris", LastName = "Cole", Email = "chris.cole@example.com", DOB = "1982-03-10", IsActive = 1 },
                new { FirstName = "Elissa", LastName = "Steamer", Email = "elissa.steamer@example.com", DOB = "1975-07-31", IsActive = 1 },
                new { FirstName = "Luan", LastName = "Oliveira", Email = "luan.oliveira@example.com", DOB = "1990-09-22", IsActive = 1 },
                new { FirstName = "Shane", LastName = "O'Neill", Email = "shane.oneill@example.com", DOB = "1990-01-03", IsActive = 1 },
                new { FirstName = "Tom", LastName = "Asta", Email = "tom.asta@example.com", DOB = "1990-01-12", IsActive = 1 },
                new { FirstName = "Sean", LastName = "Malto", Email = "sean.malto@example.com", DOB = "1989-09-09", IsActive = 1 },
                new { FirstName = "Tommy", LastName = "Guerrero", Email = "tommy.guerrero@example.com", DOB = "1966-09-09", IsActive = 1 },
                new { FirstName = "Natas", LastName = "Kaupas", Email = "natas.kaupas@example.com", DOB = "1969-03-23", IsActive = 1 },
                new { FirstName = "Mike", LastName = "Vallely", Email = "mike.vallely@example.com", DOB = "1970-06-29", IsActive = 1 },
                new { FirstName = "Bam", LastName = "Margera", Email = "bam.margera@example.com", DOB = "1979-09-28", IsActive = 1 }
            };

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                int successfulInserts = 0;
                var failedInserts = new List<string>();

                foreach (var skater in skaters)
                {
                    string insertQuery = @"
                        INSERT INTO Students (studentFirstName, studentLastName, studentEmail, studentDOB, isActive) 
                        VALUES (@FirstName, @LastName, @Email, @DOB, @IsActive)";

                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@FirstName", skater.FirstName);
                        command.Parameters.AddWithValue("@LastName", skater.LastName);
                        command.Parameters.AddWithValue("@Email", skater.Email);
                        command.Parameters.AddWithValue("@DOB", skater.DOB);
                        command.Parameters.AddWithValue("@IsActive", skater.IsActive);

                        try
                        {
                            command.ExecuteNonQuery();
                            successfulInserts++;
                        }
                        catch (Exception ex)
                        {
                            failedInserts.Add($"{skater.FirstName} {skater.LastName}");
                        }
                    }
                }

                toolStripStatusLabel1.Text = $"{successfulInserts} test entries added successfully!";
                if (failedInserts.Count > 0)
                {
                    MessageBox.Show("Could not add the following entries:\n" + string.Join("\n", failedInserts), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string createTableWithConstraintQuery = @"
                    CREATE TABLE Students (
                        studentID BIGINT IDENTITY(1,1) PRIMARY KEY,
                        studentFirstName NVARCHAR(50),
                        studentLastName NVARCHAR(50),
                        studentEmail NVARCHAR(100),
                        studentDOB DATE CHECK (studentDOB BETWEEN '1980-01-01' AND '2000-12-31'),
                        isActive BIT
                    )";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(createTableWithConstraintQuery, connection);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    toolStripStatusLabel1.Text = "Table created successfully!";
                }
                catch (Exception ex)
                {
                    toolStripStatusLabel1.Text = $"Error creating table with constraint: {ex.Message}";
                }
            }
        }
    }
}
