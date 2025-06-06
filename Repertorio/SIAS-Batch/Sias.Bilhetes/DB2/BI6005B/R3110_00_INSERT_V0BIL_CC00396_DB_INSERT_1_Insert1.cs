using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI6005B
{
    public class R3110_00_INSERT_V0BIL_CC00396_DB_INSERT_1_Insert1 : QueryBasis<R3110_00_INSERT_V0BIL_CC00396_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO SEGUROS.V0BIL_CC00396
            VALUES (:V0C396-NUMBIL ,
            :V0C396-DTMOVTO ,
            :V0C396-SITUACAO,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0BIL_CC00396 VALUES ({FieldThreatment(this.V0C396_NUMBIL)} , {FieldThreatment(this.V0C396_DTMOVTO)} , {FieldThreatment(this.V0C396_SITUACAO)}, CURRENT TIMESTAMP)";

            return query;
        }
        public string V0C396_NUMBIL { get; set; }
        public string V0C396_DTMOVTO { get; set; }
        public string V0C396_SITUACAO { get; set; }

        public static void Execute(R3110_00_INSERT_V0BIL_CC00396_DB_INSERT_1_Insert1 r3110_00_INSERT_V0BIL_CC00396_DB_INSERT_1_Insert1)
        {
            var ths = r3110_00_INSERT_V0BIL_CC00396_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3110_00_INSERT_V0BIL_CC00396_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}