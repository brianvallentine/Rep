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
    public class GE577_DCLGE_DET_ARQ_H_RETORNO_SAP : VarBasis
    {
        /*"    10 GE577-NUM-NSA-SAP    PIC S9(9) USAGE COMP.*/
        public IntBasis GE577_NUM_NSA_SAP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GE577-SEQ-REGISTRO   PIC S9(9) USAGE COMP.*/
        public IntBasis GE577_SEQ_REGISTRO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GE577-COD-RETORNO-ARQ-H       PIC X(6).*/
        public StringBasis GE577_COD_RETORNO_ARQ_H { get; set; } = new StringBasis(new PIC("X", "6", "X(6)."), @"");
        /*"    10 GE577-IND-TIPO-RETORNO       PIC S9(4) USAGE COMP.*/
        public IntBasis GE577_IND_TIPO_RETORNO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE577-COD-MODULO-SAP       PIC X(2).*/
        public StringBasis GE577_COD_MODULO_SAP { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"*/
    }
}