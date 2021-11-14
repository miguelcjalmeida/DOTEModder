using System.Collections.Generic;
using System.Xml;
using Modder.Common;
using Modder.Common.Loaders;
using Modder.Heroes.Entities;
using Modder.HeroItems.Entities;

namespace Modder.HeroItems.Loaders
{
    public class HeroGuiLoader : XmlLoader
    {
        private readonly IList<Hero> _heroes;

        public HeroGuiLoader(IList<Hero> heroes)
        {
            _heroes = heroes;
        }

        public void PopulateFromAssets(string assetsPath)
        {
            var guiDoc = LoadDocument($"{assetsPath}/Gui/GuiElements_Hero.xml");
            _heroes.ForEach(x => PopulateIcon(x, guiDoc));
        }

        private static void PopulateIcon(Hero hero, XmlDocument guiDoc)
        {
            var smalIcon = guiDoc.SelectSingleNode($"Datatable/GuiElement[@Name='{hero.Identifier}']/Icons/Icon[@Size='Small']");
            var largeIcon = guiDoc.SelectSingleNode($"Datatable/GuiElement[@Name='{hero.Identifier}']/Icons/Icon[@Size='Large']");
            hero.SmallIconPath = smalIcon.Attributes["Path"].Value;
            hero.LargeIconPath = largeIcon.Attributes["Path"].Value;
        }
    }
}