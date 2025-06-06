using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Auto.DB2.AU0025S
{
    public class M_015_000_SQL_SELECT_V1MOEDA_DB_SELECT_1_Query1 : QueryBasis<M_015_000_SQL_SELECT_V1MOEDA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            VLCRUZAD
            INTO
            :V1MOEDA-VLCRUZAD
            FROM
            SEGUROS.V1MOEDA
            WHERE
            CODUNIMO = :V1MOEDA-CODUNIMO
            AND DTINIVIG <= :V1MOEDA-DTINIVIG
            AND DTTERVIG >= :V1MOEDA-DTINIVIG
            AND SITUACAO = '0'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											VLCRUZAD
											FROM
											SEGUROS.V1MOEDA
											WHERE
											CODUNIMO = '{this.V1MOEDA_CODUNIMO}'
											AND DTINIVIG <= '{this.V1MOEDA_DTINIVIG}'
											AND DTTERVIG >= '{this.V1MOEDA_DTINIVIG}'
											AND SITUACAO = '0'";

            return query;
        }
        public string V1MOEDA_VLCRUZAD { get; set; }
        public string V1MOEDA_CODUNIMO { get; set; }
        public string V1MOEDA_DTINIVIG { get; set; }

        public static M_015_000_SQL_SELECT_V1MOEDA_DB_SELECT_1_Query1 Execute(M_015_000_SQL_SELECT_V1MOEDA_DB_SELECT_1_Query1 m_015_000_SQL_SELECT_V1MOEDA_DB_SELECT_1_Query1)
        {
            var ths = m_015_000_SQL_SELECT_V1MOEDA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_015_000_SQL_SELECT_V1MOEDA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_015_000_SQL_SELECT_V1MOEDA_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1MOEDA_VLCRUZAD = result[i++].Value?.ToString();
            return dta;
        }

    }
}