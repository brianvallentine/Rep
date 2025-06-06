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
    public class MRPROQUE_DCLMR_PROPOSTA_QUEST : VarBasis
    {
        /*"    10 MRPROQUE-COD-FONTE   PIC S9(4) USAGE COMP.*/
        public IntBasis MRPROQUE_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MRPROQUE-NUM-PROPOSTA  PIC S9(9) USAGE COMP.*/
        public IntBasis MRPROQUE_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 MRPROQUE-NUM-ITEM    PIC S9(9) USAGE COMP.*/
        public IntBasis MRPROQUE_NUM_ITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 MRPROQUE-COD-PRODUTO  PIC S9(4) USAGE COMP.*/
        public IntBasis MRPROQUE_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MRPROQUE-IND-PERGUNTA  PIC S9(4) USAGE COMP.*/
        public IntBasis MRPROQUE_IND_PERGUNTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MRPROQUE-SEQ-PERGUNTA  PIC S9(4) USAGE COMP.*/
        public IntBasis MRPROQUE_SEQ_PERGUNTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MRPROQUE-IND-RESPOSTA  PIC S9(4) USAGE COMP.*/
        public IntBasis MRPROQUE_IND_RESPOSTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MRPROQUE-SEQ-RESPOSTA  PIC S9(4) USAGE COMP.*/
        public IntBasis MRPROQUE_SEQ_RESPOSTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 MRPROQUE-DES-COMPLEMENTO.*/
        public MRPROQUE_MRPROQUE_DES_COMPLEMENTO MRPROQUE_DES_COMPLEMENTO { get; set; } = new MRPROQUE_MRPROQUE_DES_COMPLEMENTO();

        public DoubleBasis MRPROQUE_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 MRPROQUE-NUM-ENDOSSO  PIC S9(9) USAGE COMP.*/
        public IntBasis MRPROQUE_NUM_ENDOSSO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 MRPROQUE-DTH-TIMESTAMP  PIC X(26).*/
        public StringBasis MRPROQUE_DTH_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}