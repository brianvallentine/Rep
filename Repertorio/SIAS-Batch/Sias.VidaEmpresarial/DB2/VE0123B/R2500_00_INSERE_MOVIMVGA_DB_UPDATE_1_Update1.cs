using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE0123B
{
    public class R2500_00_INSERE_MOVIMVGA_DB_UPDATE_1_Update1 : QueryBasis<R2500_00_INSERE_MOVIMVGA_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.FONTES
				SET ULT_PROP_AUTOMAT =  '{this.WS_NUM_PROPOSTA_AUT}'
				WHERE  COD_FONTE =  '{this.PROPOVA_COD_FONTE}'";

            return query;
        }
        public string WS_NUM_PROPOSTA_AUT { get; set; }
        public string PROPOVA_COD_FONTE { get; set; }

        public static void Execute(R2500_00_INSERE_MOVIMVGA_DB_UPDATE_1_Update1 r2500_00_INSERE_MOVIMVGA_DB_UPDATE_1_Update1)
        {
            var ths = r2500_00_INSERE_MOVIMVGA_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2500_00_INSERE_MOVIMVGA_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}