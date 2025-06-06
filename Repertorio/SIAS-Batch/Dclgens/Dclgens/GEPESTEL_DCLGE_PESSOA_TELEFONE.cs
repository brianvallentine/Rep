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
    public class GEPESTEL_DCLGE_PESSOA_TELEFONE : VarBasis
    {
        /*"    10 GEPESTEL-COD-PESSOA  PIC S9(9) USAGE COMP.*/
        public IntBasis GEPESTEL_COD_PESSOA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GEPESTEL-SEQ-TELEFONE  PIC S9(4) USAGE COMP.*/
        public IntBasis GEPESTEL_SEQ_TELEFONE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GEPESTEL-NUM-TELEFONE  PIC S9(9) USAGE COMP.*/
        public IntBasis GEPESTEL_NUM_TELEFONE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GEPESTEL-IND-TELEFONE  PIC X(1).*/
        public StringBasis GEPESTEL_IND_TELEFONE { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 GEPESTEL-NUM-DDI     PIC S9(4) USAGE COMP.*/
        public IntBasis GEPESTEL_NUM_DDI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GEPESTEL-NUM-DDD     PIC S9(4) USAGE COMP.*/
        public IntBasis GEPESTEL_NUM_DDD { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GEPESTEL-STA-TELEFONE  PIC X(1).*/
        public StringBasis GEPESTEL_STA_TELEFONE { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 GEPESTEL-DTH-CADASTRAMENTO  PIC X(26).*/
        public StringBasis GEPESTEL_DTH_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}