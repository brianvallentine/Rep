using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI9107B
{
    public class R2400_00_INCLUI_SINIMPSE_DB_INSERT_1_Insert1 : QueryBasis<R2400_00_INCLUI_SINIMPSE_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.SINISTRO_IMP_SEG
            (NUM_APOL_SINISTRO,
            OCORR_HISTORICO,
            SIT_REGISTRO,
            COD_CAUSA,
            VAL_IS_DATA_OCORR,
            DATA_MOVIMENTO,
            DATA_OCORRENCIA,
            TIMESTAMP)
            VALUES (:SIARDEVC-NUM-APOL-SINISTRO,
            :SINIMPSE-OCORR-HISTORICO,
            ' ' ,
            :SIARDEVC-COD-CAUSA,
            :SINIMPSE-VAL-IS-DATA-OCORR,
            :SISTEMAS-DATA-MOV-ABERTO,
            :SINIMPSE-DATA-OCORRENCIA,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.SINISTRO_IMP_SEG (NUM_APOL_SINISTRO, OCORR_HISTORICO, SIT_REGISTRO, COD_CAUSA, VAL_IS_DATA_OCORR, DATA_MOVIMENTO, DATA_OCORRENCIA, TIMESTAMP) VALUES ({FieldThreatment(this.SIARDEVC_NUM_APOL_SINISTRO)}, {FieldThreatment(this.SINIMPSE_OCORR_HISTORICO)}, ' ' , {FieldThreatment(this.SIARDEVC_COD_CAUSA)}, {FieldThreatment(this.SINIMPSE_VAL_IS_DATA_OCORR)}, {FieldThreatment(this.SISTEMAS_DATA_MOV_ABERTO)}, {FieldThreatment(this.SINIMPSE_DATA_OCORRENCIA)}, CURRENT TIMESTAMP)";

            return query;
        }
        public string SIARDEVC_NUM_APOL_SINISTRO { get; set; }
        public string SINIMPSE_OCORR_HISTORICO { get; set; }
        public string SIARDEVC_COD_CAUSA { get; set; }
        public string SINIMPSE_VAL_IS_DATA_OCORR { get; set; }
        public string SISTEMAS_DATA_MOV_ABERTO { get; set; }
        public string SINIMPSE_DATA_OCORRENCIA { get; set; }

        public static void Execute(R2400_00_INCLUI_SINIMPSE_DB_INSERT_1_Insert1 r2400_00_INCLUI_SINIMPSE_DB_INSERT_1_Insert1)
        {
            var ths = r2400_00_INCLUI_SINIMPSE_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2400_00_INCLUI_SINIMPSE_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}