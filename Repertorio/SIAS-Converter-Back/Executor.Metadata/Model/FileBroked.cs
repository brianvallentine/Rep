using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Executor.Metadata.Model
{
    public class FileBroked
    {
        public string? Code { get; set; }
        public List<string> Inputs { get; set; }
        public List<string> Outputs { get; set; }
        public string? Endpoint { get; set; }
        public string? NomeArquivo { get; set; }
        public string? Err { get; set; }

        public MetadataFileModel Map()
        {
            var arq = new MetadataFileModel
            {
                Code = Code,
                Endpoint = Endpoint,
                NameFile = NomeArquivo,
                Err = Err,
                Inputs = Inputs.Select(x => new MetadataFileModel.MetadataInputModel { Field = x, Type = "string" }).ToList(),
                Outputs = Outputs.Select(x => new MetadataFileModel.MetadataOutputModel { Field = x, Type = "string" }).ToList(),
            };

            return arq;
        }

    }

}
