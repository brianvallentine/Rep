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
    public class P2113_00_CALCULA_VALORES_DB_SELECT_6_Query1 : QueryBasis<P2113_00_CALCULA_VALORES_DB_SELECT_6_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT (DATA_CALENDARIO + :WS-QT-DIAS-CANC DAYS)
            INTO :WS-DT-CANCELAMENTO-2
            FROM SEGUROS.CALENDARIO
            WHERE DATA_CALENDARIO = :SISTEMAS-DATA-MOV-ABERTO
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT (DATA_CALENDARIO + {this.WS_QT_DIAS_CANC} DAYS)
											FROM SEGUROS.CALENDARIO
											WHERE DATA_CALENDARIO = '{this.SISTEMAS_DATA_MOV_ABERTO}'
											WITH UR";

            return query;
        }
        public string WS_DT_CANCELAMENTO_2 { get; set; }
        public string SISTEMAS_DATA_MOV_ABERTO { get; set; }
        public string WS_QT_DIAS_CANC { get; set; }

        public static P2113_00_CALCULA_VALORES_DB_SELECT_6_Query1 Execute(P2113_00_CALCULA_VALORES_DB_SELECT_6_Query1 p2113_00_CALCULA_VALORES_DB_SELECT_6_Query1)
        {
            var ths = p2113_00_CALCULA_VALORES_DB_SELECT_6_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override P2113_00_CALCULA_VALORES_DB_SELECT_6_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new P2113_00_CALCULA_VALORES_DB_SELECT_6_Query1();
            var i = 0;
            dta.WS_DT_CANCELAMENTO_2 = result[i++].Value?.ToString();
            return dta;
        }

    }
}