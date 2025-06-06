using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0469B
{
    public class R1110_00_SELECT_HISLANCT_DB_SELECT_1_Query1 : QueryBasis<R1110_00_SELECT_HISLANCT_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(COUNT(*),0)
            INTO :WQTD-QTD
            FROM SEGUROS.HIST_LANC_CTA
            WHERE NUM_CERTIFICADO = :RELATORI-NUM-CERTIFICADO
            AND NUM_PARCELA = :RELATORI-NUM-PARCELA
            AND SIT_REGISTRO = '3'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(COUNT(*)
							,0)
											FROM SEGUROS.HIST_LANC_CTA
											WHERE NUM_CERTIFICADO = '{this.RELATORI_NUM_CERTIFICADO}'
											AND NUM_PARCELA = '{this.RELATORI_NUM_PARCELA}'
											AND SIT_REGISTRO = '3'";

            return query;
        }
        public string WQTD_QTD { get; set; }
        public string RELATORI_NUM_CERTIFICADO { get; set; }
        public string RELATORI_NUM_PARCELA { get; set; }

        public static R1110_00_SELECT_HISLANCT_DB_SELECT_1_Query1 Execute(R1110_00_SELECT_HISLANCT_DB_SELECT_1_Query1 r1110_00_SELECT_HISLANCT_DB_SELECT_1_Query1)
        {
            var ths = r1110_00_SELECT_HISLANCT_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1110_00_SELECT_HISLANCT_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1110_00_SELECT_HISLANCT_DB_SELECT_1_Query1();
            var i = 0;
            dta.WQTD_QTD = result[i++].Value?.ToString();
            return dta;
        }

    }
}