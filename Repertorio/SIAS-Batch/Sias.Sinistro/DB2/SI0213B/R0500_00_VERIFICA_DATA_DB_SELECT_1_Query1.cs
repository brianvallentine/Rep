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
    public class R0500_00_VERIFICA_DATA_DB_SELECT_1_Query1 : QueryBasis<R0500_00_VERIFICA_DATA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(MAX(A.DATA_CALENDARIO), '0001-01-01' )
            INTO :HOST-DATA-ANTES-DE-05-E-20
            FROM SEGUROS.CALENDARIO A
            WHERE A.DATA_CALENDARIO <= :CALENDAR-DATA-CALENDARIO
            AND A.DIA_SEMANA NOT IN ( 'S' , 'D' )
            AND A.FERIADO <> 'N'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(MAX(A.DATA_CALENDARIO)
							, '0001-01-01' )
											FROM SEGUROS.CALENDARIO A
											WHERE A.DATA_CALENDARIO <= '{this.CALENDAR_DATA_CALENDARIO}'
											AND A.DIA_SEMANA NOT IN ( 'S' 
							, 'D' )
											AND A.FERIADO <> 'N'";

            return query;
        }
        public string HOST_DATA_ANTES_DE_05_E_20 { get; set; }
        public string CALENDAR_DATA_CALENDARIO { get; set; }

        public static R0500_00_VERIFICA_DATA_DB_SELECT_1_Query1 Execute(R0500_00_VERIFICA_DATA_DB_SELECT_1_Query1 r0500_00_VERIFICA_DATA_DB_SELECT_1_Query1)
        {
            var ths = r0500_00_VERIFICA_DATA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0500_00_VERIFICA_DATA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0500_00_VERIFICA_DATA_DB_SELECT_1_Query1();
            var i = 0;
            dta.HOST_DATA_ANTES_DE_05_E_20 = result[i++].Value?.ToString();
            return dta;
        }

    }
}