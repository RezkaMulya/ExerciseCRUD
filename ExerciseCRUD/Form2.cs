using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ExerciseCRUD
{

    public partial class Form2 : Form
    {
        DataTable dt;
        DataRow dr;
        string code;
        public Form2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'rezkaDataSet.Peminjam' table. You can move, or remove it, as needed.
            this.peminjamTableAdapter.Fill(this.rezkaDataSet.Peminjam);

            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-5LL6UN5\\REZKAMULYA;database=Rezka;User ID=sa;Password=rezka123");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Peminjam values (@idPeminjam,@Nama,@Jeniskelamin,@Alamat,@No_Telpon)", con);
            cmd.Parameters.AddWithValue("@idPeminjam", textCode.Text);
            cmd.Parameters.AddWithValue("@Nama", textNama.Text);
            cmd.Parameters.AddWithValue("@JenisKelamin", textJK.Text);
            cmd.Parameters.AddWithValue("@Alamat", textAlamat.Text);
            cmd.Parameters.AddWithValue("@No_Telpon", textTelp.Text);
            cmd.ExecuteNonQuery();

            con.Close();
            MessageBox.Show("data berhasil ditambahkan");


        }

        private void buttonSave_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection("Data Source=DESKTOP-5LL6UN5\\REZKAMULYA;database=Rezka;User ID=sa;Password=rezka123");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Peminjam values (@idPeminjam,@Nama,@Jeniskelamin,@Alamat,@No_Telpon)", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("data berhasil diupdate");
            con.Close();
            

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            string code;
            code = textCode.Text;
            dr = rezkaDataSet.Tables["Peminjam"].Rows.Find(code);
            dr.Delete();
            peminjamTableAdapter.Update(rezkaDataSet);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.Show();
            this.Hide();
        }
    }
}
