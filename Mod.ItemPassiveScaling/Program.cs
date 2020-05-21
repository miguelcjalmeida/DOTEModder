using System;
using System.IO;
using System.Linq;
using Modder.Manager;

namespace Mod.ItemPassiveScaling
{
    class Program
    {
        static void Main(string[] args)
        {
            var workingDirectory = Environment.CurrentDirectory;
            var projectDirectory = Directory.GetParent(workingDirectory).Parent?.Parent?.FullName;
            var distDirectory = $"{projectDirectory}/Dist/Public";
            var assetsDirectory = $"{projectDirectory}/Assets";
            
            var manager = new EntitiesManagerFactory().Create(assetsDirectory, distDirectory);
            var skills = manager.SkillManager.Load();
            var items = manager.HeroItemManager.Load();
            var itemsWithoutPassives = items.Where(x => !x.SkillIDs.Any()).ToList();
            var itemsWithPassives = items.Where(x => x.SkillIDs.Any()).ToList();
            
            var newSkills = new ScalingSkillDuplicator().Duplicate(skills);
            var newItemsOnly = new ItemWithPassiveDuplicator().Duplicate(itemsWithPassives);
            var allItems = newItemsOnly.Concat(itemsWithoutPassives).ToList();
            
            manager.HeroItemManager.Save(allItems);
            manager.SkillManager.Save(newSkills);
        }
    }
}