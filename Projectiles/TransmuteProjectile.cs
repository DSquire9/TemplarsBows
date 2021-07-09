using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TemplarsBows.Projectiles
{
    class TransmuteProjectile : GlobalProjectile
    {
        Random rng = new Random();
        public override bool InstancePerEntity
        {
            get
            {
                return true;
            }
        }

        public override void OnHitNPC(Projectile projectile, NPC target, int damage, float knockback, bool crit)
        {
            Player player = Main.player[projectile.owner];

            // Gives projectiles fired by the Rain of Thorns a 25% chance to poison
            if (player.inventory[player.selectedItem].type == mod.ItemType("Thorns"))
            {
                if (rng.Next(4) == 3)
                {
                    target.AddBuff(BuffID.Poisoned, 240);
                }
            }
        }
    }
}
