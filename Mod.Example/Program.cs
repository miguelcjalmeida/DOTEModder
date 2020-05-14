using System;
using System.IO;
using Modder.Loaders.HeroItem;
using Modder.Loaders.Localization;
using Modder.Writers;

namespace Mod.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            var workingDirectory = Environment.CurrentDirectory;
            var projectDirectory = Directory.GetParent(workingDirectory).Parent?.Parent?.FullName;
            var distDirectory = $"{projectDirectory}/Dist";
            var assetsDirectory = $"{projectDirectory}/Assets";
            var items = HeroItemLoader.LoadFromAssets(assetsDirectory);
            
            new HeroItemConfigsWriter().Write(distDirectory, items);
            new HeroItemGuiWriter().Write(distDirectory, items);
            new HeroItemSimulationWriter().Write(distDirectory, items);

            var localizations = LocalizationLoader.LoadFromAssets(assetsDirectory);
            new LocalizationWriter().Write(distDirectory, localizations);
        }
    }
}