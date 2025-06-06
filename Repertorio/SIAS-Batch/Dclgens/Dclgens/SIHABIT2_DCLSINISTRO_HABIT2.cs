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
    public class SIHABIT2_DCLSINISTRO_HABIT2 : VarBasis
    {
        /*"    10 SIHABIT2-NUM-APOL-SINISTRO  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis SIHABIT2_NUM_APOL_SINISTRO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 SIHABIT2-COD-OPERACAO  PIC S9(4) USAGE COMP.*/
        public IntBasis SIHABIT2_COD_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SIHABIT2-OCORR-HISTORICO  PIC S9(4) USAGE COMP.*/
        public IntBasis SIHABIT2_OCORR_HISTORICO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SIHABIT2-IDTAB-REC1  PIC S9(4) USAGE COMP.*/
        public IntBasis SIHABIT2_IDTAB_REC1 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SIHABIT2-CODIGO-CH1-REC1  PIC X(1).*/
        public StringBasis SIHABIT2_CODIGO_CH1_REC1 { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SIHABIT2-DATA-INIVIG-REC1  PIC X(10).*/
        public StringBasis SIHABIT2_DATA_INIVIG_REC1 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SIHABIT2-RAMO-EMISSOR  PIC S9(4) USAGE COMP.*/
        public IntBasis SIHABIT2_RAMO_EMISSOR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SIHABIT2-COD-MODALIDADE  PIC S9(4) USAGE COMP.*/
        public IntBasis SIHABIT2_COD_MODALIDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SIHABIT2-COD-PRODUTO  PIC S9(4) USAGE COMP.*/
        public IntBasis SIHABIT2_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SIHABIT2-NUM-APOLICE  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis SIHABIT2_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 SIHABIT2-DATA-INIVIG-PARM1  PIC X(10).*/
        public StringBasis SIHABIT2_DATA_INIVIG_PARM1 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SIHABIT2-SITUACAO    PIC X(1).*/
        public StringBasis SIHABIT2_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SIHABIT2-PARCELA-PAGA  PIC S9(4) USAGE COMP.*/
        public IntBasis SIHABIT2_PARCELA_PAGA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SIHABIT2-TIMESTAMP   PIC X(26).*/
        public StringBasis SIHABIT2_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 SIHABIT2-TEXTO-RECIBO.*/
        public SIHABIT2_SIHABIT2_TEXTO_RECIBO SIHABIT2_TEXTO_RECIBO { get; set; } = new SIHABIT2_SIHABIT2_TEXTO_RECIBO();

    }
}