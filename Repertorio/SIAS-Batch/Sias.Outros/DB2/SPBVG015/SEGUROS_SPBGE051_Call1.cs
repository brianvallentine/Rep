using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.SPBVG015
{
    public class SEGUROS_SPBGE051_Call1 : QueryBasis<SEGUROS_SPBGE051_Call1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            CALL SEGUROS.SPBGE051
            ( :LK-GE051-TRACE
            , :LK-GE051-NUM-CPF-CNPJ
            , :LK-GE051-S-QTD-CNTR-PREST
            , :LK-GE051-S-VLR-IS-ACUM-PREST
            , :LK-GE051-S-DTH-CAD-PREST
            , :LK-GE051-S-QTD-CONTR-VIDA
            , :LK-GE051-S-VLR-IS-ACUM-VIDA
            , :LK-GE051-S-DTH-CAD-VIDA
            , :LK-GE051-S-QTD-CNTR-PREV
            , :LK-GE051-S-VLR-IS-ACUM-PREV
            , :LK-GE051-S-DTH-CAD-PREV
            , :LK-GE051-S-QTD-CONTR-HABIT
            , :LK-GE051-S-VLR-IS_ACUM-HABIT
            , :LK-GE051-S-DTH-CAD-HABIT
            , :LK-GE051-S-QTD-TOTAL-CNTR
            , :LK-GE051-S-VLR-TOTAL-CNTR
            , :LK-GE051-S-DTH-CADASTRAMENTO
            , :LK-GE051-IND-ERRO
            , :LK-GE051-MSG-ERRO
            , :LK-GE051-NOM-TABELA
            , :LK-GE051-SQLCODE
            , :LK-GE051-SQLERRMC
            )
            END-EXEC
            */
            #endregion
            IsProcedure = true;

            var query = @$"SEGUROS.SPBGE051";

            return query;
        }
        public string LK_GE051_TRACE { get; set; }
        public string LK_GE051_NUM_CPF_CNPJ { get; set; }
        public string LK_GE051_S_QTD_CNTR_PREST { get; set; }
        public string LK_GE051_S_VLR_IS_ACUM_PREST { get; set; }
        public string LK_GE051_S_DTH_CAD_PREST { get; set; }
        public string LK_GE051_S_QTD_CONTR_VIDA { get; set; }
        public string LK_GE051_S_VLR_IS_ACUM_VIDA { get; set; }
        public string LK_GE051_S_DTH_CAD_VIDA { get; set; }
        public string LK_GE051_S_QTD_CNTR_PREV { get; set; }
        public string LK_GE051_S_VLR_IS_ACUM_PREV { get; set; }
        public string LK_GE051_S_DTH_CAD_PREV { get; set; }
        public string LK_GE051_S_QTD_CONTR_HABIT { get; set; }
        public string LK_GE051_S_VLR_IS_ACUM_HABIT { get; set; }
        public string LK_GE051_S_DTH_CAD_HABIT { get; set; }
        public string LK_GE051_S_QTD_TOTAL_CNTR { get; set; }
        public string LK_GE051_S_VLR_TOTAL_CNTR { get; set; }
        public string LK_GE051_S_DTH_CADASTRAMENTO { get; set; }
        public string LK_GE051_IND_ERRO { get; set; }
        public string LK_GE051_MSG_ERRO { get; set; }
        public string LK_GE051_NOM_TABELA { get; set; }
        public string LK_GE051_SQLCODE { get; set; }
        public string LK_GE051_SQLERRMC { get; set; }

        public static SEGUROS_SPBGE051_Call1 Execute(SEGUROS_SPBGE051_Call1 sEGUROS_SPBGE051_Call1)
        {
            var ths = sEGUROS_SPBGE051_Call1;
            ths.SetQuery(ths.GetQuery());

            ths.Params = new
            {
                ths.LK_GE051_TRACE,
                ths.LK_GE051_NUM_CPF_CNPJ,
                ths.LK_GE051_S_QTD_CNTR_PREST,
                ths.LK_GE051_S_VLR_IS_ACUM_PREST,
                ths.LK_GE051_S_DTH_CAD_PREST,
                ths.LK_GE051_S_QTD_CONTR_VIDA,
                ths.LK_GE051_S_VLR_IS_ACUM_VIDA,
                ths.LK_GE051_S_DTH_CAD_VIDA,
                ths.LK_GE051_S_QTD_CNTR_PREV,
                ths.LK_GE051_S_VLR_IS_ACUM_PREV,
                ths.LK_GE051_S_DTH_CAD_PREV,
                ths.LK_GE051_S_QTD_CONTR_HABIT,
                ths.LK_GE051_S_VLR_IS_ACUM_HABIT,
                ths.LK_GE051_S_DTH_CAD_HABIT,
                ths.LK_GE051_S_QTD_TOTAL_CNTR,
                ths.LK_GE051_S_VLR_TOTAL_CNTR,
                ths.LK_GE051_S_DTH_CADASTRAMENTO,
                ths.LK_GE051_IND_ERRO,
                ths.LK_GE051_MSG_ERRO,
                ths.LK_GE051_NOM_TABELA,
                ths.LK_GE051_SQLCODE,
                ths.LK_GE051_SQLERRMC
            };

            ths.Open(ths.Params);
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override SEGUROS_SPBGE051_Call1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SEGUROS_SPBGE051_Call1();
            dta.LK_GE051_TRACE = result[0].Value?.ToString();
            dta.LK_GE051_NUM_CPF_CNPJ = result[1].Value?.ToString();
            dta.LK_GE051_S_QTD_CNTR_PREST = result[2].Value?.ToString();
            dta.LK_GE051_S_VLR_IS_ACUM_PREST = result[3].Value?.ToString();
            dta.LK_GE051_S_DTH_CAD_PREST = result[4].Value?.ToString();
            dta.LK_GE051_S_QTD_CONTR_VIDA = result[5].Value?.ToString();
            dta.LK_GE051_S_VLR_IS_ACUM_VIDA = result[6].Value?.ToString();
            dta.LK_GE051_S_DTH_CAD_VIDA = result[7].Value?.ToString();
            dta.LK_GE051_S_QTD_CNTR_PREV = result[8].Value?.ToString();
            dta.LK_GE051_S_VLR_IS_ACUM_PREV = result[9].Value?.ToString();
            dta.LK_GE051_S_DTH_CAD_PREV = result[10].Value?.ToString();
            dta.LK_GE051_S_QTD_CONTR_HABIT = result[11].Value?.ToString();
            dta.LK_GE051_S_VLR_IS_ACUM_HABIT = result[12].Value?.ToString();
            dta.LK_GE051_S_DTH_CAD_HABIT = result[13].Value?.ToString();
            dta.LK_GE051_S_QTD_TOTAL_CNTR = result[14].Value?.ToString();
            dta.LK_GE051_S_VLR_TOTAL_CNTR = result[15].Value?.ToString();
            dta.LK_GE051_S_DTH_CADASTRAMENTO = result[16].Value?.ToString();
            dta.LK_GE051_IND_ERRO = result[17].Value?.ToString();
            dta.LK_GE051_MSG_ERRO = result[18].Value?.ToString();
            dta.LK_GE051_NOM_TABELA = result[19].Value?.ToString();
            dta.LK_GE051_SQLCODE = result[20].Value?.ToString();
            dta.LK_GE051_SQLERRMC = result[21].Value?.ToString();
            return dta;
        }

    }
}