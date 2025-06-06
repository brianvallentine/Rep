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
    public class LBFPF010_REG_VENDAS : VarBasis
    {
        /*"    10  RC-TIPO-REG                 PIC  X(001)*/
        public StringBasis RC_TIPO_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"    10  RC-NUM-PROPOSTA             PIC  9(014)*/
        public IntBasis RC_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
        /*"    10  RC-COD-OPERADOR             PIC  X(009)*/
        public StringBasis RC_COD_OPERADOR { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"");
        /*"    10  RC-NUM-CORRESPONDENTE       PIC  9(009)*/
        public IntBasis RC_NUM_CORRESPONDENTE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"    10  RC-DATA-CONTRATACAO         PIC  9(008)*/
        public IntBasis RC_DATA_CONTRATACAO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"    10  RC-HORA-CONTRATACAO         PIC  9(006)*/
        public IntBasis RC_HORA_CONTRATACAO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
        /*"    10  RC-NUM-PROPOSTA-SICAQ       PIC  9(010)*/
        public IntBasis RC_NUM_PROPOSTA_SICAQ { get; set; } = new IntBasis(new PIC("9", "10", "9(010)"));
        /*"    10  RC-TIPO-CORREPONDENTE       PIC  9(002)*/
        public IntBasis RC_TIPO_CORREPONDENTE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
        /*"    10  RC-ORIG-PROPOSTA            PIC  X(005)*/
        public StringBasis RC_ORIG_PROPOSTA { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
        /*"    10  RC-ESPACOS                  PIC  X(236)*/
        public StringBasis RC_ESPACOS { get; set; } = new StringBasis(new PIC("X", "236", "X(236)"), @"");
        /*"*/
    }
}