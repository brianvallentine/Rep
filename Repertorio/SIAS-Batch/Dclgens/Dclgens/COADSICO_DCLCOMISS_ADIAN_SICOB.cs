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
    public class COADSICO_DCLCOMISS_ADIAN_SICOB : VarBasis
    {
        /*"    10 NUM-CERTIFICADO      PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis NUM_CERTIFICADO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 COD-FONTE            PIC S9(4) USAGE COMP.*/
        public IntBasis COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 AGE-COBRANCA         PIC S9(4) USAGE COMP.*/
        public IntBasis AGE_COBRANCA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VAL-RCAP             PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis VAL_RCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 VAL-ADIANTAMENTO     PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis VAL_ADIANTAMENTO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 DATA-CREDITO         PIC X(10).*/
        public StringBasis DATA_CREDITO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SIT-REGISTRO         PIC X(1).*/
        public StringBasis SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 COD-AGE-VENDEDOR     PIC S9(4) USAGE COMP.*/
        public IntBasis COD_AGE_VENDEDOR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 OPE-CONTA-VENDEDOR   PIC S9(4) USAGE COMP.*/
        public IntBasis OPE_CONTA_VENDEDOR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 NUM-CONTA-VENDEDOR   PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis NUM_CONTA_VENDEDOR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 DIG-CONTA-VENDEDOR   PIC S9(4) USAGE COMP.*/
        public IntBasis DIG_CONTA_VENDEDOR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 NUM-MATRI-VENDEDOR   PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis NUM_MATRI_VENDEDOR { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 DATA-MOVIMENTO       PIC X(10).*/
        public StringBasis DATA_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 TIMESTAMP            PIC X(26).*/
        public StringBasis TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 SIT-FENAE            PIC X(1).*/
        public StringBasis SIT_FENAE { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 DATA-FENAE           PIC X(10).*/
        public StringBasis DATA_FENAE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 VAL-COMISSAO-VEN     PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis VAL_COMISSAO_VEN { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 NUM-APOLICE          PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 COD-SUBGRUPO         PIC S9(4) USAGE COMP.*/
        public IntBasis COD_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 ORDEM-PAGAMENTO      PIC S9(9) USAGE COMP.*/
        public IntBasis ORDEM_PAGAMENTO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 NUM-ENDOSSO          PIC S9(9) USAGE COMP.*/
        public IntBasis NUM_ENDOSSO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 NUM-MATR-GERENTE     PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis NUM_MATR_GERENTE { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 COD-AGEN-GERENTE     PIC S9(4) USAGE COMP.*/
        public IntBasis COD_AGEN_GERENTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 OPE-CONTA-GERENTE    PIC S9(4) USAGE COMP.*/
        public IntBasis OPE_CONTA_GERENTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 NUM-CONTA-GERENTE    PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis NUM_CONTA_GERENTE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 DIG-CONTA-GERENTE    PIC S9(4) USAGE COMP.*/
        public IntBasis DIG_CONTA_GERENTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VAL-COMIS-GERENTE    PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis VAL_COMIS_GERENTE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 NUM-MATR-SUN         PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis NUM_MATR_SUN { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 COD-AGEN-SUN         PIC S9(4) USAGE COMP.*/
        public IntBasis COD_AGEN_SUN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 OPE-CONTA-SUN        PIC S9(4) USAGE COMP.*/
        public IntBasis OPE_CONTA_SUN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 NUM-CONTA-SUN        PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis NUM_CONTA_SUN { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 DIG-CONTA-SUN        PIC S9(4) USAGE COMP.*/
        public IntBasis DIG_CONTA_SUN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VAL-COMIS-SUN        PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis VAL_COMIS_SUN { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"*/
    }
}