using Obsidian.API;
using Obsidian.API.Plugins.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ObsidianAnnouncer
{
    public static class Globals
    {
        public static ILogger Logger { get; set; }
        public static IFileReader FileReader { get; set; }
        public static IFileWriter FileWriter { get; set; }


       
        //Key = color name, Value = color code
        public readonly static Dictionary<string, string> Colors = new Dictionary<string, string>()
        {
            ["black"] = "0",
            ["dark_blue"] = "1",
            ["dark_green"] = "2",
            ["dark_aqua"] = "3",
            ["dark_red"] = "4",
            ["dark_purple"] = "5",
            ["gold"] = "6",
            ["gray"] = "7",
            ["dark_gray"] = "8",
            ["blue"] = "9",
            ["green"] = "a",
            ["aqua"] = "b",
            ["red"] = "c",
            ["light_purple"] = "d",
            ["yellow"] = "e",
            ["white"] = "f",
            ["bold"] = "l",
            ["reset"] = "r"
        };
    }
}
