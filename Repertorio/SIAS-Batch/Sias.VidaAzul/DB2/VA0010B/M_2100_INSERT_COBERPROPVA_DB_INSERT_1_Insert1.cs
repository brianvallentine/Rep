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
    public class M_2100_INSERT_COBERPROPVA_DB_INSERT_1_Insert1 : QueryBasis<M_2100_INSERT_COBERPROPVA_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0COBERPROPVA
            VALUES (:V1SEGV-NRCERTIF,
            :V1SEGV-OCORHIST,
            :V1HSEG-DTMOVTO,
            '9999-12-31' ,
            :HOST-IMPSEGUR,
            1,
            :HOST-IMPSEGIND,
            :V1HSEG-CODOPER,
            ' ' ,
            :CIMP-SEGURADA-VG,
            :CIMP-SEGURADA-AP,
            :CIMP-SEGURADA-IP,
            0,
            0,
            0,
            :VLPREMIO,
            :PRMVG,
            :PRMAP,
            :HOST-QTTITCAP,
            :HOST-VLTITCAP,
            :HOST-VLCUSCAP,
            :V0PLAN-IMPSEGCDG,
            :V0PLAN-VLCUSTCDG,
            'VA0010B' ,
            CURRENT TIMESTAMP,
            NULL,
            NULL,
            NULL,
            NULL)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0COBERPROPVA VALUES ({FieldThreatment(this.V1SEGV_NRCERTIF)}, {FieldThreatment(this.V1SEGV_OCORHIST)}, {FieldThreatment(this.V1HSEG_DTMOVTO)}, '9999-12-31' , {FieldThreatment(this.HOST_IMPSEGUR)}, 1, {FieldThreatment(this.HOST_IMPSEGIND)}, {FieldThreatment(this.V1HSEG_CODOPER)}, ' ' , {FieldThreatment(this.CIMP_SEGURADA_VG)}, {FieldThreatment(this.CIMP_SEGURADA_AP)}, {FieldThreatment(this.CIMP_SEGURADA_IP)}, 0, 0, 0, {FieldThreatment(this.VLPREMIO)}, {FieldThreatment(this.PRMVG)}, {FieldThreatment(this.PRMAP)}, {FieldThreatment(this.HOST_QTTITCAP)}, {FieldThreatment(this.HOST_VLTITCAP)}, {FieldThreatment(this.HOST_VLCUSCAP)}, {FieldThreatment(this.V0PLAN_IMPSEGCDG)}, {FieldThreatment(this.V0PLAN_VLCUSTCDG)}, 'VA0010B' , CURRENT TIMESTAMP, NULL, NULL, NULL, NULL)";

            return query;
        }
        public string V1SEGV_NRCERTIF { get; set; }
        public string V1SEGV_OCORHIST { get; set; }
        public string V1HSEG_DTMOVTO { get; set; }
        public string HOST_IMPSEGUR { get; set; }
        public string HOST_IMPSEGIND { get; set; }
        public string V1HSEG_CODOPER { get; set; }
        public string CIMP_SEGURADA_VG { get; set; }
        public string CIMP_SEGURADA_AP { get; set; }
        public string CIMP_SEGURADA_IP { get; set; }
        public string VLPREMIO { get; set; }
        public string PRMVG { get; set; }
        public string PRMAP { get; set; }
        public string HOST_QTTITCAP { get; set; }
        public string HOST_VLTITCAP { get; set; }
        public string HOST_VLCUSCAP { get; set; }
        public string V0PLAN_IMPSEGCDG { get; set; }
        public string V0PLAN_VLCUSTCDG { get; set; }

        public static void Execute(M_2100_INSERT_COBERPROPVA_DB_INSERT_1_Insert1 m_2100_INSERT_COBERPROPVA_DB_INSERT_1_Insert1)
        {
            var ths = m_2100_INSERT_COBERPROPVA_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_2100_INSERT_COBERPROPVA_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}