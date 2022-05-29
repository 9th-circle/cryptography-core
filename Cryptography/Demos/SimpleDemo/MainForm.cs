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
            var instance = Cryptography.SafeCryptoFactory.createSodiumGenericHash();
            byte[] output = instance.hash(Encoding.UTF8.GetBytes(hashInputBox.Text));
            hashOutputBox.Text = Convert.ToBase64String(output);
        }

        private void macButton_Click(object sender, EventArgs e)
        {
            var instance = Cryptography.SafeCryptoFactory.createSodiumGenericMac();
            byte[] output = instance.generate(Encoding.UTF8.GetBytes(macInputBox.Text), Encoding.UTF8.GetBytes(macKeyBox.Text));
            macOutputBox.Text = Convert.ToBase64String(output);
        }

        private void generateSaltButton_Click(object sender, EventArgs e)
        {
            var instance = Cryptography.SafeCryptoFactory.createSodiumArgonKDF();
            byte[] salt = instance.generateSalt();
            kdfSaltBox.Text = Convert.ToBase64String(salt);
        }

        private void kdfButton_Click(object sender, EventArgs e)
        {
            try
            {
                var instance = Cryptography.SafeCryptoFactory.createSodiumArgonKDF();
                byte[] salt = Convert.FromBase64String(kdfSaltBox.Text);
                byte[] output = instance.generate(Encoding.UTF8.GetBytes(kdfInputBox.Text), salt);
                if (output == null)
                    kdfOutputBox.Text = "No output.";
                else
                    kdfOutputBox.Text = Convert.ToBase64String(output);
            }
            catch(System.FormatException)
            {
                kdfOutputBox.Text = "Invalid salt format.";
            }
        }
    }
}
