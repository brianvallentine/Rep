using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0814B
{
    public class M_575_000_LER_TRAMO_DB_SELECT_1_Query1 : QueryBasis<M_575_000_LER_TRAMO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NOMERAMO
            INTO :RAMO-NOMERAMO
            FROM SEGUROS.V1RAMO
            WHERE RAMO = :MEST-RAMO
            AND MODALIDA = 0
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NOMERAMO
											FROM SEGUROS.V1RAMO
											WHERE RAMO = '{this.MEST_RAMO}'
											AND MODALIDA = 0";

            return query;
        }
        public string RAMO_NOMERAMO { get; set; }
        public string MEST_RAMO { get; set; }

        public static M_575_000_LER_TRAMO_DB_SELECT_1_Query1 Execute(M_575_000_LER_TRAMO_DB_SELECT_1_Query1 m_575_000_LER_TRAMO_DB_SELECT_1_Query1)
        {
            var ths = m_575_000_LER_TRAMO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_575_000_LER_TRAMO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_575_000_LER_TRAMO_DB_SELECT_1_Query1();
            var i = 0;
            dta.RAMO_NOMERAMO = result[i++].Value?.ToString();
            return dta;
        }

    }
}