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
    public class M_160_000_PESQ_V1CATTARIFA_DB_SELECT_1_Query1 : QueryBasis<M_160_000_PESQ_V1CATTARIFA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT VLPRTXCF , PREBASBT
            INTO
            :CATTF-VLPRTXCF , :CATTF-PREBASBT
            FROM SEGUROS.V1CATTARIFA
            WHERE CODTAB = :CATTF-CODTAB
            AND CODPRODU = :CATTF-CODPRODU
            AND CATTARIF = :CATTF-CATTARIF
            AND REGIAO = :CATTF-REGIAO
            AND DTINIVIG <= :CATTF-DTINIVIG
            AND DTTERVIG >= :CATTF-DTINIVIG
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VLPRTXCF 
							, PREBASBT
											FROM SEGUROS.V1CATTARIFA
											WHERE CODTAB = '{this.CATTF_CODTAB}'
											AND CODPRODU = '{this.CATTF_CODPRODU}'
											AND CATTARIF = '{this.CATTF_CATTARIF}'
											AND REGIAO = '{this.CATTF_REGIAO}'
											AND DTINIVIG <= '{this.CATTF_DTINIVIG}'
											AND DTTERVIG >= '{this.CATTF_DTINIVIG}'";

            return query;
        }
        public string CATTF_VLPRTXCF { get; set; }
        public string CATTF_PREBASBT { get; set; }
        public string CATTF_CODPRODU { get; set; }
        public string CATTF_CATTARIF { get; set; }
        public string CATTF_DTINIVIG { get; set; }
        public string CATTF_CODTAB { get; set; }
        public string CATTF_REGIAO { get; set; }

        public static M_160_000_PESQ_V1CATTARIFA_DB_SELECT_1_Query1 Execute(M_160_000_PESQ_V1CATTARIFA_DB_SELECT_1_Query1 m_160_000_PESQ_V1CATTARIFA_DB_SELECT_1_Query1)
        {
            var ths = m_160_000_PESQ_V1CATTARIFA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_160_000_PESQ_V1CATTARIFA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_160_000_PESQ_V1CATTARIFA_DB_SELECT_1_Query1();
            var i = 0;
            dta.CATTF_VLPRTXCF = result[i++].Value?.ToString();
            dta.CATTF_PREBASBT = result[i++].Value?.ToString();
            return dta;
        }

    }
}