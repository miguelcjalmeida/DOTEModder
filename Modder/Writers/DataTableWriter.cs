using System.IO;
using System.Text;
using System.Xml;

namespace Modder.Writers
{
    public interface IDataTableWriter<in TContent>
    {
        public void Write(string distPath, TContent content);
    }
    
    public abstract class DataTableWriter<TContent> : IDataTableWriter<TContent>
    {
        public void Write(string distPath, TContent content)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(GetFilePath(distPath)));
            
            var settings = new XmlWriterSettings
            {
                Encoding = Encoding.UTF8,
                Indent = true,
                IndentChars = "  "
            };
            
            var writer = XmlWriter.Create(GetFilePath(distPath), settings);

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
        protected abstract void WriteContent(XmlWriter writer, TContent skills);
    }
}