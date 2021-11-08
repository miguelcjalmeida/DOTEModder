using System.Collections.Generic;
using System.Xml;
using Modder.Common;
using Modder.Common.Loaders;
using Modder.HeroItems.Entities;

namespace Modder.HeroItems.Loaders
{
    public class HeroItemGuiLoader : XmlLoader
    {
        private readonly IList<HeroItem> _items;

        public HeroItemGuiLoader(IList<HeroItem> items)
        {
            _items = items;
        }

        public void PopulateFromAssets(string assetsPath)
        {
            var guiDoc = LoadDocument($"{assetsPath}/Gui/GuiElements_ItemHero.xml");
            _items.ForEach(x => PopulateIcon(x, guiDoc));
        }

        private static void PopulateIcon(HeroItem item, XmlDocument guiDoc)
        {
            var icon = guiDoc.SelectSingleNode($"Datatable/GuiElement[@Name='{item.Name}']/Icons/Icon");
            item.IconPath = icon.Attributes["Path"].Value;
        }
    }
}