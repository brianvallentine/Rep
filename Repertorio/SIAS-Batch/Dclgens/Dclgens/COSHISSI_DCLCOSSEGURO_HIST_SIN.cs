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
    public class COSHISSI_DCLCOSSEGURO_HIST_SIN : VarBasis
    {
        /*"    10 COSHISSI-COD-EMPRESA  PIC S9(9) USAGE COMP.*/
        public IntBasis COSHISSI_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 COSHISSI-COD-CONGENERE  PIC S9(4) USAGE COMP.*/
        public IntBasis COSHISSI_COD_CONGENERE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 COSHISSI-NUM-SINISTRO  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis COSHISSI_NUM_SINISTRO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 COSHISSI-OCORR-HISTORICO  PIC S9(4) USAGE COMP.*/
        public IntBasis COSHISSI_OCORR_HISTORICO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 COSHISSI-COD-OPERACAO  PIC S9(4) USAGE COMP.*/
        public IntBasis COSHISSI_COD_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 COSHISSI-DATA-MOVIMENTO  PIC X(10).*/
        public StringBasis COSHISSI_DATA_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 COSHISSI-VAL-OPERACAO  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis COSHISSI_VAL_OPERACAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 COSHISSI-TIMESTAMP   PIC X(26).*/
        public StringBasis COSHISSI_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 COSHISSI-SIT-REGISTRO  PIC X(1).*/
        public StringBasis COSHISSI_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 COSHISSI-TIPO-SEGURO  PIC X(1).*/
        public StringBasis COSHISSI_TIPO_SEGURO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 COSHISSI-SIT-LIBRECUP  PIC X(1).*/
        public StringBasis COSHISSI_SIT_LIBRECUP { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"*/
    }
}