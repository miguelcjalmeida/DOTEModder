using System;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Modder;
using Modder.Manager;

namespace Mod.ItemPassiveScaling
{
    class Program
    {
        static void Main(string[] args)
        {
            var workingDirectory = Environment.CurrentDirectory;
            var projectDirectory = Directory.GetParent(workingDirectory).Parent?.Parent?.FullName;
            var distDirectory = $"{projectDirectory}/Dist";
            var assetsDirectory = $"{projectDirectory}/Assets";
            
            var manager = new EntitiesManagerFactory().Create(assetsDirectory, distDirectory);
            var skills = manager.SkillManager.Load();
            var items = manager.HeroItemManager.Load();
            var itemsWithPassives = items.Where(x => x.SkillIDs.Any()).ToList();
            
            var newSkills = new ScalingSkillDuplicator().Duplicate(skills);
            var newItems = new ItemWithPassiveDuplicator().Duplicate(itemsWithPassives);
            
            manager.HeroItemManager.Save(newItems);
            manager.SkillManager.Save(newSkills);
        }
    }
}