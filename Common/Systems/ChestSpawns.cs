using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using TemplarsBows.Items;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TemplarsBows.Common.Systems
{
    class ChestSpawns : ModSystem
    {
        public override void PostWorldGen()
        {
            Dictionary<int,string> dungeonLoot = new Dictionary<int, string>
            {
                { 113, "Magic Missile"},
                { 155, "Muramasa"},
                { 156, "Cobalt Shield"},
                { 157, "Aqua Scepter"},
                { 163, "Blue Moon"},
                { 164, "Handgun"},
                { 3317, "Valor"}
            };
            int amountToPlace = 4;
            for (int chestIndex = 0; chestIndex < 1000; chestIndex++)
            {
                Chest chest = Main.chest[chestIndex];
                int[] itemsToPlaceInChests = { ModContent.ItemType<Yumi>() };

                // X * 36 represents the chest type
                if (chest != null && Main.tile[chest.x, chest.y].TileType == TileID.Containers && dungeonLoot.ContainsKey(chest.item[0].type))
                {
                    for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
                    {
                        if (chest.item[inventoryIndex].type == ItemID.None)
                        {
                            chest.item[inventoryIndex].SetDefaults(itemsToPlaceInChests[0]); // fills empty slot with item
                            chest.item[inventoryIndex].stack = 1; // sets amount in slot
                            amountToPlace--;
                            break;
                        }
                    }
                    if (amountToPlace == 0) { break; }
                }
            }


            base.PostWorldGen();
        }
    }
}
