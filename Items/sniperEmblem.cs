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
	public class sniperEmblem : ModItem
	{
        public static bool eqiped= false;
        public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Sniper Emblem");
            Tooltip.SetDefault("Doubles Crit chances\n" +
                               "+10% Crit, +20% damage to ranged weapons\n" +
                               "+30% chance not to consume ammo\n" +
                               "but you become more vaulnerable");
		}
		public override void SetDefaults()
		{
            item.Size = new Vector2(34);
            item.value = 9003462;
            item.rare = 8;
            item.accessory = true;
            




        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.statDefense -= 15;
            player.meleeCrit = player.meleeCrit * 2;
            player.rangedCrit = player.rangedCrit * 2 + 10;
            player.rangedDamage += player.rangedDamage * 1.20f;
            player.magicCrit = player.magicCrit * 2;
            player.thrownCrit = player.thrownCrit * 2;
            eqiped = true;

        }
        public override bool ConsumeAmmo(Player player)
        {
            if (eqiped)
            {
                return Main.rand.NextFloat() >= .30f;
            }

            return true;
        }
    }
    public class playerMod : ModPlayer
    {

        

        public override void ResetEffects()
        {
            ResetVariables();
        }

        public override void UpdateDead()
        {
            ResetVariables();
        }

        private void ResetVariables()
        {
            sniperEmblem.eqiped = false;
        }

    }
}
