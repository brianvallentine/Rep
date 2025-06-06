using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI9211B
{
    public class R1210_00_LE_MOVDEBCE_DB_SELECT_1_Query1 : QueryBasis<R1210_00_LE_MOVDEBCE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_RETORNO_CEF ,
            DATA_VENCIMENTO
            INTO :MOVDEBCE-COD-RETORNO-CEF:IND-COD-RETORNO-CEF,
            :MOVDEBCE-DATA-VENCIMENTO
            FROM SEGUROS.MOVTO_DEBITOCC_CEF
            WHERE NUM_CARTAO = :SIARDEVC-NUM-CHEQUE-INTERNO
            AND NUM_APOLICE = :SIARDEVC-NUM-APOL-SINISTRO
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT COD_RETORNO_CEF 
							,
											DATA_VENCIMENTO
											FROM SEGUROS.MOVTO_DEBITOCC_CEF
											WHERE NUM_CARTAO = '{this.SIARDEVC_NUM_CHEQUE_INTERNO}'
											AND NUM_APOLICE = '{this.SIARDEVC_NUM_APOL_SINISTRO}'";

            return query;
        }
        public string MOVDEBCE_COD_RETORNO_CEF { get; set; }
        public string IND_COD_RETORNO_CEF { get; set; }
        public string MOVDEBCE_DATA_VENCIMENTO { get; set; }
        public string SIARDEVC_NUM_CHEQUE_INTERNO { get; set; }
        public string SIARDEVC_NUM_APOL_SINISTRO { get; set; }

        public static R1210_00_LE_MOVDEBCE_DB_SELECT_1_Query1 Execute(R1210_00_LE_MOVDEBCE_DB_SELECT_1_Query1 r1210_00_LE_MOVDEBCE_DB_SELECT_1_Query1)
        {
            var ths = r1210_00_LE_MOVDEBCE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1210_00_LE_MOVDEBCE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1210_00_LE_MOVDEBCE_DB_SELECT_1_Query1();
            var i = 0;
            dta.MOVDEBCE_COD_RETORNO_CEF = result[i++].Value?.ToString();
            dta.IND_COD_RETORNO_CEF = string.IsNullOrWhiteSpace(dta.MOVDEBCE_COD_RETORNO_CEF) ? "-1" : "0";
            dta.MOVDEBCE_DATA_VENCIMENTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}