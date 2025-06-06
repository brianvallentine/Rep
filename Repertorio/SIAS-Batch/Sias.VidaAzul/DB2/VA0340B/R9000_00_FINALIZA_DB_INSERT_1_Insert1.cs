using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0340B
{
    public class R9000_00_FINALIZA_DB_INSERT_1_Insert1 : QueryBasis<R9000_00_FINALIZA_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0RELATORIOS
            VALUES ( 'VA0340B' ,
            :SIST-CURRDATE,
            'VA' ,
            'VA0473B' ,
            :PARM-NSA,
            0,
            :SIST-CURRDATE,
            :SIST-CURRDATE,
            :SIST-CURRDATE,
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
				INSERT INTO SEGUROS.V0RELATORIOS VALUES ( 'VA0340B' , {FieldThreatment(this.SIST_CURRDATE)}, 'VA' , 'VA0473B' , {FieldThreatment(this.PARM_NSA)}, 0, {FieldThreatment(this.SIST_CURRDATE)}, {FieldThreatment(this.SIST_CURRDATE)}, {FieldThreatment(this.SIST_CURRDATE)}, 0, 0, 0, 0, 0, 0, 0, 0, 97010000889, 0, 0, 0, 0, 0, 0, 0, 0, ' ' , ' ' , 0, 0, ' ' , 0, 0, ' ' , '0' , ' ' , ' ' , NULL, 0, 0, CURRENT TIMESTAMP)";

            return query;
        }
        public string SIST_CURRDATE { get; set; }
        public string PARM_NSA { get; set; }

        public static void Execute(R9000_00_FINALIZA_DB_INSERT_1_Insert1 r9000_00_FINALIZA_DB_INSERT_1_Insert1)
        {
            var ths = r9000_00_FINALIZA_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R9000_00_FINALIZA_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}