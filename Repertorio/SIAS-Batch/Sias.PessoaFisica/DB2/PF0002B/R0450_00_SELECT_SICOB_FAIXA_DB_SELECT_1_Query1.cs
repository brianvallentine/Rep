using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0002B
{
    public class R0450_00_SELECT_SICOB_FAIXA_DB_SELECT_1_Query1 : QueryBasis<R0450_00_SELECT_SICOB_FAIXA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_SICOB_INI
            INTO :V0SFRC-NRTIT:VIND-NRTIT
            FROM SEGUROS.SICOB_FAIXA_RCAP
            WHERE NUM_SICOB_INI <= :V0SFRC-NRTIT
            AND NUM_SICOB_FIM >= :V0SFRC-NRTIT
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_SICOB_INI
											FROM SEGUROS.SICOB_FAIXA_RCAP
											WHERE NUM_SICOB_INI <= '{this.V0SFRC_NRTIT}'
											AND NUM_SICOB_FIM >= '{this.V0SFRC_NRTIT}'
											WITH UR";

            return query;
        }
        public string V0SFRC_NRTIT { get; set; }
        public string VIND_NRTIT { get; set; }

        public static R0450_00_SELECT_SICOB_FAIXA_DB_SELECT_1_Query1 Execute(R0450_00_SELECT_SICOB_FAIXA_DB_SELECT_1_Query1 r0450_00_SELECT_SICOB_FAIXA_DB_SELECT_1_Query1)
        {
            var ths = r0450_00_SELECT_SICOB_FAIXA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0450_00_SELECT_SICOB_FAIXA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0450_00_SELECT_SICOB_FAIXA_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0SFRC_NRTIT = result[i++].Value?.ToString();
            dta.VIND_NRTIT = string.IsNullOrWhiteSpace(dta.V0SFRC_NRTIT) ? "-1" : "0";
            return dta;
        }

    }
}