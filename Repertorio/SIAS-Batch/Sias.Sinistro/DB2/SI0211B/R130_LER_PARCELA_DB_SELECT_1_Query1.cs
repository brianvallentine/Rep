using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0211B
{
    public class R130_LER_PARCELA_DB_SELECT_1_Query1 : QueryBasis<R130_LER_PARCELA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT P.NUM_APOL_SINISTRO,
            P.OCORR_HISTORICO,
            P.COD_OPERACAO,
            P.NUM_RESSARC,
            P.SEQ_RESSARC,
            P.NUM_PARCELA,
            P.COD_AGENCIA_CEDENT,
            P.COD_SISTEMA_ORIGEM,
            P.NUM_CEDENTE,
            P.NUM_CEDENTE_DV,
            P.DTH_VENCIMENTO,
            P.NUM_NOSSO_TITULO,
            P.DTH_CADASTRAMENTO,
            P.PCT_OPERACAO,
            P.IND_FORMA_BAIXA,
            P.NOM_PROGRAMA,
            VALUE(P.DTH_PAGAMENTO, '0001-01-01' ),
            P.IND_INTEGRACAO,
            VALUE(P.NUM_TITULO_SIGCB, 0),
            A.VLR_TOTAL_ACORDO,
            A.COD_FORNECEDOR,
            A.STA_ACORDO ,
            M.RAMO ,
            M.COD_PRODUTO
            INTO :SI111-NUM-APOL-SINISTRO,
            :SI111-OCORR-HISTORICO,
            :SI111-COD-OPERACAO,
            :SI111-NUM-RESSARC,
            :SI111-SEQ-RESSARC,
            :SI111-NUM-PARCELA,
            :SI111-COD-AGENCIA-CEDENT,
            :SI111-COD-SISTEMA-ORIGEM,
            :SI111-NUM-CEDENTE,
            :SI111-NUM-CEDENTE-DV,
            :SI111-DTH-VENCIMENTO,
            :SI111-NUM-NOSSO-TITULO,
            :SI111-DTH-CADASTRAMENTO,
            :SI111-PCT-OPERACAO,
            :SI111-IND-FORMA-BAIXA,
            :SI111-NOM-PROGRAMA,
            :SI111-DTH-PAGAMENTO,
            :SI111-IND-INTEGRACAO,
            :SI111-NUM-TITULO-SIGCB,
            :SI112-VLR-TOTAL-ACORDO,
            :SI112-COD-FORNECEDOR,
            :SI112-STA-ACORDO ,
            :SINISMES-RAMO ,
            :SINISMES-COD-PRODUTO
            FROM SEGUROS.SI_RESSARC_PARCELA P,
            SEGUROS.SI_RESSARC_ACORDO A,
            SEGUROS.SINISTRO_MESTRE M,
            SEGUROS.GE_OPERACAO O
            WHERE P.NUM_NOSSO_TITULO = :MOVIMCOB-NUM-NOSSO-TITULO
            AND O.COD_OPERACAO = P.COD_OPERACAO
            AND O.IDE_SISTEMA = 'SI'
            AND ( O.FUNCAO_OPERACAO = 'RSPPR'
            AND O.COD_OPERACAO = 4000)
            AND A.NUM_APOL_SINISTRO = P.NUM_APOL_SINISTRO
            AND A.NUM_RESSARC = P.NUM_RESSARC
            AND A.SEQ_RESSARC = P.SEQ_RESSARC
            AND M.NUM_APOL_SINISTRO = A.NUM_APOL_SINISTRO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT P.NUM_APOL_SINISTRO
							,
											P.OCORR_HISTORICO
							,
											P.COD_OPERACAO
							,
											P.NUM_RESSARC
							,
											P.SEQ_RESSARC
							,
											P.NUM_PARCELA
							,
											P.COD_AGENCIA_CEDENT
							,
											P.COD_SISTEMA_ORIGEM
							,
											P.NUM_CEDENTE
							,
											P.NUM_CEDENTE_DV
							,
											P.DTH_VENCIMENTO
							,
											P.NUM_NOSSO_TITULO
							,
											P.DTH_CADASTRAMENTO
							,
											P.PCT_OPERACAO
							,
											P.IND_FORMA_BAIXA
							,
											P.NOM_PROGRAMA
							,
											VALUE(P.DTH_PAGAMENTO
							, '0001-01-01' )
							,
											P.IND_INTEGRACAO
							,
											VALUE(P.NUM_TITULO_SIGCB
							, 0)
							,
											A.VLR_TOTAL_ACORDO
							,
											A.COD_FORNECEDOR
							,
											A.STA_ACORDO 
							,
											M.RAMO 
							,
											M.COD_PRODUTO
											FROM SEGUROS.SI_RESSARC_PARCELA P
							,
											SEGUROS.SI_RESSARC_ACORDO A
							,
											SEGUROS.SINISTRO_MESTRE M
							,
											SEGUROS.GE_OPERACAO O
											WHERE P.NUM_NOSSO_TITULO = '{this.MOVIMCOB_NUM_NOSSO_TITULO}'
											AND O.COD_OPERACAO = P.COD_OPERACAO
											AND O.IDE_SISTEMA = 'SI'
											AND ( O.FUNCAO_OPERACAO = 'RSPPR'
											AND O.COD_OPERACAO = 4000)
											AND A.NUM_APOL_SINISTRO = P.NUM_APOL_SINISTRO
											AND A.NUM_RESSARC = P.NUM_RESSARC
											AND A.SEQ_RESSARC = P.SEQ_RESSARC
											AND M.NUM_APOL_SINISTRO = A.NUM_APOL_SINISTRO";

            return query;
        }
        public string SI111_NUM_APOL_SINISTRO { get; set; }
        public string SI111_OCORR_HISTORICO { get; set; }
        public string SI111_COD_OPERACAO { get; set; }
        public string SI111_NUM_RESSARC { get; set; }
        public string SI111_SEQ_RESSARC { get; set; }
        public string SI111_NUM_PARCELA { get; set; }
        public string SI111_COD_AGENCIA_CEDENT { get; set; }
        public string SI111_COD_SISTEMA_ORIGEM { get; set; }
        public string SI111_NUM_CEDENTE { get; set; }
        public string SI111_NUM_CEDENTE_DV { get; set; }
        public string SI111_DTH_VENCIMENTO { get; set; }
        public string SI111_NUM_NOSSO_TITULO { get; set; }
        public string SI111_DTH_CADASTRAMENTO { get; set; }
        public string SI111_PCT_OPERACAO { get; set; }
        public string SI111_IND_FORMA_BAIXA { get; set; }
        public string SI111_NOM_PROGRAMA { get; set; }
        public string SI111_DTH_PAGAMENTO { get; set; }
        public string SI111_IND_INTEGRACAO { get; set; }
        public string SI111_NUM_TITULO_SIGCB { get; set; }
        public string SI112_VLR_TOTAL_ACORDO { get; set; }
        public string SI112_COD_FORNECEDOR { get; set; }
        public string SI112_STA_ACORDO { get; set; }
        public string SINISMES_RAMO { get; set; }
        public string SINISMES_COD_PRODUTO { get; set; }
        public string MOVIMCOB_NUM_NOSSO_TITULO { get; set; }

        public static R130_LER_PARCELA_DB_SELECT_1_Query1 Execute(R130_LER_PARCELA_DB_SELECT_1_Query1 r130_LER_PARCELA_DB_SELECT_1_Query1)
        {
            var ths = r130_LER_PARCELA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R130_LER_PARCELA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R130_LER_PARCELA_DB_SELECT_1_Query1();
            var i = 0;
            dta.SI111_NUM_APOL_SINISTRO = result[i++].Value?.ToString();
            dta.SI111_OCORR_HISTORICO = result[i++].Value?.ToString();
            dta.SI111_COD_OPERACAO = result[i++].Value?.ToString();
            dta.SI111_NUM_RESSARC = result[i++].Value?.ToString();
            dta.SI111_SEQ_RESSARC = result[i++].Value?.ToString();
            dta.SI111_NUM_PARCELA = result[i++].Value?.ToString();
            dta.SI111_COD_AGENCIA_CEDENT = result[i++].Value?.ToString();
            dta.SI111_COD_SISTEMA_ORIGEM = result[i++].Value?.ToString();
            dta.SI111_NUM_CEDENTE = result[i++].Value?.ToString();
            dta.SI111_NUM_CEDENTE_DV = result[i++].Value?.ToString();
            dta.SI111_DTH_VENCIMENTO = result[i++].Value?.ToString();
            dta.SI111_NUM_NOSSO_TITULO = result[i++].Value?.ToString();
            dta.SI111_DTH_CADASTRAMENTO = result[i++].Value?.ToString();
            dta.SI111_PCT_OPERACAO = result[i++].Value?.ToString();
            dta.SI111_IND_FORMA_BAIXA = result[i++].Value?.ToString();
            dta.SI111_NOM_PROGRAMA = result[i++].Value?.ToString();
            dta.SI111_DTH_PAGAMENTO = result[i++].Value?.ToString();
            dta.SI111_IND_INTEGRACAO = result[i++].Value?.ToString();
            dta.SI111_NUM_TITULO_SIGCB = result[i++].Value?.ToString();
            dta.SI112_VLR_TOTAL_ACORDO = result[i++].Value?.ToString();
            dta.SI112_COD_FORNECEDOR = result[i++].Value?.ToString();
            dta.SI112_STA_ACORDO = result[i++].Value?.ToString();
            dta.SINISMES_RAMO = result[i++].Value?.ToString();
            dta.SINISMES_COD_PRODUTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}