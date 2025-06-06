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
    public class GE385_DCLGE_ROTINA_BATCH : VarBasis
    {
        /*"    10 GE385-NOM-ROTINA     PIC X(8).*/
        public StringBasis GE385_NOM_ROTINA { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 GE385-DES-ROTINA     PIC X(70).*/
        public StringBasis GE385_DES_ROTINA { get; set; } = new StringBasis(new PIC("X", "70", "X(70)."), @"");
        /*"    10 GE385-IDE-SISTEMA    PIC X(2).*/
        public StringBasis GE385_IDE_SISTEMA { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 GE385-IND-TIPO-PERIODO       PIC X(1).*/
        public StringBasis GE385_IND_TIPO_PERIODO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 GE385-IND-TIPO-EXECUCAO       PIC X(1).*/
        public StringBasis GE385_IND_TIPO_EXECUCAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 GE385-NOM-ANALISTA-RESP       PIC X(50).*/
        public StringBasis GE385_NOM_ANALISTA_RESP { get; set; } = new StringBasis(new PIC("X", "50", "X(50)."), @"");
        /*"    10 GE385-QTD-ETAPAS     PIC S9(4) USAGE COMP.*/
        public IntBasis GE385_QTD_ETAPAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE385-QTD-PROGRAMAS  PIC S9(4) USAGE COMP.*/
        public IntBasis GE385_QTD_PROGRAMAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE385-STA-ROTINA     PIC X(1).*/
        public StringBasis GE385_STA_ROTINA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 GE385-IND-ROTINA-PREC       PIC X(1).*/
        public StringBasis GE385_IND_ROTINA_PREC { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 GE385-COD-USUARIO    PIC X(8).*/
        public StringBasis GE385_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 GE385-DTH-ATUALIZACAO       PIC X(26).*/
        public StringBasis GE385_DTH_ATUALIZACAO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}