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
using Terraria.Enums;
using Terraria.GameInput;
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
using Terraria.World.Generation;


namespace CreeperSound
{
	public class CreeperSound : Mod
	{
		private ModHotKey soundUseKey;
		private ModHotKey explodeOffKey;
		private ModHotKey explodeNoTileOffKey;
		
		public CreeperSound()
		{
			Properties = new ModProperties()
			{
				Autoload = true,
				AutoloadGores = true,
				AutoloadSounds = true
			};
		}
		
		public override void Load()
		{
			//if (!Main.dedServ)
			//{
			//}
			
			soundUseKey = RegisterHotKey("Taunt", Keys.Z.ToString());
			explodeOffKey = RegisterHotKey("Explode (Tile Destroy)", Keys.C.ToString());
			explodeNoTileOffKey = RegisterHotKey("Explode (No Tile Destroy)", Keys.X.ToString());
		}
		
		public override void HotKeyPressed(string name) 
		{
			if(soundUseKey.JustPressed) 
			{
				Main.LocalPlayer.GetModPlayer<CreeperPlayer>().Taunt();
            }
			
			if(explodeOffKey.JustPressed) 
			{
				Main.LocalPlayer.GetModPlayer<CreeperPlayer>().Explode();
            }
			
			if(explodeNoTileOffKey.JustPressed) 
			{
				Main.LocalPlayer.GetModPlayer<CreeperPlayer>().ExplodeNoTile();
            }
		}
	}
}