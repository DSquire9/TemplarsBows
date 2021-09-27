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
	public class EBow : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Enchanted Bow"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("Turns wooden arrows into jesters arrows");
		}

		public override void SetDefaults()
		{
			item.damage = 8;
			item.ranged = true;
			item.useAmmo = AmmoID.Arrow;
			item.shootSpeed = 4f;
			item.noMelee = true;
			item.width = 40;
			item.height = 40;
			item.scale = .85f;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.knockBack = 1;
			item.crit = 5;
			item.value = 10000;
			item.rare = ItemRarityID.Blue;
			item.UseSound = SoundID.Item5;
			item.autoReuse = true;
			item.shoot = ProjectileID.WoodenArrowFriendly;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.ManaCrystal, 5);
			recipe.AddIngredient(ItemID.WoodenBow, 1);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();

			// Recipe for testing, remove for final build
			ModRecipe tester = new ModRecipe(mod);
			tester.AddIngredient(ItemID.DirtBlock, 1);
			tester.SetResult(this);
			tester.AddRecipe();

			// Recipe for testing, remove for final build
			ModRecipe testerArrow = new ModRecipe(mod);
			testerArrow.AddIngredient(ItemID.DirtBlock, 1);
			testerArrow.SetResult(ItemID.WoodenArrow, 50);
			testerArrow.AddRecipe();

			// Recipe for testing, remove for final build
			ModRecipe testerHArrow = new ModRecipe(mod);
			testerHArrow.AddIngredient(ItemID.DirtBlock, 1);
			testerHArrow.SetResult(ItemID.UnholyArrow, 50);
			testerHArrow.AddRecipe();

		}

		// Used to turn wooden arrows int jesters arrows
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			// If the arrow that would be fired is a wooden arrow, make it a Jester's Arrow Instead
			if (type == ProjectileID.WoodenArrowFriendly)
			{
				type = ProjectileID.JestersArrow;
			}
			return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
		}

		// Used to ensure bow looks natural to hold
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-3.5f, 0);
		}
	}
}
