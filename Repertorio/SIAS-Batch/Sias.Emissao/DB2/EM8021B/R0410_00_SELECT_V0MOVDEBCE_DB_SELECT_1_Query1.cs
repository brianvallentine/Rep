using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM8021B
{
    public class R0410_00_SELECT_V0MOVDEBCE_DB_SELECT_1_Query1 : QueryBasis<R0410_00_SELECT_V0MOVDEBCE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT A.NUM_APOLICE ,
            A.NUM_ENDOSSO ,
            A.NUM_PARCELA ,
            A.DATA_VENCIMENTO ,
            A.COD_AGENCIA_DEB ,
            A.OPER_CONTA_DEB ,
            A.NUM_CONTA_DEB ,
            A.COD_CONVENIO ,
            A.NSAS ,
            A.NUM_REQUISICAO ,
            A.VLR_CREDITO ,
            A.NUM_CARTAO ,
            B.NUM_CHEQUE_INTERNO ,
            B.AGENCIA_CONTRATO ,
            C.RAMO ,
            C.COD_PRODUTO
            INTO :MOVDEBCE-NUM-APOLICE ,
            :MOVDEBCE-NUM-ENDOSSO ,
            :MOVDEBCE-NUM-PARCELA ,
            :MOVDEBCE-DATA-VENCIMENTO ,
            :MOVDEBCE-COD-AGENCIA-DEB ,
            :MOVDEBCE-OPER-CONTA-DEB ,
            :MOVDEBCE-NUM-CONTA-DEB ,
            :MOVDEBCE-COD-CONVENIO ,
            :MOVDEBCE-NSAS ,
            :MOVDEBCE-NUM-REQUISICAO:VIND-NUMREQ ,
            :MOVDEBCE-VLR-CREDITO ,
            :MOVDEBCE-NUM-CARTAO:VIND-CARTAO ,
            :RALCHEDO-NUM-CHEQUE-INTERNO ,
            :RALCHEDO-AGENCIA-CONTRATO ,
            :SINISMES-RAMO ,
            :SINISMES-COD-PRODUTO
            FROM SEGUROS.MOVTO_DEBITOCC_CEF A,
            SEGUROS.RALACAO_CHEQ_DOCTO B,
            SEGUROS.SINISTRO_MESTRE C
            WHERE A.SITUACAO_COBRANCA = :MOVDEBCE-SITUACAO-COBRANCA
            AND A.COD_CONVENIO = :MOVDEBCE-COD-CONVENIO
            AND A.NUM_APOLICE = :MOVDEBCE-NUM-APOLICE
            AND A.NUM_PARCELA = :MOVDEBCE-NUM-PARCELA
            AND A.NUM_APOLICE = B.NUMDOC_NUM01
            AND A.NUM_PARCELA = B.OCORR_HISTORICO
            AND C.NUM_APOL_SINISTRO = A.NUM_APOLICE
            AND C.NUM_APOL_SINISTRO = B.NUMDOC_NUM01
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT A.NUM_APOLICE 
							,
											A.NUM_ENDOSSO 
							,
											A.NUM_PARCELA 
							,
											A.DATA_VENCIMENTO 
							,
											A.COD_AGENCIA_DEB 
							,
											A.OPER_CONTA_DEB 
							,
											A.NUM_CONTA_DEB 
							,
											A.COD_CONVENIO 
							,
											A.NSAS 
							,
											A.NUM_REQUISICAO 
							,
											A.VLR_CREDITO 
							,
											A.NUM_CARTAO 
							,
											B.NUM_CHEQUE_INTERNO 
							,
											B.AGENCIA_CONTRATO 
							,
											C.RAMO 
							,
											C.COD_PRODUTO
											FROM SEGUROS.MOVTO_DEBITOCC_CEF A
							,
											SEGUROS.RALACAO_CHEQ_DOCTO B
							,
											SEGUROS.SINISTRO_MESTRE C
											WHERE A.SITUACAO_COBRANCA = '{this.MOVDEBCE_SITUACAO_COBRANCA}'
											AND A.COD_CONVENIO = '{this.MOVDEBCE_COD_CONVENIO}'
											AND A.NUM_APOLICE = '{this.MOVDEBCE_NUM_APOLICE}'
											AND A.NUM_PARCELA = '{this.MOVDEBCE_NUM_PARCELA}'
											AND A.NUM_APOLICE = B.NUMDOC_NUM01
											AND A.NUM_PARCELA = B.OCORR_HISTORICO
											AND C.NUM_APOL_SINISTRO = A.NUM_APOLICE
											AND C.NUM_APOL_SINISTRO = B.NUMDOC_NUM01
											WITH UR";

            return query;
        }
        public string MOVDEBCE_NUM_APOLICE { get; set; }
        public string MOVDEBCE_NUM_ENDOSSO { get; set; }
        public string MOVDEBCE_NUM_PARCELA { get; set; }
        public string MOVDEBCE_DATA_VENCIMENTO { get; set; }
        public string MOVDEBCE_COD_AGENCIA_DEB { get; set; }
        public string MOVDEBCE_OPER_CONTA_DEB { get; set; }
        public string MOVDEBCE_NUM_CONTA_DEB { get; set; }
        public string MOVDEBCE_COD_CONVENIO { get; set; }
        public string MOVDEBCE_NSAS { get; set; }
        public string MOVDEBCE_NUM_REQUISICAO { get; set; }
        public string VIND_NUMREQ { get; set; }
        public string MOVDEBCE_VLR_CREDITO { get; set; }
        public string MOVDEBCE_NUM_CARTAO { get; set; }
        public string VIND_CARTAO { get; set; }
        public string RALCHEDO_NUM_CHEQUE_INTERNO { get; set; }
        public string RALCHEDO_AGENCIA_CONTRATO { get; set; }
        public string SINISMES_RAMO { get; set; }
        public string SINISMES_COD_PRODUTO { get; set; }
        public string MOVDEBCE_SITUACAO_COBRANCA { get; set; }

        public static R0410_00_SELECT_V0MOVDEBCE_DB_SELECT_1_Query1 Execute(R0410_00_SELECT_V0MOVDEBCE_DB_SELECT_1_Query1 r0410_00_SELECT_V0MOVDEBCE_DB_SELECT_1_Query1)
        {
            var ths = r0410_00_SELECT_V0MOVDEBCE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0410_00_SELECT_V0MOVDEBCE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0410_00_SELECT_V0MOVDEBCE_DB_SELECT_1_Query1();
            var i = 0;
            dta.MOVDEBCE_NUM_APOLICE = result[i++].Value?.ToString();
            dta.MOVDEBCE_NUM_ENDOSSO = result[i++].Value?.ToString();
            dta.MOVDEBCE_NUM_PARCELA = result[i++].Value?.ToString();
            dta.MOVDEBCE_DATA_VENCIMENTO = result[i++].Value?.ToString();
            dta.MOVDEBCE_COD_AGENCIA_DEB = result[i++].Value?.ToString();
            dta.MOVDEBCE_OPER_CONTA_DEB = result[i++].Value?.ToString();
            dta.MOVDEBCE_NUM_CONTA_DEB = result[i++].Value?.ToString();
            dta.MOVDEBCE_COD_CONVENIO = result[i++].Value?.ToString();
            dta.MOVDEBCE_NSAS = result[i++].Value?.ToString();
            dta.MOVDEBCE_NUM_REQUISICAO = result[i++].Value?.ToString();
            dta.VIND_NUMREQ = string.IsNullOrWhiteSpace(dta.MOVDEBCE_NUM_REQUISICAO) ? "-1" : "0";
            dta.MOVDEBCE_VLR_CREDITO = result[i++].Value?.ToString();
            dta.MOVDEBCE_NUM_CARTAO = result[i++].Value?.ToString();
            dta.VIND_CARTAO = string.IsNullOrWhiteSpace(dta.MOVDEBCE_NUM_CARTAO) ? "-1" : "0";
            dta.RALCHEDO_NUM_CHEQUE_INTERNO = result[i++].Value?.ToString();
            dta.RALCHEDO_AGENCIA_CONTRATO = result[i++].Value?.ToString();
            dta.SINISMES_RAMO = result[i++].Value?.ToString();
            dta.SINISMES_COD_PRODUTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}