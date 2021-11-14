using Modder.HeroItems.Entities;
using Modder.Localizations.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modder.Heroes.Entities
{
    public class Hero : TitleDescriptionEntity
    {
        public string Name { get; set; }
        public int RecruitmentFoodCost { get; set; }
        public AITargetType AITargetType { get; set; }
        public AttackType AttackType { get; set; }
        public Localization Archetype { get; set; }
        public int UnlockLevelCount { get; set; }
        public Faction Faction { get; set; }

        public IList<Dialog> IntroDialogs { get; set; }
        public IList<EquipmentSlot> EquipmentSlots { get; set; }
        public IList<HeroLevel> Levels { get; set; }
        public string SmallIconPath { get; set; }
        public string LargeIconPath { get; set; }
        public Description Title { get; set; }
        public Description Description { get; set; }
        public string Identifier
        {
            get => $"Hero_{Name}";
            set => Name = value.Replace("Hero_", "");
        }
        public string LocalizationTitlePlaceholder => $"%Hero_{Name}_Title";
        public string LocalizationDescriptionPlaceholder => $"%Hero_{Name}_Biography";
    }
}
