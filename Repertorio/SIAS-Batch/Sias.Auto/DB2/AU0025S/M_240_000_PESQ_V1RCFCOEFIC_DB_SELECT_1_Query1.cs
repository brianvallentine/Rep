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
    public class M_240_000_PESQ_V1RCFCOEFIC_DB_SELECT_1_Query1 : QueryBasis<M_240_000_PESQ_V1RCFCOEFIC_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT COEFIC
            INTO
            :CFRCF-COEFIC
            FROM SEGUROS.V1RCFCOEFIC
            WHERE CODTAB = :CFRCF-CODTAB
            AND CODPRODU = :CFRCF-CODPRODU
            AND NIVEL = :CFRCF-NIVEL
            AND DTINIVIG <= :CFRCF-DTINIVIG
            AND DTTERVIG >= :CFRCF-DTINIVIG
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COEFIC
											FROM SEGUROS.V1RCFCOEFIC
											WHERE CODTAB = '{this.CFRCF_CODTAB}'
											AND CODPRODU = '{this.CFRCF_CODPRODU}'
											AND NIVEL = '{this.CFRCF_NIVEL}'
											AND DTINIVIG <= '{this.CFRCF_DTINIVIG}'
											AND DTTERVIG >= '{this.CFRCF_DTINIVIG}'";

            return query;
        }
        public string CFRCF_COEFIC { get; set; }
        public string CFRCF_CODPRODU { get; set; }
        public string CFRCF_DTINIVIG { get; set; }
        public string CFRCF_CODTAB { get; set; }
        public string CFRCF_NIVEL { get; set; }

        public static M_240_000_PESQ_V1RCFCOEFIC_DB_SELECT_1_Query1 Execute(M_240_000_PESQ_V1RCFCOEFIC_DB_SELECT_1_Query1 m_240_000_PESQ_V1RCFCOEFIC_DB_SELECT_1_Query1)
        {
            var ths = m_240_000_PESQ_V1RCFCOEFIC_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_240_000_PESQ_V1RCFCOEFIC_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_240_000_PESQ_V1RCFCOEFIC_DB_SELECT_1_Query1();
            var i = 0;
            dta.CFRCF_COEFIC = result[i++].Value?.ToString();
            return dta;
        }

    }
}