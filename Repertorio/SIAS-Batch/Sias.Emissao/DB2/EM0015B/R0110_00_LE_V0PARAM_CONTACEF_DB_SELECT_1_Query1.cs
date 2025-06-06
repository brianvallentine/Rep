using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0015B
{
    public class R0110_00_LE_V0PARAM_CONTACEF_DB_SELECT_1_Query1 : QueryBasis<R0110_00_LE_V0PARAM_CONTACEF_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_CONVENIO
            INTO :V0PARAMC-COD-CONVENIO
            FROM SEGUROS.V0PARAM_CONTACEF
            WHERE CODPRODU = :V0PARAMC-CODPRODU
            AND TIPO_MOVTOCC = :V0PARAMC-TIPO-MOVTOCC
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_CONVENIO
											FROM SEGUROS.V0PARAM_CONTACEF
											WHERE CODPRODU = '{this.V0PARAMC_CODPRODU}'
											AND TIPO_MOVTOCC = '{this.V0PARAMC_TIPO_MOVTOCC}'";

            return query;
        }
        public string V0PARAMC_COD_CONVENIO { get; set; }
        public string V0PARAMC_TIPO_MOVTOCC { get; set; }
        public string V0PARAMC_CODPRODU { get; set; }

        public static R0110_00_LE_V0PARAM_CONTACEF_DB_SELECT_1_Query1 Execute(R0110_00_LE_V0PARAM_CONTACEF_DB_SELECT_1_Query1 r0110_00_LE_V0PARAM_CONTACEF_DB_SELECT_1_Query1)
        {
            var ths = r0110_00_LE_V0PARAM_CONTACEF_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0110_00_LE_V0PARAM_CONTACEF_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0110_00_LE_V0PARAM_CONTACEF_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0PARAMC_COD_CONVENIO = result[i++].Value?.ToString();
            return dta;
        }

    }
}