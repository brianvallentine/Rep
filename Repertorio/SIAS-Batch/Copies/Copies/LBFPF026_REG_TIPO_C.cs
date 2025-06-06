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
    public class LBFPF026_REG_TIPO_C : VarBasis
    {
        /*"    10 REGC-IDENTIFICACAO           PIC 9(001)*/
        public IntBasis REGC_IDENTIFICACAO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
        /*"    10 REGC-NUM-PROPOSTA            PIC 9(014)*/
        public IntBasis REGC_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
        /*"    10 REGC-COD-OPERADOR            PIC X(009)*/
        public StringBasis REGC_COD_OPERADOR { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"");
        /*"    10 REGC-NUM-CORRESPONDENTE      PIC 9(009)*/
        public IntBasis REGC_NUM_CORRESPONDENTE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"    10 REGC-DATA-CONTRATACAO        PIC 9(008)*/
        public IntBasis REGC_DATA_CONTRATACAO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"    10 REGC-HORA-CONTRATACAO        PIC 9(006)*/
        public IntBasis REGC_HORA_CONTRATACAO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
        /*"    10 REGC-NRO-PROPOSTA-SICAQ      PIC 9(010)*/
        public IntBasis REGC_NRO_PROPOSTA_SICAQ { get; set; } = new IntBasis(new PIC("9", "10", "9(010)"));
        /*"    10 REGC-TIPO-CORRESPONDENTE     PIC 9(002)*/
        public IntBasis REGC_TIPO_CORRESPONDENTE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
        /*"    10 REGC-ORIGEM-PROPOSTA         PIC 9(005)*/
        public IntBasis REGC_ORIGEM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
        /*"    10 REGC-CODIGO-CANAL            PIC 9(001)*/
        public IntBasis REGC_CODIGO_CANAL { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
        /*"    10 REGC-CODIGO-PRODUTO          PIC 9(002)*/
        public IntBasis REGC_CODIGO_PRODUTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
        /*"    10 FILLER                       PIC X(233)*/
        public StringBasis FILLER { get; set; } = new StringBasis(new PIC("X", "233", "X(233)"), @"");
        /*"*/
    }
}