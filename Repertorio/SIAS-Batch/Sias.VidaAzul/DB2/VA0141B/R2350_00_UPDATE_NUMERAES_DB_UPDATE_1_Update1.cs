using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0141B
{
    public class R2350_00_UPDATE_NUMERAES_DB_UPDATE_1_Update1 : QueryBasis<R2350_00_UPDATE_NUMERAES_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.NUMERO_AES
				SET ENDOS_COBRANCA =  '{this.NUMERAES_ENDOS_COBRANCA}'
				,ENDOS_RESTITUICAO =  '{this.NUMERAES_ENDOS_RESTITUICAO}'
				WHERE  ORGAO_EMISSOR =  '{this.NUMERAES_ORGAO_EMISSOR}'
				AND RAMO_EMISSOR =  '{this.NUMERAES_RAMO_EMISSOR}'";

            return query;
        }
        public string NUMERAES_ENDOS_RESTITUICAO { get; set; }
        public string NUMERAES_ENDOS_COBRANCA { get; set; }
        public string NUMERAES_ORGAO_EMISSOR { get; set; }
        public string NUMERAES_RAMO_EMISSOR { get; set; }

        public static void Execute(R2350_00_UPDATE_NUMERAES_DB_UPDATE_1_Update1 r2350_00_UPDATE_NUMERAES_DB_UPDATE_1_Update1)
        {
            var ths = r2350_00_UPDATE_NUMERAES_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2350_00_UPDATE_NUMERAES_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}