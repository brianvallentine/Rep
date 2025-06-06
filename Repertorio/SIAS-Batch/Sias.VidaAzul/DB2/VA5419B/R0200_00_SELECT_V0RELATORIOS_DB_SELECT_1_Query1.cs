using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA5419B
{
    public class R0200_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1 : QueryBasis<R0200_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            DATA_REFERENCIA
            INTO
            :V0RELA-DTREFERENCIA
            FROM SEGUROS.V0RELATORIOS
            WHERE CODRELAT = 'VA1417B'
            AND SITUACAO = '0'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											DATA_REFERENCIA
											FROM SEGUROS.V0RELATORIOS
											WHERE CODRELAT = 'VA1417B'
											AND SITUACAO = '0'";

            return query;
        }
        public string V0RELA_DTREFERENCIA { get; set; }

        public static R0200_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1 Execute(R0200_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1 r0200_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1)
        {
            var ths = r0200_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0200_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0200_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0RELA_DTREFERENCIA = result[i++].Value?.ToString();
            return dta;
        }

    }
}