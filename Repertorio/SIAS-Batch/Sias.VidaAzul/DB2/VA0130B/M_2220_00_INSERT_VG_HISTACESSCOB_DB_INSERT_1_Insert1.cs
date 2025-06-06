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
    public class M_2220_00_INSERT_VG_HISTACESSCOB_DB_INSERT_1_Insert1 : QueryBasis<M_2220_00_INSERT_VG_HISTACESSCOB_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.VG_HIST_ACESS_COB
            VALUES (:PROPVA-NRCERTIF,
            :PROPVA-OCORHIST,
            :VGPLAA-NUM-ACESSORIO,
            :VGPLAA-QTD-COBERTURA,
            :VGPLAA-IMPSEGURADA,
            :VGPLAA-CUSTO,
            :VGPLAA-PREMIO)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.VG_HIST_ACESS_COB VALUES ({FieldThreatment(this.PROPVA_NRCERTIF)}, {FieldThreatment(this.PROPVA_OCORHIST)}, {FieldThreatment(this.VGPLAA_NUM_ACESSORIO)}, {FieldThreatment(this.VGPLAA_QTD_COBERTURA)}, {FieldThreatment(this.VGPLAA_IMPSEGURADA)}, {FieldThreatment(this.VGPLAA_CUSTO)}, {FieldThreatment(this.VGPLAA_PREMIO)})";

            return query;
        }
        public string PROPVA_NRCERTIF { get; set; }
        public string PROPVA_OCORHIST { get; set; }
        public string VGPLAA_NUM_ACESSORIO { get; set; }
        public string VGPLAA_QTD_COBERTURA { get; set; }
        public string VGPLAA_IMPSEGURADA { get; set; }
        public string VGPLAA_CUSTO { get; set; }
        public string VGPLAA_PREMIO { get; set; }

        public static void Execute(M_2220_00_INSERT_VG_HISTACESSCOB_DB_INSERT_1_Insert1 m_2220_00_INSERT_VG_HISTACESSCOB_DB_INSERT_1_Insert1)
        {
            var ths = m_2220_00_INSERT_VG_HISTACESSCOB_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_2220_00_INSERT_VG_HISTACESSCOB_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}