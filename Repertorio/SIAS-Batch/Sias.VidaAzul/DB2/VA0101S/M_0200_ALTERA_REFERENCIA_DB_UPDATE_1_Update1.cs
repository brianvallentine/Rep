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
    public class M_0200_ALTERA_REFERENCIA_DB_UPDATE_1_Update1 : QueryBasis<M_0200_ALTERA_REFERENCIA_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0FATURCONTAZ
				SET QTD_VIDAS_VG =  '{this.QTD_VIDAS_VG_W}',
				QTD_VIDAS_AP =  '{this.QTD_VIDAS_AP_W}',
				PRM_VG =  '{this.PRM_VG_W}',
				PRM_AP =  '{this.PRM_AP_W}',
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  DATA_REFERENCIA =  '{this.DTREF}'
				AND CODPRODAZ =  '{this.CODPRODAZ}'";

            return query;
        }
        public string QTD_VIDAS_VG_W { get; set; }
        public string QTD_VIDAS_AP_W { get; set; }
        public string PRM_VG_W { get; set; }
        public string PRM_AP_W { get; set; }
        public string CODPRODAZ { get; set; }
        public string DTREF { get; set; }

        public static void Execute(M_0200_ALTERA_REFERENCIA_DB_UPDATE_1_Update1 m_0200_ALTERA_REFERENCIA_DB_UPDATE_1_Update1)
        {
            var ths = m_0200_ALTERA_REFERENCIA_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_0200_ALTERA_REFERENCIA_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}