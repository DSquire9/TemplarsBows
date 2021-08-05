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
    class Thorns : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rain of Thorns"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("Has a chance to poison enemies");
        }

		public override void SetDefaults()
		{
			item.damage = 26;
			item.ranged = true;
			item.useAmmo = AmmoID.Arrow;
			item.shootSpeed = 7f;
			item.noMelee = true;
			item.width = 40;
			item.height = 40;
			item.scale = .85f;
			item.useTime = 22;
			item.useAnimation = 22;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.knockBack = 1;
			item.crit = 4;
			item.value = 10000;
			item.rare = ItemRarityID.Blue;
			item.UseSound = SoundID.Item5;
			item.autoReuse = false;
			item.shoot = ProjectileID.WoodenArrowFriendly;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.JungleSpores, 12);
			recipe.AddIngredient(ItemID.Stinger, 10);
			recipe.AddIngredient(ItemID.Vine, 3);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		// Used to ensure bow looks natural to hold
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-3.5f, 0);
		}


	}
}
