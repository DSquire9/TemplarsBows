using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace TemplarsBows.Items
{
	public class EBow : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Enchanted Bow"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			// Tooltip.SetDefault("Turns wooden arrows into jesters arrows");
		}

		public override void SetDefaults()
		{
			Item.damage = 8;
			Item.DamageType = DamageClass.Ranged;
			Item.useAmmo = AmmoID.Arrow;
			Item.shootSpeed = 4f;
			Item.noMelee = true;
			Item.width = 40;
			Item.height = 40;
			Item.scale = .85f;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 1;
			Item.crit = 5;
			Item.value = 10000;
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item5;
			Item.autoReuse = true;
			Item.shoot = ProjectileID.WoodenArrowFriendly;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.ManaCrystal, 5);
			recipe.AddIngredient(ItemID.WoodenBow, 1);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();

			// Recipe for testing, remove for final build
			Recipe tester = CreateRecipe();
			tester.AddIngredient(ItemID.DirtBlock, 1);
			tester.Register();

			// Recipe for testing, remove for final build
			Recipe testerArrow = Recipe.Create(ItemID.WoodenArrow, 50);
			testerArrow.AddIngredient(ItemID.DirtBlock, 1);
			testerArrow.Register();

			// Recipe for testing, remove for final build
			Recipe testerHArrow = Recipe.Create(ItemID.UnholyArrow, 50);
			testerHArrow.AddIngredient(ItemID.DirtBlock, 1);
			testerHArrow.Register();

		}

		// Used to turn wooden arrows int jesters arrows
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			// If the arrow that would be fired is a wooden arrow, make it a Jester's Arrow Instead
			if (type == ProjectileID.WoodenArrowFriendly)
			{
				type = ProjectileID.JestersArrow;
			}
			return base.Shoot(player, source, position, velocity, type, damage, knockback);
		}

		// Used to ensure bow looks natural to hold
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-3.5f, 0);
		}
	}
}
