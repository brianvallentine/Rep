using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0716S
{
    public class SEGUROS_SPBVG012_Call1 : QueryBasis<SEGUROS_SPBVG012_Call1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            CALL SEGUROS.SPBVG012
            ( :LK-NUM-PLANO-FC12
            , :LK-NUM-PROPOSTA-FC12
            , :LK-COD-RAMO-FC12
            , :LK-TRACE-FC12
            , :LK-OUT-COD-RET-FC12
            , :LK-OUT-SQLCODE-FC12
            , :LK-OUT-MENSAGEM-FC12
            , :LK-OUT-SQLERRMC-FC12
            , :LK-OUT-SQLSTATE-FC12 )
            END-EXEC
            */
            #endregion
            IsProcedure = true;

            var query = @$"SEGUROS.SPBVG012";

            return query;
        }
        public string LK_NUM_PLANO_FC12 { get; set; }
        public string LK_NUM_PROPOSTA_FC12 { get; set; }
        public string LK_COD_RAMO_FC12 { get; set; }
        public string LK_TRACE_FC12 { get; set; }
        public string LK_OUT_COD_RET_FC12 { get; set; }
        public string LK_OUT_SQLCODE_FC12 { get; set; }
        public string LK_OUT_MENSAGEM_FC12 { get; set; }
        public string LK_OUT_SQLERRMC_FC12 { get; set; }
        public string LK_OUT_SQLSTATE_FC12 { get; set; }

        public static SEGUROS_SPBVG012_Call1 Execute(SEGUROS_SPBVG012_Call1 sEGUROS_SPBVG012_Call1)
        {
            var ths = sEGUROS_SPBVG012_Call1;
            ths.SetQuery(ths.GetQuery());

            ths.Params = new
            {
                ths.LK_NUM_PLANO_FC12,
                ths.LK_NUM_PROPOSTA_FC12,
                ths.LK_COD_RAMO_FC12,
                ths.LK_TRACE_FC12,
                ths.LK_OUT_COD_RET_FC12,
                ths.LK_OUT_SQLCODE_FC12,
                ths.LK_OUT_MENSAGEM_FC12,
                ths.LK_OUT_SQLERRMC_FC12,
                ths.LK_OUT_SQLSTATE_FC12
            };

            ths.Open(ths.Params);
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override SEGUROS_SPBVG012_Call1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SEGUROS_SPBVG012_Call1();
            dta.LK_NUM_PLANO_FC12 = result[0].Value?.ToString();
            dta.LK_NUM_PROPOSTA_FC12 = result[1].Value?.ToString();
            dta.LK_COD_RAMO_FC12 = result[2].Value?.ToString();
            dta.LK_TRACE_FC12 = result[3].Value?.ToString();
            dta.LK_OUT_COD_RET_FC12 = result[4].Value?.ToString();
            dta.LK_OUT_SQLCODE_FC12 = result[5].Value?.ToString();
            dta.LK_OUT_MENSAGEM_FC12 = result[6].Value?.ToString();
            dta.LK_OUT_SQLERRMC_FC12 = result[7].Value?.ToString();
            dta.LK_OUT_SQLSTATE_FC12 = result[8].Value?.ToString();
            return dta;
        }

    }
}