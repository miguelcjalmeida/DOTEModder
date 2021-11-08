using System.Collections.Generic;
using Modder.Common;
using Modder.HeroItems.Entities.SimulationDescriptor;
using Modder.Localizations.Entities;

namespace Modder.HeroItems.Entities
{
    public class HeroItem : TitleDescriptionEntity
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

        public HeroItem Clone()
        {
            HeroItem item = new HeroItem();
            item.Name = Name;
            item.Title = (Description)Title.Clone();
            item.Description = (Description)Description.Clone();
            item.IconPath = IconPath;
            item.DropCriteria = (DropCriteria)DropCriteria?.Clone();
            item.AttackType = AttackType;
            item.WeaponType = WeaponType;
            item.Category = Category;
            item.SkillIDs = SkillIDs?.Clone();
            item.Descriptors = Descriptors?.Clone();
            return item;
        }
    }
}