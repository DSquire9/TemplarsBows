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

		public override void SetDefaults()
		{
			Item.damage = 35;
			Item.DamageType = DamageClass.Ranged;
			Item.useAmmo = AmmoID.Arrow;
			Item.shootSpeed = 7f;
			Item.noMelee = true;
			Item.width = 40;
			Item.height = 40;
			Item.scale = .85f;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 1;
			Item.crit = 4;
			Item.value = 10000;
			Item.rare = ItemRarityID.Pink;
			Item.UseSound = SoundID.Item5;
			Item.autoReuse = true;
            Item.shoot = ProjectileID.WoodenArrowFriendly;
        }

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.HallowedBar, 10);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}

		// Used to ensure bow looks natural to hold
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-3.5f, 0);
		}
	}
}
