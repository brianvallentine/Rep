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
    public class LBFPF000_REG_PAG_AVULSO : VarBasis
    {
        /*"     10  R0-TIPO-REG                 PIC  X(001)*/
        public StringBasis R0_TIPO_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"     10  R0-NUM-PROPOSTA             PIC  9(014)*/
        public IntBasis R0_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
        /*"     10  R0-NUM-PARCELA              PIC  9(004)*/
        public IntBasis R0_NUM_PARCELA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"     10  R0-NUM-SICOB                PIC  9(014)*/
        public IntBasis R0_NUM_SICOB { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
        /*"     10  R0-VAL-PAGO                 PIC  9(013)V99*/
        public DoubleBasis R0_VAL_PAGO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
        /*"     10  R0-DATA-QUITACAO            PIC  9(008)*/
        public IntBasis R0_DATA_QUITACAO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"     10  R0-NRCERTIF                 PIC  9(015)*/
        public IntBasis R0_NRCERTIF { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
        /*"     10  R0-CPFCGC                   PIC  9(014)*/
        public IntBasis R0_CPFCGC { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
        /*"     10  R0-DATA-NASCIMENTO          PIC  9(008)*/
        public IntBasis R0_DATA_NASCIMENTO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"     10  R0-NOME-PAGADOR             PIC  X(040)*/
        public StringBasis R0_NOME_PAGADOR { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
        /*"     10  R0-COD-PRODUTO-PAGO         PIC  9(003)*/
        public IntBasis R0_COD_PRODUTO_PAGO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
        /*"     10  R0-TELEFONE-PGTO            PIC  X(011)*/
        public StringBasis R0_TELEFONE_PGTO { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"");
        /*"     10  R0-IDENTIFICA-PAGO          PIC  X(001)*/
        public StringBasis R0_IDENTIFICA_PAGO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"     10  R0-AGENCIA-RECEBEDORA       PIC  9(004)*/
        public IntBasis R0_AGENCIA_RECEBEDORA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"     10  FILLER                      PIC  X(148)*/
        public StringBasis FILLER { get; set; } = new StringBasis(new PIC("X", "148", "X(148)"), @"");
        /*"*/
    }
}