using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GE0853S
{
    public class R1000_00_PROCESSA_PARC_ATRZD_DB_SELECT_1_Query1 : QueryBasis<R1000_00_PROCESSA_PARC_ATRZD_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NRTIT
            INTO :V0BANC-NRTIT
            FROM SEGUROS.V0BANCO
            WHERE BANCO = 104
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NRTIT
											FROM SEGUROS.V0BANCO
											WHERE BANCO = 104
											WITH UR";

            return query;
        }
        public string V0BANC_NRTIT { get; set; }

        public static R1000_00_PROCESSA_PARC_ATRZD_DB_SELECT_1_Query1 Execute(R1000_00_PROCESSA_PARC_ATRZD_DB_SELECT_1_Query1 r1000_00_PROCESSA_PARC_ATRZD_DB_SELECT_1_Query1)
        {
            var ths = r1000_00_PROCESSA_PARC_ATRZD_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1000_00_PROCESSA_PARC_ATRZD_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1000_00_PROCESSA_PARC_ATRZD_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0BANC_NRTIT = result[i++].Value?.ToString();
            return dta;
        }

    }
}