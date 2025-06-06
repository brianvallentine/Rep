using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0812B
{
    public class M_0075_SOLICITA_RELAT_DB_INSERT_1_Insert1 : QueryBasis<M_0075_SOLICITA_RELAT_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0RELATORIOS
            VALUES ( 'VA0812B' ,
            :DTMOVABE,
            'VA' ,
            'VA0835B' ,
            :SQL-NSAC,
            0,
            :DTMOVABE,
            :DTMOVABE,
            :DTMOVABE,
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
				INSERT INTO SEGUROS.V0RELATORIOS VALUES ( 'VA0812B' , {FieldThreatment(this.DTMOVABE)}, 'VA' , 'VA0835B' , {FieldThreatment(this.SQL_NSAC)}, 0, {FieldThreatment(this.DTMOVABE)}, {FieldThreatment(this.DTMOVABE)}, {FieldThreatment(this.DTMOVABE)}, 0, 0, 0, 0, 0, 0, 0, 0, 97010000889, 0, 0, 0, 0, 0, 0, 0, 0, ' ' , ' ' , 0, 0, ' ' , 0, 0, ' ' , '0' , ' ' , ' ' , NULL, 0, 0, CURRENT TIMESTAMP)";

            return query;
        }
        public string DTMOVABE { get; set; }
        public string SQL_NSAC { get; set; }

        public static void Execute(M_0075_SOLICITA_RELAT_DB_INSERT_1_Insert1 m_0075_SOLICITA_RELAT_DB_INSERT_1_Insert1)
        {
            var ths = m_0075_SOLICITA_RELAT_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_0075_SOLICITA_RELAT_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}