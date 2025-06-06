using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0972B
{
    public class R2030_00_UPDATE_RELATORI_DB_UPDATE_1_Update1 : QueryBasis<R2030_00_UPDATE_RELATORI_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.RELATORIOS
				SET SIT_REGISTRO = '1'
				WHERE  NUM_CERTIFICADO =  '{this.RELATORI_NUM_CERTIFICADO}'
				AND NUM_PARCELA =  '{this.RELATORI_NUM_PARCELA}'
				AND COD_RELATORIO =  '{this.RELATORI_COD_RELATORIO}'
				AND SIT_REGISTRO =  '{this.RELATORI_SIT_REGISTRO}'";

            return query;
        }
        public string RELATORI_NUM_CERTIFICADO { get; set; }
        public string RELATORI_COD_RELATORIO { get; set; }
        public string RELATORI_SIT_REGISTRO { get; set; }
        public string RELATORI_NUM_PARCELA { get; set; }

        public static void Execute(R2030_00_UPDATE_RELATORI_DB_UPDATE_1_Update1 r2030_00_UPDATE_RELATORI_DB_UPDATE_1_Update1)
        {
            var ths = r2030_00_UPDATE_RELATORI_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2030_00_UPDATE_RELATORI_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}