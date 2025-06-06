using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0033B
{
    public class R0117_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1 : QueryBasis<R0117_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_APOLICE ,
            COD_AGENCIA_DEB ,
            OPER_CONTA_DEB ,
            NUM_CONTA_DEB ,
            DIG_CONTA_DEB ,
            DATA_VENCIMENTO ,
            VALOR_DEBITO ,
            NSAS ,
            SEQUENCIA ,
            NUM_REQUISICAO
            INTO :MOVDEBCE-NUM-APOLICE ,
            :MOVDEBCE-COD-AGENCIA-DEB ,
            :MOVDEBCE-OPER-CONTA-DEB ,
            :MOVDEBCE-NUM-CONTA-DEB ,
            :MOVDEBCE-DIG-CONTA-DEB ,
            :MOVDEBCE-DATA-VENCIMENTO ,
            :MOVDEBCE-VALOR-DEBITO ,
            :MOVDEBCE-NSAS:WS-NSAS ,
            :MOVDEBCE-SEQUENCIA:WS-SEQUENCIA,
            :MOVDEBCE-NUM-REQUISICAO:WS-REQUISICAO
            FROM SEGUROS.MOVTO_DEBITOCC_CEF
            WHERE NUM_APOLICE = :V0MOVDE-NUM-APOLICE
            AND SITUACAO_COBRANCA = '1'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_APOLICE 
							,
											COD_AGENCIA_DEB 
							,
											OPER_CONTA_DEB 
							,
											NUM_CONTA_DEB 
							,
											DIG_CONTA_DEB 
							,
											DATA_VENCIMENTO 
							,
											VALOR_DEBITO 
							,
											NSAS 
							,
											SEQUENCIA 
							,
											NUM_REQUISICAO
											FROM SEGUROS.MOVTO_DEBITOCC_CEF
											WHERE NUM_APOLICE = '{this.V0MOVDE_NUM_APOLICE}'
											AND SITUACAO_COBRANCA = '1'";

            return query;
        }
        public string MOVDEBCE_NUM_APOLICE { get; set; }
        public string MOVDEBCE_COD_AGENCIA_DEB { get; set; }
        public string MOVDEBCE_OPER_CONTA_DEB { get; set; }
        public string MOVDEBCE_NUM_CONTA_DEB { get; set; }
        public string MOVDEBCE_DIG_CONTA_DEB { get; set; }
        public string MOVDEBCE_DATA_VENCIMENTO { get; set; }
        public string MOVDEBCE_VALOR_DEBITO { get; set; }
        public string MOVDEBCE_NSAS { get; set; }
        public string WS_NSAS { get; set; }
        public string MOVDEBCE_SEQUENCIA { get; set; }
        public string WS_SEQUENCIA { get; set; }
        public string MOVDEBCE_NUM_REQUISICAO { get; set; }
        public string WS_REQUISICAO { get; set; }
        public string V0MOVDE_NUM_APOLICE { get; set; }

        public static R0117_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1 Execute(R0117_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1 r0117_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1)
        {
            var ths = r0117_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0117_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0117_00_SELECT_MOVDEBCE_DB_SELECT_1_Query1();
            var i = 0;
            dta.MOVDEBCE_NUM_APOLICE = result[i++].Value?.ToString();
            dta.MOVDEBCE_COD_AGENCIA_DEB = result[i++].Value?.ToString();
            dta.MOVDEBCE_OPER_CONTA_DEB = result[i++].Value?.ToString();
            dta.MOVDEBCE_NUM_CONTA_DEB = result[i++].Value?.ToString();
            dta.MOVDEBCE_DIG_CONTA_DEB = result[i++].Value?.ToString();
            dta.MOVDEBCE_DATA_VENCIMENTO = result[i++].Value?.ToString();
            dta.MOVDEBCE_VALOR_DEBITO = result[i++].Value?.ToString();
            dta.MOVDEBCE_NSAS = result[i++].Value?.ToString();
            dta.WS_NSAS = string.IsNullOrWhiteSpace(dta.MOVDEBCE_NSAS) ? "-1" : "0";
            dta.MOVDEBCE_SEQUENCIA = result[i++].Value?.ToString();
            dta.WS_SEQUENCIA = string.IsNullOrWhiteSpace(dta.MOVDEBCE_SEQUENCIA) ? "-1" : "0";
            dta.MOVDEBCE_NUM_REQUISICAO = result[i++].Value?.ToString();
            dta.WS_REQUISICAO = string.IsNullOrWhiteSpace(dta.MOVDEBCE_NUM_REQUISICAO) ? "-1" : "0";
            return dta;
        }

    }
}