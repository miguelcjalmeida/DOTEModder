using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            var distDirectory = $"{projectDirectory}/Dist";
            var assetsDirectory = $"{projectDirectory}/Assets";
            
            var manager = new EntitiesManagerFactory().Create(assetsDirectory, distDirectory);
            var skills = manager.SkillManager.Load();
            skills[0].Description.English = "cool!";
            skills[1].Title.French = "cool too!";

            var items = manager.HeroItemManager.Load();
            items.Add(CreateDagger());

            manager.SkillManager.Save(skills);
            manager.HeroItemManager.Save(items);
        }
        
        private static HeroItem CreateDagger() => new HeroItem
        {
            Title = new Description
            {
                English = "Dagger",
                French = "Daggery",
                German = "Daggur"
            },
            Description = new Description
            {
                English = "Quick & deadly",
                French = "Rapida e mortal",
                German = "Quickka n mortal"
            },
            Category = ItemCategory.ItemHero_Weapon,
            Name = "WeaponDagger",
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