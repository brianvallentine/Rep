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
    public class R0050_00_INICIO_DB_SELECT_2_Query1 : QueryBasis<R0050_00_INICIO_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DTMOVABE
            INTO :V1SIST-DTMOVACB
            FROM SEGUROS.V1SISTEMA
            WHERE IDSISTEM = 'CB'
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DTMOVABE
											FROM SEGUROS.V1SISTEMA
											WHERE IDSISTEM = 'CB'
											WITH UR";

            return query;
        }
        public string V1SIST_DTMOVACB { get; set; }

        public static R0050_00_INICIO_DB_SELECT_2_Query1 Execute(R0050_00_INICIO_DB_SELECT_2_Query1 r0050_00_INICIO_DB_SELECT_2_Query1)
        {
            var ths = r0050_00_INICIO_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0050_00_INICIO_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0050_00_INICIO_DB_SELECT_2_Query1();
            var i = 0;
            dta.V1SIST_DTMOVACB = result[i++].Value?.ToString();
            return dta;
        }

    }
}