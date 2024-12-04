using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.IO.Ports;

namespace Nivel_de_lluvia
{
    public partial class Form1 : Form
    {
        private SerialPort serialPort;
        private bool isBlinking;
        private SoundPlayer soundPlayer;
        public Form1()
        {
            InitializeComponent();
            serialPort = new SerialPort("COMO3", 9600);
            serialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
            button1.Click += button1_Click;
            timer1.Interval = 500;
            timer1.Tick += timer1_Tick;
            soundPlayer = new SoundPlayer();
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (serialPort.IsOpen)
            {
                serialPort.Close();
            }
        }

        void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            string data = serialPort.ReadLine();
            this.Invoke(new Action(() =>
            {
                label1.Text = "Sensor Status:" + (data.Trim() == "o" ? "Water Detected" : "No Water");
                if (data.Trim() == "o")
                {
                    if (!isBlinking)
                    {
                        timer1.Start();
                        soundPlayer.PlayLooping();
                        pictureBox1.BackColor = System.Drawing.Color.Red;
                        isBlinking = true;
                    }
                }
                else
                {
                    if (isBlinking)
                    {
                        soundPlayer.Stop();
                        pictureBox1.BackColor = System.Drawing.Color.Gray;
                        isBlinking = false;
                    }
                }
            }));
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            serialPort.Close();
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.BackColor = pictureBox1.BackColor == System.Drawing.Color.Gray ?
            System.Drawing.Color.Yellow : System.Drawing.Color.Gray;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
