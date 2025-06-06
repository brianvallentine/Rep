using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI6032B
{
    public class R0020_00_LE_V0PARAM_CONTA_DB_SELECT_1_Query1 : QueryBasis<R0020_00_LE_V0PARAM_CONTA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT CODPRODU,
            COD_CONVENIO,
            NSAS,
            DIA_DEBITO
            INTO :V0PARAMC-CODPRODU,
            :V0PARAMC-COD-CONVENIO,
            :V0PARAMC-NSAS,
            :V0PARAMC-DIA-DEBITO
            FROM SEGUROS.V0PARAM_CONTACEF
            WHERE TIPO_MOVTOCC = :V0PARAMC-TIPO-MOVTOCC
            AND SITUACAO = :V0PARAMC-SITUACAO
            AND COD_CONVENIO = 6114
            AND CODPRODU = 7106
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT CODPRODU
							,
											COD_CONVENIO
							,
											NSAS
							,
											DIA_DEBITO
											FROM SEGUROS.V0PARAM_CONTACEF
											WHERE TIPO_MOVTOCC = '{this.V0PARAMC_TIPO_MOVTOCC}'
											AND SITUACAO = '{this.V0PARAMC_SITUACAO}'
											AND COD_CONVENIO = 6114
											AND CODPRODU = 7106";

            return query;
        }
        public string V0PARAMC_CODPRODU { get; set; }
        public string V0PARAMC_COD_CONVENIO { get; set; }
        public string V0PARAMC_NSAS { get; set; }
        public string V0PARAMC_DIA_DEBITO { get; set; }
        public string V0PARAMC_TIPO_MOVTOCC { get; set; }
        public string V0PARAMC_SITUACAO { get; set; }

        public static R0020_00_LE_V0PARAM_CONTA_DB_SELECT_1_Query1 Execute(R0020_00_LE_V0PARAM_CONTA_DB_SELECT_1_Query1 r0020_00_LE_V0PARAM_CONTA_DB_SELECT_1_Query1)
        {
            var ths = r0020_00_LE_V0PARAM_CONTA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0020_00_LE_V0PARAM_CONTA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0020_00_LE_V0PARAM_CONTA_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0PARAMC_CODPRODU = result[i++].Value?.ToString();
            dta.V0PARAMC_COD_CONVENIO = result[i++].Value?.ToString();
            dta.V0PARAMC_NSAS = result[i++].Value?.ToString();
            dta.V0PARAMC_DIA_DEBITO = result[i++].Value?.ToString();
            return dta;
        }

    }
}