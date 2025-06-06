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
    public class R0610_00_VERIFICA_IDLG_DEMAIS_DB_SELECT_1_Query1 : QueryBasis<R0610_00_VERIFICA_IDLG_DEMAIS_DB_SELECT_1_Query1>
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
            INTO :MOVDEBCE-NUM-APOLICE
            , :MOVDEBCE-NUM-ENDOSSO
            , :MOVDEBCE-NUM-PARCELA
            , :MOVDEBCE-DATA-VENCIMENTO
            , :MOVDEBCE-VALOR-DEBITO
            , :MOVDEBCE-DTCREDITO:VIND-DTCREDITO
            FROM SEGUROS.MOVTO_DEBITOCC_CEF
            WHERE COD_CONVENIO = :MOVDEBCE-COD-CONVENIO
            AND NSAS = :MOVDEBCE-NSAS
            AND NUM_REQUISICAO = :MOVDEBCE-NUM-REQUISICAO
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
											FROM SEGUROS.MOVTO_DEBITOCC_CEF
											WHERE COD_CONVENIO = '{this.MOVDEBCE_COD_CONVENIO}'
											AND NSAS = '{this.MOVDEBCE_NSAS}'
											AND NUM_REQUISICAO = '{this.MOVDEBCE_NUM_REQUISICAO}'
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

        public static R0610_00_VERIFICA_IDLG_DEMAIS_DB_SELECT_1_Query1 Execute(R0610_00_VERIFICA_IDLG_DEMAIS_DB_SELECT_1_Query1 r0610_00_VERIFICA_IDLG_DEMAIS_DB_SELECT_1_Query1)
        {
            var ths = r0610_00_VERIFICA_IDLG_DEMAIS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0610_00_VERIFICA_IDLG_DEMAIS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0610_00_VERIFICA_IDLG_DEMAIS_DB_SELECT_1_Query1();
            var i = 0;
            dta.MOVDEBCE_NUM_APOLICE = result[i++].Value?.ToString();
            dta.MOVDEBCE_NUM_ENDOSSO = result[i++].Value?.ToString();
            dta.MOVDEBCE_NUM_PARCELA = result[i++].Value?.ToString();
            dta.MOVDEBCE_DATA_VENCIMENTO = result[i++].Value?.ToString();
            dta.MOVDEBCE_VALOR_DEBITO = result[i++].Value?.ToString();
            dta.MOVDEBCE_DTCREDITO = result[i++].Value?.ToString();
            dta.VIND_DTCREDITO = string.IsNullOrWhiteSpace(dta.MOVDEBCE_DTCREDITO) ? "-1" : "0";
            return dta;
        }

    }
}