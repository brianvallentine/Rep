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
    public class R1100_00_SUM_MR_APOL_COBT_DB_SELECT_1_Query1 : QueryBasis<R1100_00_SUM_MR_APOL_COBT_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT
            VALUE(SUM(PRM_TARIFARIO_VAR),+0)
            INTO :MRAPCOB-PRM-TAR-VAR
            FROM SEGUROS.MR_APOLICE_COBER
            WHERE NUM_APOLICE = :V0HISP-NUM-APOL
            AND NUM_ENDOSSO = :V0HISP-NRENDOS
            AND RAMO_COBERTURA = :V0APOL-RAMO
            AND COD_COBERTURA = 099
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											VALUE(SUM(PRM_TARIFARIO_VAR)
							,+0)
											FROM SEGUROS.MR_APOLICE_COBER
											WHERE NUM_APOLICE = '{this.V0HISP_NUM_APOL}'
											AND NUM_ENDOSSO = '{this.V0HISP_NRENDOS}'
											AND RAMO_COBERTURA = '{this.V0APOL_RAMO}'
											AND COD_COBERTURA = 099";

            return query;
        }
        public string MRAPCOB_PRM_TAR_VAR { get; set; }
        public string V0HISP_NUM_APOL { get; set; }
        public string V0HISP_NRENDOS { get; set; }
        public string V0APOL_RAMO { get; set; }

        public static R1100_00_SUM_MR_APOL_COBT_DB_SELECT_1_Query1 Execute(R1100_00_SUM_MR_APOL_COBT_DB_SELECT_1_Query1 r1100_00_SUM_MR_APOL_COBT_DB_SELECT_1_Query1)
        {
            var ths = r1100_00_SUM_MR_APOL_COBT_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1100_00_SUM_MR_APOL_COBT_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1100_00_SUM_MR_APOL_COBT_DB_SELECT_1_Query1();
            var i = 0;
            dta.MRAPCOB_PRM_TAR_VAR = result[i++].Value?.ToString();
            return dta;
        }

    }
}