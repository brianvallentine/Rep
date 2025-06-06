using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE2640B
{
    public class DB036_ACESSA_RCAPS_COMPLEMENT_DB_SELECT_1_Query1 : QueryBasis<DB036_ACESSA_RCAPS_COMPLEMENT_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_RCAP,
            VAL_RCAP
            INTO :RCAPCOMP-DATA-RCAP,
            :RCAPCOMP-VAL-RCAP
            FROM SEGUROS.RCAP_COMPLEMENTAR
            WHERE COD_FONTE = :RCAPS-COD-FONTE
            AND NUM_RCAP = :RCAPS-NUM-RCAP
            AND COD_OPERACAO BETWEEN 100 AND 199
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT DATA_RCAP
							,
											VAL_RCAP
											FROM SEGUROS.RCAP_COMPLEMENTAR
											WHERE COD_FONTE = '{this.RCAPS_COD_FONTE}'
											AND NUM_RCAP = '{this.RCAPS_NUM_RCAP}'
											AND COD_OPERACAO BETWEEN 100 AND 199";

            return query;
        }
        public string RCAPCOMP_DATA_RCAP { get; set; }
        public string RCAPCOMP_VAL_RCAP { get; set; }
        public string RCAPS_COD_FONTE { get; set; }
        public string RCAPS_NUM_RCAP { get; set; }

        public static DB036_ACESSA_RCAPS_COMPLEMENT_DB_SELECT_1_Query1 Execute(DB036_ACESSA_RCAPS_COMPLEMENT_DB_SELECT_1_Query1 dB036_ACESSA_RCAPS_COMPLEMENT_DB_SELECT_1_Query1)
        {
            var ths = dB036_ACESSA_RCAPS_COMPLEMENT_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override DB036_ACESSA_RCAPS_COMPLEMENT_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new DB036_ACESSA_RCAPS_COMPLEMENT_DB_SELECT_1_Query1();
            var i = 0;
            dta.RCAPCOMP_DATA_RCAP = result[i++].Value?.ToString();
            dta.RCAPCOMP_VAL_RCAP = result[i++].Value?.ToString();
            return dta;
        }

    }
}