using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Editor.ImageStuff
{
    class TextureSheetPage
    {
        TextureManager MyManager;
        Dictionary<int, PictureBox> itemsinholder;

        public int oldoffset;
        public int columns { get; private set; }
        public int heightofImageStack { get; private set;}
        public int minvalue{ get; private set; }
        public int maxvalue { get; private set; }
        

        public TextureSheetPage(TextureManager manager, int lastIdUsed)
        {
            MyManager = manager;            
            itemsinholder = new Dictionary<int, PictureBox>();
            minvalue = lastIdUsed + 1;
        }

        public PictureBox getItem(int key) => itemsinholder[key];

        public void consumeList(List<Image> images, Panel display)
        {

            //Loading up the itemsinHolder
            int count = minvalue;
            foreach (Image item in images)
            {
                PictureBox pb = new PictureBox();
                

                pb.Parent = display;
                pb.Size = new Size(MyManager.TextureSize, MyManager.TextureSize);
                pb.Image = item;
                pb.MouseClick += TextureClickHandler;
                itemsinholder.Add(count, pb);
                display.Controls.Add(itemsinholder[count]);
                count++;
            }
            columns = display.Width / MyManager.TextureSize;//the number of columns in this texturepanel
            DrawAllOntoPanel(display);//now we set up all the stuff
            maxvalue = count;

        }

        public void TextureClickHandler(object sender, EventArgs e)
        {
            foreach (var item in itemsinholder)
            {
                if (item.Value.Equals(sender))
                {
                    MyManager.currentTextureData = item.Key;
                    return;
                }
            }
        }

        public void DrawAllOntoPanel(Panel textureholder)
        {
            int xover = 0;
            int yover = 0;


            foreach (KeyValuePair<int, PictureBox> item in itemsinholder)
            {
                //remember these were all created with the panel as their parent
                //all this method does is set the position of the already created imageboxes
                item.Value.Location = new Point(
                    xover * MyManager.TextureSize,
                    yover * MyManager.TextureSize);

                item.Value.Show();


                if (xover % columns == 0 && xover != 0)
                {
                    xover = 0;
                    yover++;
                }
                else
                {
                    xover++;
                }
            }
            heightofImageStack = yover;
        }

        public void HideAll()
        {
            foreach (var item in itemsinholder)
            {
                item.Value.Visible = false;
            }
        }

        public void ShowAll()
        {
            foreach (var item in itemsinholder)
            {
                item.Value.Visible = true;
            }
        }
    }
}
