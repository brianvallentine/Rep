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
    public class SI127_DCLSI_PARCELA_AVISO : VarBasis
    {
        /*"    10 SI127-NUM-APOL-SINISTRO  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis SI127_NUM_APOL_SINISTRO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 SI127-COD-OPERACAO-SINI  PIC S9(4) USAGE COMP.*/
        public IntBasis SI127_COD_OPERACAO_SINI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SI127-OCORR-HISTORICO  PIC S9(4) USAGE COMP.*/
        public IntBasis SI127_OCORR_HISTORICO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SI127-NUM-RESSARC    PIC S9(9) USAGE COMP.*/
        public IntBasis SI127_NUM_RESSARC { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SI127-SEQ-RESSARC    PIC S9(4) USAGE COMP.*/
        public IntBasis SI127_SEQ_RESSARC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SI127-NUM-PARCELA    PIC S9(9) USAGE COMP.*/
        public IntBasis SI127_NUM_PARCELA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SI127-BCO-AVISO      PIC S9(4) USAGE COMP.*/
        public IntBasis SI127_BCO_AVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SI127-AGE-AVISO      PIC S9(4) USAGE COMP.*/
        public IntBasis SI127_AGE_AVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SI127-NUM-AVISO-CREDITO  PIC S9(9) USAGE COMP.*/
        public IntBasis SI127_NUM_AVISO_CREDITO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SI127-NUM-SEQUENCIA  PIC S9(9) USAGE COMP.*/
        public IntBasis SI127_NUM_SEQUENCIA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SI127-DATA-MOVIMENTO  PIC X(10).*/
        public StringBasis SI127_DATA_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SI127-COD-OPERACAO   PIC S9(4) USAGE COMP.*/
        public IntBasis SI127_COD_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SI127-DTH-CADASTRAMENTO  PIC X(26).*/
        public StringBasis SI127_DTH_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}