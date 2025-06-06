using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0124B
{
    public class R3003_00_IDENTIFICA_MOVIMENTO_DB_SELECT_1_Query1 : QueryBasis<R3003_00_IDENTIFICA_MOVIMENTO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT A.NUM_CERTIFICADO
            , A.NUM_PARCELA
            , A.OCORR_HISTORICOCTA
            , A.SIT_REGISTRO
            , A.TIPLANC
            INTO :HISLANCT-NUM-CERTIFICADO
            , :HISLANCT-NUM-PARCELA
            , :HISLANCT-OCORR-HISTORICOCTA
            , :HISLANCT-SIT-REGISTRO
            , :HISLANCT-TIPLANC
            FROM SEGUROS.HIST_LANC_CTA A
            WHERE A.NUM_CERTIFICADO = :HISLANCT-NUM-CERTIFICADO
            AND A.NUM_PARCELA = :HISLANCT-NUM-PARCELA
            AND A.OCORR_HISTORICOCTA =
            (SELECT MAX(B.OCORR_HISTORICOCTA)
            FROM SEGUROS.HIST_LANC_CTA B
            WHERE B.NUM_CERTIFICADO = A.NUM_CERTIFICADO
            AND B.NUM_PARCELA = A.NUM_PARCELA)
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT A.NUM_CERTIFICADO
											, A.NUM_PARCELA
											, A.OCORR_HISTORICOCTA
											, A.SIT_REGISTRO
											, A.TIPLANC
											FROM SEGUROS.HIST_LANC_CTA A
											WHERE A.NUM_CERTIFICADO = '{this.HISLANCT_NUM_CERTIFICADO}'
											AND A.NUM_PARCELA = '{this.HISLANCT_NUM_PARCELA}'
											AND A.OCORR_HISTORICOCTA =
											(SELECT MAX(B.OCORR_HISTORICOCTA)
											FROM SEGUROS.HIST_LANC_CTA B
											WHERE B.NUM_CERTIFICADO = A.NUM_CERTIFICADO
											AND B.NUM_PARCELA = A.NUM_PARCELA)
											WITH UR";

            return query;
        }
        public string HISLANCT_NUM_CERTIFICADO { get; set; }
        public string HISLANCT_NUM_PARCELA { get; set; }
        public string HISLANCT_OCORR_HISTORICOCTA { get; set; }
        public string HISLANCT_SIT_REGISTRO { get; set; }
        public string HISLANCT_TIPLANC { get; set; }

        public static R3003_00_IDENTIFICA_MOVIMENTO_DB_SELECT_1_Query1 Execute(R3003_00_IDENTIFICA_MOVIMENTO_DB_SELECT_1_Query1 r3003_00_IDENTIFICA_MOVIMENTO_DB_SELECT_1_Query1)
        {
            var ths = r3003_00_IDENTIFICA_MOVIMENTO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3003_00_IDENTIFICA_MOVIMENTO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3003_00_IDENTIFICA_MOVIMENTO_DB_SELECT_1_Query1();
            var i = 0;
            dta.HISLANCT_NUM_CERTIFICADO = result[i++].Value?.ToString();
            dta.HISLANCT_NUM_PARCELA = result[i++].Value?.ToString();
            dta.HISLANCT_OCORR_HISTORICOCTA = result[i++].Value?.ToString();
            dta.HISLANCT_SIT_REGISTRO = result[i++].Value?.ToString();
            dta.HISLANCT_TIPLANC = result[i++].Value?.ToString();
            return dta;
        }

    }
}