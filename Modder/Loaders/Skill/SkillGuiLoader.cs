using System;
using System.Collections.Generic;
using System.Xml;

namespace Modder.Loaders.Skill
{
    public class SkillGuiLoader : Loader
    {
        private readonly IList<Entities.Skill.Skill> _skills;

        public SkillGuiLoader(IList<Entities.Skill.Skill> skills)
        {
            _skills = skills;
        }
        
        public void PopulateFromAssets(string assetsPath)
        {
            var document = LoadDocument($"{assetsPath}/Gui/GuiElements_Skill.xml");
            _skills.ForEach(x => PopulateGuiElements(x, document));
        }

        private void PopulateGuiElements(Entities.Skill.Skill skill, XmlDocument document)
        {
            var node = document.SelectSingleNode($"Datatable/GuiElement[@Name='{skill.Identifier}']");
            skill.Icon = node.SelectSingleNode("Icons/Icon[@Size='Small']").Attributes["Path"].Value;
        }
    }
}