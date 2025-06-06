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
    public class R1082_00_INSERT_V0APOLCOSCED_DB_INSERT_1_Insert1 : QueryBasis<R1082_00_INSERT_V0APOLCOSCED_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO SEGUROS.V0APOLCOSCED
            VALUES (:V0APCC-NUM-APOL ,
            :V0APCC-CODCOSS ,
            :V0APCC-RAMOFR ,
            :V0APCC-DTINIVIG ,
            :V0APCC-DTTERVIG ,
            :V0APCC-PCPARTIC ,
            :V0APCC-PCCOMCOS ,
            :V0APCC-COD-EMPRESA ,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0APOLCOSCED VALUES ({FieldThreatment(this.V0APCC_NUM_APOL)} , {FieldThreatment(this.V0APCC_CODCOSS)} , {FieldThreatment(this.V0APCC_RAMOFR)} , {FieldThreatment(this.V0APCC_DTINIVIG)} , {FieldThreatment(this.V0APCC_DTTERVIG)} , {FieldThreatment(this.V0APCC_PCPARTIC)} , {FieldThreatment(this.V0APCC_PCCOMCOS)} , {FieldThreatment(this.V0APCC_COD_EMPRESA)} , CURRENT TIMESTAMP)";

            return query;
        }
        public string V0APCC_NUM_APOL { get; set; }
        public string V0APCC_CODCOSS { get; set; }
        public string V0APCC_RAMOFR { get; set; }
        public string V0APCC_DTINIVIG { get; set; }
        public string V0APCC_DTTERVIG { get; set; }
        public string V0APCC_PCPARTIC { get; set; }
        public string V0APCC_PCCOMCOS { get; set; }
        public string V0APCC_COD_EMPRESA { get; set; }

        public static void Execute(R1082_00_INSERT_V0APOLCOSCED_DB_INSERT_1_Insert1 r1082_00_INSERT_V0APOLCOSCED_DB_INSERT_1_Insert1)
        {
            var ths = r1082_00_INSERT_V0APOLCOSCED_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1082_00_INSERT_V0APOLCOSCED_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}