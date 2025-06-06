using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA5421B
{
    public class R130_GERA_REPASSE_CDG_DB_INSERT_1_Insert1 : QueryBasis<R130_GERA_REPASSE_CDG_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0REPASSECDG
            VALUES (:V0PROP-CODCLIEN,
            :V0CDGC-DTINIVIG,
            :V0COBV-VLCUSTCDG,
            :V0PROP-NRCERTIF,
            :V0CDGC-OCORHIST,
            '0' ,
            :V0HSAF-DTMOVTO:VIND-DTMOVTO,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0REPASSECDG VALUES ({FieldThreatment(this.V0PROP_CODCLIEN)}, {FieldThreatment(this.V0CDGC_DTINIVIG)}, {FieldThreatment(this.V0COBV_VLCUSTCDG)}, {FieldThreatment(this.V0PROP_NRCERTIF)}, {FieldThreatment(this.V0CDGC_OCORHIST)}, '0' ,  {FieldThreatment((this.VIND_DTMOVTO?.ToInt() == -1 ? null : this.V0HSAF_DTMOVTO))}, CURRENT TIMESTAMP)";

            return query;
        }
        public string V0PROP_CODCLIEN { get; set; }
        public string V0CDGC_DTINIVIG { get; set; }
        public string V0COBV_VLCUSTCDG { get; set; }
        public string V0PROP_NRCERTIF { get; set; }
        public string V0CDGC_OCORHIST { get; set; }
        public string V0HSAF_DTMOVTO { get; set; }
        public string VIND_DTMOVTO { get; set; }

        public static void Execute(R130_GERA_REPASSE_CDG_DB_INSERT_1_Insert1 r130_GERA_REPASSE_CDG_DB_INSERT_1_Insert1)
        {
            var ths = r130_GERA_REPASSE_CDG_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R130_GERA_REPASSE_CDG_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}