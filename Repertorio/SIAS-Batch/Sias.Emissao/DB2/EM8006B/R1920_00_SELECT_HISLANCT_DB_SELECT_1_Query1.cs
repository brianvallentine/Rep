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
    public class R1920_00_SELECT_HISLANCT_DB_SELECT_1_Query1 : QueryBasis<R1920_00_SELECT_HISLANCT_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NSL
            INTO :HISLANCT-NSL:WS-NULL1
            FROM SEGUROS.HIST_LANC_CTA
            WHERE NUM_CERTIFICADO = :HISLANCT-NUM-CERTIFICADO
            AND NUM_PARCELA = :HISLANCT-NUM-PARCELA
            AND CODCONV = :HISLANCT-CODCONV
            AND NSAS = :HISLANCT-NSAS
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NSL
											FROM SEGUROS.HIST_LANC_CTA
											WHERE NUM_CERTIFICADO = '{this.HISLANCT_NUM_CERTIFICADO}'
											AND NUM_PARCELA = '{this.HISLANCT_NUM_PARCELA}'
											AND CODCONV = '{this.HISLANCT_CODCONV}'
											AND NSAS = '{this.HISLANCT_NSAS}'
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string HISLANCT_NSL { get; set; }
        public string WS_NULL1 { get; set; }
        public string HISLANCT_NUM_CERTIFICADO { get; set; }
        public string HISLANCT_NUM_PARCELA { get; set; }
        public string HISLANCT_CODCONV { get; set; }
        public string HISLANCT_NSAS { get; set; }

        public static R1920_00_SELECT_HISLANCT_DB_SELECT_1_Query1 Execute(R1920_00_SELECT_HISLANCT_DB_SELECT_1_Query1 r1920_00_SELECT_HISLANCT_DB_SELECT_1_Query1)
        {
            var ths = r1920_00_SELECT_HISLANCT_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1920_00_SELECT_HISLANCT_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1920_00_SELECT_HISLANCT_DB_SELECT_1_Query1();
            var i = 0;
            dta.HISLANCT_NSL = result[i++].Value?.ToString();
            dta.WS_NULL1 = string.IsNullOrWhiteSpace(dta.HISLANCT_NSL) ? "-1" : "0";
            return dta;
        }

    }
}