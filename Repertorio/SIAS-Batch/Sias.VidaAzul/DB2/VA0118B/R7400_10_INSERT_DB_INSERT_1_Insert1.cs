using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0118B
{
    public class R7400_10_INSERT_DB_INSERT_1_Insert1 : QueryBasis<R7400_10_INSERT_DB_INSERT_1_Insert1>
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
            ( :PROPVA-NRCERTIF ,
            '0' ,
            :SISTEMA-DTMOVABE,
            CURRENT TIMESTAMP )
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.COMUNIC_FED_CAP_VA ( NUM_CERTIFICADO , SITUACAO , DATA_MOVIMENTO , TIMESTAMP ) VALUES ( {FieldThreatment(this.PROPVA_NRCERTIF)} , '0' , {FieldThreatment(this.SISTEMA_DTMOVABE)}, CURRENT TIMESTAMP )";

            return query;
        }
        public string PROPVA_NRCERTIF { get; set; }
        public string SISTEMA_DTMOVABE { get; set; }

        public static void Execute(R7400_10_INSERT_DB_INSERT_1_Insert1 r7400_10_INSERT_DB_INSERT_1_Insert1)
        {
            var ths = r7400_10_INSERT_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R7400_10_INSERT_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}