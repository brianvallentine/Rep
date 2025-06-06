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
    public class R1390_00_TRATA_INF_CONTA_DB_UPDATE_1_Update1 : QueryBasis<R1390_00_TRATA_INF_CONTA_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.OPCAO_PAG_VIDAZUL
				SET DATA_TERVIGENCIA =  '{this.V1SIST_DTMOVABE_1}',
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE NUM_CERTIFICADO =  '{this.WSHOST_NUM_PROPOSTA}'
				AND DATA_TERVIGENCIA = '9999-12-31'";

            return query;
        }
        public string V1SIST_DTMOVABE_1 { get; set; }
        public string WSHOST_NUM_PROPOSTA { get; set; }

        public static void Execute(R1390_00_TRATA_INF_CONTA_DB_UPDATE_1_Update1 r1390_00_TRATA_INF_CONTA_DB_UPDATE_1_Update1)
        {
            var ths = r1390_00_TRATA_INF_CONTA_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1390_00_TRATA_INF_CONTA_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}