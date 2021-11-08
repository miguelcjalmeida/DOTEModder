using Modder.Common;
using Modder.Common.Managers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace Modder
{
    public class Runner
    {
        private readonly string workingDirectory;

        public Runner()
        {
            workingDirectory = Environment.CurrentDirectory;
        }

        public Runner(string workingDirectory)
        {
            this.workingDirectory = workingDirectory;
        }

        public void Run(IList<IMod> mods)
        {
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US");

            var projectDirectory = Directory.GetParent(workingDirectory).Parent?.Parent?.FullName;
            var distDirectory = $"{projectDirectory}/Dist/Public";
            var assetsDirectory = $"{projectDirectory}/Assets";

            var manager = new EntitiesManagerFactory().Create(assetsDirectory, distDirectory);
            mods.ForEach(mod => mod.Apply(manager));
            manager.HeroItemManager.Save();
            manager.SkillManager.Save();
            manager.ShipManager.Save();
        }
    }
}
