using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.FederalVida.DB2.VF0813B
{
    public class M_1100_REPASSA_CDG_DB_INSERT_1_Insert1 : QueryBasis<M_1100_REPASSA_CDG_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0REPASSECDG
            VALUES (:V0PROP-CODCLIEN,
            :V0RCDG-DTREFER,
            :V0CDGC-VLCUSTCDG,
            :V0HCTA-NRCERTIF,
            :V0PARC-NRPARCEL,
            '0' ,
            :V0SIST-DTMOVABE,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0REPASSECDG VALUES ({FieldThreatment(this.V0PROP_CODCLIEN)}, {FieldThreatment(this.V0RCDG_DTREFER)}, {FieldThreatment(this.V0CDGC_VLCUSTCDG)}, {FieldThreatment(this.V0HCTA_NRCERTIF)}, {FieldThreatment(this.V0PARC_NRPARCEL)}, '0' , {FieldThreatment(this.V0SIST_DTMOVABE)}, CURRENT TIMESTAMP)";

            return query;
        }
        public string V0PROP_CODCLIEN { get; set; }
        public string V0RCDG_DTREFER { get; set; }
        public string V0CDGC_VLCUSTCDG { get; set; }
        public string V0HCTA_NRCERTIF { get; set; }
        public string V0PARC_NRPARCEL { get; set; }
        public string V0SIST_DTMOVABE { get; set; }

        public static void Execute(M_1100_REPASSA_CDG_DB_INSERT_1_Insert1 m_1100_REPASSA_CDG_DB_INSERT_1_Insert1)
        {
            var ths = m_1100_REPASSA_CDG_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_1100_REPASSA_CDG_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}