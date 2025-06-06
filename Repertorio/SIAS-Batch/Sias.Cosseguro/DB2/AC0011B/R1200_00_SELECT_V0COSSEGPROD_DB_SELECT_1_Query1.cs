using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0011B
{
    public class R1200_00_SELECT_V0COSSEGPROD_DB_SELECT_1_Query1 : QueryBasis<R1200_00_SELECT_V0COSSEGPROD_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT PCADMCOS
            INTO :V0COSP-PCADMCOS
            FROM SEGUROS.V0COSSEGPROD
            WHERE CODPRODU = :V0APOL-CODPRODU
            AND RAMO = :V0APOL-RAMO
            AND CONGENER = :V1APCD-CODCOSS
            AND DTINIVIG <= :V0ENDO-DTINIVIG
            AND DTTERVIG >= :V0ENDO-DTINIVIG
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT PCADMCOS
											FROM SEGUROS.V0COSSEGPROD
											WHERE CODPRODU = '{this.V0APOL_CODPRODU}'
											AND RAMO = '{this.V0APOL_RAMO}'
											AND CONGENER = '{this.V1APCD_CODCOSS}'
											AND DTINIVIG <= '{this.V0ENDO_DTINIVIG}'
											AND DTTERVIG >= '{this.V0ENDO_DTINIVIG}'";

            return query;
        }
        public string V0COSP_PCADMCOS { get; set; }
        public string V0APOL_CODPRODU { get; set; }
        public string V0ENDO_DTINIVIG { get; set; }
        public string V1APCD_CODCOSS { get; set; }
        public string V0APOL_RAMO { get; set; }

        public static R1200_00_SELECT_V0COSSEGPROD_DB_SELECT_1_Query1 Execute(R1200_00_SELECT_V0COSSEGPROD_DB_SELECT_1_Query1 r1200_00_SELECT_V0COSSEGPROD_DB_SELECT_1_Query1)
        {
            var ths = r1200_00_SELECT_V0COSSEGPROD_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1200_00_SELECT_V0COSSEGPROD_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1200_00_SELECT_V0COSSEGPROD_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0COSP_PCADMCOS = result[i++].Value?.ToString();
            return dta;
        }

    }
}