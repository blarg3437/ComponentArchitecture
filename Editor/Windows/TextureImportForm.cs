using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Interop;

namespace Editor
{
    public partial class TextureImportForm : Form
    {
        List<Image> textures;
        public delegate void TexSelSubmit(List<Image> textures, int tsize, string layerName);
        public event TexSelSubmit Submitted;
        int TSize;
        public TextureImportForm()
        {
            InitializeComponent();
            textures = new List<Image>();
            TexSheetIn.Checked = true;
            TexSheetName.MouseClick += ClickOnName;
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            //I do not have any handling for a file that is bigger than the specified size...
            //probably handle this by creating a new image from the top left X specified size  
            Image selected;
            try
            {
                selected = Image.FromFile(TexLocation.Text);
            }
            catch (FileNotFoundException)
            {
                SystemSounds.Exclamation.Play();
                label5.Text = "!";
                return;
            }
            if (SingleTexIn.Checked)
            {               
                textures.Add(selected);
            }
            if (TexSheetIn.Checked)
            {
                

                //add a try statement or something here to handle if the boxes arent filled
                int TWidth = int.Parse(TSizeInX.Text);
                int THeight = int.Parse(TSizeInY.Text);
                TSize = TWidth;
                for (int x = 0; x < selected.Width / TWidth; x++)//here needs to be a tryparse thing to make sure they entered an integer.
                {
                    for (int y = 0; y < selected.Height / THeight; y++)
                    {
                        //you may need to add a method for creating a number for the thing to put in the array? Huh?
                        Bitmap bit = new Bitmap(TWidth, THeight);
                        Graphics g = Graphics.FromImage(bit);
                        g.DrawImage(selected, new Rectangle(0, 0, TWidth, THeight),
                            new Rectangle(x * TWidth, y * THeight, TWidth, THeight), 
                            GraphicsUnit.Pixel);
                        
                        textures.Add(bit);
                    }
                }
            }
            Submitted(textures, TSize, TexSheetName.Text);
            this.Close();
        }

        private void SingleTexIn_CheckedChanged(object sender, EventArgs e)
        {
            foreach (Control item in SizeSelPanel.Controls)
            {
                item.Enabled = false;

            }
        }

        private void TexSheetIn_CheckedChanged(object sender, EventArgs e)
        {
            foreach (Control item in SizeSelPanel.Controls)
            {
                item.Enabled = true;

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog whereto = new OpenFileDialog();
            whereto.InitialDirectory = @"C:\Users\Nicholas\Pictures";
            whereto.ShowDialog();
            TexLocation.Text = whereto.FileName;
            TexSheetName.Text = whereto.FileName;
            TexSheetName.Focus();
        }

        private void ClickOnName(object sender, EventArgs e)
        {
            TexSheetName.Text = "";
        }
    }
}
