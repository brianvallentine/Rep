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
    public class TCAPITVG : VarBasis
    {
        /*"01  DCLTIT-CAPITALIZ-VG.*/
        public TCAPITVG_DCLTIT_CAPITALIZ_VG DCLTIT_CAPITALIZ_VG { get; set; } = new TCAPITVG_DCLTIT_CAPITALIZ_VG();

    }
}