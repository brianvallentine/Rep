using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0101B
{
    public class M_610_000_LER_TGEUNIMO_DB_SELECT_1_Query1 : QueryBasis<M_610_000_LER_TGEUNIMO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VLCRUZAD,
            SIGLUNIM
            INTO :GEUNIMO-VLCRUZAD,
            :GEUNIMO-SIGLUNIM
            FROM SEGUROS.V1MOEDA
            WHERE CODUNIMO = :WMOEDA
            AND DTINIVIG <= :WGEUNIMO-DTINIVIG
            AND DTTERVIG >= :WGEUNIMO-DTTERVIG
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VLCRUZAD
							,
											SIGLUNIM
											FROM SEGUROS.V1MOEDA
											WHERE CODUNIMO = '{this.WMOEDA}'
											AND DTINIVIG <= '{this.WGEUNIMO_DTINIVIG}'
											AND DTTERVIG >= '{this.WGEUNIMO_DTTERVIG}'";

            return query;
        }
        public string GEUNIMO_VLCRUZAD { get; set; }
        public string GEUNIMO_SIGLUNIM { get; set; }
        public string WGEUNIMO_DTINIVIG { get; set; }
        public string WGEUNIMO_DTTERVIG { get; set; }
        public string WMOEDA { get; set; }

        public static M_610_000_LER_TGEUNIMO_DB_SELECT_1_Query1 Execute(M_610_000_LER_TGEUNIMO_DB_SELECT_1_Query1 m_610_000_LER_TGEUNIMO_DB_SELECT_1_Query1)
        {
            var ths = m_610_000_LER_TGEUNIMO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_610_000_LER_TGEUNIMO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_610_000_LER_TGEUNIMO_DB_SELECT_1_Query1();
            var i = 0;
            dta.GEUNIMO_VLCRUZAD = result[i++].Value?.ToString();
            dta.GEUNIMO_SIGLUNIM = result[i++].Value?.ToString();
            return dta;
        }

    }
}