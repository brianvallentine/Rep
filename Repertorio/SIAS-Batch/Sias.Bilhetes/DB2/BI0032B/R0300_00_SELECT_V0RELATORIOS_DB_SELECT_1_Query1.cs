using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0032B
{
    public class R0300_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1 : QueryBasis<R0300_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_REFERENCIA
            INTO :V0RELA-DATA-REFER
            FROM SEGUROS.V0RELATORIOS
            WHERE CODRELAT = 'BI0032B1'
            AND SITUACAO = '0'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_REFERENCIA
											FROM SEGUROS.V0RELATORIOS
											WHERE CODRELAT = 'BI0032B1'
											AND SITUACAO = '0'";

            return query;
        }
        public string V0RELA_DATA_REFER { get; set; }

        public static R0300_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1 Execute(R0300_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1 r0300_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1)
        {
            var ths = r0300_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0300_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0300_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0RELA_DATA_REFER = result[i++].Value?.ToString();
            return dta;
        }

    }
}