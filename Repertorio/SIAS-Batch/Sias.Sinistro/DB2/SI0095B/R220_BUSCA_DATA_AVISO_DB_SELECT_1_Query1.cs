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
    public class R220_BUSCA_DATA_AVISO_DB_SELECT_1_Query1 : QueryBasis<R220_BUSCA_DATA_AVISO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_MOVIMENTO
            INTO :HOST-DATA-MOVIMENTO
            FROM SEGUROS.SINISTRO_HISTORICO
            WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO
            AND COD_OPERACAO = 101
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_MOVIMENTO
											FROM SEGUROS.SINISTRO_HISTORICO
											WHERE NUM_APOL_SINISTRO = '{this.SINISHIS_NUM_APOL_SINISTRO}'
											AND COD_OPERACAO = 101";

            return query;
        }
        public string HOST_DATA_MOVIMENTO { get; set; }
        public string SINISHIS_NUM_APOL_SINISTRO { get; set; }

        public static R220_BUSCA_DATA_AVISO_DB_SELECT_1_Query1 Execute(R220_BUSCA_DATA_AVISO_DB_SELECT_1_Query1 r220_BUSCA_DATA_AVISO_DB_SELECT_1_Query1)
        {
            var ths = r220_BUSCA_DATA_AVISO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R220_BUSCA_DATA_AVISO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R220_BUSCA_DATA_AVISO_DB_SELECT_1_Query1();
            var i = 0;
            dta.HOST_DATA_MOVIMENTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}