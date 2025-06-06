using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0071B
{
    public class R4300_00_INSERT_COMFEDCA_DB_INSERT_1_Insert1 : QueryBasis<R4300_00_INSERT_COMFEDCA_DB_INSERT_1_Insert1>
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
            ( :V1BILH-NUMBIL ,
            :WHOST-SIT-REGISTRO,
            :V1SISTE-DTMOVABE,
            CURRENT TIMESTAMP )
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.COMUNIC_FED_CAP_VA ( NUM_CERTIFICADO , SITUACAO , DATA_MOVIMENTO , TIMESTAMP ) VALUES ( {FieldThreatment(this.V1BILH_NUMBIL)} , {FieldThreatment(this.WHOST_SIT_REGISTRO)}, {FieldThreatment(this.V1SISTE_DTMOVABE)}, CURRENT TIMESTAMP )";

            return query;
        }
        public string V1BILH_NUMBIL { get; set; }
        public string WHOST_SIT_REGISTRO { get; set; }
        public string V1SISTE_DTMOVABE { get; set; }

        public static void Execute(R4300_00_INSERT_COMFEDCA_DB_INSERT_1_Insert1 r4300_00_INSERT_COMFEDCA_DB_INSERT_1_Insert1)
        {
            var ths = r4300_00_INSERT_COMFEDCA_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R4300_00_INSERT_COMFEDCA_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}