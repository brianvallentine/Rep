using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM8006B
{
    public class R2100_00_SELECT_MOVDEBCC_DB_SELECT_2_Query1 : QueryBasis<R2100_00_SELECT_MOVDEBCC_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT A.NUM_APOLICE
            ,A.NUM_ENDOSSO
            ,A.NUM_PARCELA
            ,A.DATA_VENCIMENTO
            ,A.SITUACAO_COBRANCA
            ,VALUE(A.COD_AGENCIA_DEB, 0)
            ,VALUE(A.OPER_CONTA_DEB, 0)
            ,VALUE(A.NUM_CONTA_DEB, 0)
            ,VALUE(A.DIG_CONTA_DEB, 0)
            ,A.COD_CONVENIO
            ,A.NSAS
            ,VALUE(A.NUM_REQUISICAO, 0)
            ,VALUE(A.STATUS_CARTAO, '' )
            ,B.COD_LOT_FENAL
            ,C.COD_PRODUTO
            INTO :MOVDEBCE-NUM-APOLICE
            ,:MOVDEBCE-NUM-ENDOSSO
            ,:MOVDEBCE-NUM-PARCELA
            ,:MOVDEBCE-DATA-VENCIMENTO
            ,:MOVDEBCE-SITUACAO-COBRANCA
            ,:MOVDEBCE-COD-AGENCIA-DEB
            ,:MOVDEBCE-OPER-CONTA-DEB
            ,:MOVDEBCE-NUM-CONTA-DEB
            ,:MOVDEBCE-DIG-CONTA-DEB
            ,:MOVDEBCE-COD-CONVENIO
            ,:MOVDEBCE-NSAS
            ,:MOVDEBCE-NUM-REQUISICAO
            ,:MOVDEBCE-STATUS-CARTAO
            ,:LOTERI01-COD-LOT-FENAL
            ,:APOLICES-COD-PRODUTO
            FROM SEGUROS.MOVTO_DEBITOCC_CEF A
            ,SEGUROS.LOTERICO01 B
            ,SEGUROS.APOLICES C
            WHERE A.NUM_APOLICE = :MOVDEBCE-NUM-APOLICE
            AND A.NUM_ENDOSSO = :MOVDEBCE-NUM-ENDOSSO
            AND A.NUM_PARCELA = :MOVDEBCE-NUM-PARCELA
            AND A.COD_CONVENIO = :MOVDEBCE-COD-CONVENIO
            AND A.NSAS = :MOVDEBCE-NSAS
            AND A.NUM_APOLICE = B.NUM_APOLICE
            AND A.NUM_APOLICE = C.NUM_APOLICE
            AND B.NUM_APOLICE = C.NUM_APOLICE
            ORDER BY B.DTINIVIG DESC
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT A.NUM_APOLICE
											,A.NUM_ENDOSSO
											,A.NUM_PARCELA
											,A.DATA_VENCIMENTO
											,A.SITUACAO_COBRANCA
											,VALUE(A.COD_AGENCIA_DEB
							, 0)
											,VALUE(A.OPER_CONTA_DEB
							, 0)
											,VALUE(A.NUM_CONTA_DEB
							, 0)
											,VALUE(A.DIG_CONTA_DEB
							, 0)
											,A.COD_CONVENIO
											,A.NSAS
											,VALUE(A.NUM_REQUISICAO
							, 0)
											,VALUE(A.STATUS_CARTAO
							, '' )
											,B.COD_LOT_FENAL
											,C.COD_PRODUTO
											FROM SEGUROS.MOVTO_DEBITOCC_CEF A
											,SEGUROS.LOTERICO01 B
											,SEGUROS.APOLICES C
											WHERE A.NUM_APOLICE = '{this.MOVDEBCE_NUM_APOLICE}'
											AND A.NUM_ENDOSSO = '{this.MOVDEBCE_NUM_ENDOSSO}'
											AND A.NUM_PARCELA = '{this.MOVDEBCE_NUM_PARCELA}'
											AND A.COD_CONVENIO = '{this.MOVDEBCE_COD_CONVENIO}'
											AND A.NSAS = '{this.MOVDEBCE_NSAS}'
											AND A.NUM_APOLICE = B.NUM_APOLICE
											AND A.NUM_APOLICE = C.NUM_APOLICE
											AND B.NUM_APOLICE = C.NUM_APOLICE
											ORDER BY B.DTINIVIG DESC
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string MOVDEBCE_NUM_APOLICE { get; set; }
        public string MOVDEBCE_NUM_ENDOSSO { get; set; }
        public string MOVDEBCE_NUM_PARCELA { get; set; }
        public string MOVDEBCE_DATA_VENCIMENTO { get; set; }
        public string MOVDEBCE_SITUACAO_COBRANCA { get; set; }
        public string MOVDEBCE_COD_AGENCIA_DEB { get; set; }
        public string MOVDEBCE_OPER_CONTA_DEB { get; set; }
        public string MOVDEBCE_NUM_CONTA_DEB { get; set; }
        public string MOVDEBCE_DIG_CONTA_DEB { get; set; }
        public string MOVDEBCE_COD_CONVENIO { get; set; }
        public string MOVDEBCE_NSAS { get; set; }
        public string MOVDEBCE_NUM_REQUISICAO { get; set; }
        public string MOVDEBCE_STATUS_CARTAO { get; set; }
        public string LOTERI01_COD_LOT_FENAL { get; set; }
        public string APOLICES_COD_PRODUTO { get; set; }

        public static R2100_00_SELECT_MOVDEBCC_DB_SELECT_2_Query1 Execute(R2100_00_SELECT_MOVDEBCC_DB_SELECT_2_Query1 r2100_00_SELECT_MOVDEBCC_DB_SELECT_2_Query1)
        {
            var ths = r2100_00_SELECT_MOVDEBCC_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2100_00_SELECT_MOVDEBCC_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2100_00_SELECT_MOVDEBCC_DB_SELECT_2_Query1();
            var i = 0;
            dta.MOVDEBCE_NUM_APOLICE = result[i++].Value?.ToString();
            dta.MOVDEBCE_NUM_ENDOSSO = result[i++].Value?.ToString();
            dta.MOVDEBCE_NUM_PARCELA = result[i++].Value?.ToString();
            dta.MOVDEBCE_DATA_VENCIMENTO = result[i++].Value?.ToString();
            dta.MOVDEBCE_SITUACAO_COBRANCA = result[i++].Value?.ToString();
            dta.MOVDEBCE_COD_AGENCIA_DEB = result[i++].Value?.ToString();
            dta.MOVDEBCE_OPER_CONTA_DEB = result[i++].Value?.ToString();
            dta.MOVDEBCE_NUM_CONTA_DEB = result[i++].Value?.ToString();
            dta.MOVDEBCE_DIG_CONTA_DEB = result[i++].Value?.ToString();
            dta.MOVDEBCE_COD_CONVENIO = result[i++].Value?.ToString();
            dta.MOVDEBCE_NSAS = result[i++].Value?.ToString();
            dta.MOVDEBCE_NUM_REQUISICAO = result[i++].Value?.ToString();
            dta.MOVDEBCE_STATUS_CARTAO = result[i++].Value?.ToString();
            dta.LOTERI01_COD_LOT_FENAL = result[i++].Value?.ToString();
            dta.APOLICES_COD_PRODUTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}