using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0124B
{
    public class R3100_00_VERIFICA_FATURAMENTO_DB_SELECT_1_Query1 : QueryBasis<R3100_00_VERIFICA_FATURAMENTO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COUNT(*)
            INTO :WS-CONTA-CONTABIL
            FROM SEGUROS.HIST_CONT_PARCELVA
            WHERE NUM_CERTIFICADO = :HISCONPA-NUM-CERTIFICADO
            AND NUM_PARCELA = :HISCONPA-NUM-PARCELA
            AND OCORR_HISTORICO = :HISCONPA-OCORR-HISTORICO
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT COUNT(*)
											FROM SEGUROS.HIST_CONT_PARCELVA
											WHERE NUM_CERTIFICADO = '{this.HISCONPA_NUM_CERTIFICADO}'
											AND NUM_PARCELA = '{this.HISCONPA_NUM_PARCELA}'
											AND OCORR_HISTORICO = '{this.HISCONPA_OCORR_HISTORICO}'";

            return query;
        }
        public string WS_CONTA_CONTABIL { get; set; }
        public string HISCONPA_NUM_CERTIFICADO { get; set; }
        public string HISCONPA_OCORR_HISTORICO { get; set; }
        public string HISCONPA_NUM_PARCELA { get; set; }

        public static R3100_00_VERIFICA_FATURAMENTO_DB_SELECT_1_Query1 Execute(R3100_00_VERIFICA_FATURAMENTO_DB_SELECT_1_Query1 r3100_00_VERIFICA_FATURAMENTO_DB_SELECT_1_Query1)
        {
            var ths = r3100_00_VERIFICA_FATURAMENTO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3100_00_VERIFICA_FATURAMENTO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3100_00_VERIFICA_FATURAMENTO_DB_SELECT_1_Query1();
            var i = 0;
            dta.WS_CONTA_CONTABIL = result[i++].Value?.ToString();
            return dta;
        }

    }
}