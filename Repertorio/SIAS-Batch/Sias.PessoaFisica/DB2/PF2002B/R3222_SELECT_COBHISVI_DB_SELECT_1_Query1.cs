using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF2002B
{
    public class R3222_SELECT_COBHISVI_DB_SELECT_1_Query1 : QueryBasis<R3222_SELECT_COBHISVI_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_TITULO
            INTO :COBHISVI-NUM-TITULO
            FROM SEGUROS.COBER_HIST_VIDAZUL
            WHERE NUM_TITULO = :V0MCOB-NRTIT
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_TITULO
											FROM SEGUROS.COBER_HIST_VIDAZUL
											WHERE NUM_TITULO = '{this.V0MCOB_NRTIT}'
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string COBHISVI_NUM_TITULO { get; set; }
        public string V0MCOB_NRTIT { get; set; }

        public static R3222_SELECT_COBHISVI_DB_SELECT_1_Query1 Execute(R3222_SELECT_COBHISVI_DB_SELECT_1_Query1 r3222_SELECT_COBHISVI_DB_SELECT_1_Query1)
        {
            var ths = r3222_SELECT_COBHISVI_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3222_SELECT_COBHISVI_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3222_SELECT_COBHISVI_DB_SELECT_1_Query1();
            var i = 0;
            dta.COBHISVI_NUM_TITULO = result[i++].Value?.ToString();
            return dta;
        }

    }
}