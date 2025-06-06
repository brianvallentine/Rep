using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0021B
{
    public class M_380_000_LER_V1MOEDA_DB_SELECT_1_Query1 : QueryBasis<M_380_000_LER_V1MOEDA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VLCRUZAD,
            SIGLUNIM
            INTO :V1MOED-VLCRUZAD,
            :V1MOED-SIGLUNIM
            FROM SEGUROS.V1MOEDA
            WHERE CODUNIMO = :V1MEST-MOEDA-SINI
            AND DTINIVIG <= :V1HIST-DTMOVTO
            AND DTTERVIG >= :V1HIST-DTMOVTO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VLCRUZAD
							,
											SIGLUNIM
											FROM SEGUROS.V1MOEDA
											WHERE CODUNIMO = '{this.V1MEST_MOEDA_SINI}'
											AND DTINIVIG <= '{this.V1HIST_DTMOVTO}'
											AND DTTERVIG >= '{this.V1HIST_DTMOVTO}'";

            return query;
        }
        public string V1MOED_VLCRUZAD { get; set; }
        public string V1MOED_SIGLUNIM { get; set; }
        public string V1MEST_MOEDA_SINI { get; set; }
        public string V1HIST_DTMOVTO { get; set; }

        public static M_380_000_LER_V1MOEDA_DB_SELECT_1_Query1 Execute(M_380_000_LER_V1MOEDA_DB_SELECT_1_Query1 m_380_000_LER_V1MOEDA_DB_SELECT_1_Query1)
        {
            var ths = m_380_000_LER_V1MOEDA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_380_000_LER_V1MOEDA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_380_000_LER_V1MOEDA_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1MOED_VLCRUZAD = result[i++].Value?.ToString();
            dta.V1MOED_SIGLUNIM = result[i++].Value?.ToString();
            return dta;
        }

    }
}