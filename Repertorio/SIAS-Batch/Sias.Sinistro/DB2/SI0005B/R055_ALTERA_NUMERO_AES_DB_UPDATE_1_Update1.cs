using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0005B
{
    public class R055_ALTERA_NUMERO_AES_DB_UPDATE_1_Update1 : QueryBasis<R055_ALTERA_NUMERO_AES_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.NUMERO_AES
				SET SEQ_SINISTRO =  '{this.NUMERAES_SEQ_SINISTRO}'
				WHERE  ORGAO_EMISSOR = 10
				AND RAMO_EMISSOR =  '{this.APOLICES_RAMO_EMISSOR}'";

            return query;
        }
        public string NUMERAES_SEQ_SINISTRO { get; set; }
        public string APOLICES_RAMO_EMISSOR { get; set; }

        public static void Execute(R055_ALTERA_NUMERO_AES_DB_UPDATE_1_Update1 r055_ALTERA_NUMERO_AES_DB_UPDATE_1_Update1)
        {
            var ths = r055_ALTERA_NUMERO_AES_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R055_ALTERA_NUMERO_AES_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}