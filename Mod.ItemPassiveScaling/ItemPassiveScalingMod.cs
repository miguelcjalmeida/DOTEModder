using Modder;
using Modder.Common.Managers;
using System.Linq;

namespace Mod.ItemPassiveScaling
{
    public class ItemPassiveScalingMod : IMod
    {
        public void Apply(EntitiesManager manager)
        {
            var skills = manager.SkillManager.Stored;
            var items = manager.HeroItemManager.Stored;
            var itemsWithoutPassives = items.Where(x => !x.SkillIDs.Any()).ToList();
            var itemsWithPassives = items.Where(x => x.SkillIDs.Any()).ToList();

            var newSkills = new ScalingSkillDuplicator().Duplicate(skills);
            var newItemsOnly = new ItemWithPassiveDuplicator().Duplicate(itemsWithPassives);
            var allItems = newItemsOnly.Concat(itemsWithoutPassives).ToList();

            manager.HeroItemManager.Stored = allItems;
            manager.SkillManager.Stored = newSkills;
        }
    }
}
