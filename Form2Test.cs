using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bachup_s_backup
{

    public partial class Form2Test : Form
    {
        List<Person> people = [
            new Person { Name = "John", Age = 25 },
            new Person { Name = "Jane", Age = 30 },
            new Person { Name = "Bob", Age = 22 }
        ];
        public Form2Test()
        {
            InitializeComponent();
        }

        private void Form2Test_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = people;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
