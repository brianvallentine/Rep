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
    public class PARAMCON_DCLPARAM_CONTACEF : VarBasis
    {
        /*"    10 PARAMCON-COD-EMPRESA       PIC S9(9) USAGE COMP.*/
        public IntBasis PARAMCON_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 PARAMCON-COD-BANCO   PIC S9(4) USAGE COMP.*/
        public IntBasis PARAMCON_COD_BANCO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PARAMCON-TIPO-MOVTO-CC       PIC S9(4) USAGE COMP.*/
        public IntBasis PARAMCON_TIPO_MOVTO_CC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PARAMCON-COD-PRODUTO       PIC S9(4) USAGE COMP.*/
        public IntBasis PARAMCON_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PARAMCON-COD-CONVENIO       PIC S9(9) USAGE COMP.*/
        public IntBasis PARAMCON_COD_CONVENIO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 PARAMCON-NSAS        PIC S9(4) USAGE COMP.*/
        public IntBasis PARAMCON_NSAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PARAMCON-COD-AGENCIA-SASS       PIC S9(4) USAGE COMP.*/
        public IntBasis PARAMCON_COD_AGENCIA_SASS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PARAMCON-OPER-CONTA-SASS       PIC S9(4) USAGE COMP.*/
        public IntBasis PARAMCON_OPER_CONTA_SASS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PARAMCON-NUM-CONTA-SASS       PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis PARAMCON_NUM_CONTA_SASS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 PARAMCON-DIG-CONTA-SASS       PIC S9(4) USAGE COMP.*/
        public IntBasis PARAMCON_DIG_CONTA_SASS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PARAMCON-DATA-MOVIMENTO       PIC X(10).*/
        public StringBasis PARAMCON_DATA_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 PARAMCON-DATA-PROXIMO-DEB       PIC X(10).*/
        public StringBasis PARAMCON_DATA_PROXIMO_DEB { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 PARAMCON-DIA-DEBITO  PIC S9(4) USAGE COMP.*/
        public IntBasis PARAMCON_DIA_DEBITO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PARAMCON-SIT-REGISTRO       PIC X(1).*/
        public StringBasis PARAMCON_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 PARAMCON-TIMESTAMP   PIC X(26).*/
        public StringBasis PARAMCON_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 PARAMCON-DESCR-CONVENIO       PIC X(30).*/
        public StringBasis PARAMCON_DESCR_CONVENIO { get; set; } = new StringBasis(new PIC("X", "30", "X(30)."), @"");
        /*"*/
    }
}