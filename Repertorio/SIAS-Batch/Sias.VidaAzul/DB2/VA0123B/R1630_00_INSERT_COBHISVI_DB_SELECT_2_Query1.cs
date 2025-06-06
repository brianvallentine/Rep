using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0123B
{
    public class R1630_00_INSERT_COBHISVI_DB_SELECT_2_Query1 : QueryBasis<R1630_00_INSERT_COBHISVI_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_TITULO
            INTO :BANCOS-NUM-TITULO
            FROM SEGUROS.BANCOS
            WHERE COD_BANCO = 104
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT NUM_TITULO
											FROM SEGUROS.BANCOS
											WHERE COD_BANCO = 104
											WITH UR";

            return query;
        }
        public string BANCOS_NUM_TITULO { get; set; }

        public static R1630_00_INSERT_COBHISVI_DB_SELECT_2_Query1 Execute(R1630_00_INSERT_COBHISVI_DB_SELECT_2_Query1 r1630_00_INSERT_COBHISVI_DB_SELECT_2_Query1)
        {
            var ths = r1630_00_INSERT_COBHISVI_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1630_00_INSERT_COBHISVI_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1630_00_INSERT_COBHISVI_DB_SELECT_2_Query1();
            var i = 0;
            dta.BANCOS_NUM_TITULO = result[i++].Value?.ToString();
            return dta;
        }

    }
}