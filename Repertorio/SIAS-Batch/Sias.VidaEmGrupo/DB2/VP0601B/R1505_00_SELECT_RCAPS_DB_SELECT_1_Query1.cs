using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP0601B
{
    public class R1505_00_SELECT_RCAPS_DB_SELECT_1_Query1 : QueryBasis<R1505_00_SELECT_RCAPS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_FONTE,
            NUM_RCAP,
            VAL_RCAP
            INTO :DCLRCAPS.RCAPS-COD-FONTE,
            :DCLRCAPS.RCAPS-NUM-RCAP,
            :DCLRCAPS.RCAPS-VAL-RCAP
            FROM SEGUROS.RCAPS
            WHERE NUM_TITULO =:DCLRCAPS.RCAPS-NUM-TITULO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_FONTE
							,
											NUM_RCAP
							,
											VAL_RCAP
											FROM SEGUROS.RCAPS
											WHERE NUM_TITULO ='{this.RCAPS_NUM_TITULO}'";

            return query;
        }
        public string RCAPS_COD_FONTE { get; set; }
        public string RCAPS_NUM_RCAP { get; set; }
        public string RCAPS_VAL_RCAP { get; set; }
        public string RCAPS_NUM_TITULO { get; set; }

        public static R1505_00_SELECT_RCAPS_DB_SELECT_1_Query1 Execute(R1505_00_SELECT_RCAPS_DB_SELECT_1_Query1 r1505_00_SELECT_RCAPS_DB_SELECT_1_Query1)
        {
            var ths = r1505_00_SELECT_RCAPS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1505_00_SELECT_RCAPS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1505_00_SELECT_RCAPS_DB_SELECT_1_Query1();
            var i = 0;
            dta.RCAPS_COD_FONTE = result[i++].Value?.ToString();
            dta.RCAPS_NUM_RCAP = result[i++].Value?.ToString();
            dta.RCAPS_VAL_RCAP = result[i++].Value?.ToString();
            return dta;
        }

    }
}