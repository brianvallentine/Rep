using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0095B
{
    public class R190_VALOR_ADIANTAMENTO_DB_SELECT_1_Query1 : QueryBasis<R190_VALOR_ADIANTAMENTO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(B.VAL_OPERACAO * -1,0),
            B.DATA_MOVIMENTO
            INTO :HOST-VALOR-ADIANTAMENTO,
            :HOST-DATA-ADIANTAMENTO
            FROM SEGUROS.SINISTRO_HISTORICO B
            WHERE B.NUM_APOL_SINISTRO =
            :SINISHIS-NUM-APOL-SINISTRO
            AND B.COD_OPERACAO = 1070
            AND B.SIT_REGISTRO = '2'
            AND B.OCORR_HISTORICO =
            (SELECT DISTINCT A.OCORR_HISTORICO
            FROM SEGUROS.SINISTRO_HISTORICO A
            WHERE A.NUM_APOL_SINISTRO =
            :SINISHIS-NUM-APOL-SINISTRO
            AND A.COD_OPERACAO = 1050
            AND A.SIT_REGISTRO = '0' )
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(B.VAL_OPERACAO * -1
							,0)
							,
											B.DATA_MOVIMENTO
											FROM SEGUROS.SINISTRO_HISTORICO B
											WHERE B.NUM_APOL_SINISTRO =
											'{this.SINISHIS_NUM_APOL_SINISTRO}'
											AND B.COD_OPERACAO = 1070
											AND B.SIT_REGISTRO = '2'
											AND B.OCORR_HISTORICO =
											(SELECT DISTINCT A.OCORR_HISTORICO
											FROM SEGUROS.SINISTRO_HISTORICO A
											WHERE A.NUM_APOL_SINISTRO =
											'{this.SINISHIS_NUM_APOL_SINISTRO}'
											AND A.COD_OPERACAO = 1050
											AND A.SIT_REGISTRO = '0' )";

            return query;
        }
        public string HOST_VALOR_ADIANTAMENTO { get; set; }
        public string HOST_DATA_ADIANTAMENTO { get; set; }
        public string SINISHIS_NUM_APOL_SINISTRO { get; set; }

        public static R190_VALOR_ADIANTAMENTO_DB_SELECT_1_Query1 Execute(R190_VALOR_ADIANTAMENTO_DB_SELECT_1_Query1 r190_VALOR_ADIANTAMENTO_DB_SELECT_1_Query1)
        {
            var ths = r190_VALOR_ADIANTAMENTO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R190_VALOR_ADIANTAMENTO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R190_VALOR_ADIANTAMENTO_DB_SELECT_1_Query1();
            var i = 0;
            dta.HOST_VALOR_ADIANTAMENTO = result[i++].Value?.ToString();
            dta.HOST_DATA_ADIANTAMENTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}