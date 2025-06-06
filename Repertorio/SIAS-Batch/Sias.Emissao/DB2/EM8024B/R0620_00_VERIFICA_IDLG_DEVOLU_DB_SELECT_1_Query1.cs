using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM8024B
{
    public class R0620_00_VERIFICA_IDLG_DEVOLU_DB_SELECT_1_Query1 : QueryBasis<R0620_00_VERIFICA_IDLG_DEVOLU_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_APOLICE
            , NUM_ENDOSSO
            , NUM_PARCELA
            , DATA_VENCIMENTO
            , VALOR_DEBITO
            , DTCREDITO
            , VALUE(NUM_REQUISICAO,0)
            INTO :MOVDEBCE-NUM-APOLICE
            , :MOVDEBCE-NUM-ENDOSSO
            , :MOVDEBCE-NUM-PARCELA
            , :MOVDEBCE-DATA-VENCIMENTO
            , :MOVDEBCE-VALOR-DEBITO
            , :MOVDEBCE-DTCREDITO:VIND-DTCREDITO
            , :MOVDEBCE-NUM-REQUISICAO
            FROM SEGUROS.MOVTO_DEBITOCC_CEF
            WHERE COD_CONVENIO = :MOVDEBCE-COD-CONVENIO
            AND NSAS = :MOVDEBCE-NSAS
            AND NUM_ENDOSSO = :MOVDEBCE-NUM-ENDOSSO
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT NUM_APOLICE
											, NUM_ENDOSSO
											, NUM_PARCELA
											, DATA_VENCIMENTO
											, VALOR_DEBITO
											, DTCREDITO
											, VALUE(NUM_REQUISICAO
							,0)
											FROM SEGUROS.MOVTO_DEBITOCC_CEF
											WHERE COD_CONVENIO = '{this.MOVDEBCE_COD_CONVENIO}'
											AND NSAS = '{this.MOVDEBCE_NSAS}'
											AND NUM_ENDOSSO = '{this.MOVDEBCE_NUM_ENDOSSO}'
											WITH UR";

            return query;
        }
        public string MOVDEBCE_NUM_APOLICE { get; set; }
        public string MOVDEBCE_NUM_ENDOSSO { get; set; }
        public string MOVDEBCE_NUM_PARCELA { get; set; }
        public string MOVDEBCE_DATA_VENCIMENTO { get; set; }
        public string MOVDEBCE_VALOR_DEBITO { get; set; }
        public string MOVDEBCE_DTCREDITO { get; set; }
        public string VIND_DTCREDITO { get; set; }
        public string MOVDEBCE_NUM_REQUISICAO { get; set; }
        public string MOVDEBCE_COD_CONVENIO { get; set; }
        public string MOVDEBCE_NSAS { get; set; }

        public static R0620_00_VERIFICA_IDLG_DEVOLU_DB_SELECT_1_Query1 Execute(R0620_00_VERIFICA_IDLG_DEVOLU_DB_SELECT_1_Query1 r0620_00_VERIFICA_IDLG_DEVOLU_DB_SELECT_1_Query1)
        {
            var ths = r0620_00_VERIFICA_IDLG_DEVOLU_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0620_00_VERIFICA_IDLG_DEVOLU_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0620_00_VERIFICA_IDLG_DEVOLU_DB_SELECT_1_Query1();
            var i = 0;
            dta.MOVDEBCE_NUM_APOLICE = result[i++].Value?.ToString();
            dta.MOVDEBCE_NUM_ENDOSSO = result[i++].Value?.ToString();
            dta.MOVDEBCE_NUM_PARCELA = result[i++].Value?.ToString();
            dta.MOVDEBCE_DATA_VENCIMENTO = result[i++].Value?.ToString();
            dta.MOVDEBCE_VALOR_DEBITO = result[i++].Value?.ToString();
            dta.MOVDEBCE_DTCREDITO = result[i++].Value?.ToString();
            dta.VIND_DTCREDITO = string.IsNullOrWhiteSpace(dta.MOVDEBCE_DTCREDITO) ? "-1" : "0";
            dta.MOVDEBCE_NUM_REQUISICAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}