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
    class Yumi : ModItem
    {
        /// <summary>
		/// This bow is made to be an equivilent to Muramasa. It's name comes from the asymmetrical model of bows used during the same era.
		/// </summary>
        /// 

        public override void SetDefaults() {
        
        }

        public override Vector2? HoldoutOffset()
        {
            // TODO : Change for non-placeholder art
            return new Vector2(-3.5f, 0);
        }
    }
}
