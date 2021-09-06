﻿using System;
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

        public override void AI(Projectile projectile)
        {
            base.AI(projectile);
            Player player = Main.player[projectile.owner];
            if (player.inventory[player.selectedItem].type == mod.ItemType("FailNot"))
            {
                // Lower the projectile penetrations to 3 to reduce unfair interactions
                projectile.maxPenetrate = 5; // 5 max hits

                // Loop written by Sin Costan (https://forums.terraria.org/index.php?threads/tutorial-projectile-guide-and-implementation-tmodloader-edition.40062/)
                for (int i = 0; i < 200; i++)
                {
                    NPC target = Main.npc[i];
                    //If the npc is hostile
                    if (!target.friendly)
                    {
                        //Get the shoot trajectory from the projectile and target
                        float shootToX = target.position.X + (float)target.width * 0.5f - projectile.Center.X;
                        float shootToY = target.position.Y - projectile.Center.Y;
                        float distance = (float)System.Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));

                        //If the distance between the live targeted npc and the projectile is less than 480 pixels
                        if (distance < 480f && !target.friendly && target.active)
                        {
                            //Divide the factor, 4f, which is the desired velocity
                            distance = 4f / distance;

                            //Multiply the distance by a multiplier if you wish the projectile to have go faster
                            shootToX *= distance * 5;
                            shootToY *= distance * 5;

                            //Set the velocities to the shoot values
                            projectile.velocity.X = shootToX;
                            projectile.velocity.Y = shootToY;
                        }
                    }
                }
            }
        }
    }
}
