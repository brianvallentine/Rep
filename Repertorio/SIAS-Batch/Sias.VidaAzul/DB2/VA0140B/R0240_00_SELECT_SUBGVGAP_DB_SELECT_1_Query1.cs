using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0140B
{
    public class R0240_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1 : QueryBasis<R0240_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT IND_IOF
            INTO :SUBGVGAP-IND-IOF:VIND-NULL04
            FROM SEGUROS.SUBGRUPOS_VGAP
            WHERE NUM_APOLICE = :HISCONPA-NUM-APOLICE
            AND COD_SUBGRUPO = :HISCONPA-COD-SUBGRUPO
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT IND_IOF
											FROM SEGUROS.SUBGRUPOS_VGAP
											WHERE NUM_APOLICE = '{this.HISCONPA_NUM_APOLICE}'
											AND COD_SUBGRUPO = '{this.HISCONPA_COD_SUBGRUPO}'
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string SUBGVGAP_IND_IOF { get; set; }
        public string VIND_NULL04 { get; set; }
        public string HISCONPA_COD_SUBGRUPO { get; set; }
        public string HISCONPA_NUM_APOLICE { get; set; }

        public static R0240_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1 Execute(R0240_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1 r0240_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1)
        {
            var ths = r0240_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0240_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0240_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1();
            var i = 0;
            dta.SUBGVGAP_IND_IOF = result[i++].Value?.ToString();
            dta.VIND_NULL04 = string.IsNullOrWhiteSpace(dta.SUBGVGAP_IND_IOF) ? "-1" : "0";
            return dta;
        }

    }
}