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
    public class CBMALPAR_DCLCB_MALA_PARCATRASO : VarBasis
    {
        /*"    10 CBMALPAR-NUM-APOLICE       PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis CBMALPAR_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 CBMALPAR-NUM-ENDOSSO       PIC S9(9) USAGE COMP.*/
        public IntBasis CBMALPAR_NUM_ENDOSSO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 CBMALPAR-NUM-PARCELA       PIC S9(4) USAGE COMP.*/
        public IntBasis CBMALPAR_NUM_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 CBMALPAR-DATA-MOVIMENTO       PIC X(10).*/
        public StringBasis CBMALPAR_DATA_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 CBMALPAR-DATA-VENC-CONTR       PIC X(10).*/
        public StringBasis CBMALPAR_DATA_VENC_CONTR { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 CBMALPAR-IDTAB-SITUACAO       PIC S9(4) USAGE COMP.*/
        public IntBasis CBMALPAR_IDTAB_SITUACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 CBMALPAR-SITUACAO    PIC X(1).*/
        public StringBasis CBMALPAR_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 CBMALPAR-NUM-TITULO  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis CBMALPAR_NUM_TITULO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 CBMALPAR-DATA-VENCIMENTO       PIC X(10).*/
        public StringBasis CBMALPAR_DATA_VENCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 CBMALPAR-PREMIO-TOTAL       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis CBMALPAR_PREMIO_TOTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 CBMALPAR-VALOR-ACRESCIMO       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis CBMALPAR_VALOR_ACRESCIMO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 CBMALPAR-VALOR-TARIFA       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis CBMALPAR_VALOR_TARIFA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 CBMALPAR-VALOR-VISTORIA       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis CBMALPAR_VALOR_VISTORIA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 CBMALPAR-DATA-ENVIO  PIC X(10).*/
        public StringBasis CBMALPAR_DATA_ENVIO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 CBMALPAR-TIMESTAMP   PIC X(26).*/
        public StringBasis CBMALPAR_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 CBMALPAR-DTA-VENCIMENTO-AR       PIC X(10).*/
        public StringBasis CBMALPAR_DTA_VENCIMENTO_AR { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"*/
    }
}