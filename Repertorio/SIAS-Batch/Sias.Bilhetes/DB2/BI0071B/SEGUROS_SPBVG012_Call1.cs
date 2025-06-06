using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0071B
{
    public class SEGUROS_SPBVG012_Call1 : QueryBasis<SEGUROS_SPBVG012_Call1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            CALL SEGUROS.SPBVG012
            ( :LK-NUM-PLANO
            , :LK-NUM-PROPOSTA
            , :LK-COD-RAMO
            , :LK-TRACE
            , :LK-OUT-COD-RETORNO
            , :LK-OUT-SQLCODE
            , :LK-OUT-MENSAGEM
            , :LK-OUT-SQLERRMC
            , :LK-OUT-SQLSTATE )
            END-EXEC.
            */
            #endregion
            IsProcedure = true;

            var query = @$"SEGUROS.SPBVG012";

            return query;
        }
        public string LK_NUM_PLANO { get; set; }
        public string LK_NUM_PROPOSTA { get; set; }
        public string LK_COD_RAMO { get; set; }
        public string LK_TRACE { get; set; }
        public string LK_OUT_COD_RETORNO { get; set; }
        public string LK_OUT_SQLCODE { get; set; }
        public string LK_OUT_MENSAGEM { get; set; }
        public string LK_OUT_SQLERRMC { get; set; }
        public string LK_OUT_SQLSTATE { get; set; }

        public static SEGUROS_SPBVG012_Call1 Execute(SEGUROS_SPBVG012_Call1 sEGUROS_SPBVG012_Call1)
        {
            var ths = sEGUROS_SPBVG012_Call1;
            ths.SetQuery(ths.GetQuery());

            ths.Params = new
            {
                ths.LK_NUM_PLANO,
                ths.LK_NUM_PROPOSTA,
                ths.LK_COD_RAMO,
                ths.LK_TRACE,
                ths.LK_OUT_COD_RETORNO,
                ths.LK_OUT_SQLCODE,
                ths.LK_OUT_MENSAGEM,
                ths.LK_OUT_SQLERRMC,
                ths.LK_OUT_SQLSTATE
            };

            ths.Open(ths.Params);
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override SEGUROS_SPBVG012_Call1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SEGUROS_SPBVG012_Call1();
            dta.LK_NUM_PLANO = result[0].Value?.ToString();
            dta.LK_NUM_PROPOSTA = result[1].Value?.ToString();
            dta.LK_COD_RAMO = result[2].Value?.ToString();
            dta.LK_TRACE = result[3].Value?.ToString();
            dta.LK_OUT_COD_RETORNO = result[4].Value?.ToString();
            dta.LK_OUT_SQLCODE = result[5].Value?.ToString();
            dta.LK_OUT_MENSAGEM = result[6].Value?.ToString();
            dta.LK_OUT_SQLERRMC = result[7].Value?.ToString();
            dta.LK_OUT_SQLSTATE = result[8].Value?.ToString();
            return dta;
        }

    }
}