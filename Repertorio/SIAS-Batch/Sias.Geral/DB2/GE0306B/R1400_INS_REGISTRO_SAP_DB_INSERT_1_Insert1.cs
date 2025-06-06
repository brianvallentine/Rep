using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GE0306B
{
    public class R1400_INS_REGISTRO_SAP_DB_INSERT_1_Insert1 : QueryBasis<R1400_INS_REGISTRO_SAP_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT INTO SEGUROS.GE_ARQUIVO_SAP
            ( NUM_OCORR_MOVTO ,
            COD_IDLG ,
            DTH_MOVIMENTO ,
            DTH_CADASTRAMENTO,
            NUM_LOTE_SAP ,
            TXT_REG_SAP ,
            COD_ORIGEM )
            VALUES
            (:GE102-NUM-OCORR-MOVTO ,
            :GE102-COD-IDLG ,
            :GE102-DTH-MOVIMENTO ,
            :GE102-DTH-CADASTRAMENTO,
            :GE102-NUM-LOTE-SAP ,
            :GE102-TXT-REG-SAP ,
            :GE102-COD-ORIGEM )
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.GE_ARQUIVO_SAP ( NUM_OCORR_MOVTO , COD_IDLG , DTH_MOVIMENTO , DTH_CADASTRAMENTO, NUM_LOTE_SAP , TXT_REG_SAP , COD_ORIGEM ) VALUES ({FieldThreatment(this.GE102_NUM_OCORR_MOVTO)} , {FieldThreatment(this.GE102_COD_IDLG)} , {FieldThreatment(this.GE102_DTH_MOVIMENTO)} , {FieldThreatment(this.GE102_DTH_CADASTRAMENTO)}, {FieldThreatment(this.GE102_NUM_LOTE_SAP)} , {FieldThreatment(this.GE102_TXT_REG_SAP)} , {FieldThreatment(this.GE102_COD_ORIGEM)} )";

            return query;
        }
        public string GE102_NUM_OCORR_MOVTO { get; set; }
        public string GE102_COD_IDLG { get; set; }
        public string GE102_DTH_MOVIMENTO { get; set; }
        public string GE102_DTH_CADASTRAMENTO { get; set; }
        public string GE102_NUM_LOTE_SAP { get; set; }
        public string GE102_TXT_REG_SAP { get; set; }
        public string GE102_COD_ORIGEM { get; set; }

        public static void Execute(R1400_INS_REGISTRO_SAP_DB_INSERT_1_Insert1 r1400_INS_REGISTRO_SAP_DB_INSERT_1_Insert1)
        {
            var ths = r1400_INS_REGISTRO_SAP_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1400_INS_REGISTRO_SAP_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}