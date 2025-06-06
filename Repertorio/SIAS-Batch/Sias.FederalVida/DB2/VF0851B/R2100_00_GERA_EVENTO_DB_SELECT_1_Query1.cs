using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.FederalVida.DB2.VF0851B
{
    public class R2100_00_GERA_EVENTO_DB_SELECT_1_Query1 : QueryBasis<R2100_00_GERA_EVENTO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT OCORHIST
            INTO :V0PDVF-OCORHIST
            FROM SEGUROS.V0PRODUTORVF
            WHERE CODPDT = :V0PLAC-CODPDT
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT OCORHIST
											FROM SEGUROS.V0PRODUTORVF
											WHERE CODPDT = '{this.V0PLAC_CODPDT}'";

            return query;
        }
        public string V0PDVF_OCORHIST { get; set; }
        public string V0PLAC_CODPDT { get; set; }

        public static R2100_00_GERA_EVENTO_DB_SELECT_1_Query1 Execute(R2100_00_GERA_EVENTO_DB_SELECT_1_Query1 r2100_00_GERA_EVENTO_DB_SELECT_1_Query1)
        {
            var ths = r2100_00_GERA_EVENTO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2100_00_GERA_EVENTO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2100_00_GERA_EVENTO_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0PDVF_OCORHIST = result[i++].Value?.ToString();
            return dta;
        }

    }
}