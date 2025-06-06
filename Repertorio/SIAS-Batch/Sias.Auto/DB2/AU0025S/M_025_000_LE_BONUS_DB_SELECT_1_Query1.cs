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
    public class M_025_000_LE_BONUS_DB_SELECT_1_Query1 : QueryBasis<M_025_000_LE_BONUS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT
            PCDESC
            INTO
            :BONAU-PCDESC
            FROM SEGUROS.V1BONAUTO
            WHERE CODTAB = :BONAU-CODTAB
            AND CLASSEBN = :BONAU-CLASSEBN
            AND DTINIVIG <= :BONAU-DTINIVIG
            AND DTTERVIG >= :BONAU-DTINIVIG
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											PCDESC
											FROM SEGUROS.V1BONAUTO
											WHERE CODTAB = '{this.BONAU_CODTAB}'
											AND CLASSEBN = '{this.BONAU_CLASSEBN}'
											AND DTINIVIG <= '{this.BONAU_DTINIVIG}'
											AND DTTERVIG >= '{this.BONAU_DTINIVIG}'";

            return query;
        }
        public string BONAU_PCDESC { get; set; }
        public string BONAU_CLASSEBN { get; set; }
        public string BONAU_DTINIVIG { get; set; }
        public string BONAU_CODTAB { get; set; }

        public static M_025_000_LE_BONUS_DB_SELECT_1_Query1 Execute(M_025_000_LE_BONUS_DB_SELECT_1_Query1 m_025_000_LE_BONUS_DB_SELECT_1_Query1)
        {
            var ths = m_025_000_LE_BONUS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_025_000_LE_BONUS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_025_000_LE_BONUS_DB_SELECT_1_Query1();
            var i = 0;
            dta.BONAU_PCDESC = result[i++].Value?.ToString();
            return dta;
        }

    }
}