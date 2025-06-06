using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI6252B
{
    public class R3100_00_UPDATE_NUMEROAES_DB_UPDATE_1_Update1 : QueryBasis<R3100_00_UPDATE_NUMEROAES_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.NUMERO_AES
				SET SEQ_APOLICE =
				 '{this.NUMERAES_SEQ_APOLICE}'
				WHERE  ORGAO_EMISSOR =
				 '{this.NUMERAES_ORGAO_EMISSOR}'
				AND RAMO_EMISSOR =
				 '{this.NUMERAES_RAMO_EMISSOR}'";

            return query;
        }
        public string NUMERAES_SEQ_APOLICE { get; set; }
        public string NUMERAES_ORGAO_EMISSOR { get; set; }
        public string NUMERAES_RAMO_EMISSOR { get; set; }

        public static void Execute(R3100_00_UPDATE_NUMEROAES_DB_UPDATE_1_Update1 r3100_00_UPDATE_NUMEROAES_DB_UPDATE_1_Update1)
        {
            var ths = r3100_00_UPDATE_NUMEROAES_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3100_00_UPDATE_NUMEROAES_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}