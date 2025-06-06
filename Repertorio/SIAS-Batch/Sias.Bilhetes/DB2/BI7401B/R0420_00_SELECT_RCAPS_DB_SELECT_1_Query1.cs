using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI7401B
{
    public class R0420_00_SELECT_RCAPS_DB_SELECT_1_Query1 : QueryBasis<R0420_00_SELECT_RCAPS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_RCAP
            ,COD_OPERACAO
            INTO :RCAPCOMP-NUM-RCAP
            ,:RCAPS-COD-OPERACAO
            FROM SEGUROS.RCAPS
            WHERE NUM_TITULO = :BILHETE-NUM-BILHETE
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_RCAP
											,COD_OPERACAO
											FROM SEGUROS.RCAPS
											WHERE NUM_TITULO = '{this.BILHETE_NUM_BILHETE}'
											WITH UR";

            return query;
        }
        public string RCAPCOMP_NUM_RCAP { get; set; }
        public string RCAPS_COD_OPERACAO { get; set; }
        public string BILHETE_NUM_BILHETE { get; set; }

        public static R0420_00_SELECT_RCAPS_DB_SELECT_1_Query1 Execute(R0420_00_SELECT_RCAPS_DB_SELECT_1_Query1 r0420_00_SELECT_RCAPS_DB_SELECT_1_Query1)
        {
            var ths = r0420_00_SELECT_RCAPS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0420_00_SELECT_RCAPS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0420_00_SELECT_RCAPS_DB_SELECT_1_Query1();
            var i = 0;
            dta.RCAPCOMP_NUM_RCAP = result[i++].Value?.ToString();
            dta.RCAPS_COD_OPERACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}