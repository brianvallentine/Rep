using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA6421B
{
    public class R130_GERA_REPASSE_CDG_DB_INSERT_1_Insert1 : QueryBasis<R130_GERA_REPASSE_CDG_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0REPASSECDG
            VALUES (:V0PROP-CODCLIEN,
            :V0FATUR-DTREFER,
            :V0COBV-VLCUSTCDG,
            :V0PROP-NRCERTIF,
            0,
            '0' ,
            :V0SIST-DTMOVABE,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0REPASSECDG VALUES ({FieldThreatment(this.V0PROP_CODCLIEN)}, {FieldThreatment(this.V0FATUR_DTREFER)}, {FieldThreatment(this.V0COBV_VLCUSTCDG)}, {FieldThreatment(this.V0PROP_NRCERTIF)}, 0, '0' , {FieldThreatment(this.V0SIST_DTMOVABE)}, CURRENT TIMESTAMP)";

            return query;
        }
        public string V0PROP_CODCLIEN { get; set; }
        public string V0FATUR_DTREFER { get; set; }
        public string V0COBV_VLCUSTCDG { get; set; }
        public string V0PROP_NRCERTIF { get; set; }
        public string V0SIST_DTMOVABE { get; set; }

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