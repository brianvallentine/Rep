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
    public class CONDESCE_DCLCONTROL_DESPES_CEF : VarBasis
    {
        /*"    10 CONDESCE-COD-EMPRESA  PIC S9(9) USAGE COMP.*/
        public IntBasis CONDESCE_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 CONDESCE-ANO-REFERENCIA  PIC S9(4) USAGE COMP.*/
        public IntBasis CONDESCE_ANO_REFERENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 CONDESCE-MES-REFERENCIA  PIC S9(4) USAGE COMP.*/
        public IntBasis CONDESCE_MES_REFERENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 CONDESCE-BCO-AVISO   PIC S9(4) USAGE COMP.*/
        public IntBasis CONDESCE_BCO_AVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 CONDESCE-AGE-AVISO   PIC S9(4) USAGE COMP.*/
        public IntBasis CONDESCE_AGE_AVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 CONDESCE-NUM-AVISO-CREDITO  PIC S9(9) USAGE COMP.*/
        public IntBasis CONDESCE_NUM_AVISO_CREDITO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 CONDESCE-COD-PRODUTO  PIC S9(4) USAGE COMP.*/
        public IntBasis CONDESCE_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 CONDESCE-TIPO-REGISTRO  PIC X(1).*/
        public StringBasis CONDESCE_TIPO_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 CONDESCE-SITUACAO    PIC X(1).*/
        public StringBasis CONDESCE_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 CONDESCE-TIPO-COBRANCA  PIC X(1).*/
        public StringBasis CONDESCE_TIPO_COBRANCA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 CONDESCE-DATA-MOVIMENTO  PIC X(10).*/
        public StringBasis CONDESCE_DATA_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 CONDESCE-DATA-AVISO  PIC X(10).*/
        public StringBasis CONDESCE_DATA_AVISO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 CONDESCE-QTD-REGISTROS  PIC S9(9) USAGE COMP.*/
        public IntBasis CONDESCE_QTD_REGISTROS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 CONDESCE-PRM-TOTAL   PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis CONDESCE_PRM_TOTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 CONDESCE-PRM-LIQUIDO  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis CONDESCE_PRM_LIQUIDO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 CONDESCE-VAL-TARIFA  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis CONDESCE_VAL_TARIFA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 CONDESCE-VAL-BALCAO  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis CONDESCE_VAL_BALCAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 CONDESCE-VAL-IOCC    PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis CONDESCE_VAL_IOCC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 CONDESCE-VAL-DESCONTO  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis CONDESCE_VAL_DESCONTO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 CONDESCE-VAL-JUROS   PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis CONDESCE_VAL_JUROS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 CONDESCE-VAL-MULTA   PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis CONDESCE_VAL_MULTA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 CONDESCE-TIMESTAMP   PIC X(26).*/
        public StringBasis CONDESCE_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 CONDESCE-COD-CONVENIO  PIC S9(9) USAGE COMP.*/
        public IntBasis CONDESCE_COD_CONVENIO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"*/
    }
}