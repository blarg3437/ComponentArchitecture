using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _2DGame.Map
{
    class Dungeon
    {
        /*each dungeon will have a texture list that it cycles through
            * This means that when a new 'level' is loaded, the dungeon will hold onto the active texture
            * Each individual level(of which a dungeon contains a set amount), will be randomly generated
            * and will contain a map.
            * The map will have an int[] designated as the floor tiles.
            * CurrentDungeon->CurrentLevel->RandomMap->FloorLayout[]
            * */


        Level CurrentLevel;
        List<Texture2D> AvailableTextures;
        int CurrentTexture;
        int numberoflevels;
        int currentlevelnumber;//which level is this, used to track how many
        int sizeOfLevelX, sizeOfLevelY;
        int texSize;
        public Dungeon(int levelnum)
        {

            numberoflevels = levelnum;
            sizeOfLevelX = 40;
            sizeOfLevelY = 40;
            CurrentLevel = new Level(sizeOfLevelX, sizeOfLevelY);
            currentlevelnumber = 1;
            texSize = Global.TextureSize;
        }

        public void setTextures(params Texture2D[] Textures)
        {
            AvailableTextures = Textures.ToList<Texture2D>();
            CurrentTexture = 0;
        }
        public void StartNewLevel()
        {
            CurrentLevel.setMap(DungeonGenerator.GenerateNewDungeon(sizeOfLevelX, sizeOfLevelY));
        }

        public void Update()
        {

        }

        public void Draw(SpriteBatch spritebatch, int cx, int cy)
        {
            DrawMap(spritebatch, cx, cy);
        }

        private void DrawMap(SpriteBatch spritebatch, int cx, int cy)
        {

            
            for (int y = 0; y < sizeOfLevelY; y++)
            {
                for (int x = 0; x < sizeOfLevelX; x++)
                {              
                    spritebatch.Draw(AvailableTextures[CurrentTexture],
                        new Rectangle((x + cx) * texSize, (y + cy) * texSize, texSize, texSize), 
                        TileDict.GetSourceByInt(CurrentLevel.getTileAt(x,y))
                        , Color.White);
                }
            }
        }
    }
}
