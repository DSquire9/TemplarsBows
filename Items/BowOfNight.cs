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
    class BowOfNight : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("TODO");
        }

        public override void SetDefaults()
        {
            ModRecipe recipeCrim = new ModRecipe(mod);
            ModRecipe recipeShad = new ModRecipe(mod);


        }

        public override void AddRecipes()
        {
            
        }

        // Used to ensure bow looks natural to hold
        public override Vector2? HoldoutOffset()
        {
            // TODO : Change for non-placeholder art
            return new Vector2(-3.5f, 0);
        }
    }
}
