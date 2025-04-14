using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Drawing.Text;
using System.Data.SqlClient;
using System.Reflection.Emit;





namespace projekta_darbs
{


    public partial class mainPage : MaterialForm
    {
        private bool admin = false;
        private object result;
        private string email = Global.g_email;
        string name;


        public mainPage()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.DeepPurple800, Primary.DeepPurple600, Primary.DeepPurple400, Accent.Blue200, TextShade.WHITE);



            SQLiteConnection con = new SQLiteConnection(databaseFilePath());
            con.Open();
            string query = "SELECT * FROM DarbaRiki";
            SQLiteDataAdapter da = new SQLiteDataAdapter(query, con);
            DataTable dt = new DataTable();
            PopulateComboBox();
            PopulateComboBox2();
            con.Close();

            con.Open();
            string nameQuery = "SELECT Vards FROM Lietotajs WHERE Epasts=@Email";
            using (SQLiteCommand cmd = new SQLiteCommand(nameQuery, con))
            {
                cmd.Parameters.AddWithValue("@Email", email);
                var result = cmd.ExecuteScalar();
                if (result != null)
                {
                    name = result.ToString();
                }
            }

            materialLabel2.Text = $"Esat ielogojies, kā {name}!";

            if (Global.g_admin == true)
            {
                materialButton1.Show();
            }

            textBox1.Clear(); //fetches previous logs
            using (SQLiteCommand cmd = new SQLiteCommand("SELECT ieraksts FROM zurnals", con))
            {
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        textBox1.AppendText(reader["ieraksts"].ToString());
                    }
                }
            }


        }

        protected override void OnFormClosing(FormClosingEventArgs e) //make it close
        {
            e.Cancel = false;
            base.OnFormClosing(e);
        }

        private void PopulateComboBox() // aizpilda data combo box ar darbarīku info
        {

            comboBox1.Items.Clear();

            try
            {
                using (SQLiteConnection con = new SQLiteConnection(databaseFilePath()))
                {
                    con.Open();

                    string query = "SELECT DarbarikiID FROM DarbaRiki WHERE DarbaRikiID NOT IN (SELECT DarbaRikiID FROM IzdotieRiki)";

                    using (SQLiteCommand command = new SQLiteCommand(query, con))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                comboBox1.Items.Add(reader["DarbaRikiID"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }
        private void PopulateComboBox2() // aizpilda otro combo box ar info no darbarīki
        {

            comboBox2.Items.Clear();

            try
            {
                using (SQLiteConnection con = new SQLiteConnection(databaseFilePath()))
                {
                    con.Open();

                    string query = "Select DarbaRikiID From IzdotieRiki";

                    using (SQLiteCommand command = new SQLiteCommand(query, con))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                comboBox2.Items.Add(reader["DarbaRikiID"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            PopulateComboBox();
            PopulateComboBox2();
        }



        private void materialButton1_Click(object sender, EventArgs e)
        {
            adminPage ShowAdmin = new adminPage();
            ShowAdmin.Show();

            this.Hide();
            this.Closed += (s, args) => Application.Exit();
        }

        private void SanemtBtn_Click(object sender, EventArgs e)
        {

            string logDarbaRiki;

            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Lūdzu izvēlies darbarīku!");
                return;
            }

            string selectedDarbaRikiID = comboBox1.SelectedItem.ToString();


            try
            {

                using (SQLiteConnection con = new SQLiteConnection(databaseFilePath()))
                {
                    con.Open();

                    // dabu darbarīka nosaukumu
                    string darbariks = "";
                    string getDarbaRiksQuery = "SELECT DarbaRiks FROM DarbaRiki WHERE DarbaRikiID = @id";

                    using (SQLiteCommand getCmd = new SQLiteCommand(getDarbaRiksQuery, con))
                    {
                        getCmd.Parameters.AddWithValue("@id", selectedDarbaRikiID);
                        darbariks = getCmd.ExecuteScalar()?.ToString() ?? "";
                        logDarbaRiki = darbariks;
                    }

                    // ieliek izdotajas darbariks values
                    string insertQuery = @"INSERT INTO IzdotieRiki
                                (DarbaRikiID, DarbaRiks, Vards) 
                                VALUES 
                                (@DarbaRikiID, @darbariks, @name)";

                    using (SQLiteCommand insertCmd = new SQLiteCommand(insertQuery, con))
                    {
                        insertCmd.Parameters.AddWithValue("@DarbaRikiID", selectedDarbaRikiID);
                        insertCmd.Parameters.AddWithValue("@darbariks", darbariks);
                        insertCmd.Parameters.AddWithValue("@name", name);

                        int rowsAffected = insertCmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Darbarīks izdots!");
                            //tukso combobox
                            comboBox1.SelectedIndex = -1;
                            //atjauno combo boxes
                            PopulateComboBox();
                            PopulateComboBox2();
                        }
                    }


                    string ieraksts = $"{DateTime.Now}: {name} paņēma darbarīku {logDarbaRiki}. ";

                    textBox1.AppendText(ieraksts);

                    string writeQuery = "INSERT INTO zurnals (ieraksts) VALUES (@ieraksts)";
                    using (SQLiteCommand cmd4 = new SQLiteCommand(writeQuery, con))
                    {
                        cmd4.Parameters.AddWithValue("@ieraksts", ieraksts);

                        cmd4.ExecuteNonQuery();
                    }

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Kļūda : " + ex.Message);
            }
        }

        private void NodotBtn_Click(object sender, EventArgs e)
        {

            string logDarbaRiki = "";

            if (comboBox2.SelectedItem == null)
            {
                MessageBox.Show("Izvēlies darbarīku, ko saņemt!");
                return;
            }


            string selectedDarbaRikiID = comboBox2.SelectedItem.ToString();


            try
            {
                using (SQLiteConnection con = new SQLiteConnection(databaseFilePath()))
                {
                    con.Open();

                    // Vai Atslega ir izdota
                    string checkQuery = "SELECT COUNT(*) FROM IzdotieRiki WHERE DarbaRikiID = @DarbaRikiID";
                    int keyCount;

                    using (SQLiteCommand checkCmd = new SQLiteCommand(checkQuery, con))
                    {
                        checkCmd.Parameters.AddWithValue("@DarbaRikiID", selectedDarbaRikiID);
                        keyCount = Convert.ToInt32(checkCmd.ExecuteScalar());
                    }

                    if (keyCount == 0)
                    {
                        MessageBox.Show("Šis darbarīks nav izdots!");
                        return;
                    }

                    string namequery = "SELECT COUNT(*) FROM IzdotieRiki WHERE Vards = @name";
                    int varducount;
                    using (SQLiteCommand checkname = new SQLiteCommand(namequery, con))
                    {
                        checkname.Parameters.AddWithValue("@name", name);
                        varducount = Convert.ToInt32(checkname.ExecuteScalar());
                    }
                    if (varducount == 0)
                    {
                        MessageBox.Show("Jūs šo darbarīku nesaņēmāt!");
                        comboBox2.SelectedIndex = -1;
                        return;
                    }



                    //pievieno darbarīkus izdosanu log
                    string selectQuery = "SELECT DarbaRiks FROM IzdotieRiki WHERE DarbaRikiID = @DarbaRikiID";
                    using (SQLiteCommand cmd = new SQLiteCommand(selectQuery, con))
                    {


                        cmd.Parameters.AddWithValue("@DarbaRikiID", selectedDarbaRikiID);
                        var result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            logDarbaRiki = result.ToString();

                        }
                        string ieraksts = $"{DateTime.Now}: {name} nodeva darbarīku {logDarbaRiki}. ";

                        textBox1.AppendText(ieraksts);

                        string writeQuery = "INSERT INTO zurnals (ieraksts) VALUES (@ieraksts)";
                        using (SQLiteCommand cmd4 = new SQLiteCommand(writeQuery, con))
                        {
                            cmd4.Parameters.AddWithValue("@ieraksts", ieraksts);

                            cmd4.ExecuteNonQuery();
                        }
                    }

                    // Nonem atslegu no IzdotieRiki
                    string deleteQuery = "DELETE FROM IzdotieRiki WHERE DarbaRikiID = @DarbaRikiID";

                    using (SQLiteCommand deleteCmd = new SQLiteCommand(deleteQuery, con))
                    {
                        deleteCmd.Parameters.AddWithValue("@DarbaRikiID", selectedDarbaRikiID);

                        int rowsAffected = deleteCmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Darbarīks saņemts!");
                            //tukso combobox
                            comboBox2.SelectedIndex = -1;
                            //atjauno combo boxes
                            PopulateComboBox2();
                            PopulateComboBox();
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Kļūda! " + ex.Message);
            }
        }

        string databaseFilePath() //connect sqlite database to string
        {
            string exeDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string projectRootDirectory = Path.GetFullPath(Path.Combine(exeDirectory, @"..\..\..\"));
            string dbFilePath = Path.Combine(projectRootDirectory, "db", "main.db");

            string connectionString = @"data source =" + dbFilePath;

            return connectionString;
        }

        private void AtjNoliktavuBtn_Click(object sender, EventArgs e) //darbarīki noliktavā
        {
            try
            {
                using (SQLiteConnection con = new SQLiteConnection(databaseFilePath()))
                {
                    con.Open();
                    string query = "SELECT DarbaRikiID, DarbaRiks FROM DarbaRiki WHERE DarbaRikiID NOT IN (SELECT DarbaRikiID FROM IzdotieRiki)";
                    SQLiteDataAdapter da = new SQLiteDataAdapter(query, con);
                    DataTable dt = new DataTable();

                    da.Fill(dt);
                    dataGridView2.DataSource = dt;
                    con.Close();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Atgadījusies kļūda!" + ex);
            }
        }

        private void AtjIzdotieBtn_Click(object sender, EventArgs e) //izdotie darbarīki
        {
            try
            {
                using (SQLiteConnection con = new SQLiteConnection(databaseFilePath()))
                {
                    con.Open();
                    string query = "SELECT DarbaRikiID, DarbaRiks FROM IzdotieRiki";
                    SQLiteDataAdapter da = new SQLiteDataAdapter(query, con);
                    DataTable dt = new DataTable();

                    da.Fill(dt);
                    dataGridView2.DataSource = dt;
                    con.Close();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Atgadījusies kļūda!" + ex);
            }
        }

       
    }
}
