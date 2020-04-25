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
	public class CreeperNoTile : ModProjectile
	{	
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Creeper's Explosion");
		}
		
		public override void SetDefaults()
		{
			projectile.width = 16;
			projectile.height = 16;
			projectile.aiStyle = 0;
			//projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.timeLeft = 2;
			projectile.alpha = 255;
		}
		
		public override void AI()
		{
			if (projectile.owner == Main.myPlayer && Main.player[projectile.owner].dead && projectile.timeLeft > 3)
			{
				projectile.timeLeft = 3;
			}
			
			if (projectile.owner == Main.myPlayer && projectile.timeLeft <= 3)
			{
				projectile.tileCollide = false;
				projectile.ai[1] = 0f;
				projectile.alpha = 255;
				projectile.friendly = true;
				projectile.hostile = true;
				//if (projectile.type == 133 || projectile.type == 134 || projectile.type == 135 || projectile.type == 136 || projectile.type == 137 || projectile.type == 138 || projectile.type == 338 || projectile.type == 339)
				{
					projectile.position.X = projectile.position.X + (float)(projectile.width / 2);
					projectile.position.Y = projectile.position.Y + (float)(projectile.height / 2);
					projectile.width = 256;
					projectile.height = 256;
					projectile.position.X = projectile.position.X - (float)(projectile.width / 2);
					projectile.position.Y = projectile.position.Y - (float)(projectile.height / 2);
					projectile.knockBack = 8f;
				}
				/*else if (projectile.type == 139 || projectile.type == 140 || projectile.type == 141 || projectile.type == 142 || projectile.type == 143 || projectile.type == 144 || projectile.type == 340 || projectile.type == 341)
				{
					projectile.position.X = projectile.position.X + (float)(projectile.width / 2);
					projectile.position.Y = projectile.position.Y + (float)(projectile.height / 2);
					projectile.width = 200;
					projectile.height = 200;
					projectile.position.X = projectile.position.X - (float)(projectile.width / 2);
					projectile.position.Y = projectile.position.Y - (float)(projectile.height / 2);
					projectile.knockBack = 10f;
				}*/
			}
		}
		
		public override void Kill(int timeLeft)
		{
			//Main.PlaySound(SoundID.Item14, projectile.position);
			switch (Main.rand.Next(4))
			{
				case 1:  Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Custom/Explode1"), projectile.position); break;
				case 2:  Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Custom/Explode2"), projectile.position); break;
				case 3:  Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Custom/Explode3"), projectile.position); break;
				default: Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Custom/Explode4"), projectile.position); break;
			}
				
			{
				projectile.position.X = projectile.position.X + (float)(projectile.width / 2);
				projectile.position.Y = projectile.position.Y + (float)(projectile.height / 2);
				projectile.width = 32;
				projectile.height = 32;
				projectile.position.X = projectile.position.X - (float)(projectile.width / 2);
				projectile.position.Y = projectile.position.Y - (float)(projectile.height / 2);
				int num4;
				for (int i = 0; i < 30; i++)
				{
					int index = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 31, 0f, 0f, 100, default(Color), 1.5f);
					Dust dust = Main.dust[index];
					dust.velocity *= 1.4f;
				}
				for (int i = 0; i < 20; i++)
				{
					int index = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, 0f, 0f, 100, default(Color), 3.5f);
					Main.dust[index].noGravity = true;
					Dust dust = Main.dust[index];
					dust.velocity *= 7f;
					index = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, 0f, 0f, 100, default(Color), 1.5f);
					dust = Main.dust[index];
					dust.velocity *= 3f;
				}
				for (int i = 0; i < 10; i++)
				{
					int index = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, 0f, 0f, 100, default(Color), 3.5f);
					Main.dust[index].noGravity = true;
					Dust dust = Main.dust[index];
					dust.velocity *= 14f;
					index = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, 0f, 0f, 100, default(Color), 1.5f);
					dust = Main.dust[index];
					dust.velocity *= 7f;
				}
				for (int i = 0; i < 4; i++)
				{
					float scaleFactor9 = 1.2f;
					if (i <= 1)
					{
						scaleFactor9 = 2.4f;
					}
					Vector2 position48 = new Vector2(projectile.position.X, projectile.position.Y);
					Vector2 vector = default(Vector2);
					int index = Gore.NewGore(position48, vector, Main.rand.Next(61, 64), 1f);
					Gore gore = Main.gore[index];
					gore.velocity *= scaleFactor9;
					Gore gore110 = Main.gore[index];
					gore110.velocity.X = gore110.velocity.X + 1f;
					Gore gore111 = Main.gore[index];
					gore111.velocity.Y = gore111.velocity.Y + 1f;
					Vector2 position49 = new Vector2(projectile.position.X, projectile.position.Y);
					vector = default(Vector2);
					index = Gore.NewGore(position49, vector, Main.rand.Next(61, 64), 1f);
					gore = Main.gore[index];
					gore.velocity *= scaleFactor9;
					Gore gore112 = Main.gore[index];
					gore112.velocity.X = gore112.velocity.X - 1f;
					Gore gore113 = Main.gore[index];
					gore113.velocity.Y = gore113.velocity.Y + 1f;
					Vector2 position50 = new Vector2(projectile.position.X, projectile.position.Y);
					vector = default(Vector2);
					index = Gore.NewGore(position50, vector, Main.rand.Next(61, 64), 1f);
					gore = Main.gore[index];
					gore.velocity *= scaleFactor9;
					Gore gore114 = Main.gore[index];
					gore114.velocity.X = gore114.velocity.X + 1f;
					Gore gore115 = Main.gore[index];
					gore115.velocity.Y = gore115.velocity.Y - 1f;
					Vector2 position51 = new Vector2(projectile.position.X, projectile.position.Y);
					vector = default(Vector2);
					index = Gore.NewGore(position51, vector, Main.rand.Next(61, 64), 1f);
					gore = Main.gore[index];
					gore.velocity *= scaleFactor9;
					Gore gore116 = Main.gore[index];
					gore116.velocity.X = gore116.velocity.X - 1f;
					Gore gore117 = Main.gore[index];
					gore117.velocity.Y = gore117.velocity.Y - 1f;
				}
			}
		}
	}
}