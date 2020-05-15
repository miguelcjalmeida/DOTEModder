using System.Collections.Generic;
using System.Xml;
using Modder.Entities.Skill;

namespace Modder.Writers.Skills
{
    public class SkillConfigsWriter : DataTableWriter<IList<Skill>>
    {
        protected override string GetFilePath(string distPath)
            => $"{distPath}/Configuration/SkillConfigs.xml";

        protected override void WriteContent(XmlWriter writer, IList<Skill> items)
            => items.ForEach(x => WriteSkillConfig(writer, x));
        
        private void WriteSkillConfig(XmlWriter writer, Skill item)
        {
        }
    }
}