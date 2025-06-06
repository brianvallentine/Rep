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
    public class OPPAGVA_DCLOPCAO_PAG_VIDAZUL : VarBasis
    {
        /*"    10 OPPAGVA-NUM-CERTIFICADO       PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis OPPAGVA_NUM_CERTIFICADO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 OPPAGVA-DATA-INIVIGENCIA       PIC X(10).*/
        public StringBasis OPPAGVA_DATA_INIVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 OPPAGVA-DATA-TERVIGENCIA       PIC X(10).*/
        public StringBasis OPPAGVA_DATA_TERVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 OPPAGVA-OPCAO-PAGAMENTO       PIC X(1).*/
        public StringBasis OPPAGVA_OPCAO_PAGAMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 OPPAGVA-PERI-PAGAMENTO       PIC S9(4) USAGE COMP.*/
        public IntBasis OPPAGVA_PERI_PAGAMENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 OPPAGVA-DIA-DEBITO   PIC S9(4) USAGE COMP.*/
        public IntBasis OPPAGVA_DIA_DEBITO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 OPPAGVA-COD-USUARIO  PIC X(8).*/
        public StringBasis OPPAGVA_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 OPPAGVA-TIMESTAMP    PIC X(26).*/
        public StringBasis OPPAGVA_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 OPPAGVA-COD-AGENCIA-DEBITO       PIC S9(4) USAGE COMP.*/
        public IntBasis OPPAGVA_COD_AGENCIA_DEBITO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 OPPAGVA-OPE-CONTA-DEBITO       PIC S9(4) USAGE COMP.*/
        public IntBasis OPPAGVA_OPE_CONTA_DEBITO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 OPPAGVA-NUM-CONTA-DEBITO       PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis OPPAGVA_NUM_CONTA_DEBITO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 OPPAGVA-DIG-CONTA-DEBITO       PIC S9(4) USAGE COMP.*/
        public IntBasis OPPAGVA_DIG_CONTA_DEBITO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 OPPAGVA-NUM-CARTAO-CREDITO       PIC X(16).*/
        public StringBasis OPPAGVA_NUM_CARTAO_CREDITO { get; set; } = new StringBasis(new PIC("X", "16", "X(16)."), @"");
        /*"*/
    }
}