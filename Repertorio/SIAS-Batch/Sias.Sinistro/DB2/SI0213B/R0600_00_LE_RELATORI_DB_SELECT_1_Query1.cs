using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0213B
{
    public class R0600_00_LE_RELATORI_DB_SELECT_1_Query1 : QueryBasis<R0600_00_LE_RELATORI_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT PERI_INICIAL
            INTO :RELATORI-PERI-INICIAL
            FROM SEGUROS.RELATORIOS
            WHERE COD_RELATORIO = 'SI0213B1'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT PERI_INICIAL
											FROM SEGUROS.RELATORIOS
											WHERE COD_RELATORIO = 'SI0213B1'";

            return query;
        }
        public string RELATORI_PERI_INICIAL { get; set; }

        public static R0600_00_LE_RELATORI_DB_SELECT_1_Query1 Execute(R0600_00_LE_RELATORI_DB_SELECT_1_Query1 r0600_00_LE_RELATORI_DB_SELECT_1_Query1)
        {
            var ths = r0600_00_LE_RELATORI_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0600_00_LE_RELATORI_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0600_00_LE_RELATORI_DB_SELECT_1_Query1();
            var i = 0;
            dta.RELATORI_PERI_INICIAL = result[i++].Value?.ToString();
            return dta;
        }

    }
}