using System.Collections.Generic;

namespace Modder.Common.Loaders
{
    public interface Loader<TEntity>
    {
        public IList<TEntity> LoadFromAssets(string assetsPath);
    }
}