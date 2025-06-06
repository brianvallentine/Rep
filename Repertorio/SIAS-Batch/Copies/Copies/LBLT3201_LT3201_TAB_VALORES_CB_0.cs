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
    public class LBLT3201_LT3201_TAB_VALORES_CB_0 : VarBasis
    {
        /*"         20 LT3201-COD-CB             PIC S9(04)       COMP*/
        public IntBasis LT3201_COD_CB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"         20 LT3201-IMP-SEG-CB         PIC S9(08)V9(2)  COMP-3*/
        public DoubleBasis LT3201_IMP_SEG_CB { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(08)V9(2)"), 2);
        /*"         20 LT3201-QTDDIAS-CB         PIC S9(04)       COMP*/
        public IntBasis LT3201_QTDDIAS_CB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"         20 LT3201-PCTPLURI-CB        PIC S9(03)V9(04) COMP-3*/
        public DoubleBasis LT3201_PCTPLURI_CB { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V9(04)"), 4);
        /*"         20 LT3201-FATOR-CB           PIC S9(03)V9(04) COMP-3*/
        public DoubleBasis LT3201_FATOR_CB { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V9(04)"), 4);
        /*"         20 LT3201-TAXA-CB            PIC S9(03)V9(09) COMP-3*/
        public DoubleBasis LT3201_TAXA_CB { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V9(09)"), 9);
        /*"         20 LT3201-PRMLIQ-CB          PIC S9(08)V9(02) COMP-3*/
        public DoubleBasis LT3201_PRMLIQ_CB { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(08)V9(02)"), 2);
        /*"         20 LT3201-ADIC-CB            PIC S9(08)V9(02) COMP-3*/
        public DoubleBasis LT3201_ADIC_CB { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(08)V9(02)"), 2);
        /*"         20 LT3201-IOF-CB             PIC S9(08)V9(02) COMP-3*/
        public DoubleBasis LT3201_IOF_CB { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(08)V9(02)"), 2);
        /*"         20 LT3201-PRMTOT-CB          PIC S9(08)V9(02) COMP-3*/
        public DoubleBasis LT3201_PRMTOT_CB { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(08)V9(02)"), 2);
        /*"  05 TABELA-VALORES-RETORNO*/
    }
}