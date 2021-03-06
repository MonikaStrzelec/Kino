﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace Login
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
         }

        string connection = "Data Source=35.228.52.182,1433;Network Library = DBMSSOCN; Initial Catalog =Kino;User ID = sqlserver; Password=Pa$$w0rd";

        int attempts = 3;
        int counter =600;
        
        private void Form1_Load(object sender, EventArgs e)
        {
            
           
        }

        public string HashString(string str)
        {
            SHA1CryptoServiceProvider sh = new SHA1CryptoServiceProvider();
            sh.ComputeHash(ASCIIEncoding.ASCII.GetBytes(str));
            byte[] re = sh.Hash;
            StringBuilder sb = new StringBuilder();
            foreach (byte bt in re)
                sb.Append(bt.ToString("x2"));

            return sb.ToString();

        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            #region DATABASE LOGIN CONNECTION
            try
            {
                if (string.IsNullOrWhiteSpace(textBoxLogin.Text) || string.IsNullOrWhiteSpace(textBoxPassword.Text))
                {
                    MessageBox.Show("Enter login and password");
                    textBoxLogin.Focus();
                    return;
                }
                else
                {
                    
                    SqlConnection con = new SqlConnection(connection);

                    SqlCommand cmd = new SqlCommand("SELECT id_user, login, password FROM dbo.g1_user WHERE login=@Login AND password=@password;", con);
                    cmd.Parameters.AddWithValue("@Login", textBoxLogin.Text);
                    cmd.Parameters.AddWithValue("@password", HashString(textBoxPassword.Text));

                    con.Open();

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    int count = ds.Tables[0].Rows.Count;

                    if (count == 1)
                    {
                        int id = (int)cmd.ExecuteScalar();
                        
                       

                        this.Hide();
                        MainMenu mainmenu = new MainMenu(id);
                        mainmenu.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Login failed. Check your login and password and try again");

                        attempts--;
                        label2.Visible = true;
                        textBoxLogin.Clear();
                        textBoxPassword.Clear();
                        textBox3.Clear();
                        label2.Text = "Login attempts left: " + attempts;
                  
                        if (attempts==0)
                        {
                            MessageBox.Show("You have exceeded total number of attempts");

                            label3.Visible = true;
                            timer1 = new System.Windows.Forms.Timer();
                            timer1.Interval = 1;
                            timer1.Tick += new EventHandler(Timer1_Tick);
                            timer1.Start();
                           

                            textBoxLogin.Enabled = false;
                            textBoxPassword.Enabled = false;
                            textBox3.Enabled = false;
                            buttonLogin.Enabled = false;
                            ButtonLogInWithCode.Enabled = false;
                        }

                       
                    }
                    con.Close();

                }

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
             }
            #endregion
        }


        private void ButtonLogInWithCode_Click(object sender, EventArgs e)
        {
            #region DATABASE CODE CONNECTION
            try
            {
                if (string.IsNullOrWhiteSpace(textBox3.Text))
                {
                    MessageBox.Show("Enter your code");
                    textBox3.Focus();
                    return;
                }
                else
                {

                    SqlConnection con = new SqlConnection(connection);

                    SqlCommand cmd = new SqlCommand("SELECT id_user,code FROM dbo.g1_code WHERE code=@Code;", con);
                    cmd.Parameters.AddWithValue("@Code", HashString(textBox3.Text));

                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    
                    int count = ds.Tables[0].Rows.Count;

                    if (count == 1)
                    {
                        int id = 0;
                        SqlDataReader reader;          
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                             id = (int)reader.GetValue(0);
                           
                        }


                        this.Hide();
                        MainMenu mainmenu = new MainMenu(id);
                        mainmenu.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Login failed. Check your code and try again.");
                        attempts--;
                        label2.Visible = true;
                        textBoxLogin.Clear();
                        textBoxPassword.Clear();
                        textBox3.Clear();
                        label2.Text = "Login attempts left: " + attempts;
                        if (attempts == 0)
                        {
                            MessageBox.Show("You have exceeded total number of attempts");

                            label3.Visible = true;
                            timer1 = new System.Windows.Forms.Timer();
                            timer1.Interval = 1;
                            timer1.Tick += new EventHandler(Timer1_Tick);
                            timer1.Start();

                            textBoxLogin.Enabled = false;
                            textBoxPassword.Enabled = false;
                            textBox3.Enabled = false;
                            buttonLogin.Enabled = false;
                            ButtonLogInWithCode.Enabled = false;

                        }
                            
                    }
                    con.Close();
                }

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }

            #endregion
        }

        #region NumericKeyboard
        private void Button1_Click_1(object sender, EventArgs e)
        {
            textBox3.Text = textBox3.Text + "1";

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            textBox3.Text = textBox3.Text + "2";
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            textBox3.Text = textBox3.Text + "3";
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            textBox3.Text = textBox3.Text + "4";
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            textBox3.Text = textBox3.Text + "5";
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            textBox3.Text = textBox3.Text + "6";
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            textBox3.Text = textBox3.Text + "7";
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            textBox3.Text = textBox3.Text + "8";
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            textBox3.Text = textBox3.Text + "9";
        }

        private void Button10_Click(object sender, EventArgs e)
        {
            textBox3.Text = textBox3.Text + "0";
        }
        #endregion

        private void ButtonClearCode_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
        }

        private void TextBoxPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            counter--;
            label3.Text="Try again after: "+ counter / 60 + " : " + ((counter % 60) >= 10 ? (counter % 60).ToString() : "0" + (counter % 60));

            if (counter == 0)
            {
                timer1.Stop();
                counter = 600;
                textBoxLogin.Enabled = true;
                textBoxPassword.Enabled = true;
                textBox3.Enabled = true;
                buttonLogin.Enabled = true;
                ButtonLogInWithCode.Enabled = true;
                attempts = 3;
                label2.Visible = false;
                label3.Visible = false;
            }
        }
    }
}
