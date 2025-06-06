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
    public class GE102_DCLGE_ARQUIVO_SAP : VarBasis
    {
        /*"    10 GE102-COD-IDLG       PIC X(40).*/
        public StringBasis GE102_COD_IDLG { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 GE102-DTH-MOVIMENTO  PIC X(10).*/
        public StringBasis GE102_DTH_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GE102-DTH-CADASTRAMENTO       PIC X(26).*/
        public StringBasis GE102_DTH_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 GE102-NUM-LOTE-SAP   PIC X(24).*/
        public StringBasis GE102_NUM_LOTE_SAP { get; set; } = new StringBasis(new PIC("X", "24", "X(24)."), @"");
        /*"    10 GE102-TXT-REG-SAP.*/
        public GE102_GE102_TXT_REG_SAP GE102_TXT_REG_SAP { get; set; } = new GE102_GE102_TXT_REG_SAP();

        public DoubleBasis GE102_NUM_OCORR_MOVTO { get; set; } = new DoubleBasis(new PIC("S9", "18", "S9(18)V"), 0);
        /*"    10 GE102-COD-ORIGEM     PIC X(4).*/
        public StringBasis GE102_COD_ORIGEM { get; set; } = new StringBasis(new PIC("X", "4", "X(4)."), @"");
        /*"*/
    }
}