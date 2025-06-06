using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0145B
{
    public class R2910_00_UPDATE_COBERPROPVA_DB_UPDATE_1_Update1 : QueryBasis<R2910_00_UPDATE_COBERPROPVA_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.HIS_COBER_PROPOST
				SET DATA_TERVIGENCIA =
				DATA_INIVIGENCIA
				+  {this.SUBGVGAP_PERI_FATURAMENTO} MONTHS
				- 1 DAY
				WHERE  NUM_CERTIFICADO =  '{this.PROPOVA_NUM_CERTIFICADO}'
				AND OCORR_HISTORICO =  '{this.PROPOVA_OCORR_HISTORICO}'";

            return query;
        }
        public string SUBGVGAP_PERI_FATURAMENTO { get; set; }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }
        public string PROPOVA_OCORR_HISTORICO { get; set; }

        public static void Execute(R2910_00_UPDATE_COBERPROPVA_DB_UPDATE_1_Update1 r2910_00_UPDATE_COBERPROPVA_DB_UPDATE_1_Update1)
        {
            var ths = r2910_00_UPDATE_COBERPROPVA_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2910_00_UPDATE_COBERPROPVA_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}