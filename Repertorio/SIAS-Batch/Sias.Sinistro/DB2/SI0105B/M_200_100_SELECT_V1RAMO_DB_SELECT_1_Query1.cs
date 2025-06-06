using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0105B
{
    public class M_200_100_SELECT_V1RAMO_DB_SELECT_1_Query1 : QueryBasis<M_200_100_SELECT_V1RAMO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NOMERAMO
            INTO :V1RAMO-NOMERAMO
            FROM SEGUROS.V1RAMO
            WHERE RAMO = :V1HISTMEST-RAMO
            AND MODALIDA = :V1HISTMEST-MODALIDA
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NOMERAMO
											FROM SEGUROS.V1RAMO
											WHERE RAMO = '{this.V1HISTMEST_RAMO}'
											AND MODALIDA = '{this.V1HISTMEST_MODALIDA}'";

            return query;
        }
        public string V1RAMO_NOMERAMO { get; set; }
        public string V1HISTMEST_MODALIDA { get; set; }
        public string V1HISTMEST_RAMO { get; set; }

        public static M_200_100_SELECT_V1RAMO_DB_SELECT_1_Query1 Execute(M_200_100_SELECT_V1RAMO_DB_SELECT_1_Query1 m_200_100_SELECT_V1RAMO_DB_SELECT_1_Query1)
        {
            var ths = m_200_100_SELECT_V1RAMO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_200_100_SELECT_V1RAMO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_200_100_SELECT_V1RAMO_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1RAMO_NOMERAMO = result[i++].Value?.ToString();
            return dta;
        }

    }
}