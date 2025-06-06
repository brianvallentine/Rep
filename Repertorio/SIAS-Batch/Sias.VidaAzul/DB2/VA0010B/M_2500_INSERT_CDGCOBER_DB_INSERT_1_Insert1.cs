using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0010B
{
    public class M_2500_INSERT_CDGCOBER_DB_INSERT_1_Insert1 : QueryBasis<M_2500_INSERT_CDGCOBER_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0CDGCOBER
            VALUES (:V1SEGV-CODCLI,
            :V1SIST-DTMOVABE,
            '9999-12-31' ,
            :HOST-IMPSEGCDG,
            :HOST-VLCUSTCDG,
            :V1SEGV-NRCERTIF,
            0,
            '0' ,
            'VA0010B' ,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0CDGCOBER VALUES ({FieldThreatment(this.V1SEGV_CODCLI)}, {FieldThreatment(this.V1SIST_DTMOVABE)}, '9999-12-31' , {FieldThreatment(this.HOST_IMPSEGCDG)}, {FieldThreatment(this.HOST_VLCUSTCDG)}, {FieldThreatment(this.V1SEGV_NRCERTIF)}, 0, '0' , 'VA0010B' , CURRENT TIMESTAMP)";

            return query;
        }
        public string V1SEGV_CODCLI { get; set; }
        public string V1SIST_DTMOVABE { get; set; }
        public string HOST_IMPSEGCDG { get; set; }
        public string HOST_VLCUSTCDG { get; set; }
        public string V1SEGV_NRCERTIF { get; set; }

        public static void Execute(M_2500_INSERT_CDGCOBER_DB_INSERT_1_Insert1 m_2500_INSERT_CDGCOBER_DB_INSERT_1_Insert1)
        {
            var ths = m_2500_INSERT_CDGCOBER_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_2500_INSERT_CDGCOBER_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}