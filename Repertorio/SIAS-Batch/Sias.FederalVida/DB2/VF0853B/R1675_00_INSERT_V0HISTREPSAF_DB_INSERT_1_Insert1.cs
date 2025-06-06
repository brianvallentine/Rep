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
    public class R1675_00_INSERT_V0HISTREPSAF_DB_INSERT_1_Insert1 : QueryBasis<R1675_00_INSERT_V0HISTREPSAF_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0HISTREPSAF
            VALUES (:V0PROP-CODCLIEN,
            :V0RSAF-DTREFER,
            :V0PROP-NRCERTIF,
            :V0PROP-NRPARCEL,
            0,
            :V0SAFC-VLCUSTSAF,
            :V0RSAF-CODOPER,
            '0' ,
            '0' ,
            0,
            0,
            'VF0853B' ,
            CURRENT TIMESTAMP,
            :V0PROP-DTVENCTO)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0HISTREPSAF VALUES ({FieldThreatment(this.V0PROP_CODCLIEN)}, {FieldThreatment(this.V0RSAF_DTREFER)}, {FieldThreatment(this.V0PROP_NRCERTIF)}, {FieldThreatment(this.V0PROP_NRPARCEL)}, 0, {FieldThreatment(this.V0SAFC_VLCUSTSAF)}, {FieldThreatment(this.V0RSAF_CODOPER)}, '0' , '0' , 0, 0, 'VF0853B' , CURRENT TIMESTAMP, {FieldThreatment(this.V0PROP_DTVENCTO)})";

            return query;
        }
        public string V0PROP_CODCLIEN { get; set; }
        public string V0RSAF_DTREFER { get; set; }
        public string V0PROP_NRCERTIF { get; set; }
        public string V0PROP_NRPARCEL { get; set; }
        public string V0SAFC_VLCUSTSAF { get; set; }
        public string V0RSAF_CODOPER { get; set; }
        public string V0PROP_DTVENCTO { get; set; }

        public static void Execute(R1675_00_INSERT_V0HISTREPSAF_DB_INSERT_1_Insert1 r1675_00_INSERT_V0HISTREPSAF_DB_INSERT_1_Insert1)
        {
            var ths = r1675_00_INSERT_V0HISTREPSAF_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1675_00_INSERT_V0HISTREPSAF_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}