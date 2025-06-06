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
    public class SINIPLAN : VarBasis
    {
        /*"01  DCLSINI-PLANHABIT01.*/
        public SINIPLAN_DCLSINI_PLANHABIT01 DCLSINI_PLANHABIT01 { get; set; } = new SINIPLAN_DCLSINI_PLANHABIT01();

    }
}