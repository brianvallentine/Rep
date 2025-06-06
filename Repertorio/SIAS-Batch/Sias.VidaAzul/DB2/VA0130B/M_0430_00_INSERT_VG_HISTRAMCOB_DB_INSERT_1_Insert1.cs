using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0130B
{
    public class M_0430_00_INSERT_VG_HISTRAMCOB_DB_INSERT_1_Insert1 : QueryBasis<M_0430_00_INSERT_VG_HISTRAMCOB_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.VG_HIST_RAMO_COB
            VALUES (:VGHISR-NRCERTIF,
            :COBERP-OCORHIST,
            :VGHISR-NUM-RAMO,
            :VGHISR-NUM-COBERTURA,
            :VGHISR-QTD-COBERTURA,
            :VGHISR-IMPSEGURADA,
            :VGHISR-CUSTO,
            :VGHISR-PREMIO)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.VG_HIST_RAMO_COB VALUES ({FieldThreatment(this.VGHISR_NRCERTIF)}, {FieldThreatment(this.COBERP_OCORHIST)}, {FieldThreatment(this.VGHISR_NUM_RAMO)}, {FieldThreatment(this.VGHISR_NUM_COBERTURA)}, {FieldThreatment(this.VGHISR_QTD_COBERTURA)}, {FieldThreatment(this.VGHISR_IMPSEGURADA)}, {FieldThreatment(this.VGHISR_CUSTO)}, {FieldThreatment(this.VGHISR_PREMIO)})";

            return query;
        }
        public string VGHISR_NRCERTIF { get; set; }
        public string COBERP_OCORHIST { get; set; }
        public string VGHISR_NUM_RAMO { get; set; }
        public string VGHISR_NUM_COBERTURA { get; set; }
        public string VGHISR_QTD_COBERTURA { get; set; }
        public string VGHISR_IMPSEGURADA { get; set; }
        public string VGHISR_CUSTO { get; set; }
        public string VGHISR_PREMIO { get; set; }

        public static void Execute(M_0430_00_INSERT_VG_HISTRAMCOB_DB_INSERT_1_Insert1 m_0430_00_INSERT_VG_HISTRAMCOB_DB_INSERT_1_Insert1)
        {
            var ths = m_0430_00_INSERT_VG_HISTRAMCOB_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_0430_00_INSERT_VG_HISTRAMCOB_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}