using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GE0350S
{
    public class R1100_CONS_NN_CERTIFICADO_DB_SELECT_1_Query1 : QueryBasis<R1100_CONS_NN_CERTIFICADO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_PROPOSTA ,
            NUM_APOLICE ,
            NUM_ENDOSSO ,
            SEQ_CONTROLE_SIGCB ,
            DTA_MOVIMENTO ,
            VALUE(NUM_OCORR_MOVTO, 0) ,
            VALUE(NUM_IDLG, ' ' ) ,
            COD_PRODUTO ,
            DTA_VENCIMENTO ,
            VLR_PREMIO_TOTAL ,
            VLR_IOF ,
            QTD_PARCELA ,
            QTD_DIAS_CUSTODIA ,
            COD_CLIENTE ,
            VALUE(COD_CEDENTE_SAP, ' ' ) ,
            VALUE(NUM_BOLETO_INTERNO, 0) ,
            VALUE(NUM_NOSSO_NUMERO_SAP, 0) ,
            VALUE(COD_LINHA_DIGITAVEL, ' ' ) ,
            VALUE(NUM_TITULO, 0) ,
            IDE_SISTEMA ,
            COD_USUARIO ,
            COD_SITUACAO ,
            DATE(DTA_VENCIMENTO + QTD_DIAS_CUSTODIA DAYS)
            INTO :GE403-NUM-PROPOSTA
            , :GE403-NUM-APOLICE
            , :GE403-NUM-ENDOSSO
            , :GE403-SEQ-CONTROLE-SIGCB
            , :GE403-DTA-MOVIMENTO
            , :GE403-NUM-OCORR-MOVTO
            , :GE403-NUM-IDLG
            , :GE403-COD-PRODUTO
            , :GE403-DTA-VENCIMENTO
            , :GE403-VLR-PREMIO-TOTAL
            , :GE403-VLR-IOF
            , :GE403-QTD-PARCELA
            , :GE403-QTD-DIAS-CUSTODIA
            , :GE403-COD-CLIENTE
            , :GE403-COD-CEDENTE-SAP
            , :GE403-NUM-BOLETO-INTERNO
            , :GE403-NUM-NOSSO-NUMERO-SAP
            , :GE403-COD-LINHA-DIGITAVEL
            , :GE403-NUM-TITULO
            , :GE403-IDE-SISTEMA
            , :GE403-COD-USUARIO
            , :GE403-COD-SITUACAO
            , :WS-DTA-VENC-CUSTODIA
            FROM SEGUROS.GE_CONTROLE_EMISSAO_SIGCB A
            WHERE A.NUM_CERTIFICADO = :GE403-NUM-CERTIFICADO
            AND A.NUM_PARCELA = :GE403-NUM-PARCELA
            AND A.SEQ_CONTROLE_SIGCB =
            (SELECT MAX(B.SEQ_CONTROLE_SIGCB)
            FROM SEGUROS.GE_CONTROLE_EMISSAO_SIGCB B
            WHERE B.NUM_CERTIFICADO = :GE403-NUM-CERTIFICADO
            AND B.NUM_PARCELA = :GE403-NUM-PARCELA)
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_PROPOSTA 
							,
											NUM_APOLICE 
							,
											NUM_ENDOSSO 
							,
											SEQ_CONTROLE_SIGCB 
							,
											DTA_MOVIMENTO 
							,
											VALUE(NUM_OCORR_MOVTO
							, 0) 
							,
											VALUE(NUM_IDLG
							, ' ' ) 
							,
											COD_PRODUTO 
							,
											DTA_VENCIMENTO 
							,
											VLR_PREMIO_TOTAL 
							,
											VLR_IOF 
							,
											QTD_PARCELA 
							,
											QTD_DIAS_CUSTODIA 
							,
											COD_CLIENTE 
							,
											VALUE(COD_CEDENTE_SAP
							, ' ' ) 
							,
											VALUE(NUM_BOLETO_INTERNO
							, 0) 
							,
											VALUE(NUM_NOSSO_NUMERO_SAP
							, 0) 
							,
											VALUE(COD_LINHA_DIGITAVEL
							, ' ' ) 
							,
											VALUE(NUM_TITULO
							, 0) 
							,
											IDE_SISTEMA 
							,
											COD_USUARIO 
							,
											COD_SITUACAO 
							,
											DATE(DTA_VENCIMENTO + QTD_DIAS_CUSTODIA DAYS)
											FROM SEGUROS.GE_CONTROLE_EMISSAO_SIGCB A
											WHERE A.NUM_CERTIFICADO = '{this.GE403_NUM_CERTIFICADO}'
											AND A.NUM_PARCELA = '{this.GE403_NUM_PARCELA}'
											AND A.SEQ_CONTROLE_SIGCB =
											(SELECT MAX(B.SEQ_CONTROLE_SIGCB)
											FROM SEGUROS.GE_CONTROLE_EMISSAO_SIGCB B
											WHERE B.NUM_CERTIFICADO = '{this.GE403_NUM_CERTIFICADO}'
											AND B.NUM_PARCELA = '{this.GE403_NUM_PARCELA}')
											WITH UR";

            return query;
        }
        public string GE403_NUM_PROPOSTA { get; set; }
        public string GE403_NUM_APOLICE { get; set; }
        public string GE403_NUM_ENDOSSO { get; set; }
        public string GE403_SEQ_CONTROLE_SIGCB { get; set; }
        public string GE403_DTA_MOVIMENTO { get; set; }
        public string GE403_NUM_OCORR_MOVTO { get; set; }
        public string GE403_NUM_IDLG { get; set; }
        public string GE403_COD_PRODUTO { get; set; }
        public string GE403_DTA_VENCIMENTO { get; set; }
        public string GE403_VLR_PREMIO_TOTAL { get; set; }
        public string GE403_VLR_IOF { get; set; }
        public string GE403_QTD_PARCELA { get; set; }
        public string GE403_QTD_DIAS_CUSTODIA { get; set; }
        public string GE403_COD_CLIENTE { get; set; }
        public string GE403_COD_CEDENTE_SAP { get; set; }
        public string GE403_NUM_BOLETO_INTERNO { get; set; }
        public string GE403_NUM_NOSSO_NUMERO_SAP { get; set; }
        public string GE403_COD_LINHA_DIGITAVEL { get; set; }
        public string GE403_NUM_TITULO { get; set; }
        public string GE403_IDE_SISTEMA { get; set; }
        public string GE403_COD_USUARIO { get; set; }
        public string GE403_COD_SITUACAO { get; set; }
        public string WS_DTA_VENC_CUSTODIA { get; set; }
        public string GE403_NUM_CERTIFICADO { get; set; }
        public string GE403_NUM_PARCELA { get; set; }

        public static R1100_CONS_NN_CERTIFICADO_DB_SELECT_1_Query1 Execute(R1100_CONS_NN_CERTIFICADO_DB_SELECT_1_Query1 r1100_CONS_NN_CERTIFICADO_DB_SELECT_1_Query1)
        {
            var ths = r1100_CONS_NN_CERTIFICADO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1100_CONS_NN_CERTIFICADO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1100_CONS_NN_CERTIFICADO_DB_SELECT_1_Query1();
            var i = 0;
            dta.GE403_NUM_PROPOSTA = result[i++].Value?.ToString();
            dta.GE403_NUM_APOLICE = result[i++].Value?.ToString();
            dta.GE403_NUM_ENDOSSO = result[i++].Value?.ToString();
            dta.GE403_SEQ_CONTROLE_SIGCB = result[i++].Value?.ToString();
            dta.GE403_DTA_MOVIMENTO = result[i++].Value?.ToString();
            dta.GE403_NUM_OCORR_MOVTO = result[i++].Value?.ToString();
            dta.GE403_NUM_IDLG = result[i++].Value?.ToString();
            dta.GE403_COD_PRODUTO = result[i++].Value?.ToString();
            dta.GE403_DTA_VENCIMENTO = result[i++].Value?.ToString();
            dta.GE403_VLR_PREMIO_TOTAL = result[i++].Value?.ToString();
            dta.GE403_VLR_IOF = result[i++].Value?.ToString();
            dta.GE403_QTD_PARCELA = result[i++].Value?.ToString();
            dta.GE403_QTD_DIAS_CUSTODIA = result[i++].Value?.ToString();
            dta.GE403_COD_CLIENTE = result[i++].Value?.ToString();
            dta.GE403_COD_CEDENTE_SAP = result[i++].Value?.ToString();
            dta.GE403_NUM_BOLETO_INTERNO = result[i++].Value?.ToString();
            dta.GE403_NUM_NOSSO_NUMERO_SAP = result[i++].Value?.ToString();
            dta.GE403_COD_LINHA_DIGITAVEL = result[i++].Value?.ToString();
            dta.GE403_NUM_TITULO = result[i++].Value?.ToString();
            dta.GE403_IDE_SISTEMA = result[i++].Value?.ToString();
            dta.GE403_COD_USUARIO = result[i++].Value?.ToString();
            dta.GE403_COD_SITUACAO = result[i++].Value?.ToString();
            dta.WS_DTA_VENC_CUSTODIA = result[i++].Value?.ToString();
            return dta;
        }

    }
}