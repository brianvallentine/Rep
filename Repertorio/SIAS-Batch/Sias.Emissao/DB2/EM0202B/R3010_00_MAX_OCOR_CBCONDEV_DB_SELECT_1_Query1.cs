using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0202B
{
    public class R3010_00_MAX_OCOR_CBCONDEV_DB_SELECT_1_Query1 : QueryBasis<R3010_00_MAX_OCOR_CBCONDEV_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE ( MAX ( NUM_SEQUENCIA ) , 0 )
            INTO :CBCONDEV-NUM-SEQUENCIA
            FROM SEGUROS.CB_CONTR_DEVPREMIO
            WHERE DATA_MOVIMENTO = :V1SIST-DTMOVABE
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE ( MAX ( NUM_SEQUENCIA ) 
							, 0 )
											FROM SEGUROS.CB_CONTR_DEVPREMIO
											WHERE DATA_MOVIMENTO = '{this.V1SIST_DTMOVABE}'
											WITH UR";

            return query;
        }
        public string CBCONDEV_NUM_SEQUENCIA { get; set; }
        public string V1SIST_DTMOVABE { get; set; }

        public static R3010_00_MAX_OCOR_CBCONDEV_DB_SELECT_1_Query1 Execute(R3010_00_MAX_OCOR_CBCONDEV_DB_SELECT_1_Query1 r3010_00_MAX_OCOR_CBCONDEV_DB_SELECT_1_Query1)
        {
            var ths = r3010_00_MAX_OCOR_CBCONDEV_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3010_00_MAX_OCOR_CBCONDEV_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3010_00_MAX_OCOR_CBCONDEV_DB_SELECT_1_Query1();
            var i = 0;
            dta.CBCONDEV_NUM_SEQUENCIA = result[i++].Value?.ToString();
            return dta;
        }

    }
}