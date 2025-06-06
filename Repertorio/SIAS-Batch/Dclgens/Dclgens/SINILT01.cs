using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Dclgens
{
    public class SINILT01 : VarBasis
    {
        /*"01  DCLSINI-LOTERICO01.*/
        public SINILT01_DCLSINI_LOTERICO01 DCLSINI_LOTERICO01 { get; set; } = new SINILT01_DCLSINI_LOTERICO01();

    }
}