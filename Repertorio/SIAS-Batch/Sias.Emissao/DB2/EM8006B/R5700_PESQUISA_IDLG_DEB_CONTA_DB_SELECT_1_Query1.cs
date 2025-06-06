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
    public class R5700_PESQUISA_IDLG_DEB_CONTA_DB_SELECT_1_Query1 : QueryBasis<R5700_PESQUISA_IDLG_DEB_CONTA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT E.NUM_APOLICE ,
            D.NUM_CERTIFICADO ,
            D.NUM_PARCELA ,
            D.NUM_TITULO ,
            A.NUM_OCORR_MOVTO ,
            E.COD_PRODUTO ,
            E.COD_CLIENTE
            INTO :WS-NUM-APOLICE ,
            :WS-NUM-CERTIFICADO ,
            :WS-NUM-PARCELA ,
            :WS-NUM-TITULO ,
            :WS-NUM-OCORR-MOVTO ,
            :WS-COD-PRODUTO ,
            :WS-COD-CLIENTE
            FROM SEGUROS.GE_CONTROLE_INTERF_SAP A,
            SEGUROS.GE_MOVDEBCE_SAP B,
            SEGUROS.MOVTO_DEBITOCC_CEF C,
            SEGUROS.COBER_HIST_VIDAZUL D,
            SEGUROS.PROPOSTAS_VA E
            WHERE A.COD_IDLG = :SIGC13-IDLG
            AND B.NUM_OCORR_MOVTO = A.NUM_OCORR_MOVTO
            AND C.NUM_APOLICE = B.NUM_APOLICE
            AND C.NUM_ENDOSSO = B.NUM_ENDOSSO
            AND C.NUM_PARCELA = B.NUM_PARCELA
            AND C.NSAS = B.NSAS
            AND D.NUM_TITULO = C.NUM_APOLICE
            AND E.NUM_CERTIFICADO = D.NUM_CERTIFICADO
            FETCH FIRST 01 ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT E.NUM_APOLICE 
							,
											D.NUM_CERTIFICADO 
							,
											D.NUM_PARCELA 
							,
											D.NUM_TITULO 
							,
											A.NUM_OCORR_MOVTO 
							,
											E.COD_PRODUTO 
							,
											E.COD_CLIENTE
											FROM SEGUROS.GE_CONTROLE_INTERF_SAP A
							,
											SEGUROS.GE_MOVDEBCE_SAP B
							,
											SEGUROS.MOVTO_DEBITOCC_CEF C
							,
											SEGUROS.COBER_HIST_VIDAZUL D
							,
											SEGUROS.PROPOSTAS_VA E
											WHERE A.COD_IDLG = '{this.SIGC13_IDLG}'
											AND B.NUM_OCORR_MOVTO = A.NUM_OCORR_MOVTO
											AND C.NUM_APOLICE = B.NUM_APOLICE
											AND C.NUM_ENDOSSO = B.NUM_ENDOSSO
											AND C.NUM_PARCELA = B.NUM_PARCELA
											AND C.NSAS = B.NSAS
											AND D.NUM_TITULO = C.NUM_APOLICE
											AND E.NUM_CERTIFICADO = D.NUM_CERTIFICADO
											FETCH FIRST 01 ROWS ONLY
											WITH UR";

            return query;
        }
        public string WS_NUM_APOLICE { get; set; }
        public string WS_NUM_CERTIFICADO { get; set; }
        public string WS_NUM_PARCELA { get; set; }
        public string WS_NUM_TITULO { get; set; }
        public string WS_NUM_OCORR_MOVTO { get; set; }
        public string WS_COD_PRODUTO { get; set; }
        public string WS_COD_CLIENTE { get; set; }
        public string SIGC13_IDLG { get; set; }

        public static R5700_PESQUISA_IDLG_DEB_CONTA_DB_SELECT_1_Query1 Execute(R5700_PESQUISA_IDLG_DEB_CONTA_DB_SELECT_1_Query1 r5700_PESQUISA_IDLG_DEB_CONTA_DB_SELECT_1_Query1)
        {
            var ths = r5700_PESQUISA_IDLG_DEB_CONTA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R5700_PESQUISA_IDLG_DEB_CONTA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R5700_PESQUISA_IDLG_DEB_CONTA_DB_SELECT_1_Query1();
            var i = 0;
            dta.WS_NUM_APOLICE = result[i++].Value?.ToString();
            dta.WS_NUM_CERTIFICADO = result[i++].Value?.ToString();
            dta.WS_NUM_PARCELA = result[i++].Value?.ToString();
            dta.WS_NUM_TITULO = result[i++].Value?.ToString();
            dta.WS_NUM_OCORR_MOVTO = result[i++].Value?.ToString();
            dta.WS_COD_PRODUTO = result[i++].Value?.ToString();
            dta.WS_COD_CLIENTE = result[i++].Value?.ToString();
            return dta;
        }

    }
}