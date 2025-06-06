using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0816B
{
    public class R1120_00_INCLUI_SAF_DB_INSERT_1_Insert1 : QueryBasis<R1120_00_INCLUI_SAF_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0SAFCOBER
            VALUES (:V0PROP-CODCLIEN,
            :V0RSAF-DTREFER,
            '9999-12-31' ,
            :V0COBP-IMPSEGAUXF,
            :V0SAFC-VLCUSTAUXF,
            :V0HCOB-NRCERTIF,
            0,
            '0' ,
            'VG0816B' ,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0SAFCOBER VALUES ({FieldThreatment(this.V0PROP_CODCLIEN)}, {FieldThreatment(this.V0RSAF_DTREFER)}, '9999-12-31' , {FieldThreatment(this.V0COBP_IMPSEGAUXF)}, {FieldThreatment(this.V0SAFC_VLCUSTAUXF)}, {FieldThreatment(this.V0HCOB_NRCERTIF)}, 0, '0' , 'VG0816B' , CURRENT TIMESTAMP)";

            return query;
        }
        public string V0PROP_CODCLIEN { get; set; }
        public string V0RSAF_DTREFER { get; set; }
        public string V0COBP_IMPSEGAUXF { get; set; }
        public string V0SAFC_VLCUSTAUXF { get; set; }
        public string V0HCOB_NRCERTIF { get; set; }

        public static void Execute(R1120_00_INCLUI_SAF_DB_INSERT_1_Insert1 r1120_00_INCLUI_SAF_DB_INSERT_1_Insert1)
        {
            var ths = r1120_00_INCLUI_SAF_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1120_00_INCLUI_SAF_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}