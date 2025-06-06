using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0810B
{
    public class M_0000_00_ACESSA_COTACAO_MOEDA_DB_SELECT_1_Query1 : QueryBasis<M_0000_00_ACESSA_COTACAO_MOEDA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VLCRUZAD
            INTO :V1MOED-VLCRUZAD
            FROM SEGUROS.V1MOEDA
            WHERE CODUNIMO = :WHOST-CODUNIMO
            AND DTINIVIG <= :WHOST-DTINIVIG
            AND DTTERVIG >= :WHOST-DTINIVIG
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VLCRUZAD
											FROM SEGUROS.V1MOEDA
											WHERE CODUNIMO = '{this.WHOST_CODUNIMO}'
											AND DTINIVIG <= '{this.WHOST_DTINIVIG}'
											AND DTTERVIG >= '{this.WHOST_DTINIVIG}'";

            return query;
        }
        public string V1MOED_VLCRUZAD { get; set; }
        public string WHOST_CODUNIMO { get; set; }
        public string WHOST_DTINIVIG { get; set; }

        public static M_0000_00_ACESSA_COTACAO_MOEDA_DB_SELECT_1_Query1 Execute(M_0000_00_ACESSA_COTACAO_MOEDA_DB_SELECT_1_Query1 m_0000_00_ACESSA_COTACAO_MOEDA_DB_SELECT_1_Query1)
        {
            var ths = m_0000_00_ACESSA_COTACAO_MOEDA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0000_00_ACESSA_COTACAO_MOEDA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0000_00_ACESSA_COTACAO_MOEDA_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1MOED_VLCRUZAD = result[i++].Value?.ToString();
            return dta;
        }

    }
}