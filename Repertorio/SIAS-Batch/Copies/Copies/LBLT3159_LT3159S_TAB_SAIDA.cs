using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Copies
{
    public class LBLT3159_LT3159S_TAB_SAIDA : VarBasis
    {
        /*"      15   LT3159S-TB-PARAM              PIC  9(004)*/
        public IntBasis LT3159S_TB_PARAM { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"      15   LT3159S-TB-DTINIVIG           PIC  X(010)*/
        public StringBasis LT3159S_TB_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"      15   LT3159S-TB-DTTERVIG           PIC  X(010)*/
        public StringBasis LT3159S_TB_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"      15   LT3159S-TB-NOME               PIC  X(030)*/
        public StringBasis LT3159S_TB_NOME { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
        /*"      15   LT3159S-TB-VALOR              PIC  S9(009)V999 COMP-3*/
        public DoubleBasis LT3159S_TB_VALOR { get; set; } = new DoubleBasis(new PIC("S9", "9", "S9(009)V999"), 3);
        /*"      15   LT3159S-TB-VALOR-DT           PIC  X(010)*/
        public StringBasis LT3159S_TB_VALOR_DT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"  05       LT3159S-COD-RETORNO           PIC  9(004)*/
    }
}