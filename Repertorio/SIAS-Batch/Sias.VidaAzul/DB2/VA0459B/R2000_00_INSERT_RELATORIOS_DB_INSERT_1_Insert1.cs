using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0459B
{
    public class R2000_00_INSERT_RELATORIOS_DB_INSERT_1_Insert1 : QueryBasis<R2000_00_INSERT_RELATORIOS_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.RELATORIOS
            VALUES ( 'VA0459B' ,
            :V1SIST-DTMOVABE,
            'VA' ,
            'VA0469B' ,
            0,
            0,
            :V1SIST-DTMOVABE,
            :V1SIST-DTMOVABE,
            :V1SIST-DTMOVABE,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            :V0PROP-APOLICE,
            0,
            1,
            :V0PROP-NRCERTIF,
            0,
            :V0PROP-CODSUBES,
            9,
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
				INSERT INTO SEGUROS.RELATORIOS VALUES ( 'VA0459B' , {FieldThreatment(this.V1SIST_DTMOVABE)}, 'VA' , 'VA0469B' , 0, 0, {FieldThreatment(this.V1SIST_DTMOVABE)}, {FieldThreatment(this.V1SIST_DTMOVABE)}, {FieldThreatment(this.V1SIST_DTMOVABE)}, 0, 0, 0, 0, 0, 0, 0, 0, {FieldThreatment(this.V0PROP_APOLICE)}, 0, 1, {FieldThreatment(this.V0PROP_NRCERTIF)}, 0, {FieldThreatment(this.V0PROP_CODSUBES)}, 9, 0, 0, ' ' , ' ' , 0, 0, ' ' , 0, 0, ' ' , '0' , ' ' , ' ' , NULL, 0, 0, CURRENT TIMESTAMP)";

            return query;
        }
        public string V1SIST_DTMOVABE { get; set; }
        public string V0PROP_APOLICE { get; set; }
        public string V0PROP_NRCERTIF { get; set; }
        public string V0PROP_CODSUBES { get; set; }

        public static void Execute(R2000_00_INSERT_RELATORIOS_DB_INSERT_1_Insert1 r2000_00_INSERT_RELATORIOS_DB_INSERT_1_Insert1)
        {
            var ths = r2000_00_INSERT_RELATORIOS_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2000_00_INSERT_RELATORIOS_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}