using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0280B
{
    public class R1325_00_TRATA_RENDA_IND_DB_UPDATE_1_Update1 : QueryBasis<R1325_00_TRATA_RENDA_IND_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.PROPOSTA_FIDELIZ
				SET FAIXA_RENDA_IND =  '{this.FAIXA_RENDA_IND}'
				WHERE NUM_PROPOSTA_SIVPF =  '{this.PROPOVA_NUM_CERTIFICADO}'";

            return query;
        }
        public string FAIXA_RENDA_IND { get; set; }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }

        public static void Execute(R1325_00_TRATA_RENDA_IND_DB_UPDATE_1_Update1 r1325_00_TRATA_RENDA_IND_DB_UPDATE_1_Update1)
        {
            var ths = r1325_00_TRATA_RENDA_IND_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1325_00_TRATA_RENDA_IND_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}