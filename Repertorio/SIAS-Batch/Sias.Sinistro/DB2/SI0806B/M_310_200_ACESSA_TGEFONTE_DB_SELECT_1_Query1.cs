using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0806B
{
    public class M_310_200_ACESSA_TGEFONTE_DB_SELECT_1_Query1 : QueryBasis<M_310_200_ACESSA_TGEFONTE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT
            NOMEFTE
            INTO :GEFONTE-NOMEFTE
            FROM SEGUROS.V1FONTE
            WHERE FONTE = :WCOD-FONTE
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											NOMEFTE
											FROM SEGUROS.V1FONTE
											WHERE FONTE = '{this.WCOD_FONTE}'";

            return query;
        }
        public string GEFONTE_NOMEFTE { get; set; }
        public string WCOD_FONTE { get; set; }

        public static M_310_200_ACESSA_TGEFONTE_DB_SELECT_1_Query1 Execute(M_310_200_ACESSA_TGEFONTE_DB_SELECT_1_Query1 m_310_200_ACESSA_TGEFONTE_DB_SELECT_1_Query1)
        {
            var ths = m_310_200_ACESSA_TGEFONTE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_310_200_ACESSA_TGEFONTE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_310_200_ACESSA_TGEFONTE_DB_SELECT_1_Query1();
            var i = 0;
            dta.GEFONTE_NOMEFTE = result[i++].Value?.ToString();
            return dta;
        }

    }
}