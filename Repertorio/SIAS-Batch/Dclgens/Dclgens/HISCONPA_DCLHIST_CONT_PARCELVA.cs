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
    public class HISCONPA_DCLHIST_CONT_PARCELVA : VarBasis
    {
        /*"    10 HISCONPA-NUM-CERTIFICADO  PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis HISCONPA_NUM_CERTIFICADO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 HISCONPA-NUM-PARCELA  PIC S9(4) USAGE COMP.*/
        public IntBasis HISCONPA_NUM_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 HISCONPA-NUM-TITULO  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis HISCONPA_NUM_TITULO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 HISCONPA-OCORR-HISTORICO  PIC S9(4) USAGE COMP.*/
        public IntBasis HISCONPA_OCORR_HISTORICO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 HISCONPA-NUM-APOLICE  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis HISCONPA_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 HISCONPA-COD-SUBGRUPO  PIC S9(4) USAGE COMP.*/
        public IntBasis HISCONPA_COD_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 HISCONPA-COD-FONTE   PIC S9(4) USAGE COMP.*/
        public IntBasis HISCONPA_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 HISCONPA-NUM-ENDOSSO  PIC S9(9) USAGE COMP.*/
        public IntBasis HISCONPA_NUM_ENDOSSO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 HISCONPA-PREMIO-VG   PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis HISCONPA_PREMIO_VG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 HISCONPA-PREMIO-AP   PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis HISCONPA_PREMIO_AP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 HISCONPA-DATA-MOVIMENTO  PIC X(10).*/
        public StringBasis HISCONPA_DATA_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 HISCONPA-SIT-REGISTRO  PIC X(1).*/
        public StringBasis HISCONPA_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 HISCONPA-COD-OPERACAO  PIC S9(4) USAGE COMP.*/
        public IntBasis HISCONPA_COD_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 HISCONPA-TIMESTAMP   PIC X(26).*/
        public StringBasis HISCONPA_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 HISCONPA-DTFATUR     PIC X(10).*/
        public StringBasis HISCONPA_DTFATUR { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
    }
}