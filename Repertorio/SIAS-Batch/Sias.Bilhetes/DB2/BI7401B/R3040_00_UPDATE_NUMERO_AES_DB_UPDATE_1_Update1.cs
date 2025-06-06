using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI7401B
{
    public class R3040_00_UPDATE_NUMERO_AES_DB_UPDATE_1_Update1 : QueryBasis<R3040_00_UPDATE_NUMERO_AES_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE
				SEGUROS.NUMERO_AES
				SET ENDOS_CANC_RESTI =  '{this.NUMERAES_ENDOS_CANC_RESTI}'
				WHERE  ORGAO_EMISSOR =  '{this.NUMERAES_ORGAO_EMISSOR}'
				AND RAMO_EMISSOR =  '{this.NUMERAES_RAMO_EMISSOR}'";

            return query;
        }
        public string NUMERAES_ENDOS_CANC_RESTI { get; set; }
        public string NUMERAES_ORGAO_EMISSOR { get; set; }
        public string NUMERAES_RAMO_EMISSOR { get; set; }

        public static void Execute(R3040_00_UPDATE_NUMERO_AES_DB_UPDATE_1_Update1 r3040_00_UPDATE_NUMERO_AES_DB_UPDATE_1_Update1)
        {
            var ths = r3040_00_UPDATE_NUMERO_AES_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3040_00_UPDATE_NUMERO_AES_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}