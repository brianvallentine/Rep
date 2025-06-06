using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Auto.DB2.AU0032S
{
    public class M_060_000_PESQ_TATBONUS_DB_SELECT_1_Query1 : QueryBasis<M_060_000_PESQ_TATBONUS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT PCDESC
            INTO
            :BONUS-PCDESC
            FROM SEGUROS.V1BONAUTO
            WHERE CODTAB = :BONUS-CODTAB
            AND CLASSEBN = :BONUS-CLASSEBN
            AND DTINIVIG <= :BONUS-DTINIVIG
            AND DTTERVIG >= :BONUS-DTINIVIG
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT PCDESC
											FROM SEGUROS.V1BONAUTO
											WHERE CODTAB = '{this.BONUS_CODTAB}'
											AND CLASSEBN = '{this.BONUS_CLASSEBN}'
											AND DTINIVIG <= '{this.BONUS_DTINIVIG}'
											AND DTTERVIG >= '{this.BONUS_DTINIVIG}'";

            return query;
        }
        public string BONUS_PCDESC { get; set; }
        public string BONUS_CLASSEBN { get; set; }
        public string BONUS_DTINIVIG { get; set; }
        public string BONUS_CODTAB { get; set; }

        public static M_060_000_PESQ_TATBONUS_DB_SELECT_1_Query1 Execute(M_060_000_PESQ_TATBONUS_DB_SELECT_1_Query1 m_060_000_PESQ_TATBONUS_DB_SELECT_1_Query1)
        {
            var ths = m_060_000_PESQ_TATBONUS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_060_000_PESQ_TATBONUS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_060_000_PESQ_TATBONUS_DB_SELECT_1_Query1();
            var i = 0;
            dta.BONUS_PCDESC = result[i++].Value?.ToString();
            return dta;
        }

    }
}