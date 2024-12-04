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

namespace Humedad_y_Temperatura
{
    public partial class Form1 : Form
    {
        SerialPort serialPort;
        bool puertoCerrado = false;
        public Form1()
        {
            InitializeComponent();
            serialPort = new SerialPort();
            serialPort.PortName = "COM3";
            serialPort.BaudRate = 9600;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (puertoCerrado == false)
            {
                conectar();
            }
            else
            {
                noConectado();
            }
        }
        private void conectar()
        {
            try
            {
                puertoCerrado = true;
                serialPort.Open();
                button1.BackColor = Color.Black;
                button1.Text = "DESCONECTAR";
                serialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
            }
            catch (Exception Error)
            {
                MessageBox.Show(Error.Message);
            }
        }
        private void noConectado()
        {
            try
            {
                puertoCerrado = false;
                serialPort.Close();
                button1.Text = "CONECTAR";
                button1.BackColor = Color.Plum;
                listBox1.Items.Clear();
                temperaturaLabel.Text = "TEMPERATURA °C";
                humedadLabel.Text = "HUMEDAD%";
            }
            catch (Exception Error)
            {
                MessageBox.Show(Error.Message);
            }
        }
        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            string data = serialPort.ReadLine();
            this.Invoke(new MethodInvoker(delegate
            {
                string[] values = data.Split('\t');
                if (values.Length == 2)
                {
                    temperaturaLabel.Text = values[1];
                    humedadLabel.Text = values[0];
                    listBox1.Items.Add(values[1] + "  " + values[0]);
                }
            }));
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
    }

    


