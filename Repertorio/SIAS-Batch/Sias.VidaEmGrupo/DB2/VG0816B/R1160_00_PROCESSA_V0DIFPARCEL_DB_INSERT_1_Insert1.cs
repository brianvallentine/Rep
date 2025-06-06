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
    public class R1160_00_PROCESSA_V0DIFPARCEL_DB_INSERT_1_Insert1 : QueryBasis<R1160_00_PROCESSA_V0DIFPARCEL_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0HISTREPSAF
            VALUES (:V0PROP-CODCLIEN,
            :V0RSAF-DTREFER,
            :V0HCOB-NRCERTIF,
            :V0HCOB-NRPARCEL,
            :V0PROP-NRMATRFUN,
            :V0SAFC-VLCUSTAUXF,
            1100,
            '0' ,
            '0' ,
            0,
            0,
            'VG0816B' ,
            CURRENT TIMESTAMP,
            :V0PARC-DTVENCTO:VIND-DTMOVTO)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0HISTREPSAF VALUES ({FieldThreatment(this.V0PROP_CODCLIEN)}, {FieldThreatment(this.V0RSAF_DTREFER)}, {FieldThreatment(this.V0HCOB_NRCERTIF)}, {FieldThreatment(this.V0HCOB_NRPARCEL)}, {FieldThreatment(this.V0PROP_NRMATRFUN)}, {FieldThreatment(this.V0SAFC_VLCUSTAUXF)}, 1100, '0' , '0' , 0, 0, 'VG0816B' , CURRENT TIMESTAMP,  {FieldThreatment((this.VIND_DTMOVTO?.ToInt() == -1 ? null : this.V0PARC_DTVENCTO))})";

            return query;
        }
        public string V0PROP_CODCLIEN { get; set; }
        public string V0RSAF_DTREFER { get; set; }
        public string V0HCOB_NRCERTIF { get; set; }
        public string V0HCOB_NRPARCEL { get; set; }
        public string V0PROP_NRMATRFUN { get; set; }
        public string V0SAFC_VLCUSTAUXF { get; set; }
        public string V0PARC_DTVENCTO { get; set; }
        public string VIND_DTMOVTO { get; set; }

        public static void Execute(R1160_00_PROCESSA_V0DIFPARCEL_DB_INSERT_1_Insert1 r1160_00_PROCESSA_V0DIFPARCEL_DB_INSERT_1_Insert1)
        {
            var ths = r1160_00_PROCESSA_V0DIFPARCEL_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1160_00_PROCESSA_V0DIFPARCEL_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}