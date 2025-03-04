﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIPapyru
{
    /// <summary>
    /// 资产保存类
    /// </summary>
    public static class AssetPreservation
    {
        public static string SavePath = "APIPapyru/Assets/";
        public static string SavePath_Iamge = "APIPapyru/Assets/Images/";
        public static Asset<Texture2D> Perlin;
        public static Dictionary<int, Asset<Texture2D>> Extra;
        public static void Load()
        {
            Perlin = ModContent.Request<Texture2D>(SavePath_Iamge + "Perlin");
            AddExtra();
        }
        private static void AddExtra()
        {
            Extra = new();
            int i = 0;
            while (true)
            {
                if (ModContent.HasAsset(SavePath_Iamge + "Extra_" + i))
                    Extra.Add(i, ModContent.Request<Texture2D>(SavePath_Iamge + "Extra_" + i));
                else
                    break;
            }
        }
        public static void UnLood()
        {
            Perlin = null;

            Extra.Clear();
            Extra = null;
        }
    }
}
