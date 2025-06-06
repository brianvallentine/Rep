using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0930B
{
    public class R1080_SELECT_NRCERTIF_APOL_DB_SELECT_1_Query1 : QueryBasis<R1080_SELECT_NRCERTIF_APOL_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_CLIENTE
            INTO :SUBGRU-COD-CLIENTE
            FROM SEGUROS.SUBGRUPOS_VGAP
            WHERE NUM_APOLICE = :WS-NUM-APOLICE
            AND COD_SUBGRUPO = :WS-COD-SUBGRUPO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_CLIENTE
											FROM SEGUROS.SUBGRUPOS_VGAP
											WHERE NUM_APOLICE = '{this.WS_NUM_APOLICE}'
											AND COD_SUBGRUPO = '{this.WS_COD_SUBGRUPO}'
											WITH UR";

            return query;
        }
        public string SUBGRU_COD_CLIENTE { get; set; }
        public string WS_COD_SUBGRUPO { get; set; }
        public string WS_NUM_APOLICE { get; set; }

        public static R1080_SELECT_NRCERTIF_APOL_DB_SELECT_1_Query1 Execute(R1080_SELECT_NRCERTIF_APOL_DB_SELECT_1_Query1 r1080_SELECT_NRCERTIF_APOL_DB_SELECT_1_Query1)
        {
            var ths = r1080_SELECT_NRCERTIF_APOL_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1080_SELECT_NRCERTIF_APOL_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1080_SELECT_NRCERTIF_APOL_DB_SELECT_1_Query1();
            var i = 0;
            dta.SUBGRU_COD_CLIENTE = result[i++].Value?.ToString();
            return dta;
        }

    }
}