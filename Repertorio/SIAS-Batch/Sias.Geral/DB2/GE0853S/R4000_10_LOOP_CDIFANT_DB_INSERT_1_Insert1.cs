using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GE0853S
{
    public class R4000_10_LOOP_CDIFANT_DB_INSERT_1_Insert1 : QueryBasis<R4000_10_LOOP_CDIFANT_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0DIFPARCELVA
            VALUES (:V0HISC-NRCERTIF,
            :V0PROP-NRPARCEL,
            :V2DIFP-NRPARCDIF,
            :V2DIFP-CODOPER,
            :V0PARC-DTVENCTO,
            :V2DIFP-PRMVG,
            :V2DIFP-PRMAP,
            0,
            0,
            :V2DIFP-PRMVG,
            :V2DIFP-PRMAP,
            0,
            '1' )
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0DIFPARCELVA VALUES ({FieldThreatment(this.V0HISC_NRCERTIF)}, {FieldThreatment(this.V0PROP_NRPARCEL)}, {FieldThreatment(this.V2DIFP_NRPARCDIF)}, {FieldThreatment(this.V2DIFP_CODOPER)}, {FieldThreatment(this.V0PARC_DTVENCTO)}, {FieldThreatment(this.V2DIFP_PRMVG)}, {FieldThreatment(this.V2DIFP_PRMAP)}, 0, 0, {FieldThreatment(this.V2DIFP_PRMVG)}, {FieldThreatment(this.V2DIFP_PRMAP)}, 0, '1' )";

            return query;
        }
        public string V0HISC_NRCERTIF { get; set; }
        public string V0PROP_NRPARCEL { get; set; }
        public string V2DIFP_NRPARCDIF { get; set; }
        public string V2DIFP_CODOPER { get; set; }
        public string V0PARC_DTVENCTO { get; set; }
        public string V2DIFP_PRMVG { get; set; }
        public string V2DIFP_PRMAP { get; set; }

        public static void Execute(R4000_10_LOOP_CDIFANT_DB_INSERT_1_Insert1 r4000_10_LOOP_CDIFANT_DB_INSERT_1_Insert1)
        {
            var ths = r4000_10_LOOP_CDIFANT_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R4000_10_LOOP_CDIFANT_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}