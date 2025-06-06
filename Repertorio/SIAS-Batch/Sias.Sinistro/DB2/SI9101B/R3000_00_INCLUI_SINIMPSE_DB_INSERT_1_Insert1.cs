using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI9101B
{
    public class R3000_00_INCLUI_SINIMPSE_DB_INSERT_1_Insert1 : QueryBasis<R3000_00_INCLUI_SINIMPSE_DB_INSERT_1_Insert1>
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
            VALUES (:SINISMES-NUM-APOL-SINISTRO,
            1,
            ' ' ,
            :SIARDEVC-COD-CAUSA,
            :AUTOCOBE-IMP-SEGURADA-IX,
            :SISTEMAS-DATA-MOV-ABERTO,
            :SIARDEVC-DATA-OCORRENCIA,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.SINISTRO_IMP_SEG (NUM_APOL_SINISTRO, OCORR_HISTORICO, SIT_REGISTRO, COD_CAUSA, VAL_IS_DATA_OCORR, DATA_MOVIMENTO, DATA_OCORRENCIA, TIMESTAMP) VALUES ({FieldThreatment(this.SINISMES_NUM_APOL_SINISTRO)}, 1, ' ' , {FieldThreatment(this.SIARDEVC_COD_CAUSA)}, {FieldThreatment(this.AUTOCOBE_IMP_SEGURADA_IX)}, {FieldThreatment(this.SISTEMAS_DATA_MOV_ABERTO)}, {FieldThreatment(this.SIARDEVC_DATA_OCORRENCIA)}, CURRENT TIMESTAMP)";

            return query;
        }
        public string SINISMES_NUM_APOL_SINISTRO { get; set; }
        public string SIARDEVC_COD_CAUSA { get; set; }
        public string AUTOCOBE_IMP_SEGURADA_IX { get; set; }
        public string SISTEMAS_DATA_MOV_ABERTO { get; set; }
        public string SIARDEVC_DATA_OCORRENCIA { get; set; }

        public static void Execute(R3000_00_INCLUI_SINIMPSE_DB_INSERT_1_Insert1 r3000_00_INCLUI_SINIMPSE_DB_INSERT_1_Insert1)
        {
            var ths = r3000_00_INCLUI_SINIMPSE_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3000_00_INCLUI_SINIMPSE_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}