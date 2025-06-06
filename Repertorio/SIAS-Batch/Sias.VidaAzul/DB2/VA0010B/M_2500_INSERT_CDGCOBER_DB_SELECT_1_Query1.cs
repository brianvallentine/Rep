using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0010B
{
    public class M_2500_INSERT_CDGCOBER_DB_SELECT_1_Query1 : QueryBasis<M_2500_INSERT_CDGCOBER_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            CODCLIEN
            INTO
            :V0CDGC-CODCLIEN
            FROM
            SEGUROS.V0CDGCOBER
            WHERE
            CODCLIEN = :V1SEGV-CODCLI
            AND DTINIVIG <= :V1SIST-DTMOVABE
            AND DTTERVIG >= :V1SIST-DTMOVABE
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											CODCLIEN
											FROM
											SEGUROS.V0CDGCOBER
											WHERE
											CODCLIEN = '{this.V1SEGV_CODCLI}'
											AND DTINIVIG <= '{this.V1SIST_DTMOVABE}'
											AND DTTERVIG >= '{this.V1SIST_DTMOVABE}'";

            return query;
        }
        public string V0CDGC_CODCLIEN { get; set; }
        public string V1SIST_DTMOVABE { get; set; }
        public string V1SEGV_CODCLI { get; set; }

        public static M_2500_INSERT_CDGCOBER_DB_SELECT_1_Query1 Execute(M_2500_INSERT_CDGCOBER_DB_SELECT_1_Query1 m_2500_INSERT_CDGCOBER_DB_SELECT_1_Query1)
        {
            var ths = m_2500_INSERT_CDGCOBER_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_2500_INSERT_CDGCOBER_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_2500_INSERT_CDGCOBER_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0CDGC_CODCLIEN = result[i++].Value?.ToString();
            return dta;
        }

    }
}