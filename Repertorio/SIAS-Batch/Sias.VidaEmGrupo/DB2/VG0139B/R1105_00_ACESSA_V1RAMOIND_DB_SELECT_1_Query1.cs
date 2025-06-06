using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0139B
{
    public class R1105_00_ACESSA_V1RAMOIND_DB_SELECT_1_Query1 : QueryBasis<R1105_00_ACESSA_V1RAMOIND_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT
            PCIOF
            INTO :V1RIND-PCIOF
            FROM SEGUROS.V1RAMOIND
            WHERE RAMO = :V1RIND-RAMO
            AND DTINIVIG <= :V1RIND-DTINIVIG
            AND DTTERVIG >= :V1RIND-DTINIVIG
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											PCIOF
											FROM SEGUROS.V1RAMOIND
											WHERE RAMO = '{this.V1RIND_RAMO}'
											AND DTINIVIG <= '{this.V1RIND_DTINIVIG}'
											AND DTTERVIG >= '{this.V1RIND_DTINIVIG}'
											WITH UR";

            return query;
        }
        public string V1RIND_PCIOF { get; set; }
        public string V1RIND_DTINIVIG { get; set; }
        public string V1RIND_RAMO { get; set; }

        public static R1105_00_ACESSA_V1RAMOIND_DB_SELECT_1_Query1 Execute(R1105_00_ACESSA_V1RAMOIND_DB_SELECT_1_Query1 r1105_00_ACESSA_V1RAMOIND_DB_SELECT_1_Query1)
        {
            var ths = r1105_00_ACESSA_V1RAMOIND_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1105_00_ACESSA_V1RAMOIND_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1105_00_ACESSA_V1RAMOIND_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1RIND_PCIOF = result[i++].Value?.ToString();
            return dta;
        }

    }
}