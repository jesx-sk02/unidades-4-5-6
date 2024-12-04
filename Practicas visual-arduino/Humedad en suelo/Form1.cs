using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;


namespace Humedad_en_suelo
{
    public partial class Form1 : Form
    {
        SerialPort serialPort;
        Timer timer;
        public Form1()
        {
            InitializeComponent();
            serialPort = new SerialPort("COM6", 9600);
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += timer1_Tick;
            buttonStop.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (!serialPort.IsOpen) 
           {
                serialPort.Open();
            }
            timer.Start();
            buttonStart.Enabled = false; 
            buttonStop.Enabled = true;
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            timer.Stop();
            if (serialPort.IsOpen)
            {
                serialPort.Close();
            }
            buttonStart.Enabled = true;
            buttonStop.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (serialPort.IsOpen)
            {
                try
                {
                    string data = serialPort.ReadLine();
                    DisplayData(data.Trim());
                    listBox1.Items.Add(data);
                }
                catch (TimeoutException) { }
            }
        }
        private void DisplayData(string data)
        {
            int humidity;
            if (int.TryParse(data, out humidity))
            {
                labelHumidity.Text = "Lectura: " + humidity;
                string estado;
                if (humidity >= 0 && humidity <= 300)
                {
                    estado = "Sensor en suelo seco";
                }
                else if (humidity > 300 && humidity <= 700)
                {
                    estado = "Sensor en suelo húmedo";
                }
                else
                {
                    estado = "Sensor en agua";
                }
                labelStatus.Text = "Estado: " + estado;
            }
        }
    }
}
