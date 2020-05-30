using Editor.MapStuff;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
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
        List<string> Directories;
        List<int> TexturesUsed;
        public TextureManager(Form1 parent)
        {
            this.parent = parent;
            TexturePanel = parent.GetTexturePicker();
            ListOfPages = new List<TextureSheetPage>();
            Directories = new List<string>();
            TexturesUsed = new List<int>();
            parent.clickedWithTex += RegisterClick;//subscribing this so we know what kind of id's are clicked
        }

        private void RegisterClick() {
            if(!TexturesUsed.Contains(currentTextureData))
                TexturesUsed.Add(currentTextureData);
        }

      
        public void AddTextureClick(object sender, EventArgs e)
        {
            TextureImportForm newwindow = new TextureImportForm();
            newwindow.Submitted += ConsumeList;          
            newwindow.Activate();
            newwindow.Show();
        }    

        public void ConsumeList(List<Image> images, int texsize, string layerName, string directory)
        {
            TextureSize = texsize;//maybe add support for different sized textures in the future
            TextureSheetPage newestPage = new TextureSheetPage(this, ListOfPages.Count == 0? 0: ListOfPages.Last().maxvalue);
            newestPage.SetDirectory(directory);
            newestPage.consumeList(images, TexturePanel);
            
            //maybe bad practice, but who cares honestly 
            parent.GetTexturePicker().Invalidate();
            TexturePanel.Enabled = true;
            parent.GetTabControl().Visible = true;
           





            parent.GetTabControl().TabPages.Add(new TabPage(layerName));

            //parent.GetTabControl().SelectTab(layerName);
            //this should fire off the indexchangedevent
            ListOfPages.Add(newestPage);
            parent.getMainDisplay().Enabled = true;
            parent.getGraphics().Clear(Color.Black);
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

        public void Save(StreamWriter stream)
        {
            stream.WriteLine();
            stream.WriteLine(TextureSize);
            stream.WriteLine(ListOfPages.Count);
            foreach (var item in ListOfPages)
            {
                stream.WriteLine(item.directory);
            }
        }

        public void Load(StreamReader reader)
        {
            reader.ReadLine();//getting past the blank spot
            TextureSize = int.Parse(reader.ReadLine());//causing trouble
            int count = int.Parse(reader.ReadLine());
            for (int i = 0; i < count; i++)//were trying to simulate a user clicking the button here
            {
                TextureImportForm temp = new TextureImportForm(reader.ReadLine(), TextureSize);
                temp.Submitted += ConsumeList;
                temp.Submit_Click(temp, new EventArgs());
                temp.Dispose();
            }
        }
        public void CreateSpriteSheet(string saveLocation)
        {
            //this method will create a sprite sheet from the textures used so far...
          
            Bitmap anewmap = new Bitmap(TexturesUsed.Count * TextureSize, TextureSize);
            Graphics g = Graphics.FromImage(anewmap);
           
        }

    }
}
