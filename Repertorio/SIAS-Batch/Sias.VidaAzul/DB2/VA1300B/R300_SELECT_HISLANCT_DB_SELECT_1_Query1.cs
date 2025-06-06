using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA1300B
{
    public class R300_SELECT_HISLANCT_DB_SELECT_1_Query1 : QueryBasis<R300_SELECT_HISLANCT_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT H.NUM_CERTIFICADO,
            H.NUM_PARCELA,
            C.NUM_TITULO,
            H.PRM_TOTAL,
            H.SIT_REGISTRO,
            H.DATA_VENCIMENTO,
            H.NSAS,
            H.NSL,
            H.CODCONV,
            P.NUM_OCORR_MOVTO,
            B.COD_BANCO,
            B.COD_AGENCIA,
            B.NUM_CONTA,
            B.NUM_DV_CONTA,
            B.NUM_OPERACAO_CONTA,
            B.NUM_PESSOA,
            B.SEQ_CONTA_BANCARIA,
            E.NUM_OCORR_MOVTO,
            E.NUM_PESSOA
            INTO :HISLANCT-NUM-CERTIFICADO,
            :HISLANCT-NUM-PARCELA,
            :COBHISVI-NUM-TITULO,
            :HISLANCT-PRM-TOTAL,
            :HISLANCT-SIT-REGISTRO,
            :HISLANCT-DATA-VENCIMENTO,
            :HISLANCT-NSAS:SQL-MAYBE-NULL1,
            :HISLANCT-NSL:SQL-MAYBE-NULL2,
            :HISLANCT-CODCONV,
            :VG079-NUM-OCORR-MOVTO,
            :OD009-COD-BANCO,
            :OD009-COD-AGENCIA,
            :OD009-NUM-CONTA,
            :OD009-NUM-DV-CONTA,
            :OD009-NUM-OPERACAO-CONTA,
            :OD009-NUM-PESSOA,
            :OD009-SEQ-CONTA-BANCARIA,
            :GE368-NUM-OCORR-MOVTO,
            :GE368-NUM-PESSOA
            FROM SEGUROS.VG_PESS_PARCELA P,
            SEGUROS.GE_MOVIMENTO M,
            SEGUROS.GE_LEG_PESS_EVENTO E,
            ODS.OD_PESS_CONTA_BANC B,
            SEGUROS.HIST_LANC_CTA H,
            SEGUROS.COBER_HIST_VIDAZUL C
            WHERE P.NUM_OCORR_MOVTO = :VG079-NUM-OCORR-MOVTO
            AND P.NUM_CERTIFICADO = :HISLANCT-NUM-CERTIFICADO
            AND P.NUM_PARCELA = :HISLANCT-NUM-PARCELA
            AND M.NUM_OCORR_MOVTO = P.NUM_OCORR_MOVTO
            AND M.IND_EVENTO = 1
            AND H.NUM_CERTIFICADO = P.NUM_CERTIFICADO
            AND H.NUM_PARCELA = P.NUM_PARCELA
            AND H.NSAS = :HISLANCT-NSAS
            AND H.PRM_TOTAL <> 0
            AND C.NUM_CERTIFICADO = P.NUM_CERTIFICADO
            AND C.NUM_PARCELA = P.NUM_PARCELA
            AND C.NUM_TITULO = :COBHISVI-NUM-TITULO
            AND E.NUM_OCORR_MOVTO = P.NUM_OCORR_MOVTO
            AND E.NUM_PESSOA = :GE368-NUM-PESSOA
            AND E.IND_ENTIDADE = 3
            AND B.NUM_PESSOA = E.NUM_PESSOA
            AND B.SEQ_CONTA_BANCARIA = E.SEQ_ENTIDADE
            AND B.COD_BANCO <> 104
            FETCH FIRST 1 ROW ONLY
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT H.NUM_CERTIFICADO
							,
											H.NUM_PARCELA
							,
											C.NUM_TITULO
							,
											H.PRM_TOTAL
							,
											H.SIT_REGISTRO
							,
											H.DATA_VENCIMENTO
							,
											H.NSAS
							,
											H.NSL
							,
											H.CODCONV
							,
											P.NUM_OCORR_MOVTO
							,
											B.COD_BANCO
							,
											B.COD_AGENCIA
							,
											B.NUM_CONTA
							,
											B.NUM_DV_CONTA
							,
											B.NUM_OPERACAO_CONTA
							,
											B.NUM_PESSOA
							,
											B.SEQ_CONTA_BANCARIA
							,
											E.NUM_OCORR_MOVTO
							,
											E.NUM_PESSOA
											FROM SEGUROS.VG_PESS_PARCELA P
							,
											SEGUROS.GE_MOVIMENTO M
							,
											SEGUROS.GE_LEG_PESS_EVENTO E
							,
											ODS.OD_PESS_CONTA_BANC B
							,
											SEGUROS.HIST_LANC_CTA H
							,
											SEGUROS.COBER_HIST_VIDAZUL C
											WHERE P.NUM_OCORR_MOVTO = '{this.VG079_NUM_OCORR_MOVTO}'
											AND P.NUM_CERTIFICADO = '{this.HISLANCT_NUM_CERTIFICADO}'
											AND P.NUM_PARCELA = '{this.HISLANCT_NUM_PARCELA}'
											AND M.NUM_OCORR_MOVTO = P.NUM_OCORR_MOVTO
											AND M.IND_EVENTO = 1
											AND H.NUM_CERTIFICADO = P.NUM_CERTIFICADO
											AND H.NUM_PARCELA = P.NUM_PARCELA
											AND H.NSAS = '{this.HISLANCT_NSAS}'
											AND H.PRM_TOTAL <> 0
											AND C.NUM_CERTIFICADO = P.NUM_CERTIFICADO
											AND C.NUM_PARCELA = P.NUM_PARCELA
											AND C.NUM_TITULO = '{this.COBHISVI_NUM_TITULO}'
											AND E.NUM_OCORR_MOVTO = P.NUM_OCORR_MOVTO
											AND E.NUM_PESSOA = '{this.GE368_NUM_PESSOA}'
											AND E.IND_ENTIDADE = 3
											AND B.NUM_PESSOA = E.NUM_PESSOA
											AND B.SEQ_CONTA_BANCARIA = E.SEQ_ENTIDADE
											AND B.COD_BANCO <> 104
											FETCH FIRST 1 ROW ONLY";

            return query;
        }
        public string HISLANCT_NUM_CERTIFICADO { get; set; }
        public string HISLANCT_NUM_PARCELA { get; set; }
        public string COBHISVI_NUM_TITULO { get; set; }
        public string HISLANCT_PRM_TOTAL { get; set; }
        public string HISLANCT_SIT_REGISTRO { get; set; }
        public string HISLANCT_DATA_VENCIMENTO { get; set; }
        public string HISLANCT_NSAS { get; set; }
        public string SQL_MAYBE_NULL1 { get; set; }
        public string HISLANCT_NSL { get; set; }
        public string SQL_MAYBE_NULL2 { get; set; }
        public string HISLANCT_CODCONV { get; set; }
        public string VG079_NUM_OCORR_MOVTO { get; set; }
        public string OD009_COD_BANCO { get; set; }
        public string OD009_COD_AGENCIA { get; set; }
        public string OD009_NUM_CONTA { get; set; }
        public string OD009_NUM_DV_CONTA { get; set; }
        public string OD009_NUM_OPERACAO_CONTA { get; set; }
        public string OD009_NUM_PESSOA { get; set; }
        public string OD009_SEQ_CONTA_BANCARIA { get; set; }
        public string GE368_NUM_OCORR_MOVTO { get; set; }
        public string GE368_NUM_PESSOA { get; set; }

        public static R300_SELECT_HISLANCT_DB_SELECT_1_Query1 Execute(R300_SELECT_HISLANCT_DB_SELECT_1_Query1 r300_SELECT_HISLANCT_DB_SELECT_1_Query1)
        {
            var ths = r300_SELECT_HISLANCT_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R300_SELECT_HISLANCT_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R300_SELECT_HISLANCT_DB_SELECT_1_Query1();
            var i = 0;
            dta.HISLANCT_NUM_CERTIFICADO = result[i++].Value?.ToString();
            dta.HISLANCT_NUM_PARCELA = result[i++].Value?.ToString();
            dta.COBHISVI_NUM_TITULO = result[i++].Value?.ToString();
            dta.HISLANCT_PRM_TOTAL = result[i++].Value?.ToString();
            dta.HISLANCT_SIT_REGISTRO = result[i++].Value?.ToString();
            dta.HISLANCT_DATA_VENCIMENTO = result[i++].Value?.ToString();
            dta.HISLANCT_NSAS = result[i++].Value?.ToString();
            dta.SQL_MAYBE_NULL1 = string.IsNullOrWhiteSpace(dta.HISLANCT_NSAS) ? "-1" : "0";
            dta.HISLANCT_NSL = result[i++].Value?.ToString();
            dta.SQL_MAYBE_NULL2 = string.IsNullOrWhiteSpace(dta.HISLANCT_NSL) ? "-1" : "0";
            dta.HISLANCT_CODCONV = result[i++].Value?.ToString();
            dta.VG079_NUM_OCORR_MOVTO = result[i++].Value?.ToString();
            dta.OD009_COD_BANCO = result[i++].Value?.ToString();
            dta.OD009_COD_AGENCIA = result[i++].Value?.ToString();
            dta.OD009_NUM_CONTA = result[i++].Value?.ToString();
            dta.OD009_NUM_DV_CONTA = result[i++].Value?.ToString();
            dta.OD009_NUM_OPERACAO_CONTA = result[i++].Value?.ToString();
            dta.OD009_NUM_PESSOA = result[i++].Value?.ToString();
            dta.OD009_SEQ_CONTA_BANCARIA = result[i++].Value?.ToString();
            dta.GE368_NUM_OCORR_MOVTO = result[i++].Value?.ToString();
            dta.GE368_NUM_PESSOA = result[i++].Value?.ToString();
            return dta;
        }

    }
}