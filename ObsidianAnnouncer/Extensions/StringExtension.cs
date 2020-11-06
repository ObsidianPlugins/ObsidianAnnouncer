using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ObsidianAnnouncer.Extensions
{
    public static class StringExtension
    {
        //https://github.com/Naamloos/Obsidian/blob/9cc9177a476d76a930806c50ffe8c19e3329f1c8/Obsidian/Util/Extensions/Extensions.cs#L19
        public static readonly Regex pattern = new Regex(@"[A-Z]{2,}(?=[A-Z][a-z]+[0-9]*|\b)|[A-Z]?[a-z]+[0-9]*|[A-Z]|[0-9]+");

        //https://github.com/Naamloos/Obsidian/blob/9cc9177a476d76a930806c50ffe8c19e3329f1c8/Obsidian/Util/Extensions/Extensions.cs#L69
        public static string ToSnakeCase(this string str) => string.Join("_", pattern.Matches(str)).ToLower();
    }
}
