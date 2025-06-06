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
    public class R8000_00_REPASSA_CDG_DB_INSERT_1_Insert1 : QueryBasis<R8000_00_REPASSA_CDG_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0REPASSECDG
            VALUES (:V0PROP-CODCLIEN,
            :V0RCDG-DTREFER,
            :V0CDGC-VLCUSTCDG,
            :V0HISC-NRCERTIF,
            :V2DIFP-NRPARCEL,
            '0' ,
            :V1SIST-DTMOVABE,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0REPASSECDG VALUES ({FieldThreatment(this.V0PROP_CODCLIEN)}, {FieldThreatment(this.V0RCDG_DTREFER)}, {FieldThreatment(this.V0CDGC_VLCUSTCDG)}, {FieldThreatment(this.V0HISC_NRCERTIF)}, {FieldThreatment(this.V2DIFP_NRPARCEL)}, '0' , {FieldThreatment(this.V1SIST_DTMOVABE)}, CURRENT TIMESTAMP)";

            return query;
        }
        public string V0PROP_CODCLIEN { get; set; }
        public string V0RCDG_DTREFER { get; set; }
        public string V0CDGC_VLCUSTCDG { get; set; }
        public string V0HISC_NRCERTIF { get; set; }
        public string V2DIFP_NRPARCEL { get; set; }
        public string V1SIST_DTMOVABE { get; set; }

        public static void Execute(R8000_00_REPASSA_CDG_DB_INSERT_1_Insert1 r8000_00_REPASSA_CDG_DB_INSERT_1_Insert1)
        {
            var ths = r8000_00_REPASSA_CDG_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R8000_00_REPASSA_CDG_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}