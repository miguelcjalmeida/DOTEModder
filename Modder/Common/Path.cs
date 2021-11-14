using System;
using System.Collections.Generic;
using System.Text;

namespace Modder.Common
{
    public enum Path
    {
        CurrentHero,
        MobsInRoom,
        EverythingOnFloor,
        MinorModulesInRoom,
        HeroesInRoom,
        HeroesOnFloor,
        MobsOnFloor,
        MinorModulesOnFloor,
        MajorModulesOnFloor,
        MajorModulesInRoom,
        OnNextRoom
    }

    public static class PathExtensions
    {
        private static Map<string, Path> mapping = CreateMapping();
        public static string AsText(this Path path)
        {
            if (mapping.Backward.ContainsKey(path)) return mapping.Backward[path];
            throw new Exception($"Path don't exists {path.ToString()}");
        }

        public static Path AsPath(this string value)
        {
            if (mapping.Forward.ContainsKey(value)) return mapping.Forward[value];
            throw new Exception($"Path don't exists '{value}'");
        }

        private static Map<string, Path> CreateMapping()
        {
            var mapping = new Map<string, Path>();
            mapping.Add("./Hero", Path.CurrentHero);
            mapping.Add("../Dungeon/Room", Path.OnNextRoom);
            mapping.Add("../Dungeon", Path.EverythingOnFloor);
            mapping.Add("../Room/Hero", Path.HeroesInRoom);
            mapping.Add("../Room/Mob", Path.MobsInRoom);
            mapping.Add("../Room/MinorModule", Path.MinorModulesInRoom);
            mapping.Add("../Room/MajorModule", Path.MajorModulesInRoom);
            mapping.Add("../Dungeon/Room/Hero", Path.HeroesOnFloor);
            mapping.Add("../Dungeon/Room/Mob", Path.MobsOnFloor);
            mapping.Add("../Dungeon/Room/MinorModule", Path.MinorModulesOnFloor);
            mapping.Add("../Dungeon/Room/MajorModule", Path.MajorModulesOnFloor);
            return mapping;
        }

    }
}
