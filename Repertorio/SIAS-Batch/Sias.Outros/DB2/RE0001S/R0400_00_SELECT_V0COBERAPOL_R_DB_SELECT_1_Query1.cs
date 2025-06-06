using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.RE0001S
{
    public class R0400_00_SELECT_V0COBERAPOL_R_DB_SELECT_1_Query1 : QueryBasis<R0400_00_SELECT_V0COBERAPOL_R_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT
            VALUE(SUM(IMP_SEGURADA_IX),+0),
            VALUE(SUM(PRM_TARIFARIO_VAR),+0)
            INTO :V0COBA-IMP-IX-R,
            :V0COBA-PRM-VAR-R
            FROM SEGUROS.V0COBERAPOL
            WHERE NUM_APOLICE = :WHOST-NUM-APOL
            AND NRENDOS = :WHOST-NRENDOS
            AND NUM_ITEM = 0
            AND RAMOFR = :WHOST-RAMOFR
            AND COD_COBERTURA = 0
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											VALUE(SUM(IMP_SEGURADA_IX)
							,+0)
							,
											VALUE(SUM(PRM_TARIFARIO_VAR)
							,+0)
											FROM SEGUROS.V0COBERAPOL
											WHERE NUM_APOLICE = '{this.WHOST_NUM_APOL}'
											AND NRENDOS = '{this.WHOST_NRENDOS}'
											AND NUM_ITEM = 0
											AND RAMOFR = '{this.WHOST_RAMOFR}'
											AND COD_COBERTURA = 0
											WITH UR";

            return query;
        }
        public string V0COBA_IMP_IX_R { get; set; }
        public string V0COBA_PRM_VAR_R { get; set; }
        public string WHOST_NUM_APOL { get; set; }
        public string WHOST_NRENDOS { get; set; }
        public string WHOST_RAMOFR { get; set; }

        public static R0400_00_SELECT_V0COBERAPOL_R_DB_SELECT_1_Query1 Execute(R0400_00_SELECT_V0COBERAPOL_R_DB_SELECT_1_Query1 r0400_00_SELECT_V0COBERAPOL_R_DB_SELECT_1_Query1)
        {
            var ths = r0400_00_SELECT_V0COBERAPOL_R_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0400_00_SELECT_V0COBERAPOL_R_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0400_00_SELECT_V0COBERAPOL_R_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0COBA_IMP_IX_R = result[i++].Value?.ToString();
            dta.V0COBA_PRM_VAR_R = result[i++].Value?.ToString();
            return dta;
        }

    }
}