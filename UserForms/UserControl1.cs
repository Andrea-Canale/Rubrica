using System;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.ComponentModel.Design;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace UserForms
{
    [Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof(IDesigner))]
    public partial class UserControl1: UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        private class Contatto
        {
            public string Nome;
            public string Cognome;
            public ulong Numero;


            public XmlNode genera_contatto(XmlDocument doc)
            {
                /*
                 * 	<Contatto>
		                <nome>
			                Pippo
		                </nome>
		                <cognome>
			                Pluto
		                </cognome>
	                </Contatto>
                 */
                XmlNode contatto = doc.CreateElement("contatto");   // <contatto>
                XmlNode nome = doc.CreateElement("nome");   //<nome>
                XmlNode cognome = doc.CreateElement("cognome"); // <cognome>
                XmlNode numero = doc.CreateElement("numero");   // <numero>
                nome.InnerText = Nome;  // Pippo
                cognome.InnerText = Cognome;    // Pluto
                numero.InnerText = Numero.ToString();

                contatto.AppendChild(nome); // aggingo nome a contatto
                contatto.AppendChild(cognome);
                contatto.AppendChild(numero);

                return contatto;

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            XmlNode docNode = doc.CreateXmlDeclaration("1.0", "UTF-8", null);   // Crea XML
            doc.AppendChild(docNode);


            Contatto contatto = new Contatto(); // Crea classe contatto

            string nome = textBox1.Text;
            string cognome = textBox2.Text;

            if(nome.Length == 0 || cognome.Length == 0)
            {
                MessageBox.Show("Nome o cognome vuoti");
                return;
            }else
            {
                contatto.Nome = nome;
                contatto.Cognome = cognome;
            }

            string num = textBox3.Text;
            Regex num_reg = new Regex("^\\s*(?:\\+?(\\d{1,3}))?[-. (]*(\\d{3})[-. )]*(\\d{3})[-. ]*(\\d{4})(?: *x(\\d+))?\\s*$");
            if (num_reg.IsMatch(num))
            {
                contatto.Numero = Convert.ToUInt64(num);
            }else
            {
                MessageBox.Show("Il numero è invalido");
                return;
            }



            try
            {
                if (!File.Exists("rubrica.xml"))
                {
                    XmlNode productsNode = doc.CreateElement("rubrica");    // Inizializzo la rubrica
                    productsNode.AppendChild(contatto.genera_contatto(doc));    // Aggiunge il contatto alla rubrica
                    doc.AppendChild(productsNode);
                    doc.Save("rubrica.xml");
                }
                else
                {
                    doc.Load("rubrica.xml");    // Carica la rubrica
                    XmlNode node = doc.SelectSingleNode("/rubrica");    // Prende i dati da rubrica
                    node.AppendChild(contatto.genera_contatto(doc));    // Aggiunge un nuovo contatto
                    doc.Save("rubrica.xml");
                }
                MessageBox.Show("Inserimento riuscito");
                Dispose();
            }catch
            {
                MessageBox.Show("Errore durante l'inserimento");
            }

        }
    }
}
