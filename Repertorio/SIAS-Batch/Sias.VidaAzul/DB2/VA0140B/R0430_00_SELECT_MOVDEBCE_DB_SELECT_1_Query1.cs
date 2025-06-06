using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0140B
{
    public class R0430_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1 : QueryBasis<R0430_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT SITUACAO_COBRANCA
            ,VALOR_DEBITO
            ,COD_CONVENIO
            ,VLR_CREDITO
            INTO :MOVDEBCE-SITUACAO-COBRANCA
            ,:MOVDEBCE-VALOR-DEBITO
            ,:MOVDEBCE-COD-CONVENIO
            ,:MOVDEBCE-VLR-CREDITO:VIND-NULL01
            FROM SEGUROS.MOVTO_DEBITOCC_CEF
            WHERE NUM_CARTAO = :HISCONPA-NUM-CERTIFICADO
            AND NUM_PARCELA = :HISCONPA-NUM-PARCELA
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT SITUACAO_COBRANCA
											,VALOR_DEBITO
											,COD_CONVENIO
											,VLR_CREDITO
											FROM SEGUROS.MOVTO_DEBITOCC_CEF
											WHERE NUM_CARTAO = '{this.HISCONPA_NUM_CERTIFICADO}'
											AND NUM_PARCELA = '{this.HISCONPA_NUM_PARCELA}'
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string MOVDEBCE_SITUACAO_COBRANCA { get; set; }
        public string MOVDEBCE_VALOR_DEBITO { get; set; }
        public string MOVDEBCE_COD_CONVENIO { get; set; }
        public string MOVDEBCE_VLR_CREDITO { get; set; }
        public string VIND_NULL01 { get; set; }
        public string HISCONPA_NUM_CERTIFICADO { get; set; }
        public string HISCONPA_NUM_PARCELA { get; set; }

        public static R0430_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1 Execute(R0430_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1 r0430_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1)
        {
            var ths = r0430_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0430_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0430_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1();
            var i = 0;
            dta.MOVDEBCE_SITUACAO_COBRANCA = result[i++].Value?.ToString();
            dta.MOVDEBCE_VALOR_DEBITO = result[i++].Value?.ToString();
            dta.MOVDEBCE_COD_CONVENIO = result[i++].Value?.ToString();
            dta.MOVDEBCE_VLR_CREDITO = result[i++].Value?.ToString();
            dta.VIND_NULL01 = string.IsNullOrWhiteSpace(dta.MOVDEBCE_VLR_CREDITO) ? "-1" : "0";
            return dta;
        }

    }
}