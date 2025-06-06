using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0813B
{
    public class R0050_00_GERA_FITACEF_DB_SELECT_1_Query1 : QueryBasis<R0050_00_GERA_FITACEF_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_GERACAO
            INTO :V0FTCF-DTRET
            FROM SEGUROS.V0FITACEF
            WHERE NSAC = :V0FTCF-NSAC
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_GERACAO
											FROM SEGUROS.V0FITACEF
											WHERE NSAC = '{this.V0FTCF_NSAC}'
											WITH UR";

            return query;
        }
        public string V0FTCF_DTRET { get; set; }
        public string V0FTCF_NSAC { get; set; }

        public static R0050_00_GERA_FITACEF_DB_SELECT_1_Query1 Execute(R0050_00_GERA_FITACEF_DB_SELECT_1_Query1 r0050_00_GERA_FITACEF_DB_SELECT_1_Query1)
        {
            var ths = r0050_00_GERA_FITACEF_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0050_00_GERA_FITACEF_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0050_00_GERA_FITACEF_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0FTCF_DTRET = result[i++].Value?.ToString();
            return dta;
        }

    }
}