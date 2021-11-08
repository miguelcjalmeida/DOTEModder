namespace Modder.Common.Writers
{
    public interface DataTableWriter<in TContent>
    {
        public void Write(string distPath, TContent content);
    }
}