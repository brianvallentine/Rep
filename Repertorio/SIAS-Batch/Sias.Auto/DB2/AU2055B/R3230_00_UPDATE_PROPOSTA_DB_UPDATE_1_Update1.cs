using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Auto.DB2.AU2055B
{
    public class R3230_00_UPDATE_PROPOSTA_DB_UPDATE_1_Update1 : QueryBasis<R3230_00_UPDATE_PROPOSTA_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.PROPOSTAS
				SET SIT_REGISTRO = '0'
				WHERE  COD_FONTE =  '{this.PROPOSTA_COD_FONTE}'
				AND NUM_PROPOSTA =  '{this.PROPOSTA_NUM_PROPOSTA}'
				AND SIT_REGISTRO = ' '";

            return query;
        }
        public string PROPOSTA_NUM_PROPOSTA { get; set; }
        public string PROPOSTA_COD_FONTE { get; set; }

        public static void Execute(R3230_00_UPDATE_PROPOSTA_DB_UPDATE_1_Update1 r3230_00_UPDATE_PROPOSTA_DB_UPDATE_1_Update1)
        {
            var ths = r3230_00_UPDATE_PROPOSTA_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3230_00_UPDATE_PROPOSTA_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}