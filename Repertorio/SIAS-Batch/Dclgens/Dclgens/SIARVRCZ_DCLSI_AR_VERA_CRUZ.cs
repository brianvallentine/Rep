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
    public class SIARVRCZ_DCLSI_AR_VERA_CRUZ : VarBasis
    {
        /*"    10 SIARVRCZ-NOM-ARQUIVO  PIC X(8).*/
        public StringBasis SIARVRCZ_NOM_ARQUIVO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 SIARVRCZ-SEQ-GERACAO  PIC S9(9) USAGE COMP.*/
        public IntBasis SIARVRCZ_SEQ_GERACAO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SIARVRCZ-TIPO-REGISTRO  PIC X(1).*/
        public StringBasis SIARVRCZ_TIPO_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SIARVRCZ-SEQ-REGISTRO  PIC S9(9) USAGE COMP.*/
        public IntBasis SIARVRCZ_SEQ_REGISTRO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SIARVRCZ-STA-PROCESSAMENTO  PIC X(1).*/
        public StringBasis SIARVRCZ_STA_PROCESSAMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SIARVRCZ-COD-ERRO    PIC S9(4) USAGE COMP.*/
        public IntBasis SIARVRCZ_COD_ERRO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"*/
    }
}