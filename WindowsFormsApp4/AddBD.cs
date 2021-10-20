using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class AddBD : Form
    {
        public static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Workers.mdb;";
        private OleDbConnection myConnection;
        public AddBD()
        {
            InitializeComponent();
            // создаем экземпляр класса OleDbConnection
            myConnection = new OleDbConnection(connectString);

            // открываем соединение с БД
            myConnection.Open();
        }
        string textname;
        string position;
        string salary;

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textname = textBox1.Text;
            //textBox3.Text = position; 
            // textBox4.Text = salary;
            position = textBox2.Text;
            salary = textBox3.Text;



            // текст запроса
            string query = $@"INSERT INTO Worker (w_name, w_position, w_salary) VALUES ('{textname}', '{position}', {salary})";

            // создаем объект OleDbCommand для выполнения запроса к БД MS Access
            OleDbCommand command = new OleDbCommand(query, myConnection);

            // выполняем запрос к MS Access
            command.ExecuteNonQuery();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.Red;
            button3.BackColor = Color.DarkBlue;



        }

        private void AddBD_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
           
        }
    }
}
