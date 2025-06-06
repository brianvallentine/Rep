using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA6421B
{
    public class R120_SELECT_CDGCOBER_DB_INSERT_1_Insert1 : QueryBasis<R120_SELECT_CDGCOBER_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0CDGCOBER
            VALUES (:V0PROP-CODCLIEN,
            :V0FATUR-DTREFER,
            '9999-12-31' ,
            :V0COBV-IMPSEGCDG,
            :V0COBV-VLCUSTCDG,
            :V0PROP-NRCERTIF,
            0,
            '0' ,
            'VA6421B' ,
            CURRENT TIMESTAMP)
            END-EXEC
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0CDGCOBER VALUES ({FieldThreatment(this.V0PROP_CODCLIEN)}, {FieldThreatment(this.V0FATUR_DTREFER)}, '9999-12-31' , {FieldThreatment(this.V0COBV_IMPSEGCDG)}, {FieldThreatment(this.V0COBV_VLCUSTCDG)}, {FieldThreatment(this.V0PROP_NRCERTIF)}, 0, '0' , 'VA6421B' , CURRENT TIMESTAMP)";

            return query;
        }
        public string V0PROP_CODCLIEN { get; set; }
        public string V0FATUR_DTREFER { get; set; }
        public string V0COBV_IMPSEGCDG { get; set; }
        public string V0COBV_VLCUSTCDG { get; set; }
        public string V0PROP_NRCERTIF { get; set; }

        public static void Execute(R120_SELECT_CDGCOBER_DB_INSERT_1_Insert1 r120_SELECT_CDGCOBER_DB_INSERT_1_Insert1)
        {
            var ths = r120_SELECT_CDGCOBER_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R120_SELECT_CDGCOBER_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}