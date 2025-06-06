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
    public class PMONLK01_LK_GE3000B_PARAMETROS : VarBasis
    {
        /*"    03 FILLER                             PIC X(002)*/
        public StringBasis FILLER { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
        /*"    03 LK-:GE3000B:-OPERACAO              PIC X(003)*/
        public StringBasis LK_GE3000B_OPERACAO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
        /*"    03 LK-:GE3000B:-SEQ-MONITOR           PIC 9(018)*/
        public IntBasis LK_GE3000B_SEQ_MONITOR { get; set; } = new IntBasis(new PIC("9", "18", "9(018)"));
        /*"    03 LK-:GE3000B:-COD-PROCESSAMENTO     PIC X(005)*/
        public StringBasis LK_GE3000B_COD_PROCESSAMENTO { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
        /*"    03 LK-:GE3000B:-SEQ-LOG-SISTEMA       PIC 9(018)*/
        public IntBasis LK_GE3000B_SEQ_LOG_SISTEMA { get; set; } = new IntBasis(new PIC("9", "18", "9(018)"));
        /*"    03 LK-:GE3000B:-COD-USUARIO           PIC X(008)*/
        public StringBasis LK_GE3000B_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
        /*"    03 LK-:GE3000B:-COD-PROGRAMA          PIC X(010)*/
        public StringBasis LK_GE3000B_COD_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"    03 LK-:GE3000B:-PROC-ARQ              PIC X(001)*/
        public StringBasis LK_GE3000B_PROC_ARQ { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"    03 LK-:GE3000B:-TRACE                 PIC X(003)*/
        public StringBasis LK_GE3000B_TRACE { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
        /*"    03 LK-:GE3000B:-IND-ERRO              PIC 9(002)*/
        public IntBasis LK_GE3000B_IND_ERRO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
        /*"    03 LK-:GE3000B:-MSG-RETORNO           PIC X(070)*/
        public StringBasis LK_GE3000B_MSG_RETORNO { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"");
        /*"    03 LK-:GE3000B:-COD-TP-ARQUIVO        PIC X(003)*/
        public StringBasis LK_GE3000B_COD_TP_ARQUIVO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
        /*"    03 LK-:GE3000B:-ASSIGN-DDNAME         PIC X(008)*/
        public StringBasis LK_GE3000B_ASSIGN_DDNAME { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
        /*"    03 LK-:GE3000B:-NUM-ITEM-MOV          PIC S9(9) COMP*/
        public IntBasis LK_GE3000B_NUM_ITEM_MOV { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    03 LK-:GE3000B:-COD-LEIAUTE           PIC X(010)*/
        public StringBasis LK_GE3000B_COD_LEIAUTE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"    03 LK-:GE3000B:-NUM-VERSAO            PIC S9(04) COMP*/
        public IntBasis LK_GE3000B_NUM_VERSAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"    03 LK-:GE3000B:-COD-TP-REGISTRO       PIC X(002)*/
        public StringBasis LK_GE3000B_COD_TP_REGISTRO { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
        /*"    03 LK-:GE3000B:-NUM-PES-OPERADOR      PIC S9(09) COMP*/
        public IntBasis LK_GE3000B_NUM_PES_OPERADOR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"    03 LK-:GE3000B:-NUM-LINHA-PRODUTO     PIC S9(04) COMP*/
        public IntBasis LK_GE3000B_NUM_LINHA_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"    03 LK-:GE3000B:-NUM-CONTRATO-TERC     PIC S9(18) COMP*/
        public IntBasis LK_GE3000B_NUM_CONTRATO_TERC { get; set; } = new IntBasis(new PIC("S9", "18", "S9(18)"));
        /*"    03 LK-:GE3000B:-NUM-CONTRATO          PIC S9(09) COMP*/
        public IntBasis LK_GE3000B_NUM_CONTRATO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"    03 LK-:GE3000B:-TXT-CONTD             PIC X(2000)*/
        public StringBasis LK_GE3000B_TXT_CONTD { get; set; } = new StringBasis(new PIC("X", "2000", "X(2000)"), @"");
    }
}