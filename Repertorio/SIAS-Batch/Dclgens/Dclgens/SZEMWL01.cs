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
    public class SZEMWL01 : VarBasis
    {
        /*"01     H-SZL01-SZEMNL01*/
        public SZEMWL01_H_SZL01_SZEMNL01 H_SZL01_SZEMNL01 { get; set; } = new SZEMWL01_H_SZL01_SZEMNL01();

        public SZEMWL01_N_SZL01_SZEMNL01 N_SZL01_SZEMNL01 { get; set; } = new SZEMWL01_N_SZL01_SZEMNL01();

    }
}