using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.FC0105S
{
    public class FDRCAP_FCATN061_Call1 : QueryBasis<FDRCAP_FCATN061_Call1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            CALL FDRCAP.FCATN061 ( :LK-COD-USUARIO-N061
            , :LK-COD-PROG-ORIGEM-N061
            , :LK-SIGLA-UNID-NEG-N061
            , :LK-COD-MSG-LANG-N061
            , :LK-IND-TIPO-PROC-N061
            , :LK-EMP-PARCEIRA
            , :LK-NUM-PLANO
            , :LK-NUM-SERIE
            , :LK-NUM-TITULO
            , :LK-COD-RAMO
            , :LK-NUM-PROPOSTA
            , :LK-QTD-TITULOS
            , :LK-VLR-TITULO
            , :LK-NUM-ORDEM-N061
            , :W77-NUM-NSA
            , :LK-COD-EMPRESA-N061
            , :LK-IND-ERRO-N061
            , :LK-MSG-RET-N061
            , :LK-NM-TAB-N061
            , :LK-SQLCODE-N061
            , :LK-SQLERRMC-N061)
            END-EXEC
            */
            #endregion
            IsProcedure = true;

            var query = @$"FDRCAP.FCATN061";

            return query;
        }
        public string LK_COD_USUARIO_N061 { get; set; }
        public string LK_COD_PROG_ORIGEM_N061 { get; set; }
        public string LK_SIGLA_UNID_NEG_N061 { get; set; }
        public string LK_COD_MSG_LANG_N061 { get; set; }
        public string LK_IND_TIPO_PROC_N061 { get; set; }
        public string LK_EMP_PARCEIRA { get; set; }
        public string LK_NUM_PLANO { get; set; }
        public string LK_NUM_SERIE { get; set; }
        public string LK_NUM_TITULO { get; set; }
        public string LK_COD_RAMO { get; set; }
        public string LK_NUM_PROPOSTA { get; set; }
        public string LK_QTD_TITULOS { get; set; }
        public string LK_VLR_TITULO { get; set; }
        public string LK_NUM_ORDEM_N061 { get; set; }
        public string W77_NUM_NSA { get; set; }
        public string LK_COD_EMPRESA_N061 { get; set; }
        public string LK_IND_ERRO_N061 { get; set; }
        public string LK_MSG_RET_N061 { get; set; }
        public string LK_NM_TAB_N061 { get; set; }
        public string LK_SQLCODE_N061 { get; set; }
        public string LK_SQLERRMC_N061 { get; set; }

        public static FDRCAP_FCATN061_Call1 Execute(FDRCAP_FCATN061_Call1 fDRCAP_FCATN061_Call1)
        {
            var ths = fDRCAP_FCATN061_Call1;
            ths.SetQuery(ths.GetQuery());

            ths.Params = new
            {
                ths.LK_COD_USUARIO_N061,
                ths.LK_COD_PROG_ORIGEM_N061,
                ths.LK_SIGLA_UNID_NEG_N061,
                ths.LK_COD_MSG_LANG_N061,
                ths.LK_IND_TIPO_PROC_N061,
                ths.LK_EMP_PARCEIRA,
                ths.LK_NUM_PLANO,
                ths.LK_NUM_SERIE,
                ths.LK_NUM_TITULO,
                ths.LK_COD_RAMO,
                ths.LK_NUM_PROPOSTA,
                ths.LK_QTD_TITULOS,
                ths.LK_VLR_TITULO,
                ths.LK_NUM_ORDEM_N061,
                ths.W77_NUM_NSA,
                ths.LK_COD_EMPRESA_N061,
                ths.LK_IND_ERRO_N061,
                ths.LK_MSG_RET_N061,
                ths.LK_NM_TAB_N061,
                ths.LK_SQLCODE_N061,
                ths.LK_SQLERRMC_N061
            };

            ths.Open(ths.Params);
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override FDRCAP_FCATN061_Call1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new FDRCAP_FCATN061_Call1();
            dta.LK_COD_USUARIO_N061 = result[0].Value?.ToString();
            dta.LK_COD_PROG_ORIGEM_N061 = result[1].Value?.ToString();
            dta.LK_SIGLA_UNID_NEG_N061 = result[2].Value?.ToString();
            dta.LK_COD_MSG_LANG_N061 = result[3].Value?.ToString();
            dta.LK_IND_TIPO_PROC_N061 = result[4].Value?.ToString();
            dta.LK_EMP_PARCEIRA = result[5].Value?.ToString();
            dta.LK_NUM_PLANO = result[6].Value?.ToString();
            dta.LK_NUM_SERIE = result[7].Value?.ToString();
            dta.LK_NUM_TITULO = result[8].Value?.ToString();
            dta.LK_COD_RAMO = result[9].Value?.ToString();
            dta.LK_NUM_PROPOSTA = result[10].Value?.ToString();
            dta.LK_QTD_TITULOS = result[11].Value?.ToString();
            dta.LK_VLR_TITULO = result[12].Value?.ToString();
            dta.LK_NUM_ORDEM_N061 = result[13].Value?.ToString();
            dta.W77_NUM_NSA = result[14].Value?.ToString();
            dta.LK_COD_EMPRESA_N061 = result[15].Value?.ToString();
            dta.LK_IND_ERRO_N061 = result[16].Value?.ToString();
            dta.LK_MSG_RET_N061 = result[17].Value?.ToString();
            dta.LK_NM_TAB_N061 = result[18].Value?.ToString();
            dta.LK_SQLCODE_N061 = result[19].Value?.ToString();
            dta.LK_SQLERRMC_N061 = result[20].Value?.ToString();
            return dta;
        }

    }
}