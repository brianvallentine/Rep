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
    public class R2250_00_SELECT_RCAPS_DB_SELECT_1_Query1 : QueryBasis<R2250_00_SELECT_RCAPS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT SIT_REGISTRO
            ,COD_OPERACAO
            INTO :RCAPS-SIT-REGISTRO
            ,:RCAPS-COD-OPERACAO
            FROM SEGUROS.RCAPS
            WHERE COD_FONTE = :RCAPCOMP-COD-FONTE
            AND NUM_RCAP = :RCAPCOMP-NUM-RCAP
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT SIT_REGISTRO
											,COD_OPERACAO
											FROM SEGUROS.RCAPS
											WHERE COD_FONTE = '{this.RCAPCOMP_COD_FONTE}'
											AND NUM_RCAP = '{this.RCAPCOMP_NUM_RCAP}'
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string RCAPS_SIT_REGISTRO { get; set; }
        public string RCAPS_COD_OPERACAO { get; set; }
        public string RCAPCOMP_COD_FONTE { get; set; }
        public string RCAPCOMP_NUM_RCAP { get; set; }

        public static R2250_00_SELECT_RCAPS_DB_SELECT_1_Query1 Execute(R2250_00_SELECT_RCAPS_DB_SELECT_1_Query1 r2250_00_SELECT_RCAPS_DB_SELECT_1_Query1)
        {
            var ths = r2250_00_SELECT_RCAPS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2250_00_SELECT_RCAPS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2250_00_SELECT_RCAPS_DB_SELECT_1_Query1();
            var i = 0;
            dta.RCAPS_SIT_REGISTRO = result[i++].Value?.ToString();
            dta.RCAPS_COD_OPERACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}