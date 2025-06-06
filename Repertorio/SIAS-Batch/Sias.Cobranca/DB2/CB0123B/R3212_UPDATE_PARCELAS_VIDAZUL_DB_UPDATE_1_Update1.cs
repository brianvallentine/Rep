using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0123B
{
    public class R3212_UPDATE_PARCELAS_VIDAZUL_DB_UPDATE_1_Update1 : QueryBasis<R3212_UPDATE_PARCELAS_VIDAZUL_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.PARCELAS_VIDAZUL
				SET SIT_REGISTRO = '1'
				WHERE  NUM_CERTIFICADO =  '{this.PARCEVID_NUM_CERTIFICADO}'
				AND NUM_PARCELA =  '{this.PARCEVID_NUM_PARCELA}'";

            return query;
        }
        public string PARCEVID_NUM_CERTIFICADO { get; set; }
        public string PARCEVID_NUM_PARCELA { get; set; }

        public static void Execute(R3212_UPDATE_PARCELAS_VIDAZUL_DB_UPDATE_1_Update1 r3212_UPDATE_PARCELAS_VIDAZUL_DB_UPDATE_1_Update1)
        {
            var ths = r3212_UPDATE_PARCELAS_VIDAZUL_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3212_UPDATE_PARCELAS_VIDAZUL_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}