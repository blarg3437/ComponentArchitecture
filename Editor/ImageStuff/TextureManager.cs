using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Editor.ImageStuff
{
    class TextureManager
    {
        //The texture manager is only aware of the components it needs to modify
        Form1 parent;
        Panel TexturePanel;
        public int currentTextureData;
        public int TextureSize { get; private set; }
        public int TabSelected = 0;
        
        List<TextureSheetPage> ListOfPages;

        public TextureManager(Form1 parent)
        {
            this.parent = parent;
            TexturePanel = parent.GetTexturePicker();
            ListOfPages = new List<TextureSheetPage>();
        }
        public void AddTextureClick(object sender, EventArgs e)
        {
            TextureImportForm newwindow = new TextureImportForm();
            newwindow.Submitted += ConsumeList;            
            newwindow.Activate();
            newwindow.Show();
        }    

        public void ConsumeList(List<Image> images, int texsize, string layerName)
        {
            TextureSize = texsize;//maybe add support for different sized textures in the future
            TextureSheetPage newestPage = new TextureSheetPage(this, ListOfPages.Count == 0? 0: ListOfPages.Last().maxvalue);
            
            newestPage.consumeList(images, TexturePanel);
            
            //maybe bad practice, but who cares honestly 
            parent.GetTexturePicker().Invalidate();
            TexturePanel.Enabled = true;
            parent.GetTabControl().Visible = true;
            parent.GetTextureScrollBar().Enabled = true;





            parent.GetTabControl().TabPages.Add(new TabPage(layerName));

            //parent.GetTabControl().SelectTab(layerName);
            //this should fire off the indexchangedevent
            ListOfPages.Add(newestPage);
            parent.getMainDisplay().Enabled = true;
        }

        public void TabChangedHandler(object sender, EventArgs e)
        {
            ListOfPages[TabSelected].HideAll();
            TabControl control = (TabControl)sender;
            TabSelected = control.SelectedIndex;
            ListOfPages[TabSelected].ShowAll();
            //What I want to happen is for all images to be hidden, unless they belong to 
            //the selected index's tab, in which they will be shown
        }

        public void ScrollBarChange(object sender, EventArgs e)
        {
            TextureSheetPage selected = ListOfPages[TabSelected];
            VScrollBar scrollBar = (VScrollBar)sender;
            int yoffset = -TextureSize * (selected.heightofImageStack * scrollBar.Value) / 100;
            for (int i = selected.minvalue; i < selected.maxvalue; i++)
            {
                PictureBox item = selected.getItem(i);
                item.Location = new Point(item.Location.X, item.Location.Y - selected.oldoffset + yoffset);
            }
                
            
            selected.oldoffset = yoffset;
        }


        public Image FindMyImage(int index)
        {
            int tabId = 0;
            foreach (var item in ListOfPages)
            {
                if(index >= item.minvalue && index <= item.maxvalue)
                {
                    break;
                }
                tabId++;
            }
            //now that I have found the texturesheet I'm in, its time to find the right texture
            return ListOfPages[tabId].getItem(index).Image;
        }
    }
}
