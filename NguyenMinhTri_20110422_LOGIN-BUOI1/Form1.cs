﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace NguyenMinhTri_20110422_LOGIN_BUOI1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult dg = MessageBox.Show("You want exit ?", "Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dg == DialogResult.Yes)
                Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (studentCheck.Checked)
            {
                MY_DB db = new MY_DB();
                SqlDataAdapter adapter = new SqlDataAdapter();
                DataTable table = new DataTable();
                SqlCommand command = new SqlCommand("SELECT * FROM login WHERE username = @User AND password = @Pass", db.getConnection);
                command.Parameters.Add("@User", SqlDbType.VarChar).Value = txtUserName.Text;
                command.Parameters.Add("@Pass", SqlDbType.VarChar).Value = txtPassword.Text;
                adapter.SelectCommand = command;
                adapter.Fill(table);
                if ((table.Rows.Count > 0))
                {
                    MainForm01 main = new MainForm01();
                    main.Show();
                }
                else
                {
                    MessageBox.Show("Invalid username of password", "Login error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } else
            {
                MessageBox.Show("Login error! Please check carefully your information!!", "Login error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void lbSignUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignUpForm form = new SignUpForm();
            form.Show();
        }

        private void lbForgetPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ForgetPassword form = new ForgetPassword();
            form.Show();
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            

        }

        private HelpProvider hlpProvider;
        bool isHelp = false;
        

        
        private void Form1_Load(object sender, EventArgs e)
        {
            hlpProvider = new HelpProvider();


            hlpProvider.SetShowHelp(help_btn, true);
            hlpProvider.SetHelpString(help_btn, "Click to login");
        }

        private void help_btn_Click(object sender, EventArgs e)
        {
            isHelp = !isHelp;
            MaximizeBox = !isHelp;
            MinimizeBox = !isHelp;
        }
    }
}
