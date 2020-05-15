using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using Modder.Entities.Skill;
using Modder.Loader;

namespace Modder.Loaders.Skill
{
    public class SkillConfigurationLoader : Loader
    {
        public IList<Entities.Skill.Skill> LoadFromAssets(string assetsPath)
        {
            var document = LoadDocument($"{assetsPath}/Configuration/SkillConfigs.xml");
            
            return document.SelectNodes("Datatable/SkillConfig")
                .AsQuery()
                .Select(CreateSkillLevelConfiguration)
                .GroupBy(x => x.Item1)
                .Select(CreateSkillFromLevels)
                .ToList();
        }


        private (string, SkillLevel) CreateSkillLevelConfiguration(XmlNode config)
        {
            var identifier = config.Attributes["Name"].Value;
            var pieces = identifier.Split("_LVL");
            
            var level = new SkillLevel
            {
                Level = pieces.Length > 1 ? Convert.ToInt32(pieces.LastOrDefault()) : 1,
                TargetVFXPath = config.Attributes["TargetVFXPath"]?.Value,
                TargetSFXPath = config.Attributes["TargetSFXPath"]?.Value,
                DialogVFXPath = config.Attributes["DialogVFXPath"]?.Value,
                OwnerSFXPath = config.Attributes["OwnerSFXPath"]?.Value,
                OwnerVFXPath = config.Attributes["OwnerVFXPath"]?.Value,
                IsActive = config.Attributes["IsActive"]?.Value == "1",
                Duration = ConvertToNumber(config.Attributes["Duration"]?.Value),
                CooldownTurnsCount = ConvertToNumber(config.Attributes["CooldownTurnsCount"]?.Value),
                DamagesTargetsPath = config.Attributes["DamagesTargetsPath"]?.Value,
                DeactivateOnNewTurn = config.Attributes["DeactivateOnNewTurn"]?.Value == "true"
            };

            return (pieces[0], level);
        }
        
        private Entities.Skill.Skill CreateSkillFromLevels(IGrouping<string, (string, SkillLevel)> levels)
        {
            return new Entities.Skill.Skill
            {
                Identifier = levels.Key,
                Levels = levels.Select(x => x.Item2).ToList()
            };
        }

        private float ConvertToNumber(string value)
        {
            if (value == null) return 0f;
            return Convert.ToSingle(value);
        }
    }
}