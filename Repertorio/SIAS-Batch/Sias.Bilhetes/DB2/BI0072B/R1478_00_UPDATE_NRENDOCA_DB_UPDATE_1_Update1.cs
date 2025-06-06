using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0072B
{
    public class R1478_00_UPDATE_NRENDOCA_DB_UPDATE_1_Update1 : QueryBasis<R1478_00_UPDATE_NRENDOCA_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.NUMERO_AES
				SET ENDOS_CANCELA =  '{this.NUMERAES_ENDOS_CANCELA}'
				WHERE  RAMO_EMISSOR =  '{this.NUMERAES_RAMO_EMISSOR}'
				AND ORGAO_EMISSOR =  '{this.NUMERAES_ORGAO_EMISSOR}'";

            return query;
        }
        public string NUMERAES_ENDOS_CANCELA { get; set; }
        public string NUMERAES_ORGAO_EMISSOR { get; set; }
        public string NUMERAES_RAMO_EMISSOR { get; set; }

        public static void Execute(R1478_00_UPDATE_NRENDOCA_DB_UPDATE_1_Update1 r1478_00_UPDATE_NRENDOCA_DB_UPDATE_1_Update1)
        {
            var ths = r1478_00_UPDATE_NRENDOCA_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1478_00_UPDATE_NRENDOCA_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}