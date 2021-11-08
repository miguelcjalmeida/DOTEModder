using System.Collections.Generic;

namespace Modder.Common.Managers
{
    public interface IManager<TEntity>
    {
        IList<TEntity> Load();
        void Save();
        IList<TEntity> Stored { get; set; }
    }
}