using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0005B
{
    public class R110_ROTINA_CRITICA_DADOS_DB_SELECT_1_Query1 : QueryBasis<R110_ROTINA_CRITICA_DADOS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_CALENDARIO
            INTO :CALENDAR-DATA-CALENDARIO
            FROM SEGUROS.CALENDARIO
            WHERE DATA_CALENDARIO = :HOST-DATA-OCORRENCIA
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_CALENDARIO
											FROM SEGUROS.CALENDARIO
											WHERE DATA_CALENDARIO = '{this.HOST_DATA_OCORRENCIA}'
											WITH UR";

            return query;
        }
        public string CALENDAR_DATA_CALENDARIO { get; set; }
        public string HOST_DATA_OCORRENCIA { get; set; }

        public static R110_ROTINA_CRITICA_DADOS_DB_SELECT_1_Query1 Execute(R110_ROTINA_CRITICA_DADOS_DB_SELECT_1_Query1 r110_ROTINA_CRITICA_DADOS_DB_SELECT_1_Query1)
        {
            var ths = r110_ROTINA_CRITICA_DADOS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R110_ROTINA_CRITICA_DADOS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R110_ROTINA_CRITICA_DADOS_DB_SELECT_1_Query1();
            var i = 0;
            dta.CALENDAR_DATA_CALENDARIO = result[i++].Value?.ToString();
            return dta;
        }

    }
}