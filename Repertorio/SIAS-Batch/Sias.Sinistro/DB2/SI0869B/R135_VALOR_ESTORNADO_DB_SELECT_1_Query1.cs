using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0869B
{
    public class R135_VALOR_ESTORNADO_DB_SELECT_1_Query1 : QueryBasis<R135_VALOR_ESTORNADO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(SUM(VAL_OPERACAO),0)
            INTO :HOST-VALOR-APURADO
            FROM SEGUROS.SINISTRO_HISTORICO
            WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO
            AND COD_OPERACAO IN (1181, 1182, 1183, 1184)
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(SUM(VAL_OPERACAO)
							,0)
											FROM SEGUROS.SINISTRO_HISTORICO
											WHERE NUM_APOL_SINISTRO = '{this.SINISHIS_NUM_APOL_SINISTRO}'
											AND COD_OPERACAO IN (1181
							, 1182
							, 1183
							, 1184)";

            return query;
        }
        public string HOST_VALOR_APURADO { get; set; }
        public string SINISHIS_NUM_APOL_SINISTRO { get; set; }

        public static R135_VALOR_ESTORNADO_DB_SELECT_1_Query1 Execute(R135_VALOR_ESTORNADO_DB_SELECT_1_Query1 r135_VALOR_ESTORNADO_DB_SELECT_1_Query1)
        {
            var ths = r135_VALOR_ESTORNADO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R135_VALOR_ESTORNADO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R135_VALOR_ESTORNADO_DB_SELECT_1_Query1();
            var i = 0;
            dta.HOST_VALOR_APURADO = result[i++].Value?.ToString();
            return dta;
        }

    }
}