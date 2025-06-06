using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1853B
{
    public class R0000_00_PRINCIPAL_DB_SELECT_2_Query1 : QueryBasis<R0000_00_PRINCIPAL_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DTINIVIG
            INTO :V0COTA-DTINIVIG
            FROM SEGUROS.V0COTACAO
            WHERE CODUNIMO = 23
            AND DTINIVIG = :V1SIST-DTTERCOT
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DTINIVIG
											FROM SEGUROS.V0COTACAO
											WHERE CODUNIMO = 23
											AND DTINIVIG = '{this.V1SIST_DTTERCOT}'";

            return query;
        }
        public string V0COTA_DTINIVIG { get; set; }
        public string V1SIST_DTTERCOT { get; set; }

        public static R0000_00_PRINCIPAL_DB_SELECT_2_Query1 Execute(R0000_00_PRINCIPAL_DB_SELECT_2_Query1 r0000_00_PRINCIPAL_DB_SELECT_2_Query1)
        {
            var ths = r0000_00_PRINCIPAL_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0000_00_PRINCIPAL_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0000_00_PRINCIPAL_DB_SELECT_2_Query1();
            var i = 0;
            dta.V0COTA_DTINIVIG = result[i++].Value?.ToString();
            return dta;
        }

    }
}