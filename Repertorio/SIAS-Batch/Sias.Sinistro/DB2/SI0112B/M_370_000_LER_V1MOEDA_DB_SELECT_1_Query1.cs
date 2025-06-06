using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0112B
{
    public class M_370_000_LER_V1MOEDA_DB_SELECT_1_Query1 : QueryBasis<M_370_000_LER_V1MOEDA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VLCRUZAD,
            SIGLUNIM
            INTO :MOEDA-VLCRUZAD,
            :MOEDA-SIGLUNIM
            FROM SEGUROS.V1MOEDA
            WHERE CODUNIMO = :MEST-MOEDA-SINI
            AND DTINIVIG <= :THIST-DTMOVTO
            AND DTTERVIG >= :THIST-DTMOVTO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VLCRUZAD
							,
											SIGLUNIM
											FROM SEGUROS.V1MOEDA
											WHERE CODUNIMO = '{this.MEST_MOEDA_SINI}'
											AND DTINIVIG <= '{this.THIST_DTMOVTO}'
											AND DTTERVIG >= '{this.THIST_DTMOVTO}'";

            return query;
        }
        public string MOEDA_VLCRUZAD { get; set; }
        public string MOEDA_SIGLUNIM { get; set; }
        public string MEST_MOEDA_SINI { get; set; }
        public string THIST_DTMOVTO { get; set; }

        public static M_370_000_LER_V1MOEDA_DB_SELECT_1_Query1 Execute(M_370_000_LER_V1MOEDA_DB_SELECT_1_Query1 m_370_000_LER_V1MOEDA_DB_SELECT_1_Query1)
        {
            var ths = m_370_000_LER_V1MOEDA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_370_000_LER_V1MOEDA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_370_000_LER_V1MOEDA_DB_SELECT_1_Query1();
            var i = 0;
            dta.MOEDA_VLCRUZAD = result[i++].Value?.ToString();
            dta.MOEDA_SIGLUNIM = result[i++].Value?.ToString();
            return dta;
        }

    }
}