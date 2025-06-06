using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Executor.Metadata.Model
{
    public class MetadataFileModel
    {
        public string? Code { get; set; }
        public List<MetadataInputModel> Inputs { get; set; } = new List<MetadataInputModel>();
        public List<MetadataOutputModel> Outputs { get; set; } = new List<MetadataOutputModel>();
        public string? Endpoint { get; set; }
        public string? NameFile { get; set; }
        public string? Err { get; set; }

        public class MetadataInputModel
        {
            public string? Field { get; set; }
            public string? Type { get; set; }
        }

        public class MetadataOutputModel
        {
            public string? Field { get; set; }
            public string? Type { get; set; }
        }


    }
}
