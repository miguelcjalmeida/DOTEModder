using System.Collections.Generic;

namespace Modder.Loaders
{
    public interface Loader<TEntity>
    {
        public IList<TEntity> LoadFromAssets(string assetsPath);
    }
}