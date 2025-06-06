using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0003B
{
    public class R3200_00_SELECT_V1PARCELA_DB_SELECT_1_Query1 : QueryBasis<R3200_00_SELECT_V1PARCELA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT MIN(NRPARCEL)
            INTO :V1PARC-NRPARCEL
            FROM SEGUROS.V0PARCELA
            WHERE NRTIT = :V1MCOB-NRTIT
            AND SITUACAO = '0'
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT MIN(NRPARCEL)
											FROM SEGUROS.V0PARCELA
											WHERE NRTIT = '{this.V1MCOB_NRTIT}'
											AND SITUACAO = '0'";

            return query;
        }
        public string V1PARC_NRPARCEL { get; set; }
        public string V1MCOB_NRTIT { get; set; }

        public static R3200_00_SELECT_V1PARCELA_DB_SELECT_1_Query1 Execute(R3200_00_SELECT_V1PARCELA_DB_SELECT_1_Query1 r3200_00_SELECT_V1PARCELA_DB_SELECT_1_Query1)
        {
            var ths = r3200_00_SELECT_V1PARCELA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3200_00_SELECT_V1PARCELA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3200_00_SELECT_V1PARCELA_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1PARC_NRPARCEL = result[i++].Value?.ToString();
            return dta;
        }

    }
}