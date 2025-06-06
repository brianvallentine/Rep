using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.FederalVida.DB2.VF0851B
{
    public class R1200_00_CANCELA_NAO_ACEITACAO_DB_UPDATE_1_Update1 : QueryBasis<R1200_00_CANCELA_NAO_ACEITACAO_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0PROPOSTAVA
				SET SITUACAO = '4' ,
				CODOPER = 403,
				DTMOVTO = DTQITBCO,
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  NRCERTIF =  '{this.V0PROP_NRCERTIF}'";

            return query;
        }
        public string V0PROP_NRCERTIF { get; set; }

        public static void Execute(R1200_00_CANCELA_NAO_ACEITACAO_DB_UPDATE_1_Update1 r1200_00_CANCELA_NAO_ACEITACAO_DB_UPDATE_1_Update1)
        {
            var ths = r1200_00_CANCELA_NAO_ACEITACAO_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1200_00_CANCELA_NAO_ACEITACAO_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}