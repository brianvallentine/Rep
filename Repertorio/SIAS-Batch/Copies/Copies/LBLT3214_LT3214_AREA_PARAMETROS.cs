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
    public class LBLT3214_LT3214_AREA_PARAMETROS : VarBasis
    {
        /*"  05  LT3214-TIPO-OPERACAO          PIC  X(02)*/
        public StringBasis LT3214_TIPO_OPERACAO { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"");
        /*"  05  LT3214-COD-LOTERICO           PIC S9(10)       COMP-3*/
        public IntBasis LT3214_COD_LOTERICO { get; set; } = new IntBasis(new PIC("S9", "10", "S9(10)"));
        /*"  05  LT3214-NUM-PROPOSTA-SIM       PIC S9(18)       COMP*/
        public IntBasis LT3214_NUM_PROPOSTA_SIM { get; set; } = new IntBasis(new PIC("S9", "18", "S9(18)"));
        /*"  05  LT3214-IND-TIPO-VIGENCIA      PIC S9(04)       COMP*/
        public IntBasis LT3214_IND_TIPO_VIGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"  05  LT3214-SEQ-PROPOSTA           PIC S9(09)       COMP*/
        public IntBasis LT3214_SEQ_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"  05  LT3214-DATA-MOVIMENTO         PIC  X(10)*/
        public StringBasis LT3214_DATA_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"  05  LT3214-HORA-MOVIMENTO         PIC  X(08)*/
        public StringBasis LT3214_HORA_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
        /*"  05 TABELA-VALORES-RETORNO*/
        public LBLT3214_TABELA_VALORES_RETORNO TABELA_VALORES_RETORNO { get; set; } = new LBLT3214_TABELA_VALORES_RETORNO();

        public IntBasis LT3214_COD_RETORNO { get; set; } = new IntBasis(new PIC("S9", "5", "S9(05)"));
        /*"  05  LT3214-MSG-RETORNO            PIC  X(100)*/
        public StringBasis LT3214_MSG_RETORNO { get; set; } = new StringBasis(new PIC("X", "100", "X(100)"), @"");
    }
}