using Copybook.Converter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileResolver.Model
{
    public class MethodReferenceInfo
    {
        public string ModuleName { get; set; }
        public string MethodName { get; set; }
        public List<ReferenceModel> References { get; set; }

        public MethodReferenceInfo(string moduleName, string methodName, List<ReferenceModel> references)
        {
            ModuleName = moduleName;
            MethodName = methodName;
            References = references ?? new List<ReferenceModel>();
        }
    }
}
