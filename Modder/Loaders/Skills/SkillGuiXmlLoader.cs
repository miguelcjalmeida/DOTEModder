using System.Collections.Generic;
using System.Xml;
using Modder.Entities.Skill;

namespace Modder.Loaders.Skills
{
    public class SkillGuiXmlLoader : XmlLoader
    {
        private readonly IList<Skill> _skills;

        public SkillGuiXmlLoader(IList<Skill> skills)
        {
            _skills = skills;
        }
        
        public void PopulateFromAssets(string assetsPath)
        {
            var document = LoadDocument($"{assetsPath}/Gui/GuiElements_Skill.xml");
            _skills.ForEach(x => PopulateGuiElements(x, document));
        }

        private void PopulateGuiElements(Skill skill, XmlDocument document)
        {
            var node = document.SelectSingleNode($"Datatable/GuiElement[@Name='{skill.Identifier}']");
            skill.Icon = node.SelectSingleNode("Icons/Icon[@Size='Small']").Attributes["Path"].Value;
        }
    }
}