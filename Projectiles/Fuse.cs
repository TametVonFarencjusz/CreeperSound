using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.GameContent.Achievements;
using System;
using System.Collections.Generic;

namespace CreeperSound.Projectiles
{
	public class Fuse : ModProjectile //Don't know why play sound in PreUpdate don't sync
	{	
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fuse");
		}
		
		public override void SetDefaults()
		{
			projectile.width = 16;
			projectile.height = 16;
			projectile.aiStyle = 0;
			projectile.friendly = false;
			projectile.hostile = false;
			projectile.damage = 0;
			projectile.penetrate = -1;
			projectile.timeLeft = 2;
			projectile.alpha = 255;
		}
		
		public override void Kill(int timeLeft)
		{
			Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Custom/Fuse"), projectile.position);
		}
	}
}