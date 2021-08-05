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
    class FailNot : ModItem
    {
		/// <summary>
		/// This bow is made to be an equivilent to Excalibur. It's name comes from Arthurian Legend and the archer Tristan.
		/// </summary>
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fail-not"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("Arrows home on the nearest enemy");
		}

		public override void SetDefaults()
		{
			item.damage = 35;
			item.ranged = true;
			item.useAmmo = AmmoID.Arrow;
			item.shootSpeed = 7f;
			item.noMelee = true;
			item.width = 40;
			item.height = 40;
			item.scale = .85f;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.knockBack = 1;
			item.crit = 4;
			item.value = 10000;
			item.rare = ItemRarityID.Pink;
			item.UseSound = SoundID.Item5;
			item.autoReuse = true;
			item.shoot = ProjectileID.WoodenArrowFriendly;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.HallowedBar, 10);
			recipe.AddTile(TileID.MythrilAnvil);
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
