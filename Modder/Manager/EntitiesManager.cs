namespace Modder.Manager
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