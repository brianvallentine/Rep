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
    public class COMISSOE_DCLCOMISSOES : VarBasis
    {
        /*"    10 COMISSOE-NUM-APOLICE  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis COMISSOE_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 COMISSOE-NUM-ENDOSSO  PIC S9(9) USAGE COMP.*/
        public IntBasis COMISSOE_NUM_ENDOSSO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 COMISSOE-NUM-CERTIFICADO  PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis COMISSOE_NUM_CERTIFICADO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 COMISSOE-DAC-CERTIFICADO  PIC X(1).*/
        public StringBasis COMISSOE_DAC_CERTIFICADO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 COMISSOE-TIPO-SEGURADO  PIC X(1).*/
        public StringBasis COMISSOE_TIPO_SEGURADO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 COMISSOE-NUM-PARCELA  PIC S9(4) USAGE COMP.*/
        public IntBasis COMISSOE_NUM_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 COMISSOE-COD-OPERACAO  PIC S9(4) USAGE COMP.*/
        public IntBasis COMISSOE_COD_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 COMISSOE-COD-PRODUTOR  PIC S9(9) USAGE COMP.*/
        public IntBasis COMISSOE_COD_PRODUTOR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 COMISSOE-RAMO-COBERTURA  PIC S9(4) USAGE COMP.*/
        public IntBasis COMISSOE_RAMO_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 COMISSOE-MODALI-COBERTURA  PIC S9(4) USAGE COMP.*/
        public IntBasis COMISSOE_MODALI_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 COMISSOE-OCORR-HISTORICO  PIC S9(4) USAGE COMP.*/
        public IntBasis COMISSOE_OCORR_HISTORICO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 COMISSOE-COD-FONTE   PIC S9(4) USAGE COMP.*/
        public IntBasis COMISSOE_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 COMISSOE-COD-CLIENTE  PIC S9(9) USAGE COMP.*/
        public IntBasis COMISSOE_COD_CLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 COMISSOE-VAL-COMISSAO  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis COMISSOE_VAL_COMISSAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 COMISSOE-DATA-CALCULO  PIC X(10).*/
        public StringBasis COMISSOE_DATA_CALCULO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 COMISSOE-NUM-RECIBO  PIC S9(9) USAGE COMP.*/
        public IntBasis COMISSOE_NUM_RECIBO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 COMISSOE-VAL-BASICO  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis COMISSOE_VAL_BASICO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 COMISSOE-TIPO-COMISSAO  PIC X(1).*/
        public StringBasis COMISSOE_TIPO_COMISSAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 COMISSOE-QTD-PARCELAS  PIC S9(4) USAGE COMP.*/
        public IntBasis COMISSOE_QTD_PARCELAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 COMISSOE-PCT-COM-CORRETOR  PIC S9(3)V9(2) USAGE COMP-3.*/
        public DoubleBasis COMISSOE_PCT_COM_CORRETOR { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"    10 COMISSOE-PCT-DESC-PREMIO  PIC S9(3)V9(2) USAGE COMP-3.*/
        public DoubleBasis COMISSOE_PCT_DESC_PREMIO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"    10 COMISSOE-COD-SUBGRUPO  PIC S9(4) USAGE COMP.*/
        public IntBasis COMISSOE_COD_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 COMISSOE-HORA-OPERACAO  PIC X(8).*/
        public StringBasis COMISSOE_HORA_OPERACAO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 COMISSOE-DATA-MOVIMENTO  PIC X(10).*/
        public StringBasis COMISSOE_DATA_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 COMISSOE-DATA-SELECAO  PIC X(10).*/
        public StringBasis COMISSOE_DATA_SELECAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 COMISSOE-COD-EMPRESA  PIC S9(9) USAGE COMP.*/
        public IntBasis COMISSOE_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 COMISSOE-COD-PREPOSTO  PIC S9(9) USAGE COMP.*/
        public IntBasis COMISSOE_COD_PREPOSTO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 COMISSOE-TIMESTAMP   PIC X(26).*/
        public StringBasis COMISSOE_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 COMISSOE-NUM-BILHETE  PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis COMISSOE_NUM_BILHETE { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 COMISSOE-VAL-VARMON  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis COMISSOE_VAL_VARMON { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 COMISSOE-DATA-QUITACAO  PIC X(10).*/
        public StringBasis COMISSOE_DATA_QUITACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"*/
    }
}