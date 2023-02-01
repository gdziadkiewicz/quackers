﻿using System;
using Pastel;
using static Quackers.TestLogger.ConsoleColors;

namespace Quackers.TestLogger
{
    public static class StringColorExtensions
    {
        public static bool DisableColor { get; set; } = false;
        
        private static ITheme Theme =>
            _theme ??= DetermineTheme();

        public static string ThemeName { get; set; } = "default";

        private static ITheme DetermineTheme()
        {
            var themeName = ThemeName ?? "default";
            Console.WriteLine($"--- using theme: {ThemeName} ---"); 
            var result = themeName.Equals("darker", StringComparison.OrdinalIgnoreCase)
                ? new DarkerTheme() as ITheme
                : new DefaultTheme();
            Console.WriteLine($"Resolved theme: {result.GetType().Name}");
            return result;
        }

        private static ITheme _theme;

        public static string Fail(this string str)
        {
            return DisableColor
                ? str
                : str.Pastel(Theme.Fail);
        }

        public static string Pass(this string str)
        {
            return DisableColor
                ? str
                : str.Pastel(Theme.Pass);
        }

        public static string StackTrace(this string str)
        {
            return DisableColor
                ? str
                : str.Pastel(Theme.StackTrace);
        }

        public static string Error(this string str)
        {
            return DisableColor
                ? str
                : str.Pastel(Theme.Error);
        }

        public static string Debug(this string str)
        {
            return DisableColor
                ? str
                : str.Pastel(Theme.Debug);
        }


        public static string Disabled(this string str)
        {
            return DisableColor
                ? str
                : str.Pastel(Theme.Disabled);
        }

        public static string DisabledReason(this string str)
        {
            return DisableColor
                ? str
                : str.Pastel(Theme.DisabledReason);
        }
    }
}