using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TemplarsBows.Items
{
    internal class ForgottenShaft : ModItem
    {
        public override void SetDefaults()
        {
            Item.value = Item.buyPrice(gold: 5);
            Item.ResearchUnlockCount = 1;
            Item.maxStack = 9999;
            Item.rare = ItemRarityID.Yellow;
        }
    }
}
