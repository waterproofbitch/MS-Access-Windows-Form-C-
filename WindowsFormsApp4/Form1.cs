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
    public partial class Form1 : Form
    {
        public static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Workers.mdb;";
        private OleDbConnection myConnection;
        public Form1()
        {
            InitializeComponent();
            // создаем экземпляр класса OleDbConnection
            myConnection = new OleDbConnection(connectString);

            // открываем соединение с БД
            myConnection.Open();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // текст запроса
            string query = "SELECT w_name FROM Worker WHERE w_id = 3";

            // создаем объект OleDbCommand для выполнения запроса к БД MS Access
            OleDbCommand command = new OleDbCommand(query, myConnection);

            // выполняем запрос и выводим результат в textBox1
            textBox1.Text = command.ExecuteScalar().ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // текст запроса
            string query = "SELECT w_name, w_position, w_salary FROM Worker ORDER BY w_salary";

            // создаем объект OleDbCommand для выполнения запроса к БД MS Access
            OleDbCommand command = new OleDbCommand(query, myConnection);

            // получаем объект OleDbDataReader для чтения табличного результата запроса SELECT
            OleDbDataReader reader = command.ExecuteReader();

            // очищаем listBox1
            listBox1.Items.Clear();

            // в цикле построчно читаем ответ от БД
            while (reader.Read())
            {
                // выводим данные столбцов текущей строки в listBox1
                listBox1.Items.Add(reader[0].ToString() + " " + reader[1].ToString() + " " + reader[2].ToString() + " ");
            }

            // закрываем OleDbDataReader
            reader.Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            myConnection.Close();
        }

        string textname;
        string position;
        string salary;



        private void button4_Click(object sender, EventArgs e)
        {
            



            // текст запроса
            string query = $@"INSERT INTO Worker (w_name, w_position, w_salary) VALUES ('{textname}', '{position}', {salary})";

            // создаем объект OleDbCommand для выполнения запроса к БД MS Access
            OleDbCommand command = new OleDbCommand(query, myConnection);

            // выполняем запрос к MS Access
            command.ExecuteNonQuery();

        }

        private void button7_Click(object sender, EventArgs e)
        {
           



        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        string DeleteBD;
        

        private void button5_Click(object sender, EventArgs e)
        {
            DeleteBD=textBox1.Text;

            // текст запроса
            string query = $"DELETE FROM Worker WHERE w_id = {DeleteBD}";

            // создаем объект OleDbCommand для выполнения запроса к БД MS Access
            OleDbCommand command = new OleDbCommand(query, myConnection);

            // выполняем запрос к MS Access
            command.ExecuteNonQuery();
        }
    }
}
