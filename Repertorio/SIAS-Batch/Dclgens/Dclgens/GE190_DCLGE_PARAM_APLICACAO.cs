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
    public class GE190_DCLGE_PARAM_APLICACAO : VarBasis
    {
        /*"    10 GE190-COD-PARAMETRO  PIC S9(4) USAGE COMP.*/
        public IntBasis GE190_COD_PARAMETRO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE190-COD-PRODUTO    PIC S9(4) USAGE COMP.*/
        public IntBasis GE190_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE190-STA-PARAMETRO  PIC S9(4) USAGE COMP.*/
        public IntBasis GE190_STA_PARAMETRO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE190-NOM-CLASSE-PARAM       PIC X(15).*/
        public StringBasis GE190_NOM_CLASSE_PARAM { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
        /*"    10 GE190-COD-SISTEMA    PIC X(5).*/
        public StringBasis GE190_COD_SISTEMA { get; set; } = new StringBasis(new PIC("X", "5", "X(5)."), @"");
        /*"    10 GE190-DTA-INI-VIGENCA       PIC X(10).*/
        public StringBasis GE190_DTA_INI_VIGENCA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GE190-DTA-FIM-VIGENCIA       PIC X(10).*/
        public StringBasis GE190_DTA_FIM_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GE190-DES-PARAMETRO  PIC X(100).*/
        public StringBasis GE190_DES_PARAMETRO { get; set; } = new StringBasis(new PIC("X", "100", "X(100)."), @"");
        /*"    10 GE190-IND-TP-PARAMETRO       PIC S9(4) USAGE COMP.*/
        public IntBasis GE190_IND_TP_PARAMETRO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE190-VLR-PARAMETRO  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis GE190_VLR_PARAMETRO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 GE190-VLR-PARAM-INT  PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis GE190_VLR_PARAM_INT { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 GE190-PCT-PARAMETRO  PIC S9(5)V9(2) USAGE COMP-3.*/
        public DoubleBasis GE190_PCT_PARAMETRO { get; set; } = new DoubleBasis(new PIC("S9", "5", "S9(5)V9(2)"), 2);
        /*"    10 GE190-VLR-PARAM-TAXA       PIC S9(3)V9(9) USAGE COMP-3.*/
        public DoubleBasis GE190_VLR_PARAM_TAXA { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(9)"), 9);
        /*"    10 GE190-DTA-PARAMETRO  PIC X(10).*/
        public StringBasis GE190_DTA_PARAMETRO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GE190-VLR-PARAM-REDUZIDO       PIC X(15).*/
        public StringBasis GE190_VLR_PARAM_REDUZIDO { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
        /*"    10 GE190-VLR-PARAM-EXTENDIDO       PIC X(60).*/
        public StringBasis GE190_VLR_PARAM_EXTENDIDO { get; set; } = new StringBasis(new PIC("X", "60", "X(60)."), @"");
        /*"    10 GE190-COD-PROGRAMA   PIC X(10).*/
        public StringBasis GE190_COD_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GE190-COD-USUARIO    PIC X(8).*/
        public StringBasis GE190_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 GE190-DTH-CADASTRAMENTO       PIC X(26).*/
        public StringBasis GE190_DTH_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
    }
}