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
    public class VGCOBSUB : VarBasis
    {
        /*"01  DCLVG-COBERTURAS-SUBG.*/
        public VGCOBSUB_DCLVG_COBERTURAS_SUBG DCLVG_COBERTURAS_SUBG { get; set; } = new VGCOBSUB_DCLVG_COBERTURAS_SUBG();

    }
}