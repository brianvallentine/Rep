using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB1280B
{
    public class P2113_00_CALCULA_VALORES_DB_SELECT_5_Query1 : QueryBasis<P2113_00_CALCULA_VALORES_DB_SELECT_5_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT MAX(A.DATA_CALENDARIO)
            INTO :WS-DT-CANCELAMENTO-1
            FROM ( SELECT DATA_CALENDARIO
            FROM SEGUROS.CALENDARIO
            WHERE DATA_CALENDARIO > :WS-DT-FIM-VIG-PROP
            AND DIA_SEMANA NOT IN ( 'S' , 'D' )
            AND FERIADO <> 'N'
            FETCH FIRST 5 ROW ONLY
            ) A
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT MAX(A.DATA_CALENDARIO)
											FROM ( SELECT DATA_CALENDARIO
											FROM SEGUROS.CALENDARIO
											WHERE DATA_CALENDARIO > '{this.WS_DT_FIM_VIG_PROP}'
											AND DIA_SEMANA NOT IN ( 'S' 
							, 'D' )
											AND FERIADO <> 'N'
											FETCH FIRST 5 ROW ONLY
											) A
											WITH UR";

            return query;
        }
        public string WS_DT_CANCELAMENTO_1 { get; set; }
        public string WS_DT_FIM_VIG_PROP { get; set; }

        public static P2113_00_CALCULA_VALORES_DB_SELECT_5_Query1 Execute(P2113_00_CALCULA_VALORES_DB_SELECT_5_Query1 p2113_00_CALCULA_VALORES_DB_SELECT_5_Query1)
        {
            var ths = p2113_00_CALCULA_VALORES_DB_SELECT_5_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override P2113_00_CALCULA_VALORES_DB_SELECT_5_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new P2113_00_CALCULA_VALORES_DB_SELECT_5_Query1();
            var i = 0;
            dta.WS_DT_CANCELAMENTO_1 = result[i++].Value?.ToString();
            return dta;
        }

    }
}