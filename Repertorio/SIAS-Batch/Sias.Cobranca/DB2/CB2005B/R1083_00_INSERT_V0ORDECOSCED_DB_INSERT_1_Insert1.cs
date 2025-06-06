using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB2005B
{
    public class R1083_00_INSERT_V0ORDECOSCED_DB_INSERT_1_Insert1 : QueryBasis<R1083_00_INSERT_V0ORDECOSCED_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO SEGUROS.V0ORDECOSCED
            VALUES (:V0ORDC-NUM-APOL ,
            :V0ORDC-NRENDOS ,
            :V0ORDC-CODCOSS ,
            :V0ORDC-ORDEM-CED ,
            :V0ORDC-COD-EMPRESA ,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0ORDECOSCED VALUES ({FieldThreatment(this.V0ORDC_NUM_APOL)} , {FieldThreatment(this.V0ORDC_NRENDOS)} , {FieldThreatment(this.V0ORDC_CODCOSS)} , {FieldThreatment(this.V0ORDC_ORDEM_CED)} , {FieldThreatment(this.V0ORDC_COD_EMPRESA)} , CURRENT TIMESTAMP)";

            return query;
        }
        public string V0ORDC_NUM_APOL { get; set; }
        public string V0ORDC_NRENDOS { get; set; }
        public string V0ORDC_CODCOSS { get; set; }
        public string V0ORDC_ORDEM_CED { get; set; }
        public string V0ORDC_COD_EMPRESA { get; set; }

        public static void Execute(R1083_00_INSERT_V0ORDECOSCED_DB_INSERT_1_Insert1 r1083_00_INSERT_V0ORDECOSCED_DB_INSERT_1_Insert1)
        {
            var ths = r1083_00_INSERT_V0ORDECOSCED_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1083_00_INSERT_V0ORDECOSCED_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}