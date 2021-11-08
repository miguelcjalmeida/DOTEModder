using System.Collections.Generic;
using Modder.Common.Writers;
using Modder.Skills.Entities;

namespace Modder.Skills.Writers
{
    public class SkillWriter : DataTableWriter<IList<Skill>>
    {
        public void Write(string distPath, IList<Skill> items)
        {
            new SkillConfigsWriter().Write(distPath, items);
            new SkillGuiWriter().Write(distPath, items);
            new SkillSimulationWriter().Write(distPath, items);
        }
    }
}