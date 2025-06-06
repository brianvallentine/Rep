using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0100B
{
    public class R1900_00_SELECT_V1RAMOIND_DB_SELECT_1_Query1 : QueryBasis<R1900_00_SELECT_V1RAMOIND_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT
            ISECUSTO, PCIOF
            INTO :V1RIND-ISECUSTO, :V1RIND-PCIOF
            FROM SEGUROS.V1RAMOIND
            WHERE RAMO = :V1APOL-RAMO
            AND DTINIVIG <= :V1RIND-DTINIVIG
            AND DTTERVIG >= :V1RIND-DTINIVIG
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											ISECUSTO
							, PCIOF
											FROM SEGUROS.V1RAMOIND
											WHERE RAMO = '{this.V1APOL_RAMO}'
											AND DTINIVIG <= '{this.V1RIND_DTINIVIG}'
											AND DTTERVIG >= '{this.V1RIND_DTINIVIG}'";

            return query;
        }
        public string V1RIND_ISECUSTO { get; set; }
        public string V1RIND_PCIOF { get; set; }
        public string V1RIND_DTINIVIG { get; set; }
        public string V1APOL_RAMO { get; set; }

        public static R1900_00_SELECT_V1RAMOIND_DB_SELECT_1_Query1 Execute(R1900_00_SELECT_V1RAMOIND_DB_SELECT_1_Query1 r1900_00_SELECT_V1RAMOIND_DB_SELECT_1_Query1)
        {
            var ths = r1900_00_SELECT_V1RAMOIND_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1900_00_SELECT_V1RAMOIND_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1900_00_SELECT_V1RAMOIND_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1RIND_ISECUSTO = result[i++].Value?.ToString();
            dta.V1RIND_PCIOF = result[i++].Value?.ToString();
            return dta;
        }

    }
}