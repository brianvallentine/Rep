using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA5419B
{
    public class R1400_00_SELECT_V0SAFCOBER_DB_INSERT_1_Insert1 : QueryBasis<R1400_00_SELECT_V0SAFCOBER_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT
            INTO SEGUROS.V0SAFCOBER
            VALUES(:V0RSAF-CODCLIEN,
            :V0RSAF-DTREF,
            '9999-12-31' ,
            3000.00,
            :V0RSAF-VLCUSTAUXF,
            :V0RSAF-NRCERTIF,
            0,
            '0' ,
            'VA5419B' ,
            CURRENT TIMESTAMP)
            END-EXEC
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0SAFCOBER VALUES({FieldThreatment(this.V0RSAF_CODCLIEN)}, {FieldThreatment(this.V0RSAF_DTREF)}, '9999-12-31' , 3000.00, {FieldThreatment(this.V0RSAF_VLCUSTAUXF)}, {FieldThreatment(this.V0RSAF_NRCERTIF)}, 0, '0' , 'VA5419B' , CURRENT TIMESTAMP)";

            return query;
        }
        public string V0RSAF_CODCLIEN { get; set; }
        public string V0RSAF_DTREF { get; set; }
        public string V0RSAF_VLCUSTAUXF { get; set; }
        public string V0RSAF_NRCERTIF { get; set; }

        public static void Execute(R1400_00_SELECT_V0SAFCOBER_DB_INSERT_1_Insert1 r1400_00_SELECT_V0SAFCOBER_DB_INSERT_1_Insert1)
        {
            var ths = r1400_00_SELECT_V0SAFCOBER_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1400_00_SELECT_V0SAFCOBER_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}