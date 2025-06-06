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
    public class R2100_00_GRAVA_DIFPARCEL_DB_DELETE_1_Delete1 : QueryBasis<R2100_00_GRAVA_DIFPARCEL_DB_DELETE_1_Delete1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            DELETE FROM SEGUROS.V0DIFPARCELVA
            WHERE NRCERTIF = :V0HCOB-NRCERTIF
            AND NRPARCEL = :V0HCOB-NRPARCELMAX
            AND NRPARCELDIF = :V0PARC-NRPARCEL
            AND CODOPER = :V0DIFP-CODOPER
            END-EXEC
            */
            #endregion
            var query = @$"
				DELETE FROM SEGUROS.V0DIFPARCELVA
				WHERE NRCERTIF = '{this.V0HCOB_NRCERTIF}'
				AND NRPARCEL = '{this.V0HCOB_NRPARCELMAX}'
				AND NRPARCELDIF = '{this.V0PARC_NRPARCEL}'
				AND CODOPER = '{this.V0DIFP_CODOPER}'";

            return query;
        }
        public string V0HCOB_NRCERTIF { get; set; }
        public string V0HCOB_NRPARCELMAX { get; set; }
        public string V0PARC_NRPARCEL { get; set; }
        public string V0DIFP_CODOPER { get; set; }

        public static void Execute(R2100_00_GRAVA_DIFPARCEL_DB_DELETE_1_Delete1 r2100_00_GRAVA_DIFPARCEL_DB_DELETE_1_Delete1)
        {
            var ths = r2100_00_GRAVA_DIFPARCEL_DB_DELETE_1_Delete1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2100_00_GRAVA_DIFPARCEL_DB_DELETE_1_Delete1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}