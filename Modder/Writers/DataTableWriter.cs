using System.Text;
using System.Xml;

namespace Modder.Writers
{
    public abstract class DataTableWriter<TContent>
    {
        public void Write(string assetsPath, TContent content)
        {
            var settings = new XmlWriterSettings
            {
                Encoding = Encoding.UTF8,
                Indent = true,
                IndentChars = "  "
            };
            
            var writer = XmlWriter.Create(GetFilePath(assetsPath), settings);

            writer.WriteStartDocument();
            writer.WriteComment("Warning: this XML is automatically generated from the XLS. Do not modify!");
            writer.WriteStartElement("Datatable");
            writer.WriteAttributeString("xmlns", "xsi", null, "http://www.w3.org/2001/XMLSchema-instance");
            writer.WriteAttributeString("xmlns", "xsd", null, "http://www.w3.org/2001/XMLSchema");

            WriteContent(writer, content);
            
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();
        }

        protected abstract string GetFilePath(string distPath);
        protected abstract void WriteContent(XmlWriter writer, TContent content);
    }
}