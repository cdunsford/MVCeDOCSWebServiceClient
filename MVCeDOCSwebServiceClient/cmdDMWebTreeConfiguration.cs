using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace MVCeDOCSwebServiceClient
{
    public class cmdDMWebTreeConfiguration : ConfigurationSection
    {
        [ConfigurationProperty("isExternalSite", DefaultValue = true)]
        public Boolean IsExternalSite
        {
            get
            {
                return (Boolean)this["isExternalSite"];
            }
        }
        //2020-07-07 beginning of added properties for large file caching
        [ConfigurationProperty("largeFileCacheLocation")]
        public string LargeFileCacheLocation
        {
            get
            {
                return this["largeFileCacheLocation"] as string;
            }

        }
        [ConfigurationProperty("cacheFilesLargerThan", DefaultValue = "500")]
        public long CacheFilesLargerThan
        {
            get
            {
                return (long)this["cacheFilesLargerThan"];
            }

        }

        [ConfigurationProperty("deleteCacheFilesOlderThan", DefaultValue = "10")]
        public double DeleteCacheFilesOlderThan
        {
            get
            {
                return (double)this["deleteCacheFilesOlderThan"];
            }

        }

        [ConfigurationProperty("maxCacheDiskSpace", DefaultValue = "1500")]
        public int MaxCacheDiskSpace
        {
            get
            {
                return (int)this["maxCacheDiskSpace"];
            }

        }




    }
}