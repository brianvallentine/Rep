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
    public class R2100_00_GRAVA_DIFPARCEL_DB_INSERT_1_Insert1 : QueryBasis<R2100_00_GRAVA_DIFPARCEL_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0DIFPARCELVA
            VALUES (:V0HCOB-NRCERTIF,
            :V0HCOB-NRPARCELMAX,
            :V0PARC-NRPARCEL,
            :V0DIFP-CODOPER,
            :V0PARC-DTVENCTO,
            :V0PARC-PRMVG,
            :V0PARC-PRMAP,
            0,
            0,
            :V0PARC-PRMVG,
            :V0PARC-PRMAP,
            0,
            '1' )
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0DIFPARCELVA VALUES ({FieldThreatment(this.V0HCOB_NRCERTIF)}, {FieldThreatment(this.V0HCOB_NRPARCELMAX)}, {FieldThreatment(this.V0PARC_NRPARCEL)}, {FieldThreatment(this.V0DIFP_CODOPER)}, {FieldThreatment(this.V0PARC_DTVENCTO)}, {FieldThreatment(this.V0PARC_PRMVG)}, {FieldThreatment(this.V0PARC_PRMAP)}, 0, 0, {FieldThreatment(this.V0PARC_PRMVG)}, {FieldThreatment(this.V0PARC_PRMAP)}, 0, '1' )";

            return query;
        }
        public string V0HCOB_NRCERTIF { get; set; }
        public string V0HCOB_NRPARCELMAX { get; set; }
        public string V0PARC_NRPARCEL { get; set; }
        public string V0DIFP_CODOPER { get; set; }
        public string V0PARC_DTVENCTO { get; set; }
        public string V0PARC_PRMVG { get; set; }
        public string V0PARC_PRMAP { get; set; }

        public static void Execute(R2100_00_GRAVA_DIFPARCEL_DB_INSERT_1_Insert1 r2100_00_GRAVA_DIFPARCEL_DB_INSERT_1_Insert1)
        {
            var ths = r2100_00_GRAVA_DIFPARCEL_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2100_00_GRAVA_DIFPARCEL_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}