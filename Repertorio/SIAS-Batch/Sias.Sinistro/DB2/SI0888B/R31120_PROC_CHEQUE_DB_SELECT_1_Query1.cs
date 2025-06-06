using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0888B
{
    public class R31120_PROC_CHEQUE_DB_SELECT_1_Query1 : QueryBasis<R31120_PROC_CHEQUE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            NUM_CHEQUE_INTERNO
            INTO
            :SISINCHE-NUM-CHEQUE-INTERNO:NL-NUM-CHEQUE-INTERNO
            FROM SEGUROS.SI_SINI_CHEQUE
            WHERE NUM_APOL_SINISTRO = :SISINCHE-NUM-APOL-SINISTRO
            AND COD_OPERACAO = :SISINCHE-COD-OPERACAO
            AND OCORR_HISTORICO = :SISINCHE-OCORR-HISTORICO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											NUM_CHEQUE_INTERNO
											FROM SEGUROS.SI_SINI_CHEQUE
											WHERE NUM_APOL_SINISTRO = '{this.SISINCHE_NUM_APOL_SINISTRO}'
											AND COD_OPERACAO = '{this.SISINCHE_COD_OPERACAO}'
											AND OCORR_HISTORICO = '{this.SISINCHE_OCORR_HISTORICO}'";

            return query;
        }
        public string SISINCHE_NUM_CHEQUE_INTERNO { get; set; }
        public string NL_NUM_CHEQUE_INTERNO { get; set; }
        public string SISINCHE_NUM_APOL_SINISTRO { get; set; }
        public string SISINCHE_OCORR_HISTORICO { get; set; }
        public string SISINCHE_COD_OPERACAO { get; set; }

        public static R31120_PROC_CHEQUE_DB_SELECT_1_Query1 Execute(R31120_PROC_CHEQUE_DB_SELECT_1_Query1 r31120_PROC_CHEQUE_DB_SELECT_1_Query1)
        {
            var ths = r31120_PROC_CHEQUE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R31120_PROC_CHEQUE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R31120_PROC_CHEQUE_DB_SELECT_1_Query1();
            var i = 0;
            dta.SISINCHE_NUM_CHEQUE_INTERNO = result[i++].Value?.ToString();
            dta.NL_NUM_CHEQUE_INTERNO = string.IsNullOrWhiteSpace(dta.SISINCHE_NUM_CHEQUE_INTERNO) ? "-1" : "0";
            return dta;
        }

    }
}