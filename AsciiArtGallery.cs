using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Project_Alpha_Teem;

public static class AsciiArtGallery
{
    private static Dictionary<string, string[]> artCollection = new();
    private static readonly string jsonFilePath = "ascii_art.json";

    // Static constructor that runs when the class is first accessed
    static AsciiArtGallery()
    {
        LoadArtFromJson();
    }

    private static void LoadArtFromJson()
    {
        try
        {
            if (File.Exists(jsonFilePath))
            {
                string jsonContent = File.ReadAllText(jsonFilePath);
                var loadedCollection = JsonSerializer.Deserialize<Dictionary<string, string[]>>(
                    jsonContent,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                );

                if (loadedCollection != null)
                {
                    artCollection = loadedCollection;
                    // Console.WriteLine($"Loaded {artCollection.Count} ASCII art pieces from file.");
                }
            }
            else
            {
                Console.WriteLine("ASCII art file not found. Please create ascii_art.json");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading ASCII art from JSON: {ex.Message}");
        }
    }

    public static string DisplayArt(string artName)
    {
        return artCollection.ContainsKey(artName) ? string.Join("\n", artCollection[artName]) : $"Art '{artName}' not found in the gallery.";
    }

    public static List<string> GetAvailableArtNames()
    {
        return artCollection.Keys.ToList();
    }
}