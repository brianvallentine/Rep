using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI9102B
{
    public class R1600_00_LE_FONTES_DB_SELECT_1_Query1 : QueryBasis<R1600_00_LE_FONTES_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT SIT_REGISTRO
            INTO :FONTES-SIT-REGISTRO
            FROM SEGUROS.FONTES
            WHERE COD_FONTE = :SIARDEVC-COD-FONTE
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT SIT_REGISTRO
											FROM SEGUROS.FONTES
											WHERE COD_FONTE = '{this.SIARDEVC_COD_FONTE}'
											WITH UR";

            return query;
        }
        public string FONTES_SIT_REGISTRO { get; set; }
        public string SIARDEVC_COD_FONTE { get; set; }

        public static R1600_00_LE_FONTES_DB_SELECT_1_Query1 Execute(R1600_00_LE_FONTES_DB_SELECT_1_Query1 r1600_00_LE_FONTES_DB_SELECT_1_Query1)
        {
            var ths = r1600_00_LE_FONTES_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1600_00_LE_FONTES_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1600_00_LE_FONTES_DB_SELECT_1_Query1();
            var i = 0;
            dta.FONTES_SIT_REGISTRO = result[i++].Value?.ToString();
            return dta;
        }

    }
}