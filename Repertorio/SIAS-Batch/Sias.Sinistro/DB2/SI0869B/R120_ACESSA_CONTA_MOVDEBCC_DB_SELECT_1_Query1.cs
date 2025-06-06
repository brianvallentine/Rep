using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0869B
{
    public class R120_ACESSA_CONTA_MOVDEBCC_DB_SELECT_1_Query1 : QueryBasis<R120_ACESSA_CONTA_MOVDEBCC_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT M.COD_AGENCIA_DEB,
            M.OPER_CONTA_DEB,
            M.NUM_CONTA_DEB,
            M.DIG_CONTA_DEB,
            VALUE(M.DATA_ENVIO,:SISTEMAS-DATA-MOV-ABERTO),
            M.DATA_VENCIMENTO
            INTO :MOVDEBCE-COD-AGENCIA-DEB,
            :MOVDEBCE-OPER-CONTA-DEB,
            :MOVDEBCE-NUM-CONTA-DEB,
            :MOVDEBCE-DIG-CONTA-DEB,
            :MOVDEBCE-DATA-ENVIO,
            :MOVDEBCE-DATA-VENCIMENTO
            FROM SEGUROS.MOVTO_DEBITOCC_CEF M
            WHERE M.NUM_APOLICE = :MOVDEBCE-NUM-APOLICE
            AND M.NUM_ENDOSSO = :MOVDEBCE-NUM-ENDOSSO
            AND M.NUM_PARCELA = :MOVDEBCE-NUM-PARCELA
            AND M.NSAS = (SELECT MAX(X.NSAS)
            FROM SEGUROS.MOVTO_DEBITOCC_CEF X
            WHERE X.NUM_APOLICE = M.NUM_APOLICE
            AND X.NUM_ENDOSSO = M.NUM_ENDOSSO
            AND X.NUM_PARCELA = M.NUM_PARCELA)
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT M.COD_AGENCIA_DEB
							,
											M.OPER_CONTA_DEB
							,
											M.NUM_CONTA_DEB
							,
											M.DIG_CONTA_DEB
							,
											VALUE(M.DATA_ENVIO
							,'{this.SISTEMAS_DATA_MOV_ABERTO}')
							,
											M.DATA_VENCIMENTO
											FROM SEGUROS.MOVTO_DEBITOCC_CEF M
											WHERE M.NUM_APOLICE = '{this.MOVDEBCE_NUM_APOLICE}'
											AND M.NUM_ENDOSSO = '{this.MOVDEBCE_NUM_ENDOSSO}'
											AND M.NUM_PARCELA = '{this.MOVDEBCE_NUM_PARCELA}'
											AND M.NSAS =
							(SELECT  MAX(X.NSAS)
											FROM SEGUROS.MOVTO_DEBITOCC_CEF X
											WHERE X.NUM_APOLICE = M.NUM_APOLICE
											AND X.NUM_ENDOSSO = M.NUM_ENDOSSO
											AND X.NUM_PARCELA = M.NUM_PARCELA)";

            return query;
        }
        public string MOVDEBCE_COD_AGENCIA_DEB { get; set; }
        public string MOVDEBCE_OPER_CONTA_DEB { get; set; }
        public string MOVDEBCE_NUM_CONTA_DEB { get; set; }
        public string MOVDEBCE_DIG_CONTA_DEB { get; set; }
        public string MOVDEBCE_DATA_ENVIO { get; set; }
        public string MOVDEBCE_DATA_VENCIMENTO { get; set; }
        public string SISTEMAS_DATA_MOV_ABERTO { get; set; }
        public string MOVDEBCE_NUM_APOLICE { get; set; }
        public string MOVDEBCE_NUM_ENDOSSO { get; set; }
        public string MOVDEBCE_NUM_PARCELA { get; set; }

        public static R120_ACESSA_CONTA_MOVDEBCC_DB_SELECT_1_Query1 Execute(R120_ACESSA_CONTA_MOVDEBCC_DB_SELECT_1_Query1 r120_ACESSA_CONTA_MOVDEBCC_DB_SELECT_1_Query1)
        {
            var ths = r120_ACESSA_CONTA_MOVDEBCC_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R120_ACESSA_CONTA_MOVDEBCC_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R120_ACESSA_CONTA_MOVDEBCC_DB_SELECT_1_Query1();
            var i = 0;
            dta.MOVDEBCE_COD_AGENCIA_DEB = result[i++].Value?.ToString();
            dta.MOVDEBCE_OPER_CONTA_DEB = result[i++].Value?.ToString();
            dta.MOVDEBCE_NUM_CONTA_DEB = result[i++].Value?.ToString();
            dta.MOVDEBCE_DIG_CONTA_DEB = result[i++].Value?.ToString();
            dta.MOVDEBCE_DATA_ENVIO = result[i++].Value?.ToString();
            dta.MOVDEBCE_DATA_VENCIMENTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}