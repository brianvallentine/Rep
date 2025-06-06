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
    public class LBLT2118_LT2118S_ENTRADA : VarBasis
    {
        /*"    10   LT2118S-COD-MOVIMENTO         PIC  X(001)*/
        public StringBasis LT2118S_COD_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"    10   LT2118S-NUM-APOLICE           PIC S9(013)  COMP-3*/
        public IntBasis LT2118S_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"    10   LT2118S-NUM-CLASSE            PIC S9(004)  COMP*/
        public IntBasis LT2118S_NUM_CLASSE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"    10   LT2118S-IND-REGIAO            PIC S9(004)  COMP*/
        public IntBasis LT2118S_IND_REGIAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"    10   LT2118S-PCT-DESC-FIDEL        PIC S9(03)V9(02) COMP-3*/
        public DoubleBasis LT2118S_PCT_DESC_FIDEL { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V9(02)"), 2);
        /*"    10   LT2118S-PCT-DESC-EXP          PIC S9(03)V9(02) COMP-3*/
        public DoubleBasis LT2118S_PCT_DESC_EXP { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V9(02)"), 2);
        /*"    10   LT2118S-PCT-DESC-AGRUP        PIC S9(03)V9(02) COMP-3*/
        public DoubleBasis LT2118S_PCT_DESC_AGRUP { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V9(02)"), 2);
        /*"    10   LT2118S-PCT-DESC-COFRE        PIC S9(03)V9(02) COMP-3*/
        public DoubleBasis LT2118S_PCT_DESC_COFRE { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V9(02)"), 2);
        /*"    10   LT2118S-PCT-DESC-BLINDAGEM    PIC S9(03)V9(02) COMP-3*/
        public DoubleBasis LT2118S_PCT_DESC_BLINDAGEM { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V9(02)"), 2);
        /*"    10   LT2118S-DATA-INIVIGENCIA      PIC  X(010)*/
        public StringBasis LT2118S_DATA_INIVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"    10   LT2118S-QTD-PARCELAS          PIC S9(004)  COMP*/
        public IntBasis LT2118S_QTD_PARCELAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"    10   LT2118S-TIPO-CALCULO          PIC S9(004)  COMP*/
        public IntBasis LT2118S_TIPO_CALCULO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"    10   LT2118S-ISENTA-CUSTO          PIC  X(001)*/
        public StringBasis LT2118S_ISENTA_CUSTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"    10   LT2118S-PRM-TARIFARIO-1PCL    PIC S9(010)V9999*/
        public DoubleBasis LT2118S_PRM_TARIFARIO_1PCL { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9999"), 4);
        /*"    10   LT2118S-PRM-TARIFARIO-TOTAL   PIC S9(010)V9999*/
        public DoubleBasis LT2118S_PRM_TARIFARIO_TOTAL { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9999"), 4);
        /*"  05     LT2118S-SAIDA-PARCELA1*/
    }
}