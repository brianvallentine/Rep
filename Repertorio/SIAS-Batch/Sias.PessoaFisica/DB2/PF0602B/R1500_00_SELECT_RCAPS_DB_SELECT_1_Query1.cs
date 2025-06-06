using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0602B
{
    public class R1500_00_SELECT_RCAPS_DB_SELECT_1_Query1 : QueryBasis<R1500_00_SELECT_RCAPS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VAL_RCAP
            INTO :DCLRCAPS.RCAPS-VAL-RCAP
            FROM SEGUROS.RCAPS
            WHERE NUM_TITULO =:DCLRCAPS.RCAPS-NUM-TITULO
            AND COD_FONTE =:DCLRCAPS.RCAPS-COD-FONTE
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VAL_RCAP
											FROM SEGUROS.RCAPS
											WHERE NUM_TITULO ='{this.RCAPS_NUM_TITULO}'
											AND COD_FONTE ='{this.RCAPS_COD_FONTE}'
											WITH UR";

            return query;
        }
        public string RCAPS_VAL_RCAP { get; set; }
        public string RCAPS_NUM_TITULO { get; set; }
        public string RCAPS_COD_FONTE { get; set; }

        public static R1500_00_SELECT_RCAPS_DB_SELECT_1_Query1 Execute(R1500_00_SELECT_RCAPS_DB_SELECT_1_Query1 r1500_00_SELECT_RCAPS_DB_SELECT_1_Query1)
        {
            var ths = r1500_00_SELECT_RCAPS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1500_00_SELECT_RCAPS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1500_00_SELECT_RCAPS_DB_SELECT_1_Query1();
            var i = 0;
            dta.RCAPS_VAL_RCAP = result[i++].Value?.ToString();
            return dta;
        }

    }
}