using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0813B
{
    public class R1099_00_INCLUI_CDG_DB_INSERT_1_Insert1 : QueryBasis<R1099_00_INCLUI_CDG_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0CDGCOBER
            VALUES (:V0PROP-CODCLIEN,
            :V0RCDG-DTREFER,
            '9999-12-31' ,
            :V0COBP-IMPSEGCDG,
            :V0COBP-VLCUSTCDG,
            :V0HCTA-NRCERTIF,
            0,
            '0' ,
            'VA0813B' ,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0CDGCOBER VALUES ({FieldThreatment(this.V0PROP_CODCLIEN)}, {FieldThreatment(this.V0RCDG_DTREFER)}, '9999-12-31' , {FieldThreatment(this.V0COBP_IMPSEGCDG)}, {FieldThreatment(this.V0COBP_VLCUSTCDG)}, {FieldThreatment(this.V0HCTA_NRCERTIF)}, 0, '0' , 'VA0813B' , CURRENT TIMESTAMP)";

            return query;
        }
        public string V0PROP_CODCLIEN { get; set; }
        public string V0RCDG_DTREFER { get; set; }
        public string V0COBP_IMPSEGCDG { get; set; }
        public string V0COBP_VLCUSTCDG { get; set; }
        public string V0HCTA_NRCERTIF { get; set; }

        public static void Execute(R1099_00_INCLUI_CDG_DB_INSERT_1_Insert1 r1099_00_INCLUI_CDG_DB_INSERT_1_Insert1)
        {
            var ths = r1099_00_INCLUI_CDG_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1099_00_INCLUI_CDG_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}