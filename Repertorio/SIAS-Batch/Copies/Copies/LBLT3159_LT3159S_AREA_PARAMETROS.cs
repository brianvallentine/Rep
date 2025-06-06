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
    public class LBLT3159_LT3159S_AREA_PARAMETROS : VarBasis
    {
        /*"  05       LT3159S-OPERACAO              PIC  X(002)*/
        public StringBasis LT3159S_OPERACAO { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
        /*"  05       LT3159S-ANO-RENOVACAO         PIC S9(004)  COMP*/
        public IntBasis LT3159S_ANO_RENOVACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"  05       LT3159S-PARAM                 PIC S9(004)  COMP*/
        public IntBasis LT3159S_PARAM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"  05       LT3159S-DATA-INIVIGENCIA      PIC  X(010)*/
        public StringBasis LT3159S_DATA_INIVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"  05       LT3159S-DATA-FIMVIGENCIA      PIC  X(010)*/
        public StringBasis LT3159S_DATA_FIMVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"  05       LT3159S-VALOR                 PIC  S9(09)V999 COMP-3*/
        public DoubleBasis LT3159S_VALOR { get; set; } = new DoubleBasis(new PIC("S9", "9", "S9(09)V999"), 3);
        /*"  05       LT3159S-VALOR-DT              PIC  X(010)*/
        public StringBasis LT3159S_VALOR_DT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"  05       LT3159S-NOME                  PIC  X(030)*/
        public StringBasis LT3159S_NOME { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
        /*"  05       LT3159S-PCT-DESC-BLINDAGEM    PIC  S9(003)V999 COMP-3*/
        public DoubleBasis LT3159S_PCT_DESC_BLINDAGEM { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V999"), 3);
        /*"  05       LT3159S-TABELA-SAIDA*/
        public LBLT3159_LT3159S_TABELA_SAIDA LT3159S_TABELA_SAIDA { get; set; } = new LBLT3159_LT3159S_TABELA_SAIDA();

        public IntBasis LT3159S_COD_RETORNO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"  05       LT3159S-MSG-RETORNO           PIC  X(070)*/
        public StringBasis LT3159S_MSG_RETORNO { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"");
        /*"  05       LT3159S-VALOR-TXT             PIC  X(015)*/
        public StringBasis LT3159S_VALOR_TXT { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"");
        /*"  05       LT3159S-TIPO-PARAM            PIC S9(004)  COMP*/
        public IntBasis LT3159S_TIPO_PARAM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"  05       LT3159S-DATA-PARAM            PIC X(010)*/
        public StringBasis LT3159S_DATA_PARAM { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"  05       LT3159S-COD-PRODUTO           PIC S9(004) COMP*/
        public IntBasis LT3159S_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
    }
}