using System.Collections.Generic;

namespace Modder.Manager
{
    public interface IManager<TEntity>
    {
        IList<TEntity> Load();
        void Save();
        IList<TEntity> Stored { get; set;  }
    }
}