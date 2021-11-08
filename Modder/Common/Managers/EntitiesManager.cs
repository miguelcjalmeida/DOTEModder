using Modder.HeroItems.Managers;
using Modder.Ships.Managers;
using Modder.Skills.Managers;

namespace Modder.Common.Managers
{
    public class EntitiesManager
    {
        public HeroItemManager HeroItemManager { get; }
        public SkillManager SkillManager { get; }
        public ShipManager ShipManager { get; }

        public EntitiesManager(HeroItemManager heroItemManager, SkillManager skillManager, ShipManager shipManager)
        {
            HeroItemManager = heroItemManager;
            SkillManager = skillManager;
            ShipManager = shipManager;
        }
    }
}