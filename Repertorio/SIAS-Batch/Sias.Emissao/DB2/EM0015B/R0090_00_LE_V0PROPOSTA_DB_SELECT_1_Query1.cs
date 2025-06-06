using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0015B
{
    public class R0090_00_LE_V0PROPOSTA_DB_SELECT_1_Query1 : QueryBasis<R0090_00_LE_V0PROPOSTA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT AGECOBR,
            RAMO
            INTO :V0PROPO-AGECOBR,
            :V0PROPO-RAMO
            FROM SEGUROS.V0PROPOSTA
            WHERE FONTE = :V0PROPO-FONTE
            AND NRPROPOS = :V0PROPO-NRPROPOS
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT AGECOBR
							,
											RAMO
											FROM SEGUROS.V0PROPOSTA
											WHERE FONTE = '{this.V0PROPO_FONTE}'
											AND NRPROPOS = '{this.V0PROPO_NRPROPOS}'";

            return query;
        }
        public string V0PROPO_AGECOBR { get; set; }
        public string V0PROPO_RAMO { get; set; }
        public string V0PROPO_NRPROPOS { get; set; }
        public string V0PROPO_FONTE { get; set; }

        public static R0090_00_LE_V0PROPOSTA_DB_SELECT_1_Query1 Execute(R0090_00_LE_V0PROPOSTA_DB_SELECT_1_Query1 r0090_00_LE_V0PROPOSTA_DB_SELECT_1_Query1)
        {
            var ths = r0090_00_LE_V0PROPOSTA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0090_00_LE_V0PROPOSTA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0090_00_LE_V0PROPOSTA_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0PROPO_AGECOBR = result[i++].Value?.ToString();
            dta.V0PROPO_RAMO = result[i++].Value?.ToString();
            return dta;
        }

    }
}