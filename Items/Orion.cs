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
    internal class Orion : ModItem
    {
        public override void SetDefaults()
        {

            Item.DefaultToBow(19, 10.5f, true);
            Item.rare = ItemRarityID.LightRed;
            Item.damage = 48;
            Item.knockBack = 3;
            Item.crit = 6;
            Item.useTime = Item.useAnimation / 2;
            Item.consumeAmmoOnLastShotOnly = true;
            Item.reuseDelay = 16;
            Item.value = Item.buyPrice(gold: 2, silver: 80);
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();

            recipe.AddIngredient<TrueDaybreak>();
            recipe.AddIngredient<TrueFailNot>();
            //recipe.AddIngredient<ForgottenShaft>();

            recipe.AddTile(TileID.MythrilAnvil);

            recipe.Register();
        }

        // Used to ensure bow looks natural to hold
        public override Vector2? HoldoutOffset()
        {
            // TODO : Change for non-placeholder art
            return new Vector2(-3.5f, 0);
        }
    }
}
