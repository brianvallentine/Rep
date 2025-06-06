using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GE0853S
{
    public class R1050_00_CANCELA_PROPOSTA_DB_UPDATE_1_Update1 : QueryBasis<R1050_00_CANCELA_PROPOSTA_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0PROPOSTAVA
				SET SITUACAO = '2' ,
				CODOPER = 403,
				CODUSU = 'GE0853S' ,
				DTMOVTO =  '{this.V1SIST_DTMOVABE}',
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  NRCERTIF =  '{this.V0HISC_NRCERTIF}'";

            return query;
        }
        public string V1SIST_DTMOVABE { get; set; }
        public string V0HISC_NRCERTIF { get; set; }

        public static void Execute(R1050_00_CANCELA_PROPOSTA_DB_UPDATE_1_Update1 r1050_00_CANCELA_PROPOSTA_DB_UPDATE_1_Update1)
        {
            var ths = r1050_00_CANCELA_PROPOSTA_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1050_00_CANCELA_PROPOSTA_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}