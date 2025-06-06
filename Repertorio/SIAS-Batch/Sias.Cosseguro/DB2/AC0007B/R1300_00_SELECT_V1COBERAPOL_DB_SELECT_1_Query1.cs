using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0007B
{
    public class R1300_00_SELECT_V1COBERAPOL_DB_SELECT_1_Query1 : QueryBasis<R1300_00_SELECT_V1COBERAPOL_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT
            VALUE(SUM(PRM_TARIFARIO_VAR),+0)
            INTO :V1COBA-PRM-TAR-VAR
            FROM SEGUROS.V1COBERAPOL
            WHERE NUM_APOLICE = :V0HISP-NUM-APOL
            AND NRENDOS = :V0HISP-NRENDOS
            AND NUM_ITEM = 00
            AND RAMOFR = 81
            AND MODALIFR = 00
            AND COD_COBERTURA = 05
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											VALUE(SUM(PRM_TARIFARIO_VAR)
							,+0)
											FROM SEGUROS.V1COBERAPOL
											WHERE NUM_APOLICE = '{this.V0HISP_NUM_APOL}'
											AND NRENDOS = '{this.V0HISP_NRENDOS}'
											AND NUM_ITEM = 00
											AND RAMOFR = 81
											AND MODALIFR = 00
											AND COD_COBERTURA = 05";

            return query;
        }
        public string V1COBA_PRM_TAR_VAR { get; set; }
        public string V0HISP_NUM_APOL { get; set; }
        public string V0HISP_NRENDOS { get; set; }

        public static R1300_00_SELECT_V1COBERAPOL_DB_SELECT_1_Query1 Execute(R1300_00_SELECT_V1COBERAPOL_DB_SELECT_1_Query1 r1300_00_SELECT_V1COBERAPOL_DB_SELECT_1_Query1)
        {
            var ths = r1300_00_SELECT_V1COBERAPOL_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1300_00_SELECT_V1COBERAPOL_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1300_00_SELECT_V1COBERAPOL_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1COBA_PRM_TAR_VAR = result[i++].Value?.ToString();
            return dta;
        }

    }
}