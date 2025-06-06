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
    public class LBLT3150_LT3150_AREA_PARAMETROS : VarBasis
    {
        /*"  03       LT3150-NUM-CLASSE            PIC  9(004)*/
        public IntBasis LT3150_NUM_CLASSE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"  03       LT3150-COD-REGIAO            PIC  9(004)*/
        public IntBasis LT3150_COD_REGIAO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"  03       LT3150-DTINIVIG              PIC  X(010)*/
        public StringBasis LT3150_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"  03       LT3150-DTTERVIG              PIC  X(010)*/
        public StringBasis LT3150_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"  03       LT3150-TAB-TAXAS*/
        public LBLT3150_LT3150_TAB_TAXAS LT3150_TAB_TAXAS { get; set; } = new LBLT3150_LT3150_TAB_TAXAS();

        public LBLT3150_LT3150_TAB_COEFICIENTES LT3150_TAB_COEFICIENTES { get; set; } = new LBLT3150_LT3150_TAB_COEFICIENTES();

        public StringBasis LT3150_DISPLAY { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"  03       LT3150-COD-RETORNO           PIC  9(006)*/
        public IntBasis LT3150_COD_RETORNO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
        /*"  03       LT3150-MENSAGEM              PIC  X(070)*/
        public StringBasis LT3150_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"");
        /*"*/
    }
}