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
    public class VG083_DCLVG_VIGENCIA_FATURA : VarBasis
    {
        /*"    10 VG083-NUM-APOLICE    PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis VG083_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 VG083-COD-SUBGRUPO   PIC S9(4) USAGE COMP.*/
        public IntBasis VG083_COD_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VG083-SEQ-FATURAMENTO       PIC S9(4) USAGE COMP.*/
        public IntBasis VG083_SEQ_FATURAMENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VG083-DTA-INI-FATURA       PIC X(10).*/
        public StringBasis VG083_DTA_INI_FATURA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 VG083-DTA-FIM-FATURA       PIC X(10).*/
        public StringBasis VG083_DTA_FIM_FATURA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 VG083-DTA-VENC-FATURA       PIC X(10).*/
        public StringBasis VG083_DTA_VENC_FATURA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 VG083-QTD-DIAS-FATURA       PIC S9(4) USAGE COMP.*/
        public IntBasis VG083_QTD_DIAS_FATURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VG083-IND-PROCESSAMENTO       PIC X(2).*/
        public StringBasis VG083_IND_PROCESSAMENTO { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 VG083-COD-USUARIO    PIC X(8).*/
        public StringBasis VG083_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 VG083-DTH-CADASTRAMENTO       PIC X(26).*/
        public StringBasis VG083_DTH_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 VG083-VLR-IS-MINIMA  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis VG083_VLR_IS_MINIMA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"*/
    }
}