using System;
using System.Collections.Generic;
using System.IO;
using Modder.Entities.HeroItem;
using Modder.Entities.HeroItem.Rarity;
using Modder.Entities.HeroItem.SimulationDescriptor;
using Modder.Entities.Localization;
using Modder.Manager;

namespace Mod.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            var workingDirectory = Environment.CurrentDirectory;
            var projectDirectory = Directory.GetParent(workingDirectory).Parent?.Parent?.FullName;
            var distDirectory = $"{projectDirectory}/Dist/Public";
            var assetsDirectory = $"{projectDirectory}/Assets";
            
            // this manager has all entities you can manipulate across this framework 
            var manager = new EntitiesManagerFactory().Create(assetsDirectory, distDirectory);
            
            // load game skills 
            var skills = manager.SkillManager.Load();
            
            // Modifying the first two existent skills title and description
            skills[0].Description.English = "Hello";
            skills[1].Title.French = "World";
            
            // Adding a new single-rarity item just for fun
            var items = manager.HeroItemManager.Load();
            items.Add(CreateDagger());

            // saving all the changes
            manager.SkillManager.Save(skills);
            manager.HeroItemManager.Save(items);
        }
        
        private static HeroItem CreateDagger() => new HeroItem
        {
            Name = "WeaponDagger",
            Title = new Description
            {
                English = "Dagger",
                French = "Dague",
                German = "Dolch"
            },
            Description = new Description
            {
                English = "Quick & deadly",
                French = "Rapide et mortel",
                German = "Schnell und tödlich"
            },
            Category = ItemCategory.ItemHero_Weapon,
            AttackType = AttackType.Sword,
            DropCriteria = new DropCriteria
            {
                MaxLevel = 10,
                MinLevel = 0,
                ProbabilityWeight = 100
            },
            IconPath = "GUI/DynamicBitmaps/Items/Weapon002",
            WeaponType = WeaponType.Weapon_Sword,
            SkillIDs = new List<string>(),
            Descriptors = new List<HeroItemDescriptor>()
            {
                new HeroItemDescriptor
                {
                    Rarity = new ItemRarity
                    {
                        Name = RarityName.Common,
                        DropCriteria = new DropCriteria
                        {
                            MinLevel = 0,
                            MaxLevel = 10,
                            ProbabilityWeight = 100
                        }
                    },
                    Modifiers = new List<ModifierDescriptor>
                    {
                        new ModifierDescriptor
                        {
                            TargetProperty = TargetProperty.AttackCooldown,
                            Operation = Operation.Subtraction,
                            Value = 0.2f
                        },
                        new ModifierDescriptor
                        {
                            TargetProperty = TargetProperty.MoveSpeed,
                            Operation = Operation.Addition,
                            Value = 2f
                        }
                    }
                }
            }
        };
    }
}