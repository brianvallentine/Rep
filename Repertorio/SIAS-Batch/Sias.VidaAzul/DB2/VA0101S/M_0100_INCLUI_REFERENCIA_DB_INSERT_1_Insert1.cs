using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0101S
{
    public class M_0100_INCLUI_REFERENCIA_DB_INSERT_1_Insert1 : QueryBasis<M_0100_INCLUI_REFERENCIA_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0FATURCONTAZ
            VALUES (:DTREF,
            :CODPRODAZ,
            :QTD-VIDAS-VG,
            :QTD-VIDAS-AP,
            :PRM-VG,
            :PRM-AP,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0FATURCONTAZ VALUES ({FieldThreatment(this.DTREF)}, {FieldThreatment(this.CODPRODAZ)}, {FieldThreatment(this.QTD_VIDAS_VG)}, {FieldThreatment(this.QTD_VIDAS_AP)}, {FieldThreatment(this.PRM_VG)}, {FieldThreatment(this.PRM_AP)}, CURRENT TIMESTAMP)";

            return query;
        }
        public string DTREF { get; set; }
        public string CODPRODAZ { get; set; }
        public string QTD_VIDAS_VG { get; set; }
        public string QTD_VIDAS_AP { get; set; }
        public string PRM_VG { get; set; }
        public string PRM_AP { get; set; }

        public static void Execute(M_0100_INCLUI_REFERENCIA_DB_INSERT_1_Insert1 m_0100_INCLUI_REFERENCIA_DB_INSERT_1_Insert1)
        {
            var ths = m_0100_INCLUI_REFERENCIA_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_0100_INCLUI_REFERENCIA_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}