using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA5421B
{
    public class R150_REABI_VIG_CDG_DB_INSERT_1_Insert1 : QueryBasis<R150_REABI_VIG_CDG_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0CDGCOBER
            VALUES (:V0PROP-CODCLIEN,
            :V0HSEG-DTREABI,
            '9999-12-31' ,
            :V0COBV-IMPSEGCDG,
            :V0COBV-VLCUSTCDG,
            :V0PROP-NRCERTIF,
            :V0CDGC-OCORHIST,
            '0' ,
            'VA5421B' ,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0CDGCOBER VALUES ({FieldThreatment(this.V0PROP_CODCLIEN)}, {FieldThreatment(this.V0HSEG_DTREABI)}, '9999-12-31' , {FieldThreatment(this.V0COBV_IMPSEGCDG)}, {FieldThreatment(this.V0COBV_VLCUSTCDG)}, {FieldThreatment(this.V0PROP_NRCERTIF)}, {FieldThreatment(this.V0CDGC_OCORHIST)}, '0' , 'VA5421B' , CURRENT TIMESTAMP)";

            return query;
        }
        public string V0PROP_CODCLIEN { get; set; }
        public string V0HSEG_DTREABI { get; set; }
        public string V0COBV_IMPSEGCDG { get; set; }
        public string V0COBV_VLCUSTCDG { get; set; }
        public string V0PROP_NRCERTIF { get; set; }
        public string V0CDGC_OCORHIST { get; set; }

        public static void Execute(R150_REABI_VIG_CDG_DB_INSERT_1_Insert1 r150_REABI_VIG_CDG_DB_INSERT_1_Insert1)
        {
            var ths = r150_REABI_VIG_CDG_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R150_REABI_VIG_CDG_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}