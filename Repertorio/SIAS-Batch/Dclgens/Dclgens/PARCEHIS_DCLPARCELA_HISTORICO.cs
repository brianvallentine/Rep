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
    public class PARCEHIS_DCLPARCELA_HISTORICO : VarBasis
    {
        /*"    10 PARCEHIS-NUM-APOLICE  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis PARCEHIS_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 PARCEHIS-NUM-ENDOSSO  PIC S9(9) USAGE COMP.*/
        public IntBasis PARCEHIS_NUM_ENDOSSO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 PARCEHIS-NUM-PARCELA  PIC S9(4) USAGE COMP.*/
        public IntBasis PARCEHIS_NUM_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PARCEHIS-DAC-PARCELA  PIC X(1).*/
        public StringBasis PARCEHIS_DAC_PARCELA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 PARCEHIS-DATA-MOVIMENTO  PIC X(10).*/
        public StringBasis PARCEHIS_DATA_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 PARCEHIS-COD-OPERACAO  PIC S9(4) USAGE COMP.*/
        public IntBasis PARCEHIS_COD_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PARCEHIS-HORA-OPERACAO  PIC X(8).*/
        public StringBasis PARCEHIS_HORA_OPERACAO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 PARCEHIS-OCORR-HISTORICO  PIC S9(4) USAGE COMP.*/
        public IntBasis PARCEHIS_OCORR_HISTORICO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PARCEHIS-PRM-TARIFARIO  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis PARCEHIS_PRM_TARIFARIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 PARCEHIS-VAL-DESCONTO  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis PARCEHIS_VAL_DESCONTO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 PARCEHIS-PRM-LIQUIDO  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis PARCEHIS_PRM_LIQUIDO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 PARCEHIS-ADICIONAL-FRACIO  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis PARCEHIS_ADICIONAL_FRACIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 PARCEHIS-VAL-CUSTO-EMISSAO  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis PARCEHIS_VAL_CUSTO_EMISSAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 PARCEHIS-VAL-IOCC    PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis PARCEHIS_VAL_IOCC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 PARCEHIS-PRM-TOTAL   PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis PARCEHIS_PRM_TOTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 PARCEHIS-VAL-OPERACAO  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis PARCEHIS_VAL_OPERACAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 PARCEHIS-DATA-VENCIMENTO  PIC X(10).*/
        public StringBasis PARCEHIS_DATA_VENCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 PARCEHIS-BCO-COBRANCA  PIC S9(4) USAGE COMP.*/
        public IntBasis PARCEHIS_BCO_COBRANCA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PARCEHIS-AGE-COBRANCA  PIC S9(4) USAGE COMP.*/
        public IntBasis PARCEHIS_AGE_COBRANCA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PARCEHIS-NUM-AVISO-CREDITO  PIC S9(9) USAGE COMP.*/
        public IntBasis PARCEHIS_NUM_AVISO_CREDITO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 PARCEHIS-ENDOS-CANCELA  PIC S9(9) USAGE COMP.*/
        public IntBasis PARCEHIS_ENDOS_CANCELA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 PARCEHIS-SIT-CONTABIL  PIC X(1).*/
        public StringBasis PARCEHIS_SIT_CONTABIL { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 PARCEHIS-COD-USUARIO  PIC X(8).*/
        public StringBasis PARCEHIS_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 PARCEHIS-RENUM-DOCUMENTO  PIC S9(9) USAGE COMP.*/
        public IntBasis PARCEHIS_RENUM_DOCUMENTO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 PARCEHIS-DATA-QUITACAO  PIC X(10).*/
        public StringBasis PARCEHIS_DATA_QUITACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 PARCEHIS-COD-EMPRESA  PIC S9(9) USAGE COMP.*/
        public IntBasis PARCEHIS_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 PARCEHIS-TIMESTAMP   PIC X(26).*/
        public StringBasis PARCEHIS_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}