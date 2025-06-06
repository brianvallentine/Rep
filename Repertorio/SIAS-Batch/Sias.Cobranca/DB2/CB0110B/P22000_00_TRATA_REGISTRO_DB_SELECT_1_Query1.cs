using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0110B
{
    public class P22000_00_TRATA_REGISTRO_DB_SELECT_1_Query1 : QueryBasis<P22000_00_TRATA_REGISTRO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(OPER_CONTA_DEB,0)
            ,VALUE(COD_AGENCIA_DEB,0)
            ,VALUE(NUM_CONTA_DEB,0)
            ,VALUE(DIG_CONTA_DEB,0)
            ,SITUACAO_COBRANCA
            ,VALUE(COD_RETORNO_CEF,0)
            ,VALUE(VALOR_DEBITO,0)
            INTO :MOVDEBCE-OPER-CONTA-DEB
            ,:MOVDEBCE-COD-AGENCIA-DEB
            ,:MOVDEBCE-NUM-CONTA-DEB
            ,:MOVDEBCE-DIG-CONTA-DEB
            ,:MOVDEBCE-SITUACAO-COBRANCA
            ,:MOVDEBCE-COD-RETORNO-CEF
            ,:MOVDEBCE-VALOR-DEBITO
            FROM SEGUROS.MOVTO_DEBITOCC_CEF
            WHERE NUM_APOLICE = :FOLLOUP-NUM-APOLICE
            AND NUM_ENDOSSO = :FOLLOUP-NUM-ENDOSSO
            AND NUM_PARCELA = :FOLLOUP-NUM-PARCELA
            ORDER BY TIMESTAMP DESC
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT VALUE(OPER_CONTA_DEB
							,0)
											,VALUE(COD_AGENCIA_DEB
							,0)
											,VALUE(NUM_CONTA_DEB
							,0)
											,VALUE(DIG_CONTA_DEB
							,0)
											,SITUACAO_COBRANCA
											,VALUE(COD_RETORNO_CEF
							,0)
											,VALUE(VALOR_DEBITO
							,0)
											FROM SEGUROS.MOVTO_DEBITOCC_CEF
											WHERE NUM_APOLICE = '{this.FOLLOUP_NUM_APOLICE}'
											AND NUM_ENDOSSO = '{this.FOLLOUP_NUM_ENDOSSO}'
											AND NUM_PARCELA = '{this.FOLLOUP_NUM_PARCELA}'
											ORDER BY TIMESTAMP DESC
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string MOVDEBCE_OPER_CONTA_DEB { get; set; }
        public string MOVDEBCE_COD_AGENCIA_DEB { get; set; }
        public string MOVDEBCE_NUM_CONTA_DEB { get; set; }
        public string MOVDEBCE_DIG_CONTA_DEB { get; set; }
        public string MOVDEBCE_SITUACAO_COBRANCA { get; set; }
        public string MOVDEBCE_COD_RETORNO_CEF { get; set; }
        public string MOVDEBCE_VALOR_DEBITO { get; set; }
        public string FOLLOUP_NUM_APOLICE { get; set; }
        public string FOLLOUP_NUM_ENDOSSO { get; set; }
        public string FOLLOUP_NUM_PARCELA { get; set; }

        public static P22000_00_TRATA_REGISTRO_DB_SELECT_1_Query1 Execute(P22000_00_TRATA_REGISTRO_DB_SELECT_1_Query1 p22000_00_TRATA_REGISTRO_DB_SELECT_1_Query1)
        {
            var ths = p22000_00_TRATA_REGISTRO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override P22000_00_TRATA_REGISTRO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new P22000_00_TRATA_REGISTRO_DB_SELECT_1_Query1();
            var i = 0;
            dta.MOVDEBCE_OPER_CONTA_DEB = result[i++].Value?.ToString();
            dta.MOVDEBCE_COD_AGENCIA_DEB = result[i++].Value?.ToString();
            dta.MOVDEBCE_NUM_CONTA_DEB = result[i++].Value?.ToString();
            dta.MOVDEBCE_DIG_CONTA_DEB = result[i++].Value?.ToString();
            dta.MOVDEBCE_SITUACAO_COBRANCA = result[i++].Value?.ToString();
            dta.MOVDEBCE_COD_RETORNO_CEF = result[i++].Value?.ToString();
            dta.MOVDEBCE_VALOR_DEBITO = result[i++].Value?.ToString();
            return dta;
        }

    }
}