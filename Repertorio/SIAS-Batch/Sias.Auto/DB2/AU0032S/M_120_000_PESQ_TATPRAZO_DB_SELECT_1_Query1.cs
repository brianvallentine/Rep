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
    public class M_120_000_PESQ_TATPRAZO_DB_SELECT_1_Query1 : QueryBasis<M_120_000_PESQ_TATPRAZO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT PCPRMANO
            INTO
            :PRAZO-PCPRMANO
            FROM SEGUROS.V1PRAZOSEG
            WHERE CODTAB = :PRAZO-CODTAB
            AND PRAZOINI <= :PRAZO-PRAZOINI
            AND PRAZOFIM >= :PRAZO-PRAZOINI
            AND DTINIVIG <= :PRAZO-DTINIVIG
            AND DTTERVIG >= :PRAZO-DTINIVIG
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT PCPRMANO
											FROM SEGUROS.V1PRAZOSEG
											WHERE CODTAB = '{this.PRAZO_CODTAB}'
											AND PRAZOINI <= '{this.PRAZO_PRAZOINI}'
											AND PRAZOFIM >= '{this.PRAZO_PRAZOINI}'
											AND DTINIVIG <= '{this.PRAZO_DTINIVIG}'
											AND DTTERVIG >= '{this.PRAZO_DTINIVIG}'";

            return query;
        }
        public string PRAZO_PCPRMANO { get; set; }
        public string PRAZO_PRAZOINI { get; set; }
        public string PRAZO_DTINIVIG { get; set; }
        public string PRAZO_CODTAB { get; set; }

        public static M_120_000_PESQ_TATPRAZO_DB_SELECT_1_Query1 Execute(M_120_000_PESQ_TATPRAZO_DB_SELECT_1_Query1 m_120_000_PESQ_TATPRAZO_DB_SELECT_1_Query1)
        {
            var ths = m_120_000_PESQ_TATPRAZO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_120_000_PESQ_TATPRAZO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_120_000_PESQ_TATPRAZO_DB_SELECT_1_Query1();
            var i = 0;
            dta.PRAZO_PCPRMANO = result[i++].Value?.ToString();
            return dta;
        }

    }
}