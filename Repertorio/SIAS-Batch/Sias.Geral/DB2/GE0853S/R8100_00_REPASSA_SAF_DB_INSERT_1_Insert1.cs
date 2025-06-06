using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GE0853S
{
    public class R8100_00_REPASSA_SAF_DB_INSERT_1_Insert1 : QueryBasis<R8100_00_REPASSA_SAF_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0HISTREPSAF
            VALUES (:V0PROP-CODCLIEN,
            :V0RSAF-DTREFER,
            :V0HISC-NRCERTIF,
            :V2DIFP-NRPARCEL,
            :V0PROP-NRMATRFUN,
            :V0SAFC-VLCUSTSAF,
            1100,
            '0' ,
            '0' ,
            0,
            0,
            'GE0853S' ,
            CURRENT TIMESTAMP,
            :V0PARC-DTVENCTO:VIND-DTMOVTO)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0HISTREPSAF VALUES ({FieldThreatment(this.V0PROP_CODCLIEN)}, {FieldThreatment(this.V0RSAF_DTREFER)}, {FieldThreatment(this.V0HISC_NRCERTIF)}, {FieldThreatment(this.V2DIFP_NRPARCEL)}, {FieldThreatment(this.V0PROP_NRMATRFUN)}, {FieldThreatment(this.V0SAFC_VLCUSTSAF)}, 1100, '0' , '0' , 0, 0, 'GE0853S' , CURRENT TIMESTAMP,  {FieldThreatment((this.VIND_DTMOVTO?.ToInt() == -1 ? null : this.V0PARC_DTVENCTO))})";

            return query;
        }
        public string V0PROP_CODCLIEN { get; set; }
        public string V0RSAF_DTREFER { get; set; }
        public string V0HISC_NRCERTIF { get; set; }
        public string V2DIFP_NRPARCEL { get; set; }
        public string V0PROP_NRMATRFUN { get; set; }
        public string V0SAFC_VLCUSTSAF { get; set; }
        public string V0PARC_DTVENCTO { get; set; }
        public string VIND_DTMOVTO { get; set; }

        public static void Execute(R8100_00_REPASSA_SAF_DB_INSERT_1_Insert1 r8100_00_REPASSA_SAF_DB_INSERT_1_Insert1)
        {
            var ths = r8100_00_REPASSA_SAF_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R8100_00_REPASSA_SAF_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}