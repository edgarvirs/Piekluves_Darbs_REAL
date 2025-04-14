using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace projekta_darbs
{
    public partial class adminPage : MaterialForm
    {

        public adminPage()
        {


            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.DeepPurple800, Primary.DeepPurple600, Primary.DeepPurple400, Accent.Blue200, TextShade.WHITE);
        }

        private string DarbaRikiID;
        private string DarbaRiks;

        protected override void OnFormClosing(FormClosingEventArgs e) //make it close
        {
            e.Cancel = false;
            base.OnFormClosing(e);
        }


        private void materialButton1_Click(object sender, EventArgs e) // pievienot darbarīku
        {
            DarbaRikiID = materialTextBox1.Text;
            DarbaRiks = materialTextBox2.Text;

            try
            {
                if (String.IsNullOrEmpty(DarbaRikiID))
                {
                    MessageBox.Show("Ievadiet darbarīka ID!");
                }
                else if (String.IsNullOrEmpty(DarbaRiks))
                {
                    MessageBox.Show("Ievadiet darbarīka nosaukumu!");
                }
                else
                {
                    
                    SQLiteConnection con = new SQLiteConnection(databaseFilePath());
                    con.Open();
                    string query = "INSERT INTO DarbaRiki (DarbaRikiID, DarbaRiks) VALUES (@DarbaRikiID, @DarbaRiks)";
                    using (SQLiteCommand cmd2 = new SQLiteCommand(query, con))
                    {
                        cmd2.Parameters.AddWithValue("@DarbaRikiID", DarbaRikiID);
                        cmd2.Parameters.AddWithValue("@DarbaRiks", DarbaRiks);
                        cmd2.ExecuteNonQuery();
                    }
                    MessageBox.Show("Darbarīks tika pievienots datubāzei!");
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Atgadījusies kļūda!");
            }
        }

        private void materialButton2_Click(object sender, EventArgs e) //atsvaidzināt lapu
        {
            try
            {
           
                SQLiteConnection con = new SQLiteConnection(databaseFilePath());
                con.Open();
                string query = "SELECT * FROM DarbaRiki";
                SQLiteDataAdapter da = new SQLiteDataAdapter(query, con);
                DataTable dt = new DataTable();

                da.Fill(dt);
                dataGridView2.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Atgadījusies kļūda!");
            }
        }

        private void materialButton3_Click(object sender, EventArgs e) //noņemt darbarīku
        {
            DarbaRikiID = materialTextBox3.Text;

            try
            {
                if (String.IsNullOrEmpty(DarbaRikiID))
                {
                    MessageBox.Show("Ievadiet darbarīka ID!");
                }
                else
                {
                 
                    SQLiteConnection con = new SQLiteConnection(databaseFilePath());
                    con.Open();
                    string queryRemove = @"DELETE FROM DarbaRiki WHERE DarbaRikiID = @DarbaRikiID;
                                            UPDATE DarbaRiki
                                            SET DarbaRikiID = DarbaRikiID - 1
                                            WHERE DarbaRikiID > @DarbaRikiID;";
                    using (SQLiteCommand cmd3 = new SQLiteCommand(queryRemove, con))
                    {
                        cmd3.Parameters.AddWithValue("@DarbaRikiID", DarbaRikiID);
                        cmd3.ExecuteNonQuery();
                    }

                    MessageBox.Show("Darbarīks tika noņemts no datubāzes!");
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Atgadījusies kļūda!");
            }
        }

        private void materialButton4_Click(object sender, EventArgs e)
        {
            mainPage ShowMain = new mainPage();
            ShowMain.Show();

            this.Hide();
            this.Closed += (s, args) => Application.Exit();
        }

        string databaseFilePath() //connect sqlite database to string
        {
            string exeDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string projectRootDirectory = Path.GetFullPath(Path.Combine(exeDirectory, @"..\..\..\"));
            string dbFilePath = Path.Combine(projectRootDirectory, "db", "main.db");

            string connectionString = @"data source =" + dbFilePath;

            return connectionString;
        }
    }
}
