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
    public class LBFPF162_REGISTRO_PRESTAMISTA : VarBasis
    {
        /*"  10   R6-TIPO-REG                     PIC  X(001)*/
        public StringBasis R6_TIPO_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"  10   R6-NUM-PROPOSTA                 PIC  9(014)*/
        public IntBasis R6_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
        /*"  10   R6-DES-OPER-CREDITO             PIC  X(030)*/
        public StringBasis R6_DES_OPER_CREDITO { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
        /*"  10   R6-NUM-CONTR-VINCULO            PIC  9(018)*/
        public IntBasis R6_NUM_CONTR_VINCULO { get; set; } = new IntBasis(new PIC("9", "18", "9(018)"));
        /*"  10   R6-COD-CORRESP-BANC             PIC  9(009)*/
        public IntBasis R6_COD_CORRESP_BANC { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"  10   R6-VLR-CONTRATO                 PIC  9(010)*/
        public IntBasis R6_VLR_CONTRATO { get; set; } = new IntBasis(new PIC("9", "10", "9(010)"));
        /*"  10   R6-QTD-PRAZO                    PIC  9(003)*/
        public IntBasis R6_QTD_PRAZO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
        /*"  10   FILLER                          PIC  X(215)*/
        public StringBasis FILLER { get; set; } = new StringBasis(new PIC("X", "215", "X(215)"), @"");
        /*"*/
    }
}