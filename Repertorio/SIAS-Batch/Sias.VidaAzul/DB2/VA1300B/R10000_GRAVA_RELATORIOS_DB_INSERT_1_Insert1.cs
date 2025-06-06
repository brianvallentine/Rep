using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA1300B
{
    public class R10000_GRAVA_RELATORIOS_DB_INSERT_1_Insert1 : QueryBasis<R10000_GRAVA_RELATORIOS_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0RELATORIOS
            VALUES ( 'VA1300B' ,
            :HOST-CURRENT-DATE,
            'VA' ,
            'VA0473B' ,
            :PARM-NSA,
            0,
            :HOST-CURRENT-DATE,
            :HOST-CURRENT-DATE,
            :HOST-CURRENT-DATE,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            97010000889,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            ' ' ,
            ' ' ,
            0,
            0,
            ' ' ,
            0,
            0,
            ' ' ,
            '0' ,
            ' ' ,
            ' ' ,
            NULL,
            0,
            0,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0RELATORIOS VALUES ( 'VA1300B' , {FieldThreatment(this.HOST_CURRENT_DATE)}, 'VA' , 'VA0473B' , {FieldThreatment(this.PARM_NSA)}, 0, {FieldThreatment(this.HOST_CURRENT_DATE)}, {FieldThreatment(this.HOST_CURRENT_DATE)}, {FieldThreatment(this.HOST_CURRENT_DATE)}, 0, 0, 0, 0, 0, 0, 0, 0, 97010000889, 0, 0, 0, 0, 0, 0, 0, 0, ' ' , ' ' , 0, 0, ' ' , 0, 0, ' ' , '0' , ' ' , ' ' , NULL, 0, 0, CURRENT TIMESTAMP)";

            return query;
        }
        public string HOST_CURRENT_DATE { get; set; }
        public string PARM_NSA { get; set; }

        public static void Execute(R10000_GRAVA_RELATORIOS_DB_INSERT_1_Insert1 r10000_GRAVA_RELATORIOS_DB_INSERT_1_Insert1)
        {
            var ths = r10000_GRAVA_RELATORIOS_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R10000_GRAVA_RELATORIOS_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}