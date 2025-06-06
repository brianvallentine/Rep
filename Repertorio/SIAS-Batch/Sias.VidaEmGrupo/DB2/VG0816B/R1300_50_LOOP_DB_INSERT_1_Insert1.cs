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
    public class R1300_50_LOOP_DB_INSERT_1_Insert1 : QueryBasis<R1300_50_LOOP_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0EVENTOSVF
            VALUES (:V0PLCO-CODPDT,
            :V0PDTV-OCORHIST,
            0,
            :V0HCOB-NRCERTIF,
            :V0CMPT-NRPARCEL,
            8,
            :V0DIFP-CODOPER,
            :V0SIST-DTMOVABE,
            :V0MOVC-DTQITBCO,
            '0' ,
            :V0CMPT-VLPRMDIF,
            0,
            'VG0816B' ,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0EVENTOSVF VALUES ({FieldThreatment(this.V0PLCO_CODPDT)}, {FieldThreatment(this.V0PDTV_OCORHIST)}, 0, {FieldThreatment(this.V0HCOB_NRCERTIF)}, {FieldThreatment(this.V0CMPT_NRPARCEL)}, 8, {FieldThreatment(this.V0DIFP_CODOPER)}, {FieldThreatment(this.V0SIST_DTMOVABE)}, {FieldThreatment(this.V0MOVC_DTQITBCO)}, '0' , {FieldThreatment(this.V0CMPT_VLPRMDIF)}, 0, 'VG0816B' , CURRENT TIMESTAMP)";

            return query;
        }
        public string V0PLCO_CODPDT { get; set; }
        public string V0PDTV_OCORHIST { get; set; }
        public string V0HCOB_NRCERTIF { get; set; }
        public string V0CMPT_NRPARCEL { get; set; }
        public string V0DIFP_CODOPER { get; set; }
        public string V0SIST_DTMOVABE { get; set; }
        public string V0MOVC_DTQITBCO { get; set; }
        public string V0CMPT_VLPRMDIF { get; set; }

        public static void Execute(R1300_50_LOOP_DB_INSERT_1_Insert1 r1300_50_LOOP_DB_INSERT_1_Insert1)
        {
            var ths = r1300_50_LOOP_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1300_50_LOOP_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}