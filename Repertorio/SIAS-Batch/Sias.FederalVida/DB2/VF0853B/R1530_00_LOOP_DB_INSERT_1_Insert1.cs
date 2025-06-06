using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.FederalVida.DB2.VF0853B
{
    public class R1530_00_LOOP_DB_INSERT_1_Insert1 : QueryBasis<R1530_00_LOOP_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0DIFPARCELVA
            VALUES (:V0PROP-NRCERTIF,
            9999,
            :V0DIFP-NRPARCEL,
            :V3DIFP-CODOPER,
            :V0DIFP-DTVENCTO,
            :V0DIFP-PRMDIFVG,
            :V0DIFP-PRMDIFAP,
            0,
            0,
            :V0DIFP-PRMDIFVG,
            :V0DIFP-PRMDIFAP,
            0,
            ' ' )
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0DIFPARCELVA VALUES ({FieldThreatment(this.V0PROP_NRCERTIF)}, 9999, {FieldThreatment(this.V0DIFP_NRPARCEL)}, {FieldThreatment(this.V3DIFP_CODOPER)}, {FieldThreatment(this.V0DIFP_DTVENCTO)}, {FieldThreatment(this.V0DIFP_PRMDIFVG)}, {FieldThreatment(this.V0DIFP_PRMDIFAP)}, 0, 0, {FieldThreatment(this.V0DIFP_PRMDIFVG)}, {FieldThreatment(this.V0DIFP_PRMDIFAP)}, 0, ' ' )";

            return query;
        }
        public string V0PROP_NRCERTIF { get; set; }
        public string V0DIFP_NRPARCEL { get; set; }
        public string V3DIFP_CODOPER { get; set; }
        public string V0DIFP_DTVENCTO { get; set; }
        public string V0DIFP_PRMDIFVG { get; set; }
        public string V0DIFP_PRMDIFAP { get; set; }

        public static void Execute(R1530_00_LOOP_DB_INSERT_1_Insert1 r1530_00_LOOP_DB_INSERT_1_Insert1)
        {
            var ths = r1530_00_LOOP_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1530_00_LOOP_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}