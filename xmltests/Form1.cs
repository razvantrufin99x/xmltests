using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace xmltests
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void scriexml()
        {

            XmlWriterSettings settings = new XmlWriterSettings();
settings.Indent = true;
settings.NewLineOnAttributes = true;
XmlWriter writer = XmlWriter.Create("newbook.xml", settings);
writer.WriteStartDocument();
//Start creating elements and attributes
writer.WriteStartElement("book");
writer.WriteAttributeString("genre", "Mystery");
writer.WriteAttributeString("publicationdate", "2001");
writer.WriteAttributeString("ISBN", "123456789");
writer.WriteElementString("title", "Case of the Missing Cookie");
writer.WriteStartElement("author");
writer.WriteElementString("name", "Cookie Monster");
writer.WriteEndElement();
writer.WriteElementString("price", "9.99");
writer.WriteEndElement();
writer.WriteEndDocument();
//clean up
writer.Flush();
writer.Close();

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            XmlReader rdr = XmlReader.Create("ebooks.xml");
            while (rdr.Read())
            {
                if (rdr.NodeType == XmlNodeType.Text)
                    richTextBox1.AppendText(rdr.Value + "\r\n");
            }
            scriexml();
        }
    }
}
