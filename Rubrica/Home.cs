using System;
using System.Windows.Forms;
using System.Xml;
using Rubrica.FileWatcherRubrica;

namespace Rubrica
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
            FIleWatcher fw = new FIleWatcher();
            fw.CreateFileWatcher("./", dataGridView1);
            var griglia = new Griglia.Griglia();
            griglia.CreateFirstGrid(dataGridView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Aggiungi().Show();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void DataGridView1_RowStateChanged(Object sender, DataGridViewRowStateChangedEventArgs e)
        {

            System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
            messageBoxCS.AppendFormat("{0} = {1}", "Row", e.Row);
            messageBoxCS.AppendLine();
            messageBoxCS.AppendFormat("{0} = {1}", "StateChanged", e.StateChanged);
            messageBoxCS.AppendLine();
            MessageBox.Show(messageBoxCS.ToString(), "RowStateChanged Event");
        }
    }
}
