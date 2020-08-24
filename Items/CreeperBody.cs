using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;
using Terraria.Localization;

namespace CreeperSound.Items
{
	[AutoloadEquip(EquipType.Body)]
	public class CreeperBody : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Creeper Vest");
	
			DisplayName.AddTranslation(GameCulture.German, "Kriecherweste");
			DisplayName.AddTranslation(GameCulture.Italian, "Panciotto da ragno");
			DisplayName.AddTranslation(GameCulture.French, "Gilet de Creeper");
			DisplayName.AddTranslation(GameCulture.Spanish, "Chaleco de criatura");
			DisplayName.AddTranslation(GameCulture.Russian, "Жилет ползуна");
			DisplayName.AddTranslation(GameCulture.Chinese, "苦力怕馬甲");
			DisplayName.AddTranslation(GameCulture.Portuguese, "Colete de Creeper");
			DisplayName.AddTranslation(GameCulture.Polish, "Kamizelka pełzaka");
		}

		public override void SetDefaults()
		{
			item.width = 14;
			item.height = 18;
			item.value = Item.sellPrice(0, 0, 60, 0);
			item.rare = 0;
			item.vanity = true;
		}
	
		public override bool DrawBody()
        {
            return false;
        }

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.CreeperShirt, 1);
			recipe.SetResult(this);
			recipe.AddRecipe();
			
			ModRecipe recipe2 = new ModRecipe(mod);
			recipe2.AddIngredient(this, 1);
			recipe2.SetResult(ItemID.CreeperShirt);
			recipe2.AddRecipe();
		
			
			ModRecipe recipe4 = new ModRecipe(mod);
			recipe4.AddIngredient(ItemID.Grenade, 1);
			recipe4.AddIngredient(ItemID.Bomb, 1);
			recipe4.AddIngredient(ItemID.Dynamite, 1);;
			recipe4.SetResult(ItemID.CreeperMask);
			recipe4.AddRecipe();
			
			ModRecipe recipe3 = new ModRecipe(mod);
			recipe3.AddIngredient(ItemID.Grenade, 1);
			recipe3.AddIngredient(ItemID.Bomb, 1);
			recipe3.AddIngredient(ItemID.Dynamite, 1);
			recipe3.SetResult(ItemID.CreeperShirt);
			recipe3.AddRecipe();
			
			ModRecipe recipe5 = new ModRecipe(mod);
			recipe5.AddIngredient(ItemID.Grenade, 1);
			recipe5.AddIngredient(ItemID.Bomb, 1);
			recipe5.AddIngredient(ItemID.Dynamite, 1);
			recipe5.SetResult(ItemID.CreeperPants);
			recipe5.AddRecipe();
			
			ModRecipe recipe6 = new ModRecipe(mod);
			recipe6.AddIngredient(ItemID.Grenade, 1);
			recipe6.AddIngredient(ItemID.Bomb, 1);
			recipe6.AddIngredient(ItemID.Dynamite, 1);
			recipe6.SetResult(this);
			recipe6.AddRecipe();
		}
	}
}