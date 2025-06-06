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
    public class GE387_DCLGE_EXEC_ROTINA_ETAPA : VarBasis
    {
        /*"    10 GE387-NOM-ROTINA     PIC X(8).*/
        public StringBasis GE387_NOM_ROTINA { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 GE387-SEQ-ETAPA      PIC S9(4) USAGE COMP.*/
        public IntBasis GE387_SEQ_ETAPA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE387-DTH-INI-VIGENCIA       PIC X(26).*/
        public StringBasis GE387_DTH_INI_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 GE387-NUM-EXEC-ETAPA       PIC S9(9) USAGE COMP.*/
        public IntBasis GE387_NUM_EXEC_ETAPA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GE387-DTA-INI-MOVIMENTO       PIC X(10).*/
        public StringBasis GE387_DTA_INI_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GE387-DTA-FIM-MOVIMENTO       PIC X(10).*/
        public StringBasis GE387_DTA_FIM_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GE387-QTD-REG-LIDOS  PIC S9(9) USAGE COMP.*/
        public IntBasis GE387_QTD_REG_LIDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GE387-QTD-REG-PROCS  PIC S9(9) USAGE COMP.*/
        public IntBasis GE387_QTD_REG_PROCS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GE387-QTD-REG-GRAVD  PIC S9(9) USAGE COMP.*/
        public IntBasis GE387_QTD_REG_GRAVD { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GE387-QTD-REG-ALTER  PIC S9(9) USAGE COMP.*/
        public IntBasis GE387_QTD_REG_ALTER { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GE387-QTD-REG-EXCLU  PIC S9(9) USAGE COMP.*/
        public IntBasis GE387_QTD_REG_EXCLU { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GE387-STA-EXECUCAO   PIC X(1).*/
        public StringBasis GE387_STA_EXECUCAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 GE387-DTH-INI-EXECUCAO       PIC X(26).*/
        public StringBasis GE387_DTH_INI_EXECUCAO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 GE387-DTH-FIM-EXECUCAO       PIC X(26).*/
        public StringBasis GE387_DTH_FIM_EXECUCAO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}