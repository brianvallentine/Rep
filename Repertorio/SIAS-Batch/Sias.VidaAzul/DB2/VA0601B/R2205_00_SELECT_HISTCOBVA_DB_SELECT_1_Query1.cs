using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0601B
{
    public class R2205_00_SELECT_HISTCOBVA_DB_SELECT_1_Query1 : QueryBasis<R2205_00_SELECT_HISTCOBVA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_TITULO
            INTO :DCLCOBER-HIST-VIDAZUL.NUM-TITULO
            FROM SEGUROS.COBER_HIST_VIDAZUL
            WHERE NUM_TITULO =
            :DCLCOBER-HIST-VIDAZUL.NUM-TITULO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_TITULO
											FROM SEGUROS.COBER_HIST_VIDAZUL
											WHERE NUM_TITULO =
											'{this.NUM_TITULO}'";

            return query;
        }
        public string NUM_TITULO { get; set; }

        public static R2205_00_SELECT_HISTCOBVA_DB_SELECT_1_Query1 Execute(R2205_00_SELECT_HISTCOBVA_DB_SELECT_1_Query1 r2205_00_SELECT_HISTCOBVA_DB_SELECT_1_Query1)
        {
            var ths = r2205_00_SELECT_HISTCOBVA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2205_00_SELECT_HISTCOBVA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2205_00_SELECT_HISTCOBVA_DB_SELECT_1_Query1();
            var i = 0;
            dta.NUM_TITULO = result[i++].Value?.ToString();
            return dta;
        }

    }
}