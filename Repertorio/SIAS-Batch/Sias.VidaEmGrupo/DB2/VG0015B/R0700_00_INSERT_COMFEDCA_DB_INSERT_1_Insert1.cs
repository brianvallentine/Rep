using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0015B
{
    public class R0700_00_INSERT_COMFEDCA_DB_INSERT_1_Insert1 : QueryBasis<R0700_00_INSERT_COMFEDCA_DB_INSERT_1_Insert1>
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
            VALUES (:WS-NUM-CERTIFICADO,
            'R' ,
            CURRENT DATE ,
            CURRENT TIMESTAMP )
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.COMUNIC_FED_CAP_VA ( NUM_CERTIFICADO, SITUACAO , DATA_MOVIMENTO , TIMESTAMP ) VALUES ({FieldThreatment(this.WS_NUM_CERTIFICADO)}, 'R' , CURRENT DATE , CURRENT TIMESTAMP )";

            return query;
        }
        public string WS_NUM_CERTIFICADO { get; set; }

        public static void Execute(R0700_00_INSERT_COMFEDCA_DB_INSERT_1_Insert1 r0700_00_INSERT_COMFEDCA_DB_INSERT_1_Insert1)
        {
            var ths = r0700_00_INSERT_COMFEDCA_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0700_00_INSERT_COMFEDCA_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}