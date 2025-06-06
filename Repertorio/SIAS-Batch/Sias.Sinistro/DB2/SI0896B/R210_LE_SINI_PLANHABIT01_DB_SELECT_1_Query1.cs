using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0896B
{
    public class R210_LE_SINI_PLANHABIT01_DB_SELECT_1_Query1 : QueryBasis<R210_LE_SINI_PLANHABIT01_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(VAL_SALDO_DEVEDOR,0),
            VALUE(VAL_ACORRIGIR,0),
            VALUE(VAL_PREMIO,0),
            PERC_PARTICIPACAO
            INTO :SINIPLAN-VAL-SALDO-DEVEDOR,
            :SINIPLAN-VAL-ACORRIGIR,
            :SINIPLAN-VAL-PREMIO,
            :SINIPLAN-PERC-PARTICIPACAO
            FROM SEGUROS.SINI_PLANHABIT01
            WHERE NUM_APOL_SINISTRO = :SINIPLAN-NUM-APOL-SINISTRO
            AND OCORHIST = :SINIPLAN-OCORHIST
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(VAL_SALDO_DEVEDOR
							,0)
							,
											VALUE(VAL_ACORRIGIR
							,0)
							,
											VALUE(VAL_PREMIO
							,0)
							,
											PERC_PARTICIPACAO
											FROM SEGUROS.SINI_PLANHABIT01
											WHERE NUM_APOL_SINISTRO = '{this.SINIPLAN_NUM_APOL_SINISTRO}'
											AND OCORHIST = '{this.SINIPLAN_OCORHIST}'";

            return query;
        }
        public string SINIPLAN_VAL_SALDO_DEVEDOR { get; set; }
        public string SINIPLAN_VAL_ACORRIGIR { get; set; }
        public string SINIPLAN_VAL_PREMIO { get; set; }
        public string SINIPLAN_PERC_PARTICIPACAO { get; set; }
        public string SINIPLAN_NUM_APOL_SINISTRO { get; set; }
        public string SINIPLAN_OCORHIST { get; set; }

        public static R210_LE_SINI_PLANHABIT01_DB_SELECT_1_Query1 Execute(R210_LE_SINI_PLANHABIT01_DB_SELECT_1_Query1 r210_LE_SINI_PLANHABIT01_DB_SELECT_1_Query1)
        {
            var ths = r210_LE_SINI_PLANHABIT01_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R210_LE_SINI_PLANHABIT01_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R210_LE_SINI_PLANHABIT01_DB_SELECT_1_Query1();
            var i = 0;
            dta.SINIPLAN_VAL_SALDO_DEVEDOR = result[i++].Value?.ToString();
            dta.SINIPLAN_VAL_ACORRIGIR = result[i++].Value?.ToString();
            dta.SINIPLAN_VAL_PREMIO = result[i++].Value?.ToString();
            dta.SINIPLAN_PERC_PARTICIPACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}