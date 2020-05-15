using System.Collections.Generic;
using Modder.Entities.Skill;

namespace Modder.Writers.Skills
{
    public class SkillWriter : IDataTableWriter<IList<Skill>>
    {
        public void Write(string distPath, IList<Skill> items)
        {
            new SkillConfigsWriter().Write(distPath, items);
            new SkillGuiWriter().Write(distPath, items);
            new SkillSimulationWriter().Write(distPath, items);
        }
    }
}