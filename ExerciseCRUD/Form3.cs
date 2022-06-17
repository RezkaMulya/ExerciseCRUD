using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace ExerciseCRUD
{
    public partial class Form3 : Form
    {
        DataTable dt;
        DataRow dr;
        string code;
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'rezkaDataSet.Buku' table. You can move, or remove it, as needed.
            this.bukuTableAdapter.Fill(this.rezkaDataSet.Buku);

           

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-5LL6UN5\\REZKAMULYA;database=Rezka;User ID=sa;Password=rezka123");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Buku values (@idBuku,@Judul,@No_Rak,@penulis)", con);
            cmd.Parameters.AddWithValue("@idBuku", textCodeBuku.Text);
            cmd.Parameters.AddWithValue("@Judul", textJudul.Text);
            cmd.Parameters.AddWithValue("@No_Rak", textRak.Text);
            cmd.Parameters.AddWithValue("@penulis", textPenulis.Text);
            cmd.ExecuteNonQuery();

            con.Close();
            MessageBox.Show("data berhasil ditambahkan");
            



        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            dt = rezkaDataSet.Tables["Buku"];
            dr = dt.NewRow();
            dr[0] = textCodeBuku.Text;
            dr[1] = textJudul.Text;
            dr[2] = textRak.Text;
            dr[3] = textPenulis.Text;
            dt.Rows.Add(dr);
            bukuTableAdapter.Update(rezkaDataSet);
            textCodeBuku.Text = System.Convert.ToString(dr[0]);
            textCodeBuku.Enabled = false;
            textJudul.Enabled = false;
            textRak.Enabled = false;
            textPenulis.Enabled = false;
            this.bukuTableAdapter.Fill(this.rezkaDataSet.Buku);
            buttonAdd.Enabled = true;
            buttonSave.Enabled = false;
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            string code;
            code = textCodeBuku.Text;
            dr = rezkaDataSet.Tables["Buku"].Rows.Find(code);
            dr.Delete();
            bukuTableAdapter.Update(rezkaDataSet);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.Show();
            this.Hide();
        }
    }
}
