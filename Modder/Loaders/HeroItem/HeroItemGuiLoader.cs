using System.Collections.Generic;
using System.Xml;

namespace Modder.Loaders.HeroItem
{
    public class HeroItemGuiLoader : XmlLoader
    {
        private readonly IList<Entities.Item.HeroItem> _items;

        public HeroItemGuiLoader(IList<Entities.Item.HeroItem> items)
        {
            _items = items;
        }
        
        public void PopulateFromAssets(string assetsPath)
        {
            var guiDoc = LoadDocument($"{assetsPath}/Gui/GuiElements_ItemHero.xml");
            _items.ForEach(x => PopulateIcon(x, guiDoc));
        }

        private static void PopulateIcon(Entities.Item.HeroItem item, XmlDocument guiDoc)
        {
            var icon = guiDoc.SelectSingleNode($"Datatable/GuiElement[@Name='{item.Name}']/Icons/Icon");
            item.IconPath = icon.Attributes["Path"].Value;
        }
    }
}