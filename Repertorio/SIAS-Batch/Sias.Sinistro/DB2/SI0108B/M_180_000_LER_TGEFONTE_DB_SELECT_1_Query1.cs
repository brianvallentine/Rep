using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0108B
{
    public class M_180_000_LER_TGEFONTE_DB_SELECT_1_Query1 : QueryBasis<M_180_000_LER_TGEFONTE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NOMEFTE, FONTE
            INTO :TGEFON-NOMEFTE, :TGEFON-FONTE
            FROM SEGUROS.V1FONTE
            WHERE FONTE = :WH-FONTE
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NOMEFTE
							, FONTE
											FROM SEGUROS.V1FONTE
											WHERE FONTE = '{this.WH_FONTE}'";

            return query;
        }
        public string TGEFON_NOMEFTE { get; set; }
        public string TGEFON_FONTE { get; set; }
        public string WH_FONTE { get; set; }

        public static M_180_000_LER_TGEFONTE_DB_SELECT_1_Query1 Execute(M_180_000_LER_TGEFONTE_DB_SELECT_1_Query1 m_180_000_LER_TGEFONTE_DB_SELECT_1_Query1)
        {
            var ths = m_180_000_LER_TGEFONTE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_180_000_LER_TGEFONTE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_180_000_LER_TGEFONTE_DB_SELECT_1_Query1();
            var i = 0;
            dta.TGEFON_NOMEFTE = result[i++].Value?.ToString();
            dta.TGEFON_FONTE = result[i++].Value?.ToString();
            return dta;
        }

    }
}