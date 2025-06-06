using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Copies
{
    public class LBSI505B_SI0505B_ENTRADA : VarBasis
    {
        /*"       05  SI0505B-NUM-APOL-SINISTRO  PIC  9(013)*/
        public IntBasis SI0505B_NUM_APOL_SINISTRO { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
        /*"   03  SI0505B-SAIDA*/
    }
}