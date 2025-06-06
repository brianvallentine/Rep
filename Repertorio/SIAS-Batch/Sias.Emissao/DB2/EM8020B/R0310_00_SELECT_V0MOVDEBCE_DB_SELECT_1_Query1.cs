using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM8020B
{
    public class R0310_00_SELECT_V0MOVDEBCE_DB_SELECT_1_Query1 : QueryBasis<R0310_00_SELECT_V0MOVDEBCE_DB_SELECT_1_Query1>
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
            A.SITUACAO_COBRANCA ,
            B.COD_AGENCIA ,
            B.COD_BANCO ,
            B.NUM_CONTA_CNB ,
            B.NUM_DV_CONTA_CNB ,
            B.IND_CONTA_BANCARIA
            INTO :MOVDEBCE-NUM-APOLICE ,
            :MOVDEBCE-NUM-ENDOSSO ,
            :MOVDEBCE-NUM-PARCELA ,
            :MOVDEBCE-DATA-VENCIMENTO ,
            :MOVDEBCE-COD-AGENCIA-DEB ,
            :MOVDEBCE-OPER-CONTA-DEB ,
            :MOVDEBCE-NUM-CONTA-DEB ,
            :MOVDEBCE-COD-CONVENIO ,
            :MOVDEBCE-NSAS ,
            :MOVDEBCE-NUM-REQUISICAO ,
            :MOVDEBCE-VLR-CREDITO ,
            :MOVDEBCE-NUM-CARTAO:VIND-CARTAO ,
            :MOVDEBCE-SITUACAO-COBRANCA,
            :GE369-COD-AGENCIA ,
            :GE369-COD-BANCO ,
            :GE369-NUM-CONTA-CNB ,
            :GE369-NUM-DV-CONTA-CNB ,
            :GE369-IND-CONTA-BANCARIA
            FROM SEGUROS.MOVTO_DEBITOCC_CEF A,
            SEGUROS.GE_MOVTO_CONTA B
            WHERE A.NUM_REQUISICAO = :MOVDEBCE-NUM-REQUISICAO
            AND A.COD_CONVENIO = :MOVDEBCE-COD-CONVENIO
            AND A.NUM_APOLICE = B.NUM_APOLICE
            AND A.NUM_ENDOSSO = B.NUM_ENDOSSO
            AND A.NUM_PARCELA = B.NUM_PARCELA
            AND A.COD_CONVENIO = B.COD_CONVENIO
            AND A.NSAS = B.NSAS
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
											A.SITUACAO_COBRANCA 
							,
											B.COD_AGENCIA 
							,
											B.COD_BANCO 
							,
											B.NUM_CONTA_CNB 
							,
											B.NUM_DV_CONTA_CNB 
							,
											B.IND_CONTA_BANCARIA
											FROM SEGUROS.MOVTO_DEBITOCC_CEF A
							,
											SEGUROS.GE_MOVTO_CONTA B
											WHERE A.NUM_REQUISICAO = '{this.MOVDEBCE_NUM_REQUISICAO}'
											AND A.COD_CONVENIO = '{this.MOVDEBCE_COD_CONVENIO}'
											AND A.NUM_APOLICE = B.NUM_APOLICE
											AND A.NUM_ENDOSSO = B.NUM_ENDOSSO
											AND A.NUM_PARCELA = B.NUM_PARCELA
											AND A.COD_CONVENIO = B.COD_CONVENIO
											AND A.NSAS = B.NSAS
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
        public string MOVDEBCE_VLR_CREDITO { get; set; }
        public string MOVDEBCE_NUM_CARTAO { get; set; }
        public string VIND_CARTAO { get; set; }
        public string MOVDEBCE_SITUACAO_COBRANCA { get; set; }
        public string GE369_COD_AGENCIA { get; set; }
        public string GE369_COD_BANCO { get; set; }
        public string GE369_NUM_CONTA_CNB { get; set; }
        public string GE369_NUM_DV_CONTA_CNB { get; set; }
        public string GE369_IND_CONTA_BANCARIA { get; set; }

        public static R0310_00_SELECT_V0MOVDEBCE_DB_SELECT_1_Query1 Execute(R0310_00_SELECT_V0MOVDEBCE_DB_SELECT_1_Query1 r0310_00_SELECT_V0MOVDEBCE_DB_SELECT_1_Query1)
        {
            var ths = r0310_00_SELECT_V0MOVDEBCE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0310_00_SELECT_V0MOVDEBCE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0310_00_SELECT_V0MOVDEBCE_DB_SELECT_1_Query1();
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
            dta.MOVDEBCE_VLR_CREDITO = result[i++].Value?.ToString();
            dta.MOVDEBCE_NUM_CARTAO = result[i++].Value?.ToString();
            dta.VIND_CARTAO = string.IsNullOrWhiteSpace(dta.MOVDEBCE_NUM_CARTAO) ? "-1" : "0";
            dta.MOVDEBCE_SITUACAO_COBRANCA = result[i++].Value?.ToString();
            dta.GE369_COD_AGENCIA = result[i++].Value?.ToString();
            dta.GE369_COD_BANCO = result[i++].Value?.ToString();
            dta.GE369_NUM_CONTA_CNB = result[i++].Value?.ToString();
            dta.GE369_NUM_DV_CONTA_CNB = result[i++].Value?.ToString();
            dta.GE369_IND_CONTA_BANCARIA = result[i++].Value?.ToString();
            return dta;
        }

    }
}