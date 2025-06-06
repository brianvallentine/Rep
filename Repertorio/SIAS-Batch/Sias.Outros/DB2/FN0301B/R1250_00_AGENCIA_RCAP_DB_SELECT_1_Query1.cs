using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.FN0301B
{
    public class R1250_00_AGENCIA_RCAP_DB_SELECT_1_Query1 : QueryBasis<R1250_00_AGENCIA_RCAP_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT AGECOBR
            INTO :V0RCAP-AGECOBR
            FROM SEGUROS.V0RCAP
            WHERE NRRCAP = :V1ENDO-NRRCAP
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT AGECOBR
											FROM SEGUROS.V0RCAP
											WHERE NRRCAP = '{this.V1ENDO_NRRCAP}'
											WITH UR";

            return query;
        }
        public string V0RCAP_AGECOBR { get; set; }
        public string V1ENDO_NRRCAP { get; set; }

        public static R1250_00_AGENCIA_RCAP_DB_SELECT_1_Query1 Execute(R1250_00_AGENCIA_RCAP_DB_SELECT_1_Query1 r1250_00_AGENCIA_RCAP_DB_SELECT_1_Query1)
        {
            var ths = r1250_00_AGENCIA_RCAP_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1250_00_AGENCIA_RCAP_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1250_00_AGENCIA_RCAP_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0RCAP_AGECOBR = result[i++].Value?.ToString();
            return dta;
        }

    }
}