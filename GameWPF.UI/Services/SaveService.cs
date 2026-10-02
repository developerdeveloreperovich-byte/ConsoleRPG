using GameWPF.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.IO;
using GameWPF.Core.Models;

namespace GameWPF.UI.Services
{
    internal class SaveService
    {
        public SaveService()
        {
            
        }
        public static void SaveProgress(SaveData saveData)
        {
            string saveDirectory = GetSaveDirectory();
            Directory.CreateDirectory(saveDirectory);

            string filePath = Path.Combine(saveDirectory, "save.json");
            string jsonString = JsonSerializer.Serialize(saveData, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, jsonString);
        }

        public static SaveData? LoadProgress()
        {
            string filePath = Path.Combine(GetSaveDirectory(), "save.json");

            if (!File.Exists(filePath))
                return null;

            string jsonString = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<SaveData>(jsonString);
        }

        private static string GetSaveDirectory()
        {
            return Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "GameWPF");
        }
        
    }
}
