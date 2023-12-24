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
    class Daybreak : ModItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("TODO");
        }

        public override void SetDefaults()
        {
            
        }

        public override void AddRecipes()
        {
            Recipe recipeCrim = CreateRecipe();
            Recipe recipeShad = CreateRecipe();

            recipeCrim.AddIngredient<Thorns>(1);
            recipeShad.AddIngredient<Thorns>(1);

            // Dungeon Sword Equiv
            //recipeCrim.AddIngredient();
            //recipeShad.AddIngredient();

            recipeCrim.AddIngredient(ItemID.MoltenFury, 1);
            recipeShad.AddIngredient(ItemID.MoltenFury, 1);

            recipeCrim.AddIngredient(ItemID.TendonBow, 1);
            recipeShad.AddIngredient(ItemID.DemonBow, 1);

            recipeCrim.AddTile(TileID.DemonAltar);
            recipeShad.AddTile(TileID.DemonAltar);
        }

        // Used to ensure bow looks natural to hold
        public override Vector2? HoldoutOffset()
        {
            // TODO : Change for non-placeholder art
            return new Vector2(-3.5f, 0);
        }
    }
}
