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
    public class FCTITULO_DCLFC_TITULO : VarBasis
    {
        /*"    10 FCTITULO-NUM-TITULO  PIC S9(9) USAGE COMP.*/
        public IntBasis FCTITULO_NUM_TITULO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 FCTITULO-NUM-SERIE   PIC S9(4) USAGE COMP.*/
        public IntBasis FCTITULO_NUM_SERIE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FCTITULO-NUM-PLANO   PIC S9(4) USAGE COMP.*/
        public IntBasis FCTITULO_NUM_PLANO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FCTITULO-COD-STA-TITULO       PIC X(3).*/
        public StringBasis FCTITULO_COD_STA_TITULO { get; set; } = new StringBasis(new PIC("X", "3", "X(3)."), @"");
        /*"    10 FCTITULO-IDE-SERIEPADRAO       PIC S9(4) USAGE COMP.*/
        public IntBasis FCTITULO_IDE_SERIEPADRAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FCTITULO-NUM-LOTE    PIC S9(9) USAGE COMP.*/
        public IntBasis FCTITULO_NUM_LOTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 FCTITULO-NUM-PEDIDO  PIC S9(9) USAGE COMP.*/
        public IntBasis FCTITULO_NUM_PEDIDO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 FCTITULO-COD-SUB-STATUS       PIC X(3).*/
        public StringBasis FCTITULO_COD_SUB_STATUS { get; set; } = new StringBasis(new PIC("X", "3", "X(3)."), @"");
        /*"    10 FCTITULO-DES-CODIGO-BARRA       PIC X(48).*/
        public StringBasis FCTITULO_DES_CODIGO_BARRA { get; set; } = new StringBasis(new PIC("X", "48", "X(48)."), @"");
        /*"    10 FCTITULO-DTH-ATIVACAO       PIC X(26).*/
        public StringBasis FCTITULO_DTH_ATIVACAO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 FCTITULO-DTH-CADUCACAO       PIC X(10).*/
        public StringBasis FCTITULO_DTH_CADUCACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 FCTITULO-DTH-CRIACAO       PIC X(26).*/
        public StringBasis FCTITULO_DTH_CRIACAO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 FCTITULO-DTH-DISTRIBUICAO       PIC X(10).*/
        public StringBasis FCTITULO_DTH_DISTRIBUICAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 FCTITULO-DTH-FIM-VIGENCIA       PIC X(10).*/
        public StringBasis FCTITULO_DTH_FIM_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 FCTITULO-DTH-INI-SORTEIO       PIC X(10).*/
        public StringBasis FCTITULO_DTH_INI_SORTEIO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 FCTITULO-DTH-INI-VIGENCIA       PIC X(10).*/
        public StringBasis FCTITULO_DTH_INI_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 FCTITULO-DTH-PEDIDO-RESGATE       PIC X(10).*/
        public StringBasis FCTITULO_DTH_PEDIDO_RESGATE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 FCTITULO-DTH-PG-ULT-RECEB       PIC X(10).*/
        public StringBasis FCTITULO_DTH_PG_ULT_RECEB { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 FCTITULO-DTH-PRAZO-CONSIG       PIC X(10).*/
        public StringBasis FCTITULO_DTH_PRAZO_CONSIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 FCTITULO-DTH-PROCES-RESGATE       PIC X(10).*/
        public StringBasis FCTITULO_DTH_PROCES_RESGATE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 FCTITULO-DTH-PROX-REAJUSTE       PIC X(10).*/
        public StringBasis FCTITULO_DTH_PROX_REAJUSTE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 FCTITULO-DTH-SUSPENSAO       PIC X(10).*/
        public StringBasis FCTITULO_DTH_SUSPENSAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 FCTITULO-IDE-TITULAR       PIC S9(9) USAGE COMP.*/
        public IntBasis FCTITULO_IDE_TITULAR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 FCTITULO-IDE-CTA-BANC-TIT       PIC S9(9) USAGE COMP.*/
        public IntBasis FCTITULO_IDE_CTA_BANC_TIT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 FCTITULO-IDE-ENDERECO-TIT       PIC S9(9) USAGE COMP.*/
        public IntBasis FCTITULO_IDE_ENDERECO_TIT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 FCTITULO-IND-DIA-VENCTO       PIC S9(4) USAGE COMP.*/
        public IntBasis FCTITULO_IND_DIA_VENCTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FCTITULO-IND-DV      PIC S9(4) USAGE COMP.*/
        public IntBasis FCTITULO_IND_DV { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FCTITULO-IND-NSR     PIC S9(9) USAGE COMP.*/
        public IntBasis FCTITULO_IND_NSR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 FCTITULO-NUM-VIA-CART-EMIT       PIC S9(9) USAGE COMP.*/
        public IntBasis FCTITULO_NUM_VIA_CART_EMIT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 FCTITULO-NUM-VIA-TITULO       PIC S9(9) USAGE COMP.*/
        public IntBasis FCTITULO_NUM_VIA_TITULO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 FCTITULO-VLR-MENSALIDADE       PIC S9(8)V9(2) USAGE COMP-3.*/
        public DoubleBasis FCTITULO_VLR_MENSALIDADE { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(8)V9(2)"), 2);
        /*"    10 FCTITULO-VLR-PROX-MENSAL       PIC S9(8)V9(2) USAGE COMP-3.*/
        public DoubleBasis FCTITULO_VLR_PROX_MENSAL { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(8)V9(2)"), 2);
        /*"    10 FCTITULO-VLR-SALDO-CAPIT       PIC S9(8)V9(2) USAGE COMP-3.*/
        public DoubleBasis FCTITULO_VLR_SALDO_CAPIT { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(8)V9(2)"), 2);
        /*"    10 FCTITULO-VLR-SALDO-MEN-QUIT       PIC S9(8)V9(2) USAGE COMP-3.*/
        public DoubleBasis FCTITULO_VLR_SALDO_MEN_QUIT { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(8)V9(2)"), 2);
        /*"    10 FCTITULO-VLR-SLD-CAP-SEM-TX       PIC S9(8)V9(4) USAGE COMP-3.*/
        public DoubleBasis FCTITULO_VLR_SLD_CAP_SEM_TX { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(8)V9(4)"), 4);
        /*"    10 FCTITULO-VLR-SLD-CAP-TX       PIC S9(8)V9(4) USAGE COMP-3.*/
        public DoubleBasis FCTITULO_VLR_SLD_CAP_TX { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(8)V9(4)"), 4);
        /*"    10 FCTITULO-NUM-PROPOSTA       PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis FCTITULO_NUM_PROPOSTA { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 FCTITULO-NUM-NSA     PIC S9(9) USAGE COMP.*/
        public IntBasis FCTITULO_NUM_NSA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 FCTITULO-IND-ENVIO-SIGPF       PIC S9(4) USAGE COMP.*/
        public IntBasis FCTITULO_IND_ENVIO_SIGPF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FCTITULO-COD-TIPO-PAGTO       PIC X(3).*/
        public StringBasis FCTITULO_COD_TIPO_PAGTO { get; set; } = new StringBasis(new PIC("X", "3", "X(3)."), @"");
        /*"    10 FCTITULO-IND-SLD-MENS-QUIT       PIC S9(4) USAGE COMP.*/
        public IntBasis FCTITULO_IND_SLD_MENS_QUIT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FCTITULO-IND-ENVIO-CONTABIL       PIC X(1).*/
        public StringBasis FCTITULO_IND_ENVIO_CONTABIL { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 FCTITULO-IDE-SUBSCRITOR       PIC S9(9) USAGE COMP.*/
        public IntBasis FCTITULO_IDE_SUBSCRITOR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 FCTITULO-IDE-ENDERECO-SUBS       PIC S9(9) USAGE COMP.*/
        public IntBasis FCTITULO_IDE_ENDERECO_SUBS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 FCTITULO-IDE-CTA-BANC-SUBS       PIC S9(9) USAGE COMP.*/
        public IntBasis FCTITULO_IDE_CTA_BANC_SUBS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 FCTITULO-NOM-ULT-PROGRAMA       PIC X(8).*/
        public StringBasis FCTITULO_NOM_ULT_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 FCTITULO-NUM-MOD-PLANO       PIC S9(4) USAGE COMP.*/
        public IntBasis FCTITULO_NUM_MOD_PLANO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FCTITULO-DTH-ATUALIZACAO       PIC X(26).*/
        public StringBasis FCTITULO_DTH_ATUALIZACAO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}