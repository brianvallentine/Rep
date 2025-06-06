using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI5166B
{
    public class R0230_00_SELECT_RCAPS_DB_SELECT_1_Query1 : QueryBasis<R0230_00_SELECT_RCAPS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_CADASTRAMENTO
            INTO :RCAPS-DATA-CADASTRAMENTO
            FROM SEGUROS.RCAPS
            WHERE NUM_TITULO = :BILHETE-NUM-BILHETE
            AND SIT_REGISTRO = '0'
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_CADASTRAMENTO
											FROM SEGUROS.RCAPS
											WHERE NUM_TITULO = '{this.BILHETE_NUM_BILHETE}'
											AND SIT_REGISTRO = '0'
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string RCAPS_DATA_CADASTRAMENTO { get; set; }
        public string BILHETE_NUM_BILHETE { get; set; }

        public static R0230_00_SELECT_RCAPS_DB_SELECT_1_Query1 Execute(R0230_00_SELECT_RCAPS_DB_SELECT_1_Query1 r0230_00_SELECT_RCAPS_DB_SELECT_1_Query1)
        {
            var ths = r0230_00_SELECT_RCAPS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0230_00_SELECT_RCAPS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0230_00_SELECT_RCAPS_DB_SELECT_1_Query1();
            var i = 0;
            dta.RCAPS_DATA_CADASTRAMENTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}