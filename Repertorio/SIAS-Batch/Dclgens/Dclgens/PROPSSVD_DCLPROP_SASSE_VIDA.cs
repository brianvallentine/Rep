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
    public class PROPSSVD_DCLPROP_SASSE_VIDA : VarBasis
    {
        /*"    10 PROPSSVD-NUM-IDENTIFICACAO       PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis PROPSSVD_NUM_IDENTIFICACAO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 PROPSSVD-DPS-TITULAR       PIC X(25).*/
        public StringBasis PROPSSVD_DPS_TITULAR { get; set; } = new StringBasis(new PIC("X", "25", "X(25)."), @"");
        /*"    10 PROPSSVD-DPS-CONJUGE       PIC X(25).*/
        public StringBasis PROPSSVD_DPS_CONJUGE { get; set; } = new StringBasis(new PIC("X", "25", "X(25)."), @"");
        /*"    10 PROPSSVD-APOS-INVALIDEZ       PIC X(1).*/
        public StringBasis PROPSSVD_APOS_INVALIDEZ { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 PROPSSVD-COD-USUARIO       PIC X(8).*/
        public StringBasis PROPSSVD_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 PROPSSVD-NUM-APOLICE       PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis PROPSSVD_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 PROPSSVD-COD-SUBGRUPO       PIC S9(4) USAGE COMP.*/
        public IntBasis PROPSSVD_COD_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PROPSSVD-TIMESTAMP   PIC X(26).*/
        public StringBasis PROPSSVD_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 PROPSSVD-NUM-CONTR-VINCULO       PIC S9(18)V USAGE COMP-3.*/
        public DoubleBasis PROPSSVD_NUM_CONTR_VINCULO { get; set; } = new DoubleBasis(new PIC("S9", "18", "S9(18)V"), 0);
        /*"    10 PROPSSVD-COD-CORRESP-BANC       PIC S9(9) USAGE COMP.*/
        public IntBasis PROPSSVD_COD_CORRESP_BANC { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 PROPSSVD-NUM-PRAZO-FIN       PIC S9(4) USAGE COMP.*/
        public IntBasis PROPSSVD_NUM_PRAZO_FIN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PROPSSVD-COD-OPER-CREDITO       PIC S9(4) USAGE COMP.*/
        public IntBasis PROPSSVD_COD_OPER_CREDITO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"*/
    }
}