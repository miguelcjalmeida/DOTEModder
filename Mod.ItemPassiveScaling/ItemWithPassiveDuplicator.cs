using System.Collections.Generic;
using System.Linq;
using Modder.Common;
using Modder.HeroItems.Entities;
using Modder.HeroItems.Entities.Rarity;
using Modder.Localizations.Entities;

namespace Mod.ItemPassiveScaling
{
    public class ItemWithPassiveDuplicator
    {
        private readonly RarityName[] _rarity = {RarityName.Common, RarityName.Rarity0, RarityName.Rarity1, RarityName.Rarity2};
        
        public IList<HeroItem> Duplicate(IList<HeroItem> items)
        {
            return items.SelectMany(CreateItemVersions).ToList();
        }

        private IList<HeroItem> CreateItemVersions(HeroItem item)
        {
            return _rarity.Select(x => CreateItemOfGivenRarity(x, item)).ToList();
        }

        private HeroItem CreateItemOfGivenRarity(RarityName rarityName, HeroItem originalItem)
        {
            var item = originalItem.Copy();
            var rarity = RaritySuffix.FormatIdentifier(rarityName);

            item.Name = $"{item.Name}{rarity}";
            ImproveSkillInTheDescription(item.Description, rarityName);
                
            for (var i = 0; i < originalItem.SkillIDs.Count; i++)
                item.SkillIDs[i] = $"{item.SkillIDs[i]}{rarity}";
            
            item.DropCriteria = item.Descriptors
                .First(x => x.Rarity.Name == rarityName)
                .Rarity.DropCriteria.Copy();

            item.DropCriteria.ProbabilityWeight = originalItem.DropCriteria.ProbabilityWeight;
            
            item.Descriptors.Where(x => x.Rarity.Name != rarityName)
                .Select(x => x.Rarity.DropCriteria)
                .ForEach(criteria =>
                {
                    criteria.MaxLevel = 0;
                    criteria.MinLevel = 0;
                });
            
            return item;
        }

        private void ImproveSkillInTheDescription(Description description, RarityName rarity)
        {
            description.English = GetImprovedSkillDescriptionText(description.English, rarity);
            description.French = GetImprovedSkillDescriptionText(description.French, rarity);
            description.German = GetImprovedSkillDescriptionText(description.German, rarity);
        }

        private string GetImprovedSkillDescriptionText(string text, RarityName rarity)
        {
            return text.Replace("#Revert#", $"{RaritySuffix.GetSuffix(rarity)}#Revert#");
        }
    }
}