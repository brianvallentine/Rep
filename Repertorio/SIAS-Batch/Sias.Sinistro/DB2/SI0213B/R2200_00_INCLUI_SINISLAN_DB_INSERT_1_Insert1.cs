using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0213B
{
    public class R2200_00_INCLUI_SINISLAN_DB_INSERT_1_Insert1 : QueryBasis<R2200_00_INCLUI_SINISLAN_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.SINISTRO_LANCLOTE1
            (COD_FONTE,
            NUM_LOTE,
            NUM_APOL_SINISTRO,
            OCORR_HISTORICO,
            COD_OPERACAO,
            VAL_OPERACAO,
            DATA_MOVIMENTO,
            COD_USUARIO,
            TIMESTAMP,
            COD_PROCESSO_JURID)
            VALUES (:SINNUMLO-COD-FONTE,
            :SINNUMLO-NUM-LOTE,
            :SINISHIS-NUM-APOL-SINISTRO,
            :SINISHIS-OCORR-HISTORICO,
            :SINISHIS-COD-OPERACAO,
            :SINISHIS-VAL-OPERACAO,
            :SISTEMAS-DATA-MOV-ABERTO,
            'SI0213B' ,
            CURRENT TIMESTAMP,
            NULL)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.SINISTRO_LANCLOTE1 (COD_FONTE, NUM_LOTE, NUM_APOL_SINISTRO, OCORR_HISTORICO, COD_OPERACAO, VAL_OPERACAO, DATA_MOVIMENTO, COD_USUARIO, TIMESTAMP, COD_PROCESSO_JURID) VALUES ({FieldThreatment(this.SINNUMLO_COD_FONTE)}, {FieldThreatment(this.SINNUMLO_NUM_LOTE)}, {FieldThreatment(this.SINISHIS_NUM_APOL_SINISTRO)}, {FieldThreatment(this.SINISHIS_OCORR_HISTORICO)}, {FieldThreatment(this.SINISHIS_COD_OPERACAO)}, {FieldThreatment(this.SINISHIS_VAL_OPERACAO)}, {FieldThreatment(this.SISTEMAS_DATA_MOV_ABERTO)}, 'SI0213B' , CURRENT TIMESTAMP, NULL)";

            return query;
        }
        public string SINNUMLO_COD_FONTE { get; set; }
        public string SINNUMLO_NUM_LOTE { get; set; }
        public string SINISHIS_NUM_APOL_SINISTRO { get; set; }
        public string SINISHIS_OCORR_HISTORICO { get; set; }
        public string SINISHIS_COD_OPERACAO { get; set; }
        public string SINISHIS_VAL_OPERACAO { get; set; }
        public string SISTEMAS_DATA_MOV_ABERTO { get; set; }

        public static void Execute(R2200_00_INCLUI_SINISLAN_DB_INSERT_1_Insert1 r2200_00_INCLUI_SINISLAN_DB_INSERT_1_Insert1)
        {
            var ths = r2200_00_INCLUI_SINISLAN_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2200_00_INCLUI_SINISLAN_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}