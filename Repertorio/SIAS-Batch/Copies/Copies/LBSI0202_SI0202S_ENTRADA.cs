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
    public class LBSI0202_SI0202S_ENTRADA : VarBasis
    {
        /*"      05 SI0202S-NUM-APOL-SINISTRO  PIC  9(013)*/
        public IntBasis SI0202S_NUM_APOL_SINISTRO { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
        /*"   03 SI0202S-SAIDA*/
    }
}