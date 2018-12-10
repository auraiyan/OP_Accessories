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
    public class lifeStealEmblem : ModItem
    {
        public static bool equipped = false;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lifesteal Emblem");
            Tooltip.SetDefault("20% of the damage dealt is regained as HP"
                /*+"\nShields you 10% of you maximum HP"*/);
        }
        public override void SetDefaults()
        {
            item.Size = new Vector2(34);
            item.value = 3887345;
            item.rare = 10;
            item.accessory = true;

        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            equipped = true;
        }

    }
    public class lifesteal : ModPlayer
    {



        public virtual void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            if (lifeStealEmblem.equipped && player.statLife < player.statLifeMax2)
            {
                int lifeSteal = damage / 5;
                player.statLife += lifeSteal;
                player.HealEffect(lifeSteal);
            }


        }

        public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
        {

            if (lifeStealEmblem.equipped && player.statLife < player.statLifeMax2)
            {
                int lifeSteal = damage / 5;
                player.statLife += lifeSteal;
                player.HealEffect(lifeSteal);
            }


        }
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
            lifeStealEmblem.equipped = false;
        }
    }

    


    //    public class LifeShield : ModBuff
    //{


    //    public override void SetDefaults()
    //    {
    //        DisplayName.SetDefault("Shielded");
    //        Description.SetDefault("you have a shield which prevents damage");
    //        Main.buffNoSave[Type] = true;
    //        Main.debuff[Type] = false;
    //        canBeCleared = false;
    //    }
    //}

}
