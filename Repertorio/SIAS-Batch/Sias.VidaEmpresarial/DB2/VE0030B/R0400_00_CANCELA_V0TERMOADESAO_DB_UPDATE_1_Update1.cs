using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE0030B
{
    public class R0400_00_CANCELA_V0TERMOADESAO_DB_UPDATE_1_Update1 : QueryBasis<R0400_00_CANCELA_V0TERMOADESAO_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE
				SEGUROS.V0TERMOADESAO
				SET COD_USUARIO =  '{this.V1REL_COD_USUR}',
				TIMESTAMP = CURRENT TIMESTAMP,
				SITUACAO = '2'
				WHERE  NUM_TERMO =  '{this.V0TERMO_NUM_TERMO}'
				AND COD_SUBGRUPO =  '{this.V0TERMO_COD_SUBG}'";

            return query;
        }
        public string V1REL_COD_USUR { get; set; }
        public string V0TERMO_NUM_TERMO { get; set; }
        public string V0TERMO_COD_SUBG { get; set; }

        public static void Execute(R0400_00_CANCELA_V0TERMOADESAO_DB_UPDATE_1_Update1 r0400_00_CANCELA_V0TERMOADESAO_DB_UPDATE_1_Update1)
        {
            var ths = r0400_00_CANCELA_V0TERMOADESAO_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0400_00_CANCELA_V0TERMOADESAO_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}