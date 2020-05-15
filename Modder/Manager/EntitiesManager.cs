namespace Modder.Manager
{
    public class EntitiesManager
    {
        public HeroItemManager HeroItemManager { get; }
        public SkillManager SkillManager { get; }

        public EntitiesManager(HeroItemManager heroItemManager, SkillManager skillManager)
        {
            HeroItemManager = heroItemManager;
            SkillManager = skillManager;
        }
    }
}