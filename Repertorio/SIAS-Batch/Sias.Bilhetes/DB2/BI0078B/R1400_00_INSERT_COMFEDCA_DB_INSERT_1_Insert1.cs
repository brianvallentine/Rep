using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0078B
{
    public class R1400_00_INSERT_COMFEDCA_DB_INSERT_1_Insert1 : QueryBasis<R1400_00_INSERT_COMFEDCA_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT
            INTO SEGUROS.COMUNIC_FED_CAP_VA
            ( NUM_CERTIFICADO,
            SITUACAO ,
            DATA_MOVIMENTO ,
            TIMESTAMP )
            VALUES (:BILHETE-NUM-BILHETE,
            'R' ,
            CURRENT DATE ,
            CURRENT TIMESTAMP )
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.COMUNIC_FED_CAP_VA ( NUM_CERTIFICADO, SITUACAO , DATA_MOVIMENTO , TIMESTAMP ) VALUES ({FieldThreatment(this.BILHETE_NUM_BILHETE)}, 'R' , CURRENT DATE , CURRENT TIMESTAMP )";

            return query;
        }
        public string BILHETE_NUM_BILHETE { get; set; }

        public static void Execute(R1400_00_INSERT_COMFEDCA_DB_INSERT_1_Insert1 r1400_00_INSERT_COMFEDCA_DB_INSERT_1_Insert1)
        {
            var ths = r1400_00_INSERT_COMFEDCA_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1400_00_INSERT_COMFEDCA_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}