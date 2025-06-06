using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1625B
{
    public class R2470_UPDATE_PLAN_VGAP_DB_UPDATE_1_Update1 : QueryBasis<R2470_UPDATE_PLAN_VGAP_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.PLANOS_VGAP
				SET SIT_REGISTRO =  '{this.WS_SIT_REGISTRO}'
				WHERE  NUM_APOLICE =  '{this.PROPOVA_NUM_APOLICE}'
				AND COD_PLANO =  '{this.PLANOVGA_COD_PLANO}'
				AND COD_SUBGRUPO =  '{this.PROPOVA_COD_SUBGRUPO}'";

            return query;
        }
        public string WS_SIT_REGISTRO { get; set; }
        public string PROPOVA_COD_SUBGRUPO { get; set; }
        public string PROPOVA_NUM_APOLICE { get; set; }
        public string PLANOVGA_COD_PLANO { get; set; }

        public static void Execute(R2470_UPDATE_PLAN_VGAP_DB_UPDATE_1_Update1 r2470_UPDATE_PLAN_VGAP_DB_UPDATE_1_Update1)
        {
            var ths = r2470_UPDATE_PLAN_VGAP_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2470_UPDATE_PLAN_VGAP_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}