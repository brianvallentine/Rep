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
    public class R31140_PROC_SICOV_DB_SELECT_1_Query1 : QueryBasis<R31140_PROC_SICOV_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            VALUE(NUM_CARTAO,1)
            INTO
            :MOVDEBCE-NUM-CARTAO
            FROM SEGUROS.MOVTO_DEBITOCC_CEF
            WHERE NUM_APOLICE = :MOVDEBCE-NUM-APOLICE
            AND NUM_PARCELA = :MOVDEBCE-NUM-PARCELA
            AND TIMESTAMP =
            (SELECT MAX(TIMESTAMP)
            FROM SEGUROS.MOVTO_DEBITOCC_CEF D
            WHERE D.NUM_APOLICE = :MOVDEBCE-NUM-APOLICE
            AND D.NUM_PARCELA = :MOVDEBCE-NUM-PARCELA
            AND (NUM_CARTAO <> 0 OR NUM_CARTAO IS NULL))
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											VALUE(NUM_CARTAO
							,1)
											FROM SEGUROS.MOVTO_DEBITOCC_CEF
											WHERE NUM_APOLICE = '{this.MOVDEBCE_NUM_APOLICE}'
											AND NUM_PARCELA = '{this.MOVDEBCE_NUM_PARCELA}'
											AND TIMESTAMP =
											(SELECT MAX(TIMESTAMP)
											FROM SEGUROS.MOVTO_DEBITOCC_CEF D
											WHERE D.NUM_APOLICE = '{this.MOVDEBCE_NUM_APOLICE}'
											AND D.NUM_PARCELA = '{this.MOVDEBCE_NUM_PARCELA}'
											AND (NUM_CARTAO <> 0 OR NUM_CARTAO IS NULL))
											WITH UR";

            return query;
        }
        public string MOVDEBCE_NUM_CARTAO { get; set; }
        public string MOVDEBCE_NUM_APOLICE { get; set; }
        public string MOVDEBCE_NUM_PARCELA { get; set; }

        public static R31140_PROC_SICOV_DB_SELECT_1_Query1 Execute(R31140_PROC_SICOV_DB_SELECT_1_Query1 r31140_PROC_SICOV_DB_SELECT_1_Query1)
        {
            var ths = r31140_PROC_SICOV_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R31140_PROC_SICOV_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R31140_PROC_SICOV_DB_SELECT_1_Query1();
            var i = 0;
            dta.MOVDEBCE_NUM_CARTAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}