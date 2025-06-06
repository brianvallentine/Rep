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
    public class R3400_10_INSERT_DB_INSERT_1_Insert1 : QueryBasis<R3400_10_INSERT_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.COMUNIC_FED_CAP_VA
            ( NUM_CERTIFICADO ,
            SITUACAO ,
            DATA_MOVIMENTO ,
            TIMESTAMP )
            VALUES
            ( :V0BILH-NUMBIL ,
            '0' ,
            :V1SIST-DTMOVABE ,
            CURRENT TIMESTAMP )
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.COMUNIC_FED_CAP_VA ( NUM_CERTIFICADO , SITUACAO , DATA_MOVIMENTO , TIMESTAMP ) VALUES ( {FieldThreatment(this.V0BILH_NUMBIL)} , '0' , {FieldThreatment(this.V1SIST_DTMOVABE)} , CURRENT TIMESTAMP )";

            return query;
        }
        public string V0BILH_NUMBIL { get; set; }
        public string V1SIST_DTMOVABE { get; set; }

        public static void Execute(R3400_10_INSERT_DB_INSERT_1_Insert1 r3400_10_INSERT_DB_INSERT_1_Insert1)
        {
            var ths = r3400_10_INSERT_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3400_10_INSERT_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}