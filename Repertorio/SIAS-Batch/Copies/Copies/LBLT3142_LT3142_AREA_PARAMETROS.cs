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
    public class LBLT3142_LT3142_AREA_PARAMETROS : VarBasis
    {
        /*"  03       LT3142-NUM-CLASSE            PIC  9(004)*/
        public IntBasis LT3142_NUM_CLASSE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"  03       LT3142-QTD-PARCELAS          PIC  9(004)*/
        public IntBasis LT3142_QTD_PARCELAS { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"  03       LT3142-DTINIVIG              PIC  X(010)*/
        public StringBasis LT3142_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"  03       LT3142-DTTERVIG              PIC  X(010)*/
        public StringBasis LT3142_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"  03       LT3142-TAB-TAXAS*/
        public LBLT3142_LT3142_TAB_TAXAS LT3142_TAB_TAXAS { get; set; } = new LBLT3142_LT3142_TAB_TAXAS();

        public LBLT3142_LT3142_TAB_TAXAS_1PCL LT3142_TAB_TAXAS_1PCL { get; set; } = new LBLT3142_LT3142_TAB_TAXAS_1PCL();

        public StringBasis LT3142_DISPLAY { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"  03       LT3142-COD-RETORNO           PIC  9(006)*/
        public IntBasis LT3142_COD_RETORNO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
        /*"  03       LT3142-MENSAGEM              PIC  X(070)*/
        public StringBasis LT3142_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"");
    }
}