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
    public class TARIBCEF_DCLTARIFA_BALCAO_CEF : VarBasis
    {
        /*"    10 COD-EMPRESA          PIC S9(9) USAGE COMP.*/
        public IntBasis COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 NUM-MATRICULA        PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis NUM_MATRICULA { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 TIPO-FUNCIONARIO     PIC X(1).*/
        public StringBasis TIPO_FUNCIONARIO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 NUM-CERTIFICADO      PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis NUM_CERTIFICADO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 DATA-MOVIMENTO       PIC X(10).*/
        public StringBasis DATA_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 COD-PRODUTO          PIC S9(4) USAGE COMP.*/
        public IntBasis COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SITUACAO             PIC X(1).*/
        public StringBasis SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 COD-FONTE            PIC S9(4) USAGE COMP.*/
        public IntBasis COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 COD-ESCNEG           PIC S9(4) USAGE COMP.*/
        public IntBasis COD_ESCNEG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 AGE-COBRANCA         PIC S9(4) USAGE COMP.*/
        public IntBasis AGE_COBRANCA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 BCO-AVISO            PIC S9(4) USAGE COMP.*/
        public IntBasis BCO_AVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 AGE-AVISO            PIC S9(4) USAGE COMP.*/
        public IntBasis AGE_AVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 NUM-AVISO-CREDITO    PIC S9(9) USAGE COMP.*/
        public IntBasis NUM_AVISO_CREDITO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 VAL-TARIFA           PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis VAL_TARIFA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 VAL-BALCAO           PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis VAL_BALCAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 TIMESTAMP            PIC X(26).*/
        public StringBasis TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}