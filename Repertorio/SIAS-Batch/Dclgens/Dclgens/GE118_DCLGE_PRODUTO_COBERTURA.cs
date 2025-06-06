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
    public class GE118_DCLGE_PRODUTO_COBERTURA : VarBasis
    {
        /*"    10 GE118-COD-PRODUTO    PIC S9(4) USAGE COMP.*/
        public IntBasis GE118_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE118-SEQ-PRODUTO-VRS       PIC S9(4) USAGE COMP.*/
        public IntBasis GE118_SEQ_PRODUTO_VRS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE118-COD-COBERTURA  PIC S9(4) USAGE COMP.*/
        public IntBasis GE118_COD_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE118-IND-TIPO-COBERTURA       PIC X(1).*/
        public StringBasis GE118_IND_TIPO_COBERTURA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 GE118-IND-SINISTRO-CANCELA       PIC X(1).*/
        public StringBasis GE118_IND_SINISTRO_CANCELA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 GE118-IND-INDENIZA-MAIS-VEZES       PIC X(1).*/
        public StringBasis GE118_IND_INDENIZA_MAIS_VEZES { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 GE118-COD-RAMO-COBERTURA       PIC S9(4) USAGE COMP.*/
        public IntBasis GE118_COD_RAMO_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE118-DES-APRESENTA-DOC.*/
        public GE118_GE118_DES_APRESENTA_DOC GE118_DES_APRESENTA_DOC { get; set; } = new GE118_GE118_DES_APRESENTA_DOC();

    }
}