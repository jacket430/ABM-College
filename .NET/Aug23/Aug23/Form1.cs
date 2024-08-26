using System.ComponentModel;

namespace Aug23
{
    public partial class Form1 : Form
    {
        private List<object[]> data;
        private int currentPage;
        private int itemsPerPage = 10;
        private string currentSortColumn = string.Empty;
        private ListSortDirection currentSortDirection = ListSortDirection.Ascending;

        public Form1()
        {
            InitializeComponent();
            data = new List<object[]>();
            currentPage = 0;
            dataGridView1.ColumnHeaderMouseClick += DataGridView1_ColumnHeaderMouseClick;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AddCheckBoxColumn();
            LoadData();
        }

        private void AddCheckBoxColumn()
        {
            var checkBoxColumn = new DataGridViewCheckBoxColumn
            {
                HeaderText = "",
                Width = 30,
                Name = "checkBoxColumn"
            };
            dataGridView1.Columns.Insert(0, checkBoxColumn);

            var headerCheckBox = new CheckBox
            {
                Size = new Size(15, 15),
                BackColor = Color.Transparent,
                Location = new Point(5, 5)
            };
            headerCheckBox.CheckedChanged += HeaderCheckBox_CheckedChanged;
            dataGridView1.Controls.Add(headerCheckBox);

            var rect = dataGridView1.GetCellDisplayRectangle(0, -1, true);
            headerCheckBox.Location = new Point(rect.Location.X + (rect.Width - headerCheckBox.Width) / 2, rect.Location.Y + (rect.Height - headerCheckBox.Height) / 2);
        }

        private void HeaderCheckBox_CheckedChanged(object? sender, EventArgs e)
        {
            if (sender is CheckBox headerCheckBox)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    row.Cells[0].Value = headerCheckBox.Checked;
                }
            }
        }

        private void LoadData()
        {
            LoadMoreData();
            DisplayPage();
        }

        private void LoadMoreData()
        {
            data.AddRange(new List<object[]>
                {
                    new object[] { false, 100011, "Eddie", "Van Halen", 34, "Male", "eddie.vanhalen@example.com", "123-456-7890" },
                    new object[] { false, 100012, "Slash", "Hudson", 32, "Male", "slash@example.com", "234-567-8901" },
                    new object[] { false, 100013, "Jimi", "Hendrix", 27, "Male", "jimi.hendrix@example.com", "345-678-9012" },
                    new object[] { false, 100014, "Angus", "Young", 30, "Male", "angus.young@example.com", "456-789-0123" },
                    new object[] { false, 100015, "Jimmy", "Page", 32, "Male", "jimmy.page@example.com", "567-890-1234" },
                    new object[] { false, 100016, "Keith", "Richards", 36, "Male", "keith.richards@example.com", "678-901-2345" },
                    new object[] { false, 100017, "Eric", "Clapton", 35, "Male", "eric.clapton@example.com", "789-012-3456" },
                    new object[] { false, 100018, "Stevie", "Ray Vaughan", 33, "Male", "stevie.vaughan@example.com", "890-123-4567" },
                    new object[] { false, 100019, "Kurt", "Cobain", 27, "Male", "kurt.cobain@example.com", "901-234-5678" },
                    new object[] { false, 100020, "Freddie", "Mercury", 35, "Male", "freddie.mercury@example.com", "012-345-6789" },
                    new object[] { false, 100021, "Janis", "Joplin", 29, "Female", "janis.joplin@example.com", "123-456-7890" },
                    new object[] { false, 100022, "Tina", "Turner", 31, "Female", "tina.turner@example.com", "234-567-8901" },
                    new object[] { false, 100023, "Amy", "Winehouse", 27, "Female", "amy.winehouse@example.com", "345-678-9012" },
                    new object[] { false, 100024, "Joan", "Jett", 30, "Female", "joan.jett@example.com", "456-789-0123" },
                    new object[] { false, 100025, "Debbie", "Harry", 32, "Female", "debbie.harry@example.com", "567-890-1234" },
                    new object[] { false, 100026, "Courtney", "Love", 34, "Female", "courtney.love@example.com", "678-901-2345" },
                    new object[] { false, 100027, "Gwen", "Stefani", 33, "Female", "gwen.stefani@example.com", "789-012-3456" },
                    new object[] { false, 100028, "Bonnie", "Raitt", 35, "Female", "bonnie.raitt@example.com", "890-123-4567" },
                    new object[] { false, 100029, "Alanis", "Morissette", 31, "Female", "alanis.morissette@example.com", "901-234-5678" },
                    new object[] { false, 100030, "Sheryl", "Crow", 34, "Female", "sheryl.crow@example.com", "012-345-6789" },
                    new object[] { false, 100031, "B.B.", "King", 40, "Male", "bb.king@example.com", "123-456-7890" },
                    new object[] { false, 100032, "Carlos", "Santana", 38, "Male", "carlos.santana@example.com", "234-567-8901" },
                    new object[] { false, 100033, "John", "Lennon", 35, "Male", "john.lennon@example.com", "345-678-9012" },
                    new object[] { false, 100034, "Bob", "Dylan", 37, "Male", "bob.dylan@example.com", "456-789-0123" },
                    new object[] { false, 100035, "Mick", "Jagger", 39, "Male", "mick.jagger@example.com", "567-890-1234" },
                    new object[] { false, 100036, "Elvis", "Presley", 36, "Male", "elvis.presley@example.com", "678-901-2345" },
                    new object[] { false, 100037, "Prince", "", 33, "Male", "prince@example.com", "789-012-3456" },
                    new object[] { false, 100038, "David", "Bowie", 38, "Male", "david.bowie@example.com", "890-123-4567" },
                    new object[] { false, 100039, "Freddie", "King", 35, "Male", "freddie.king@example.com", "901-234-5678" },
                    new object[] { false, 100040, "Stevie", "Nicks", 37, "Female", "stevie.nicks@example.com", "012-345-6789" }
                });
        }

        private void DisplayPage()
        {
            SortData();
            dataGridView1.Rows.Clear();
            int start = currentPage * itemsPerPage;
            int end = Math.Min(start + itemsPerPage, data.Count);

            for (int i = start; i < end; i++)
            {
                dataGridView1.Rows.Add(data[i]);
            }

            UpdateRowColors();
            UpdateTextBox();
        }

        private void UpdateRowColors()
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].DefaultCellStyle.BackColor = i % 2 == 0 ? Color.Yellow : Color.Red;
            }
        }

        private void UpdateTextBox()
        {
            int end = Math.Min((currentPage + 1) * itemsPerPage, data.Count);
            textBox2.Text = $"{end}/{data.Count}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string searchText = textBox1.Text.ToLower();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow)
                {
                    var cell = row.Cells["Column2"];
                    row.Visible = cell?.Value?.ToString()?.ToLower()?.Contains(searchText) == true;
                }
            }

            UpdateRowColors();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = dataGridView1.Rows.Count - 1; i >= 0; i--)
            {
                DataGridViewRow row = dataGridView1.Rows[i];
                if (row.IsNewRow) continue; // Skip new rows
                if (row.Cells[0].Value != null && (bool)row.Cells[0].Value)
                {
                    dataGridView1.Rows.RemoveAt(i);
                }
            }

            UpdateRowColors();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (currentPage > 0)
            {
                currentPage--;
                DisplayPage();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            currentPage = 0;
            DisplayPage();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            currentPage = (data.Count - 1) / itemsPerPage;
            DisplayPage();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if ((currentPage + 1) * itemsPerPage < data.Count)
            {
                currentPage++;
                DisplayPage();
            }
        }
        private void DataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string columnName = dataGridView1.Columns[e.ColumnIndex].Name;
            if (currentSortColumn == columnName)
            {
                currentSortDirection = currentSortDirection == ListSortDirection.Ascending ? ListSortDirection.Descending : ListSortDirection.Ascending;
            }
            else
            {
                currentSortColumn = columnName;
                currentSortDirection = ListSortDirection.Ascending;
            }

            SortData();
            DisplayPage();
        }
        private void SortData()
        {
            if (string.IsNullOrEmpty(currentSortColumn)) return;

            data = currentSortDirection == ListSortDirection.Ascending
                ? data.OrderBy(row => row[dataGridView1.Columns[currentSortColumn].Index]).ToList()
                : data.OrderByDescending(row => row[dataGridView1.Columns[currentSortColumn].Index]).ToList();
        }

    }
}
