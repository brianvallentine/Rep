using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA2513B
{
    public class R2750_00_SELECT_V0CONDTEC_DB_SELECT_1_Query1 : QueryBasis<R2750_00_SELECT_V0CONDTEC_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT CARREGA_CONJUGE
            INTO :V0COND-CAR-CONJUGE
            FROM SEGUROS.V0CONDTEC
            WHERE NUM_APOLICE = :WHOST-NRAPOLICE
            AND COD_SUBGRUPO = :WHOST-CODSUBES
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT CARREGA_CONJUGE
											FROM SEGUROS.V0CONDTEC
											WHERE NUM_APOLICE = '{this.WHOST_NRAPOLICE}'
											AND COD_SUBGRUPO = '{this.WHOST_CODSUBES}'";

            return query;
        }
        public string V0COND_CAR_CONJUGE { get; set; }
        public string WHOST_NRAPOLICE { get; set; }
        public string WHOST_CODSUBES { get; set; }

        public static R2750_00_SELECT_V0CONDTEC_DB_SELECT_1_Query1 Execute(R2750_00_SELECT_V0CONDTEC_DB_SELECT_1_Query1 r2750_00_SELECT_V0CONDTEC_DB_SELECT_1_Query1)
        {
            var ths = r2750_00_SELECT_V0CONDTEC_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2750_00_SELECT_V0CONDTEC_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2750_00_SELECT_V0CONDTEC_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0COND_CAR_CONJUGE = result[i++].Value?.ToString();
            return dta;
        }

    }
}