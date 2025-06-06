using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0213B
{
    public class R2700_00_LE_SINIHAB1_DB_SELECT_1_Query1 : QueryBasis<R2700_00_LE_SINIHAB1_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT OPERACAO,
            PONTO_VENDA,
            NUM_CONTRATO
            INTO :SINIHAB1-OPERACAO,
            :SINIHAB1-PONTO-VENDA,
            :SINIHAB1-NUM-CONTRATO
            FROM SEGUROS.SINISTRO_HABIT01
            WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT OPERACAO
							,
											PONTO_VENDA
							,
											NUM_CONTRATO
											FROM SEGUROS.SINISTRO_HABIT01
											WHERE NUM_APOL_SINISTRO = '{this.SINISHIS_NUM_APOL_SINISTRO}'";

            return query;
        }
        public string SINIHAB1_OPERACAO { get; set; }
        public string SINIHAB1_PONTO_VENDA { get; set; }
        public string SINIHAB1_NUM_CONTRATO { get; set; }
        public string SINISHIS_NUM_APOL_SINISTRO { get; set; }

        public static R2700_00_LE_SINIHAB1_DB_SELECT_1_Query1 Execute(R2700_00_LE_SINIHAB1_DB_SELECT_1_Query1 r2700_00_LE_SINIHAB1_DB_SELECT_1_Query1)
        {
            var ths = r2700_00_LE_SINIHAB1_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2700_00_LE_SINIHAB1_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2700_00_LE_SINIHAB1_DB_SELECT_1_Query1();
            var i = 0;
            dta.SINIHAB1_OPERACAO = result[i++].Value?.ToString();
            dta.SINIHAB1_PONTO_VENDA = result[i++].Value?.ToString();
            dta.SINIHAB1_NUM_CONTRATO = result[i++].Value?.ToString();
            return dta;
        }

    }
}