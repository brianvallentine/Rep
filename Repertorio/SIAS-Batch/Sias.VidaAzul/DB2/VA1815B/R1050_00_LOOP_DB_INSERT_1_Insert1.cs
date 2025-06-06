using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA1815B
{
    public class R1050_00_LOOP_DB_INSERT_1_Insert1 : QueryBasis<R1050_00_LOOP_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0DIFPARCELVA
            VALUES (:V0HCTA-NRCERTIF,
            9999,
            :V0DIFP-NRPARCEL,
            :V0DIFP-CODOPER,
            :V0PARC-DTVENCTO,
            :V0DIFP-PRMDEVVG,
            :V0DIFP-PRMDEVAP,
            :V0DIFP-PRMPAGVG,
            :V0DIFP-PRMPAGAP,
            :V0DIFP-PRMDIFVG,
            :V0DIFP-PRMDIFAP,
            0,
            ' ' )
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0DIFPARCELVA VALUES ({FieldThreatment(this.V0HCTA_NRCERTIF)}, 9999, {FieldThreatment(this.V0DIFP_NRPARCEL)}, {FieldThreatment(this.V0DIFP_CODOPER)}, {FieldThreatment(this.V0PARC_DTVENCTO)}, {FieldThreatment(this.V0DIFP_PRMDEVVG)}, {FieldThreatment(this.V0DIFP_PRMDEVAP)}, {FieldThreatment(this.V0DIFP_PRMPAGVG)}, {FieldThreatment(this.V0DIFP_PRMPAGAP)}, {FieldThreatment(this.V0DIFP_PRMDIFVG)}, {FieldThreatment(this.V0DIFP_PRMDIFAP)}, 0, ' ' )";

            return query;
        }
        public string V0HCTA_NRCERTIF { get; set; }
        public string V0DIFP_NRPARCEL { get; set; }
        public string V0DIFP_CODOPER { get; set; }
        public string V0PARC_DTVENCTO { get; set; }
        public string V0DIFP_PRMDEVVG { get; set; }
        public string V0DIFP_PRMDEVAP { get; set; }
        public string V0DIFP_PRMPAGVG { get; set; }
        public string V0DIFP_PRMPAGAP { get; set; }
        public string V0DIFP_PRMDIFVG { get; set; }
        public string V0DIFP_PRMDIFAP { get; set; }

        public static void Execute(R1050_00_LOOP_DB_INSERT_1_Insert1 r1050_00_LOOP_DB_INSERT_1_Insert1)
        {
            var ths = r1050_00_LOOP_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1050_00_LOOP_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}