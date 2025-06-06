using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI9101B
{
    public class R2550_00_ALTERA_NUMERAES_DB_UPDATE_1_Update1 : QueryBasis<R2550_00_ALTERA_NUMERAES_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.NUMERO_AES
				SET SEQ_SINISTRO =  '{this.NUMERAES_SEQ_SINISTRO}',
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  ORGAO_EMISSOR =  '{this.APOLICES_ORGAO_EMISSOR}'
				AND RAMO_EMISSOR =  '{this.SIARDEVC_COD_RAMO}'";

            return query;
        }
        public string NUMERAES_SEQ_SINISTRO { get; set; }
        public string APOLICES_ORGAO_EMISSOR { get; set; }
        public string SIARDEVC_COD_RAMO { get; set; }

        public static void Execute(R2550_00_ALTERA_NUMERAES_DB_UPDATE_1_Update1 r2550_00_ALTERA_NUMERAES_DB_UPDATE_1_Update1)
        {
            var ths = r2550_00_ALTERA_NUMERAES_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2550_00_ALTERA_NUMERAES_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}