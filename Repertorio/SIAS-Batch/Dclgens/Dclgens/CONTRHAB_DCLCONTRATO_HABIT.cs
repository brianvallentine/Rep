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
    public class CONTRHAB_DCLCONTRATO_HABIT : VarBasis
    {
        /*"    10 CONTRHAB-COD-PRODUTO  PIC S9(4) USAGE COMP.*/
        public IntBasis CONTRHAB_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 CONTRHAB-COD-CLIENTE  PIC S9(9) USAGE COMP.*/
        public IntBasis CONTRHAB_COD_CLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 CONTRHAB-NUM-APOLICE  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis CONTRHAB_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 CONTRHAB-OPERACAO    PIC S9(4) USAGE COMP.*/
        public IntBasis CONTRHAB_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 CONTRHAB-PONTO-VENDA  PIC S9(4) USAGE COMP.*/
        public IntBasis CONTRHAB_PONTO_VENDA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 CONTRHAB-NUM-CONTRATO  PIC S9(9) USAGE COMP.*/
        public IntBasis CONTRHAB_NUM_CONTRATO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 CONTRHAB-COD-FILIAL  PIC S9(4) USAGE COMP.*/
        public IntBasis CONTRHAB_COD_FILIAL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 CONTRHAB-TIPO-CREDITO  PIC S9(4) USAGE COMP.*/
        public IntBasis CONTRHAB_TIPO_CREDITO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 CONTRHAB-TAXA-JUROS  PIC S9(3)V9(4) USAGE COMP-3.*/
        public DoubleBasis CONTRHAB_TAXA_JUROS { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(4)"), 4);
        /*"    10 CONTRHAB-PRZ-VIGENCIA  PIC S9(4) USAGE COMP.*/
        public IntBasis CONTRHAB_PRZ_VIGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 CONTRHAB-NUM-ORDEM-INCLUSAO  PIC S9(9) USAGE COMP.*/
        public IntBasis CONTRHAB_NUM_ORDEM_INCLUSAO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 CONTRHAB-DATA-CONTRATO  PIC X(10).*/
        public StringBasis CONTRHAB_DATA_CONTRATO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 CONTRHAB-DATA-INCLUSAO  PIC X(10).*/
        public StringBasis CONTRHAB_DATA_INCLUSAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 CONTRHAB-VAL-FINANCIAMENTO  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis CONTRHAB_VAL_FINANCIAMENTO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 CONTRHAB-VAL-SALDEV-ULTREAJ  PIC S9(13)V9(2) USAGE COMP-3*/
        public DoubleBasis CONTRHAB_VAL_SALDEV_ULTREAJ { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 CONTRHAB-TIPO-GARANTIA  PIC X(1).*/
        public StringBasis CONTRHAB_TIPO_GARANTIA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 CONTRHAB-COD-RISCO   PIC S9(4) USAGE COMP.*/
        public IntBasis CONTRHAB_COD_RISCO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 CONTRHAB-SITUACAO    PIC X(1).*/
        public StringBasis CONTRHAB_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 CONTRHAB-DATA-SIT-INI  PIC X(10).*/
        public StringBasis CONTRHAB_DATA_SIT_INI { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 CONTRHAB-USUARIO     PIC X(8).*/
        public StringBasis CONTRHAB_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 CONTRHAB-QTD-REAJ    PIC S9(4) USAGE COMP.*/
        public IntBasis CONTRHAB_QTD_REAJ { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 CONTRHAB-TIMESTAMP   PIC X(26).*/
        public StringBasis CONTRHAB_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 CONTRHAB-VAL-AVALIA-ULTREAJ  PIC S9(13)V9(2) USAGE COMP-3*/
        public DoubleBasis CONTRHAB_VAL_AVALIA_ULTREAJ { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 CONTRHAB-PRZ-CONSTRUC  PIC S9(4) USAGE COMP.*/
        public IntBasis CONTRHAB_PRZ_CONSTRUC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 CONTRHAB-DATA-VENC-PRESTAC  PIC X(10).*/
        public StringBasis CONTRHAB_DATA_VENC_PRESTAC { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 CONTRHAB-DATA-INI-AMORT  PIC X(10).*/
        public StringBasis CONTRHAB_DATA_INI_AMORT { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 CONTRHAB-MOTIVO-ENCERRAMENT  PIC S9(4) USAGE COMP.*/
        public IntBasis CONTRHAB_MOTIVO_ENCERRAMENT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 CONTRHAB-VAL-OBRA    PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis CONTRHAB_VAL_OBRA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 CONTRHAB-MATRIC-AGENTE  PIC S9(9) USAGE COMP.*/
        public IntBasis CONTRHAB_MATRIC_AGENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 CONTRHAB-DATA-SIT-FIM  PIC X(10).*/
        public StringBasis CONTRHAB_DATA_SIT_FIM { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 CONTRHAB-DATA-ENCERRAMENTO  PIC X(10).*/
        public StringBasis CONTRHAB_DATA_ENCERRAMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 CONTRHAB-VAL-PARCELAS-LIB  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis CONTRHAB_VAL_PARCELAS_LIB { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 CONTRHAB-DDD         PIC S9(4) USAGE COMP.*/
        public IntBasis CONTRHAB_DDD { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 CONTRHAB-TELEFONE    PIC S9(9) USAGE COMP.*/
        public IntBasis CONTRHAB_TELEFONE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 CONTRHAB-TIPO-PESSOA  PIC X(1).*/
        public StringBasis CONTRHAB_TIPO_PESSOA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 CONTRHAB-TIPO-IMOVEL  PIC X(1).*/
        public StringBasis CONTRHAB_TIPO_IMOVEL { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 CONTRHAB-COD-SUBESTIPULANTE  PIC S9(9) USAGE COMP.*/
        public IntBasis CONTRHAB_COD_SUBESTIPULANTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 CONTRHAB-NUM-ORIG-RECURSO  PIC S9(4) USAGE COMP.*/
        public IntBasis CONTRHAB_NUM_ORIG_RECURSO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 CONTRHAB-NUM-LINHA-FINANC  PIC S9(4) USAGE COMP.*/
        public IntBasis CONTRHAB_NUM_LINHA_FINANC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 CONTRHAB-NUM-TIPO-FINANC  PIC S9(4) USAGE COMP.*/
        public IntBasis CONTRHAB_NUM_TIPO_FINANC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 CONTRHAB-NUM-MES-RECALCULO  PIC S9(4) USAGE COMP.*/
        public IntBasis CONTRHAB_NUM_MES_RECALCULO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 CONTRHAB-DTH-FIM-CONTRATO  PIC X(10).*/
        public StringBasis CONTRHAB_DTH_FIM_CONTRATO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 CONTRHAB-DTH-PRIM-PREST  PIC X(10).*/
        public StringBasis CONTRHAB_DTH_PRIM_PREST { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 CONTRHAB-NUM-LEGISLACAO  PIC S9(4) USAGE COMP.*/
        public IntBasis CONTRHAB_NUM_LEGISLACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 CONTRHAB-NUM-GRUPO-HABIT  PIC S9(9) USAGE COMP.*/
        public IntBasis CONTRHAB_NUM_GRUPO_HABIT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 CONTRHAB-NUM-CRITERIO-EXCEP  PIC S9(4) USAGE COMP.*/
        public IntBasis CONTRHAB_NUM_CRITERIO_EXCEP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 CONTRHAB-NUM-REG-EVOLUCAO  PIC S9(4) USAGE COMP.*/
        public IntBasis CONTRHAB_NUM_REG_EVOLUCAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 CONTRHAB-VLR-RENDA-FAMILIAR  PIC S9(7)V9(2) USAGE COMP-3.*/
        public DoubleBasis CONTRHAB_VLR_RENDA_FAMILIAR { get; set; } = new DoubleBasis(new PIC("S9", "7", "S9(7)V9(2)"), 2);
        /*"*/
    }
}