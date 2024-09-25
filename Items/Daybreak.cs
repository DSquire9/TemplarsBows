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
        public override void SetDefaults()
        {
            
        }

        public override void AddRecipes()
        {
            Recipe recipeCrim = CreateRecipe();
            Recipe recipeShad = CreateRecipe();

            recipeCrim.AddIngredient<Thorns>();
            recipeShad.AddIngredient<Thorns>();

            recipeCrim.AddIngredient<Yumi>();
            recipeShad.AddIngredient<Yumi>();

            recipeCrim.AddIngredient(ItemID.MoltenFury);
            recipeShad.AddIngredient(ItemID.MoltenFury);

            recipeCrim.AddIngredient(ItemID.TendonBow);
            recipeShad.AddIngredient(ItemID.DemonBow);

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
