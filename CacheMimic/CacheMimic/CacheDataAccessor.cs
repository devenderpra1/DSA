using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheMimic
{
    public abstract class CacheDataAccessor
    {

        #region Factory Creates
        public CacheDataAccessor Create(DataType dataType)
        {
            if (dataType.IsVersioned)
            {
                return CreateVersionedDataAccessor((dynamic)(dataType));

            }
            else if (!dataType.IsVersioned)
            {
                return CreateDatedCachedDataAccessor((dynamic)(dataType));
            }
            else
            {
                throw new NotSupportedException();
            }
        }

        public CacheDataAccessor CreateVersionedDataAccessor<T>(DataType<T> dataType)
        {
            return new VersionedCacheDataAccessor<T>();
        }

        public CacheDataAccessor CreateDatedCachedDataAccessor<T>(DataType<T> dataType)
        {
            return new DatedCacheDataProcessor<T>();
        }

        #endregion

        #region Base Methods
        public abstract void SetupDataRequest();

        public abstract void UpdateCache();

        #endregion

        #region ReaderForCache If not Available Get from DB
        public class CacheReader
        {

        }
        #endregion

        #region Writer to Cache Will check Write Through or Around the cache
        public class CacheWriter
        {

        }
        #endregion
    }

    public class VersionedCacheDataAccessor<T> : CacheDataAccessor
    {
        public VersionedCacheDataAccessor()
        {

        }

        public override void SetupDataRequest()
        {
            throw new NotImplementedException();
        }

        public override void UpdateCache()
        {
            throw new NotImplementedException();
        }
    }

    public class DatedCacheDataProcessor<T> : CacheDataAccessor
    {
        public override void SetupDataRequest()
        {
            throw new NotImplementedException();
        }

        public override void UpdateCache()
        {
            throw new NotImplementedException();
        }
    }
}
