using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE0030B
{
    public class R0390_00_LER_V0FUNCIOCEF_DB_SELECT_1_Query1 : QueryBasis<R0390_00_LER_V0FUNCIOCEF_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_MATRICULA,
            COD_ANGARIADOR
            INTO :V1FUNC-NUM-MATRIC,
            :V1FUNC-COD-ANGARIA
            FROM SEGUROS.V1FUNCIOCEF
            WHERE NUM_MATRICULA = :V1FUNC-NUM-MATRIC
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_MATRICULA
							,
											COD_ANGARIADOR
											FROM SEGUROS.V1FUNCIOCEF
											WHERE NUM_MATRICULA = '{this.V1FUNC_NUM_MATRIC}'
											WITH UR";

            return query;
        }
        public string V1FUNC_NUM_MATRIC { get; set; }
        public string V1FUNC_COD_ANGARIA { get; set; }

        public static R0390_00_LER_V0FUNCIOCEF_DB_SELECT_1_Query1 Execute(R0390_00_LER_V0FUNCIOCEF_DB_SELECT_1_Query1 r0390_00_LER_V0FUNCIOCEF_DB_SELECT_1_Query1)
        {
            var ths = r0390_00_LER_V0FUNCIOCEF_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0390_00_LER_V0FUNCIOCEF_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0390_00_LER_V0FUNCIOCEF_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1FUNC_NUM_MATRIC = result[i++].Value?.ToString();
            dta.V1FUNC_COD_ANGARIA = result[i++].Value?.ToString();
            return dta;
        }

    }
}