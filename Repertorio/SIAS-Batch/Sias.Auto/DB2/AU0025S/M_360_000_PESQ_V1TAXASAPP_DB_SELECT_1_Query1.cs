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
    public class M_360_000_PESQ_V1TAXASAPP_DB_SELECT_1_Query1 : QueryBasis<M_360_000_PESQ_V1TAXASAPP_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT TAXAAPPM, TAXAAPPI,
            TAXAAPPA, TAXAAPPD
            INTO
            :TXAPP-TAXAAPPM,
            :TXAPP-TAXAAPPI,
            :TXAPP-TAXAAPPA,
            :TXAPP-TAXAAPPD
            FROM SEGUROS.V1TAXASAPP
            WHERE CODTAB = :TXAPP-CODTAB
            AND DTINIVIG <= :TXAPP-DTINIVIG
            AND DTTERVIG >= :TXAPP-DTINIVIG
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT TAXAAPPM
							, TAXAAPPI
							,
											TAXAAPPA
							, TAXAAPPD
											FROM SEGUROS.V1TAXASAPP
											WHERE CODTAB = '{this.TXAPP_CODTAB}'
											AND DTINIVIG <= '{this.TXAPP_DTINIVIG}'
											AND DTTERVIG >= '{this.TXAPP_DTINIVIG}'";

            return query;
        }
        public string TXAPP_TAXAAPPM { get; set; }
        public string TXAPP_TAXAAPPI { get; set; }
        public string TXAPP_TAXAAPPA { get; set; }
        public string TXAPP_TAXAAPPD { get; set; }
        public string TXAPP_DTINIVIG { get; set; }
        public string TXAPP_CODTAB { get; set; }

        public static M_360_000_PESQ_V1TAXASAPP_DB_SELECT_1_Query1 Execute(M_360_000_PESQ_V1TAXASAPP_DB_SELECT_1_Query1 m_360_000_PESQ_V1TAXASAPP_DB_SELECT_1_Query1)
        {
            var ths = m_360_000_PESQ_V1TAXASAPP_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_360_000_PESQ_V1TAXASAPP_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_360_000_PESQ_V1TAXASAPP_DB_SELECT_1_Query1();
            var i = 0;
            dta.TXAPP_TAXAAPPM = result[i++].Value?.ToString();
            dta.TXAPP_TAXAAPPI = result[i++].Value?.ToString();
            dta.TXAPP_TAXAAPPA = result[i++].Value?.ToString();
            dta.TXAPP_TAXAAPPD = result[i++].Value?.ToString();
            return dta;
        }

    }
}