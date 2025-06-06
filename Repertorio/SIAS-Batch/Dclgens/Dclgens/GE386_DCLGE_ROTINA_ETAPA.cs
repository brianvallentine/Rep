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
    public class GE386_DCLGE_ROTINA_ETAPA : VarBasis
    {
        /*"    10 GE386-NOM-ROTINA     PIC X(8).*/
        public StringBasis GE386_NOM_ROTINA { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 GE386-SEQ-ETAPA      PIC S9(4) USAGE COMP.*/
        public IntBasis GE386_SEQ_ETAPA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE386-DTH-INI-VIGENCIA       PIC X(26).*/
        public StringBasis GE386_DTH_INI_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 GE386-DTH-FIM-VIGENCIA       PIC X(26).*/
        public StringBasis GE386_DTH_FIM_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 GE386-IND-TIPO-ETAPA       PIC S9(4) USAGE COMP.*/
        public IntBasis GE386_IND_TIPO_ETAPA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE386-NOM-PROGRAMA   PIC X(8).*/
        public StringBasis GE386_NOM_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 GE386-STA-ETAPA      PIC X(1).*/
        public StringBasis GE386_STA_ETAPA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 GE386-QTD-EXEC-ETAPA       PIC S9(9) USAGE COMP.*/
        public IntBasis GE386_QTD_EXEC_ETAPA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GE386-STA-ULTIMA-EXEC       PIC X(1).*/
        public StringBasis GE386_STA_ULTIMA_EXEC { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 GE386-SEQ-ETAPA-ANT  PIC S9(4) USAGE COMP.*/
        public IntBasis GE386_SEQ_ETAPA_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE386-COD-USUARIO    PIC X(8).*/
        public StringBasis GE386_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"*/
    }
}