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
    public class SINIMPSE : VarBasis
    {
        /*"01  DCLSINISTRO-IMP-SEG.*/
        public SINIMPSE_DCLSINISTRO_IMP_SEG DCLSINISTRO_IMP_SEG { get; set; } = new SINIMPSE_DCLSINISTRO_IMP_SEG();

    }
}