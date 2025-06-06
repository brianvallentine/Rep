using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0850B
{
    public class R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1 : QueryBasis<R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NRTIT,
            OPCAOPAG
            INTO :V0HCOB-NRTIT,
            :V0HCOB-OPCAOPAG
            FROM SEGUROS.V0HISTCOBVA
            WHERE NRCERTIF = :V0HCOB-NRCERTIF
            AND NRPARCEL = :V0HCOB-NRPARCELMAX
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NRTIT
							,
											OPCAOPAG
											FROM SEGUROS.V0HISTCOBVA
											WHERE NRCERTIF = '{this.V0HCOB_NRCERTIF}'
											AND NRPARCEL = '{this.V0HCOB_NRPARCELMAX}'";

            return query;
        }
        public string V0HCOB_NRTIT { get; set; }
        public string V0HCOB_OPCAOPAG { get; set; }
        public string V0HCOB_NRPARCELMAX { get; set; }
        public string V0HCOB_NRCERTIF { get; set; }

        public static R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1 Execute(R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1 r1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1)
        {
            var ths = r1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1();
            var i = 0;
            dta.V0HCOB_NRTIT = result[i++].Value?.ToString();
            dta.V0HCOB_OPCAOPAG = result[i++].Value?.ToString();
            return dta;
        }

    }
}