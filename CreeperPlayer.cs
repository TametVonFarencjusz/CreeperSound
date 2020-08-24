using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ReLogic.Utilities;

using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.GameContent;
using Terraria.GameContent.Achievements;
using Terraria.GameContent.Events;
using Terraria.GameContent.Tile_Entities;
using Terraria.GameContent.UI;
using Terraria.GameInput;
using Terraria.Graphics.Capture;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.IO;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ModLoader.Default;
using Terraria.ModLoader.Exceptions;
using Terraria.ModLoader.IO;
using Terraria.ObjectData;
using Terraria.Social;
using Terraria.UI;
using Terraria.UI.Chat;
using Terraria.UI.Gamepad;
using Terraria.Utilities;
using Terraria.World.Generation;

namespace CreeperSound
{
	public class CreeperPlayer: ModPlayer
	{
		public int explodeCountdown = -1;
		public bool explodeTile = false;
		public bool  explodeFuse = false;
		
		private bool IsCreeper ()
		{
			if ((player.armor[10].type == 1746 || player.armor[0].type == 1746) 
				&& (player.armor[11].type == 1747 || player.armor[1].type == 1747 || player.armor[1].type == ItemType<Items.CreeperBody>() || player.armor[11].type == ItemType<Items.CreeperBody>()) 
				&& (player.armor[12].type == 1748 || player.armor[2].type == 1748))
			return true;
			return false;
		}
		
		public override bool PreKill(double damage, int hitDirection, bool pvp, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
		{
			if (IsCreeper())
			{
				playSound = false;
				Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Custom/Death"), player.position);
			}
			return base.PreKill(damage, hitDirection, pvp, ref playSound, ref genGore, ref damageSource);
		}

		public override bool PreHurt (bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
		{
			if (IsCreeper())
			{
				playSound = false;
				switch (Main.rand.Next(4))
				{
					case 1:  Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Custom/Hit1"), player.position); break;
					case 2:  Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Custom/Hit2"), player.position); break;
					case 3:  Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Custom/Hit3"), player.position); break;
					default: Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Custom/Hit4"), player.position); break;
				}
			}
			return base.PreHurt(pvp, quiet, ref damage, ref hitDirection, ref crit, ref customDamage, ref playSound, ref genGore, ref damageSource);
		}
		 
		public override void PreUpdate() 
		{
			if (explodeFuse)
			{
				//Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Custom/Fuse"), player.position);  //Don't work online and I don't know why (PreUpdate don't sync sounds?)
				Projectile.NewProjectile(player.position,new Vector2(0,0), ProjectileType<Projectiles.Fuse>(), 0, 0, player.whoAmI, 0, 1); 
				explodeFuse = false;
			}				
			if (explodeCountdown > 0) --explodeCountdown;
			if (explodeCountdown == 0 && !player.dead) 
			{
				if (explodeTile) Projectile.NewProjectile(player.position,new Vector2(0,0), ProjectileType<Projectiles.Creeper>(), 250, 5, player.whoAmI, 0, 1); 
				if(!explodeTile) Projectile.NewProjectile(player.position,new Vector2(0,0), ProjectileType<Projectiles.CreeperNoTile>(), 250, 5, player.whoAmI, 0, 1); 
				player.statLife = 1;
				explodeTile = false;
				explodeCountdown = -1;
			}
		}
		
		public void Taunt() 
		{
			if (IsCreeper())
			{
				if (explodeCountdown > 0)
				{
					explodeCountdown = -1;
				}
				else
				explodeFuse = true;
			}
		}
		
		public void Explode() 
		{
			if (IsCreeper())
			{
				explodeCountdown = 120;
				explodeTile = true;
				explodeFuse = true;
			}
		}		
		
		public void ExplodeNoTile() 
		{
			if (IsCreeper())
			{
				explodeCountdown = 120;
				explodeTile = false;
				explodeFuse = true;
			}
		}
	}
}