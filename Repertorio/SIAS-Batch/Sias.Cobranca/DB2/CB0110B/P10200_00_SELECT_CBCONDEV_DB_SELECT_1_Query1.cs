using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0110B
{
    public class P10200_00_SELECT_CBCONDEV_DB_SELECT_1_Query1 : QueryBasis<P10200_00_SELECT_CBCONDEV_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE ( MAX ( NUM_SEQUENCIA ) , 0 )
            INTO :CBCONDEV-NUM-SEQUENCIA
            FROM SEGUROS.CB_CONTR_DEVPREMIO
            WHERE DATA_MOVIMENTO = :SISTEMAS-DATA-MOV-ABERTO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE ( MAX ( NUM_SEQUENCIA ) 
							, 0 )
											FROM SEGUROS.CB_CONTR_DEVPREMIO
											WHERE DATA_MOVIMENTO = '{this.SISTEMAS_DATA_MOV_ABERTO}'
											WITH UR";

            return query;
        }
        public string CBCONDEV_NUM_SEQUENCIA { get; set; }
        public string SISTEMAS_DATA_MOV_ABERTO { get; set; }

        public static P10200_00_SELECT_CBCONDEV_DB_SELECT_1_Query1 Execute(P10200_00_SELECT_CBCONDEV_DB_SELECT_1_Query1 p10200_00_SELECT_CBCONDEV_DB_SELECT_1_Query1)
        {
            var ths = p10200_00_SELECT_CBCONDEV_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override P10200_00_SELECT_CBCONDEV_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new P10200_00_SELECT_CBCONDEV_DB_SELECT_1_Query1();
            var i = 0;
            dta.CBCONDEV_NUM_SEQUENCIA = result[i++].Value?.ToString();
            return dta;
        }

    }
}