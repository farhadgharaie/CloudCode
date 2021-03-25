using System;

namespace CloudInfra.ResourceTypes.Database
{
    public class DatabaseResource
    {
        public string Instance { get; set; }
        public string Charset { get; set; }
        public string Collation { get; set; }
        public override bool Equals(Object obj)
        {
            if (obj is DatabaseResource)
            {
                var that = obj as DatabaseResource;
                return this.Instance == that.Instance &&
                       this.Charset == that.Charset &&
                       this.Collation == that.Collation;
            }
            return false;
        }
    }
}
