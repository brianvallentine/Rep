using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG4267B
{
    public class R1510_00_SELECT_V0OPCAOPAGVA_DB_SELECT_1_Query1 : QueryBasis<R1510_00_SELECT_V0OPCAOPAGVA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT PERIPGTO
            INTO :V0OPCP-PERIPGTO
            FROM SEGUROS.V0OPCAOPAGVA
            WHERE NRCERTIF = :V0HIST-NRCERTIF
            AND DTTERVIG = '9999-12-31'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT PERIPGTO
											FROM SEGUROS.V0OPCAOPAGVA
											WHERE NRCERTIF = '{this.V0HIST_NRCERTIF}'
											AND DTTERVIG = '9999-12-31'";

            return query;
        }
        public string V0OPCP_PERIPGTO { get; set; }
        public string V0HIST_NRCERTIF { get; set; }

        public static R1510_00_SELECT_V0OPCAOPAGVA_DB_SELECT_1_Query1 Execute(R1510_00_SELECT_V0OPCAOPAGVA_DB_SELECT_1_Query1 r1510_00_SELECT_V0OPCAOPAGVA_DB_SELECT_1_Query1)
        {
            var ths = r1510_00_SELECT_V0OPCAOPAGVA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1510_00_SELECT_V0OPCAOPAGVA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1510_00_SELECT_V0OPCAOPAGVA_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0OPCP_PERIPGTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}