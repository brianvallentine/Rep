using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SICP001S
{
    public class R19300_SELECT_INSS_DB_SELECT_1_Query1 : QueryBasis<R19300_SELECT_INSS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_TP_SERVICO_INSS
            INTO :GE612-COD-TP-SERVICO-INSS
            FROM SIUS.GE_TP_SERVICO_INSS
            WHERE SEQ_TP_SERVICO_INSS =
            :GE612-SEQ-TP-SERVICO-INSS
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_TP_SERVICO_INSS
											FROM SIUS.GE_TP_SERVICO_INSS
											WHERE SEQ_TP_SERVICO_INSS =
											'{this.GE612_SEQ_TP_SERVICO_INSS}'";

            return query;
        }
        public string GE612_COD_TP_SERVICO_INSS { get; set; }
        public string GE612_SEQ_TP_SERVICO_INSS { get; set; }

        public static R19300_SELECT_INSS_DB_SELECT_1_Query1 Execute(R19300_SELECT_INSS_DB_SELECT_1_Query1 r19300_SELECT_INSS_DB_SELECT_1_Query1)
        {
            var ths = r19300_SELECT_INSS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R19300_SELECT_INSS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R19300_SELECT_INSS_DB_SELECT_1_Query1();
            var i = 0;
            dta.GE612_COD_TP_SERVICO_INSS = result[i++].Value?.ToString();
            return dta;
        }

    }
}