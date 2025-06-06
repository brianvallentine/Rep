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
    public class SIARREVC_DCLSI_AR_RETORNO_VC : VarBasis
    {
        /*"    10 SIARREVC-NOM-ARQUIVO-VC  PIC X(8).*/
        public StringBasis SIARREVC_NOM_ARQUIVO_VC { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 SIARREVC-SEQ-GERACAO-VC  PIC S9(9) USAGE COMP.*/
        public IntBasis SIARREVC_SEQ_GERACAO_VC { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SIARREVC-TIPO-REGISTRO-VC  PIC X(1).*/
        public StringBasis SIARREVC_TIPO_REGISTRO_VC { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SIARREVC-SEQ-REGISTRO-VC  PIC S9(9) USAGE COMP.*/
        public IntBasis SIARREVC_SEQ_REGISTRO_VC { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SIARREVC-NOM-ARQUIVO  PIC X(8).*/
        public StringBasis SIARREVC_NOM_ARQUIVO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 SIARREVC-SEQ-GERACAO  PIC S9(9) USAGE COMP.*/
        public IntBasis SIARREVC_SEQ_GERACAO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SIARREVC-TIPO-REGISTRO  PIC X(1).*/
        public StringBasis SIARREVC_TIPO_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SIARREVC-NUM-SEQ-REG  PIC S9(9) USAGE COMP.*/
        public IntBasis SIARREVC_NUM_SEQ_REG { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"*/
    }
}