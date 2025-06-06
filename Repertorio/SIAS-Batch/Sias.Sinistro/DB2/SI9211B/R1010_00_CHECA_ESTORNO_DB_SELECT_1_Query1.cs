using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI9211B
{
    public class R1010_00_CHECA_ESTORNO_DB_SELECT_1_Query1 : QueryBasis<R1010_00_CHECA_ESTORNO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT MAX(DATA_MOVIMENTO)
            INTO :SINISHIS-DATA-MOVIMENTO
            FROM SEGUROS.SINISTRO_HISTORICO
            WHERE NUM_APOL_SINISTRO = :SIARDEVC-NUM-APOL-SINISTRO
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT MAX(DATA_MOVIMENTO)
											FROM SEGUROS.SINISTRO_HISTORICO
											WHERE NUM_APOL_SINISTRO = '{this.SIARDEVC_NUM_APOL_SINISTRO}'";

            return query;
        }
        public string SINISHIS_DATA_MOVIMENTO { get; set; }
        public string SIARDEVC_NUM_APOL_SINISTRO { get; set; }

        public static R1010_00_CHECA_ESTORNO_DB_SELECT_1_Query1 Execute(R1010_00_CHECA_ESTORNO_DB_SELECT_1_Query1 r1010_00_CHECA_ESTORNO_DB_SELECT_1_Query1)
        {
            var ths = r1010_00_CHECA_ESTORNO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1010_00_CHECA_ESTORNO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1010_00_CHECA_ESTORNO_DB_SELECT_1_Query1();
            var i = 0;
            dta.SINISHIS_DATA_MOVIMENTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}