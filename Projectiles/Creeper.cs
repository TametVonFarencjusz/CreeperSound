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
	public class Creeper : ModProjectile
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
			
			{
				int explosionRadius = 8;
				int minTileX = (int)(projectile.position.X / 16f - (float)explosionRadius);
				int maxTileX = (int)(projectile.position.X / 16f + (float)explosionRadius);
				int minTileY = (int)(projectile.position.Y / 16f - (float)explosionRadius);
				int maxTileY = (int)(projectile.position.Y / 16f + (float)explosionRadius);
				if (minTileX < 0) {
					minTileX = 0;
				}
				if (maxTileX > Main.maxTilesX) {
					maxTileX = Main.maxTilesX;
				}
				if (minTileY < 0) {
					minTileY = 0;
				}
				if (maxTileY > Main.maxTilesY) {
					maxTileY = Main.maxTilesY;
				}
				bool canKillWalls = false;
				for (int x = minTileX; x <= maxTileX; x++) {
					for (int y = minTileY; y <= maxTileY; y++) {
						float diffX = Math.Abs((float)x - projectile.position.X / 16f);
						float diffY = Math.Abs((float)y - projectile.position.Y / 16f);
						double distance = Math.Sqrt((double)(diffX * diffX + diffY * diffY));
						if (distance < (double)explosionRadius && Main.tile[x, y] != null && Main.tile[x, y].wall == 0) {
							canKillWalls = true;
							break;
						}
					}
				}
				for (int i = minTileX; i <= maxTileX; i++) {
					for (int j = minTileY; j <= maxTileY; j++) {
						float diffX = Math.Abs((float)i - projectile.position.X / 16f);
						float diffY = Math.Abs((float)j - projectile.position.Y / 16f);
						double distanceToTile = Math.Sqrt((double)(diffX * diffX + diffY * diffY));
						if (distanceToTile < (double)explosionRadius) {
							bool canKillTile = true;
							if (Main.tile[i, j] != null && Main.tile[i, j].active()) {
								canKillTile = true;
								if (Main.tileDungeon[(int)Main.tile[i, j].type] || Main.tile[i, j].type == 88 || Main.tile[i, j].type == 21 || Main.tile[i, j].type == 26 || Main.tile[i, j].type == 107 || Main.tile[i, j].type == 108 || Main.tile[i, j].type == 111 || Main.tile[i, j].type == 226 || Main.tile[i, j].type == 237 || Main.tile[i, j].type == 221 || Main.tile[i, j].type == 222 || Main.tile[i, j].type == 223 || Main.tile[i, j].type == 211 || Main.tile[i, j].type == 404) {
									canKillTile = false;
								}
								if (!Main.hardMode && Main.tile[i, j].type == 58) {
									canKillTile = false;
								}
								if (!TileLoader.CanExplode(i, j)) {
									canKillTile = false;
								}
								if (canKillTile) {
									WorldGen.KillTile(i, j, false, false, false);
									if (!Main.tile[i, j].active() && Main.netMode != 0) {
										NetMessage.SendData(17, -1, -1, null, 0, (float)i, (float)j, 0f, 0, 0, 0);
									}
								}
							}
							if (canKillTile) {
								for (int x = i - 1; x <= i + 1; x++) {
									for (int y = j - 1; y <= j + 1; y++) {
										if (Main.tile[x, y] != null && Main.tile[x, y].wall > 0 && canKillWalls && WallLoader.CanExplode(x, y, Main.tile[x, y].wall)) {
											WorldGen.KillWall(x, y, false);
											if (Main.tile[x, y].wall == 0 && Main.netMode != 0) {
												NetMessage.SendData(17, -1, -1, null, 2, (float)x, (float)y, 0f, 0, 0, 0);
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
	}
}