using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ChessELO_Test_Application
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChessELO.EloScore.Winner w = new ChessELO.EloScore.Winner();
            if (radioButton1.Checked)
            {
                w = ChessELO.EloScore.Winner.White;
            }
            if (radioButton2.Checked)
            {
                w = ChessELO.EloScore.Winner.Black;
            }
            if (radioButton3.Checked)
            {
                w = ChessELO.EloScore.Winner.Draw;
            }
            ChessELO.EloScore a = new ChessELO.EloScore();
            ChessELO.EloResult b = a.CalcElo(System.Convert.ToInt32(textBox1.Text),System.Convert.ToInt32(textBox2.Text), w);
            // MessageBox.Show("White Score: " + b.White.ToString() + " - Black Score: " + b.Black.ToString());
            textBox3.Text = b.White.ToString();
            textBox4.Text = b.Black.ToString();
            textBox5.Text = b.updown.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox3.Text;
            textBox2.Text = textBox4.Text;
        }
    }
}
