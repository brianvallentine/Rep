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
    public class OPCPAGVI_DCLOPCAO_PAG_VIDAZUL : VarBasis
    {
        /*"    10 OPCPAGVI-NUM-CERTIFICADO       PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis OPCPAGVI_NUM_CERTIFICADO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 OPCPAGVI-DATA-INIVIGENCIA       PIC X(10).*/
        public StringBasis OPCPAGVI_DATA_INIVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 OPCPAGVI-DATA-TERVIGENCIA       PIC X(10).*/
        public StringBasis OPCPAGVI_DATA_TERVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 OPCPAGVI-OPCAO-PAGAMENTO       PIC X(1).*/
        public StringBasis OPCPAGVI_OPCAO_PAGAMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 OPCPAGVI-PERI-PAGAMENTO       PIC S9(4) USAGE COMP.*/
        public IntBasis OPCPAGVI_PERI_PAGAMENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 OPCPAGVI-DIA-DEBITO  PIC S9(4) USAGE COMP.*/
        public IntBasis OPCPAGVI_DIA_DEBITO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 OPCPAGVI-COD-USUARIO       PIC X(8).*/
        public StringBasis OPCPAGVI_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 OPCPAGVI-TIMESTAMP   PIC X(26).*/
        public StringBasis OPCPAGVI_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 OPCPAGVI-COD-AGENCIA-DEBITO       PIC S9(4) USAGE COMP.*/
        public IntBasis OPCPAGVI_COD_AGENCIA_DEBITO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 OPCPAGVI-OPE-CONTA-DEBITO       PIC S9(4) USAGE COMP.*/
        public IntBasis OPCPAGVI_OPE_CONTA_DEBITO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 OPCPAGVI-NUM-CONTA-DEBITO       PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis OPCPAGVI_NUM_CONTA_DEBITO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 OPCPAGVI-DIG-CONTA-DEBITO       PIC S9(4) USAGE COMP.*/
        public IntBasis OPCPAGVI_DIG_CONTA_DEBITO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 OPCPAGVI-NUM-CARTAO-CREDITO       PIC X(16).*/
        public StringBasis OPCPAGVI_NUM_CARTAO_CREDITO { get; set; } = new StringBasis(new PIC("X", "16", "X(16)."), @"");
        /*"*/
    }
}