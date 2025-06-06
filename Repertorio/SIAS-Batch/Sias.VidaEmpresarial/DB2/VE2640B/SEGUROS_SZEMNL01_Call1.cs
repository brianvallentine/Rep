using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE2640B
{
    public class SEGUROS_SZEMNL01_Call1 : QueryBasis<SEGUROS_SZEMNL01_Call1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            CALL SEGUROS.SZEMNL01
            ( :H-SZL01-COD-USUARIO
            INDICATOR :N-SZL01-COD-USUARIO
            , :H-SZL01-COD-PROGRAMA
            INDICATOR :N-SZL01-COD-PROGRAMA
            , :H-SZL01-DES-MSG-SISTEMA
            INDICATOR :N-SZL01-DES-MSG-SISTEMA
            , :H-SZL01-IND-ERRO-LOG
            INDICATOR :N-SZL01-IND-ERRO-LOG
            , :H-SZL01-SQLCODE-LOG
            INDICATOR :N-SZL01-SQLCODE-LOG
            , :H-SZL01-SQLERRMC-LOG
            INDICATOR :N-SZL01-SQLERRMC-LOG
            , :H-SZL01-DES-MSG-RETORNO
            INDICATOR :N-SZL01-DES-MSG-RETORNO
            , :H-SZL01-SEQ-LOG-SISTEMA
            INDICATOR :N-SZL01-SEQ-LOG-SISTEMA
            , :H-SZL01-IND-ERRO
            INDICATOR :N-SZL01-IND-ERRO
            , :H-SZL01-MSG-RET
            INDICATOR :N-SZL01-MSG-RET
            , :H-SZL01-NM-TAB
            INDICATOR :N-SZL01-NM-TAB
            , :H-SZL01-SQLCODE
            INDICATOR :N-SZL01-SQLCODE
            , :H-SZL01-SQLERRMC
            INDICATOR :N-SZL01-SQLERRMC)
            END-EXEC
            */
            #endregion
            IsProcedure = true;

            var query = @$"SEGUROS.SZEMNL01";

            return query;
        }
        public string H_SZL01_COD_USUARIO { get; set; }
        public string N_SZL01_COD_USUARIO { get; set; }
        public string H_SZL01_COD_PROGRAMA { get; set; }
        public string N_SZL01_COD_PROGRAMA { get; set; }
        public string H_SZL01_DES_MSG_SISTEMA { get; set; }
        public string N_SZL01_DES_MSG_SISTEMA { get; set; }
        public string H_SZL01_IND_ERRO_LOG { get; set; }
        public string N_SZL01_IND_ERRO_LOG { get; set; }
        public string H_SZL01_SQLCODE_LOG { get; set; }
        public string N_SZL01_SQLCODE_LOG { get; set; }
        public string H_SZL01_SQLERRMC_LOG { get; set; }
        public string N_SZL01_SQLERRMC_LOG { get; set; }
        public string H_SZL01_DES_MSG_RETORNO { get; set; }
        public string N_SZL01_DES_MSG_RETORNO { get; set; }
        public string H_SZL01_SEQ_LOG_SISTEMA { get; set; }
        public string N_SZL01_SEQ_LOG_SISTEMA { get; set; }
        public string H_SZL01_IND_ERRO { get; set; }
        public string N_SZL01_IND_ERRO { get; set; }
        public string H_SZL01_MSG_RET { get; set; }
        public string N_SZL01_MSG_RET { get; set; }
        public string H_SZL01_NM_TAB { get; set; }
        public string N_SZL01_NM_TAB { get; set; }
        public string H_SZL01_SQLCODE { get; set; }
        public string N_SZL01_SQLCODE { get; set; }
        public string H_SZL01_SQLERRMC { get; set; }
        public string N_SZL01_SQLERRMC { get; set; }

        public static SEGUROS_SZEMNL01_Call1 Execute(SEGUROS_SZEMNL01_Call1 sEGUROS_SZEMNL01_Call1)
        {
            var ths = sEGUROS_SZEMNL01_Call1;
            ths.SetQuery(ths.GetQuery());

            ths.Params = new
            {
                ths.H_SZL01_COD_USUARIO,
                ths.N_SZL01_COD_USUARIO,
                ths.H_SZL01_COD_PROGRAMA,
                ths.N_SZL01_COD_PROGRAMA,
                ths.H_SZL01_DES_MSG_SISTEMA,
                ths.N_SZL01_DES_MSG_SISTEMA,
                ths.H_SZL01_IND_ERRO_LOG,
                ths.N_SZL01_IND_ERRO_LOG,
                ths.H_SZL01_SQLCODE_LOG,
                ths.N_SZL01_SQLCODE_LOG,
                ths.H_SZL01_SQLERRMC_LOG,
                ths.N_SZL01_SQLERRMC_LOG,
                ths.H_SZL01_DES_MSG_RETORNO,
                ths.N_SZL01_DES_MSG_RETORNO,
                ths.H_SZL01_SEQ_LOG_SISTEMA,
                ths.N_SZL01_SEQ_LOG_SISTEMA,
                ths.H_SZL01_IND_ERRO,
                ths.N_SZL01_IND_ERRO,
                ths.H_SZL01_MSG_RET,
                ths.N_SZL01_MSG_RET,
                ths.H_SZL01_NM_TAB,
                ths.N_SZL01_NM_TAB,
                ths.H_SZL01_SQLCODE,
                ths.N_SZL01_SQLCODE,
                ths.H_SZL01_SQLERRMC,
                ths.N_SZL01_SQLERRMC
            };

            ths.Open(ths.Params);
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override SEGUROS_SZEMNL01_Call1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SEGUROS_SZEMNL01_Call1();
            dta.H_SZL01_COD_USUARIO = result[0].Value?.ToString();
            dta.N_SZL01_COD_USUARIO = result[1].Value?.ToString();
            dta.H_SZL01_COD_PROGRAMA = result[2].Value?.ToString();
            dta.N_SZL01_COD_PROGRAMA = result[3].Value?.ToString();
            dta.H_SZL01_DES_MSG_SISTEMA = result[4].Value?.ToString();
            dta.N_SZL01_DES_MSG_SISTEMA = result[5].Value?.ToString();
            dta.H_SZL01_IND_ERRO_LOG = result[6].Value?.ToString();
            dta.N_SZL01_IND_ERRO_LOG = result[7].Value?.ToString();
            dta.H_SZL01_SQLCODE_LOG = result[8].Value?.ToString();
            dta.N_SZL01_SQLCODE_LOG = result[9].Value?.ToString();
            dta.H_SZL01_SQLERRMC_LOG = result[10].Value?.ToString();
            dta.N_SZL01_SQLERRMC_LOG = result[11].Value?.ToString();
            dta.H_SZL01_DES_MSG_RETORNO = result[12].Value?.ToString();
            dta.N_SZL01_DES_MSG_RETORNO = result[13].Value?.ToString();
            dta.H_SZL01_SEQ_LOG_SISTEMA = result[14].Value?.ToString();
            dta.N_SZL01_SEQ_LOG_SISTEMA = result[15].Value?.ToString();
            dta.H_SZL01_IND_ERRO = result[16].Value?.ToString();
            dta.N_SZL01_IND_ERRO = result[17].Value?.ToString();
            dta.H_SZL01_MSG_RET = result[18].Value?.ToString();
            dta.N_SZL01_MSG_RET = result[19].Value?.ToString();
            dta.H_SZL01_NM_TAB = result[20].Value?.ToString();
            dta.N_SZL01_NM_TAB = result[21].Value?.ToString();
            dta.H_SZL01_SQLCODE = result[22].Value?.ToString();
            dta.N_SZL01_SQLCODE = result[23].Value?.ToString();
            dta.H_SZL01_SQLERRMC = result[24].Value?.ToString();
            dta.N_SZL01_SQLERRMC = result[25].Value?.ToString();
            return dta;
        }

    }
}