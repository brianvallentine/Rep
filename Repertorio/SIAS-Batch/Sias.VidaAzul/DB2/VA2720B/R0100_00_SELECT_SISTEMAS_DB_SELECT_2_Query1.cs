using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA2720B
{
    public class R0100_00_SELECT_SISTEMAS_DB_SELECT_2_Query1 : QueryBasis<R0100_00_SELECT_SISTEMAS_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_SOLICITACAO + 1 DAY
            INTO :WS-PERIODO-DE
            FROM SEGUROS.RELATORIOS
            WHERE IDE_SISTEMA = 'VA'
            AND COD_USUARIO = 'VA2720B'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_SOLICITACAO + 1 DAY
											FROM SEGUROS.RELATORIOS
											WHERE IDE_SISTEMA = 'VA'
											AND COD_USUARIO = 'VA2720B'";

            return query;
        }
        public string WS_PERIODO_DE { get; set; }

        public static R0100_00_SELECT_SISTEMAS_DB_SELECT_2_Query1 Execute(R0100_00_SELECT_SISTEMAS_DB_SELECT_2_Query1 r0100_00_SELECT_SISTEMAS_DB_SELECT_2_Query1)
        {
            var ths = r0100_00_SELECT_SISTEMAS_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0100_00_SELECT_SISTEMAS_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0100_00_SELECT_SISTEMAS_DB_SELECT_2_Query1();
            var i = 0;
            dta.WS_PERIODO_DE = result[i++].Value?.ToString();
            return dta;
        }

    }
}