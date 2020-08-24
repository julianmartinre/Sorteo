using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.AccessControl;
using System.IO;

namespace Sorteo
{
    public partial class Form1 : Form
    {

        List<string> alumnos = new List<string>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        public void cargarAlumnos()
        {
            try
            {
                StreamReader sr = new StreamReader("D:\\sorteo.txt");
                string line = sr.ReadLine();
                while (line != null)
                {
                    Console.WriteLine(line);
                    line = sr.ReadLine();
                    if (line != null)
                    {
                        alumnos.Add(line);
                    }
                }
                sr.Close();
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message.ToString());
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            cargarAlumnos();
            listBox1.Items.Clear();      
            var seed = Environment.TickCount;
            var random = new Random(seed);
            var cantidad = alumnos.Count;

            for (int i = 1; i <= cantidad; i++)
            {
                var value = random.Next(1, alumnos.Count);
                listBox1.Items.Add(alumnos[value - 1]);
                alumnos.RemoveAt(value - 1);
            }
        }
    }
}
