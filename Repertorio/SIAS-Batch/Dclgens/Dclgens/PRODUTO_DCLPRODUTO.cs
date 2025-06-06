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
    public class PRODUTO_DCLPRODUTO : VarBasis
    {
        /*"    10 PRODUTO-COD-EMPRESA  PIC S9(9) USAGE COMP*/
        public IntBasis PRODUTO_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 PRODUTO-COD-PRODUTO  PIC S9(4) USAGE COMP*/
        public IntBasis PRODUTO_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PRODUTO-DESCR-PRODUTO       PIC X(40)*/
        public StringBasis PRODUTO_DESCR_PRODUTO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
        /*"    10 PRODUTO-RAMO-EMISSOR       PIC S9(4) USAGE COMP*/
        public IntBasis PRODUTO_RAMO_EMISSOR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PRODUTO-TIPO-COSSEGURO-CED       PIC X(1)*/
        public StringBasis PRODUTO_TIPO_COSSEGURO_CED { get; set; } = new StringBasis(new PIC("X", "1", "X(1)"), @"");
        /*"    10 PRODUTO-NUM-MAX-PARCELA       PIC S9(4) USAGE COMP*/
        public IntBasis PRODUTO_NUM_MAX_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PRODUTO-IDE-COBERTURA       PIC X(1)*/
        public StringBasis PRODUTO_IDE_COBERTURA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)"), @"");
        /*"    10 PRODUTO-SIT-REGISTRO       PIC X(1)*/
        public StringBasis PRODUTO_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)"), @"");
        /*"    10 PRODUTO-TIMESTAMP    PIC X(26)*/
        public StringBasis PRODUTO_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)"), @"");
        /*"    10 PRODUTO-TIPO-PRODUTO       PIC X(1)*/
        public StringBasis PRODUTO_TIPO_PRODUTO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)"), @"");
        /*"    10 PRODUTO-IDENT-IMP-ESPECIF       PIC X(1)*/
        public StringBasis PRODUTO_IDENT_IMP_ESPECIF { get; set; } = new StringBasis(new PIC("X", "1", "X(1)"), @"");
        /*"    10 PRODUTO-IDENT-IMP-CERTIF       PIC X(1)*/
        public StringBasis PRODUTO_IDENT_IMP_CERTIF { get; set; } = new StringBasis(new PIC("X", "1", "X(1)"), @"");
        /*"    10 PRODUTO-QUANT-MIN-COBER       PIC S9(4) USAGE COMP*/
        public IntBasis PRODUTO_QUANT_MIN_COBER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PRODUTO-VLR-TARIFA   PIC S9(13)V9(2) USAGE COMP-3*/
        public DoubleBasis PRODUTO_VLR_TARIFA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 PRODUTO-RESUMO-PRODUTO*/
        public PRODUTO_PRODUTO_RESUMO_PRODUTO PRODUTO_RESUMO_PRODUTO { get; set; } = new PRODUTO_PRODUTO_RESUMO_PRODUTO();

        public StringBasis PRODUTO_NUM_PROCESSO_SUSEP { get; set; } = new StringBasis(new PIC("X", "25", "X(25)"), @"");
        /*"    10 PRODUTO-IND-PESSOA-VENDA       PIC X(1)*/
        public StringBasis PRODUTO_IND_PESSOA_VENDA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)"), @"");
        /*"    10 PRODUTO-DTH-INI-VIGENCIA       PIC X(10)*/
        public StringBasis PRODUTO_DTH_INI_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"    10 PRODUTO-DTH-FIM-VIGENCIA       PIC X(10)*/
        public StringBasis PRODUTO_DTH_FIM_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"    10 PRODUTO-STA-HABILITA-MENOR       PIC X(1)*/
        public StringBasis PRODUTO_STA_HABILITA_MENOR { get; set; } = new StringBasis(new PIC("X", "1", "X(1)"), @"");
        /*"    10 PRODUTO-STA-MOSTRA-RESP       PIC X(1)*/
        public StringBasis PRODUTO_STA_MOSTRA_RESP { get; set; } = new StringBasis(new PIC("X", "1", "X(1)"), @"");
    }
}