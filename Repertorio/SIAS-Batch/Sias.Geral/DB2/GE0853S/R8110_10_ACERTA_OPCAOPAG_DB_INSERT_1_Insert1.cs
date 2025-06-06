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
    public class R8110_10_ACERTA_OPCAOPAG_DB_INSERT_1_Insert1 : QueryBasis<R8110_10_ACERTA_OPCAOPAG_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0DIFPARCELVA
            VALUES (:V0HISC-NRCERTIF,
            9999,
            :V0HISC-NRPARCEL,
            :V4DIFP-CODOPER,
            :V0PARC-DTVENCTO,
            :DEVIDO-PRMVG,
            :DEVIDO-PRMAP,
            0,
            0,
            :DEVIDO-PRMVG,
            :DEVIDO-PRMAP,
            0,
            ' ' )
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0DIFPARCELVA VALUES ({FieldThreatment(this.V0HISC_NRCERTIF)}, 9999, {FieldThreatment(this.V0HISC_NRPARCEL)}, {FieldThreatment(this.V4DIFP_CODOPER)}, {FieldThreatment(this.V0PARC_DTVENCTO)}, {FieldThreatment(this.DEVIDO_PRMVG)}, {FieldThreatment(this.DEVIDO_PRMAP)}, 0, 0, {FieldThreatment(this.DEVIDO_PRMVG)}, {FieldThreatment(this.DEVIDO_PRMAP)}, 0, ' ' )";

            return query;
        }
        public string V0HISC_NRCERTIF { get; set; }
        public string V0HISC_NRPARCEL { get; set; }
        public string V4DIFP_CODOPER { get; set; }
        public string V0PARC_DTVENCTO { get; set; }
        public string DEVIDO_PRMVG { get; set; }
        public string DEVIDO_PRMAP { get; set; }

        public static void Execute(R8110_10_ACERTA_OPCAOPAG_DB_INSERT_1_Insert1 r8110_10_ACERTA_OPCAOPAG_DB_INSERT_1_Insert1)
        {
            var ths = r8110_10_ACERTA_OPCAOPAG_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R8110_10_ACERTA_OPCAOPAG_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}