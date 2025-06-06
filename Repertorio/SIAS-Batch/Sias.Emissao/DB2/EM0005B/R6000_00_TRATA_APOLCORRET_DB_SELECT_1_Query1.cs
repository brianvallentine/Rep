using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0005B
{
    public class R6000_00_TRATA_APOLCORRET_DB_SELECT_1_Query1 : QueryBasis<R6000_00_TRATA_APOLCORRET_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DISTINCT DTINIVIG, DTTERVIG
            INTO :V2PROP-DTINIVIG,
            :V2PROP-DTTERVIG
            FROM SEGUROS.V0APOLCORRET
            WHERE NUM_APOLICE = :V1PROP-NUM-APOLICE
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DISTINCT DTINIVIG
							, DTTERVIG
											FROM SEGUROS.V0APOLCORRET
											WHERE NUM_APOLICE = '{this.V1PROP_NUM_APOLICE}'";

            return query;
        }
        public string V2PROP_DTINIVIG { get; set; }
        public string V2PROP_DTTERVIG { get; set; }
        public string V1PROP_NUM_APOLICE { get; set; }

        public static R6000_00_TRATA_APOLCORRET_DB_SELECT_1_Query1 Execute(R6000_00_TRATA_APOLCORRET_DB_SELECT_1_Query1 r6000_00_TRATA_APOLCORRET_DB_SELECT_1_Query1)
        {
            var ths = r6000_00_TRATA_APOLCORRET_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R6000_00_TRATA_APOLCORRET_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R6000_00_TRATA_APOLCORRET_DB_SELECT_1_Query1();
            var i = 0;
            dta.V2PROP_DTINIVIG = result[i++].Value?.ToString();
            dta.V2PROP_DTTERVIG = result[i++].Value?.ToString();
            return dta;
        }

    }
}