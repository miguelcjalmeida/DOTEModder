﻿using System.Collections.Generic;
using Modder.Entities.Item.SimulationDescriptor;
using Modder.Entities.Localization;

namespace Modder.Entities.Item
{
    public class HeroItem
    {
        public string Name { get; set; }
        public Description Title { get; set; }
        public Description Description { get; set; }
        public string IconPath { get; set; }        
        public DropCriteria DropCriteria { get; set; }
        public AttackType? AttackType { get; set; }
        public WeaponType? WeaponType { get; set; }
        public ItemCategory Category { get; set; }
        public IList<string> SkillIDs { get; set; }
        public IList<HeroItemDescriptor> Descriptors { get; set; }

        public string LocalizationTitlePlaceholder => $"%Item_{Name}";
        public string LocalizationDescriptionPlaceholder => $"%Item_{Name}_Description";
    }
}