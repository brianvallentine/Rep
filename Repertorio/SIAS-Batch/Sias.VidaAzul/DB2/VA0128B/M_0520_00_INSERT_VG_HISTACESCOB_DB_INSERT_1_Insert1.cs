using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0128B
{
    public class M_0520_00_INSERT_VG_HISTACESCOB_DB_INSERT_1_Insert1 : QueryBasis<M_0520_00_INSERT_VG_HISTACESCOB_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.VG_HIST_ACESS_COB
            VALUES (:VGHISA-NRCERTIF,
            :COBERP-OCORHIST,
            :VGHISA-NUM-ACESSORIO,
            :VGHISA-QTD-COBERTURA,
            :VGHISA-IMPSEGURADA,
            :VGHISA-CUSTO,
            :VGHISA-PREMIO)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.VG_HIST_ACESS_COB VALUES ({FieldThreatment(this.VGHISA_NRCERTIF)}, {FieldThreatment(this.COBERP_OCORHIST)}, {FieldThreatment(this.VGHISA_NUM_ACESSORIO)}, {FieldThreatment(this.VGHISA_QTD_COBERTURA)}, {FieldThreatment(this.VGHISA_IMPSEGURADA)}, {FieldThreatment(this.VGHISA_CUSTO)}, {FieldThreatment(this.VGHISA_PREMIO)})";

            return query;
        }
        public string VGHISA_NRCERTIF { get; set; }
        public string COBERP_OCORHIST { get; set; }
        public string VGHISA_NUM_ACESSORIO { get; set; }
        public string VGHISA_QTD_COBERTURA { get; set; }
        public string VGHISA_IMPSEGURADA { get; set; }
        public string VGHISA_CUSTO { get; set; }
        public string VGHISA_PREMIO { get; set; }

        public static void Execute(M_0520_00_INSERT_VG_HISTACESCOB_DB_INSERT_1_Insert1 m_0520_00_INSERT_VG_HISTACESCOB_DB_INSERT_1_Insert1)
        {
            var ths = m_0520_00_INSERT_VG_HISTACESCOB_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_0520_00_INSERT_VG_HISTACESCOB_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}