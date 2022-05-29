using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleDemo
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void doHashButton_Click(object sender, EventArgs e)
        {
            string s = hashInputBox.Text;
            var instance = Cryptography.SafeCryptoFactory.createSodiumGenericHash();
            byte[] output = instance.hash(Encoding.UTF8.GetBytes(s));
            hashOutputBox.Text = Convert.ToBase64String(output);
        }

        private void macButton_Click(object sender, EventArgs e)
        {
            string s = macInputBox.Text;
            var instance = Cryptography.SafeCryptoFactory.createSodiumGenericMac();
            byte[] output = instance.generate(Encoding.UTF8.GetBytes(s), Encoding.UTF8.GetBytes(macKeyBox.Text));
            macOutputBox.Text = Convert.ToBase64String(output);
        }
    }
}
