using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace OP_Accessories.Sprites
{
	public class speedEmblem : ModItem
	{
        public float speed = 0.45f;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Speed Emblem");
			Tooltip.SetDefault("Increases physical Speed by 35%. \n" +
                "Melee speed by 15%.\n" +
                "Tool speed by 50% \n" +
                "Massivly increases projectile and throwing damage\n" +
                "Grants rapid placement speed and reach");
		}
		public override void SetDefaults()
		{
            item.Size = new Vector2(34);
            item.value = 4562445;
			item.rare = 8;
            item.accessory = true;
            
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {

            player.maxRunSpeed += player.maxRunSpeed * speed;
            player.moveSpeed += player.moveSpeed * speed;
            player.maxFallSpeed += player.maxFallSpeed * speed;
            player.accRunSpeed += player.accRunSpeed  * speed;
            player.toolTime -= (player.toolTime * 50)/100;
            player.meleeSpeed += player.meleeSpeed * 0.15f;
            player.thrownVelocity += player.thrownVelocity * 0.30f;
            player.thrownDamage += player.thrownDamage * 4f;
            player.thrownCrit += player.thrownCrit * 2;
            player.bulletDamage += player.bulletDamage * 3;
            player.arrowDamage += player.arrowDamage * 3;
            player.tileSpeed += player.tileSpeed * 0.45f;
            player.wallSpeed += player.wallSpeed * 0.45f;
            player.blockRange += 10;

        }
              
	}
}
