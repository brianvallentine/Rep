using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP0118B
{
    public class R0820_00_INSERT_CDG_DB_INSERT_1_Insert1 : QueryBasis<R0820_00_INSERT_CDG_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0CDGCOBER
            VALUES (:V0PROP-CODCLIEN,
            :HOST-DTINIVIG,
            :HOST-DTTERVIG,
            :HOST-IMPSEGCDC-NEW,
            :HOST-VLCUSTCDG,
            :V0PROP-NRCERTIF,
            :HOST-OCORHIST,
            '0' ,
            'VP0118B' ,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0CDGCOBER VALUES ({FieldThreatment(this.V0PROP_CODCLIEN)}, {FieldThreatment(this.HOST_DTINIVIG)}, {FieldThreatment(this.HOST_DTTERVIG)}, {FieldThreatment(this.HOST_IMPSEGCDC_NEW)}, {FieldThreatment(this.HOST_VLCUSTCDG)}, {FieldThreatment(this.V0PROP_NRCERTIF)}, {FieldThreatment(this.HOST_OCORHIST)}, '0' , 'VP0118B' , CURRENT TIMESTAMP)";

            return query;
        }
        public string V0PROP_CODCLIEN { get; set; }
        public string HOST_DTINIVIG { get; set; }
        public string HOST_DTTERVIG { get; set; }
        public string HOST_IMPSEGCDC_NEW { get; set; }
        public string HOST_VLCUSTCDG { get; set; }
        public string V0PROP_NRCERTIF { get; set; }
        public string HOST_OCORHIST { get; set; }

        public static void Execute(R0820_00_INSERT_CDG_DB_INSERT_1_Insert1 r0820_00_INSERT_CDG_DB_INSERT_1_Insert1)
        {
            var ths = r0820_00_INSERT_CDG_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0820_00_INSERT_CDG_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}