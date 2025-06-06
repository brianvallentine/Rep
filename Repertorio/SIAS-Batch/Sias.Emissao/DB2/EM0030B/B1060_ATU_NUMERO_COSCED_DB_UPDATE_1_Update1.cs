using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0030B
{
    public class B1060_ATU_NUMERO_COSCED_DB_UPDATE_1_Update1 : QueryBasis<B1060_ATU_NUMERO_COSCED_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0NUMERO_COSSEGURO
				SET NRORDEM =  '{this.NORD_NRORDEM}',
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  ORGAO =  '{this.ENDO_ORGAO}'
				AND CONGENER =  '{this.COSS_CODCOSS}'";

            return query;
        }
        public string NORD_NRORDEM { get; set; }
        public string COSS_CODCOSS { get; set; }
        public string ENDO_ORGAO { get; set; }

        public static void Execute(B1060_ATU_NUMERO_COSCED_DB_UPDATE_1_Update1 b1060_ATU_NUMERO_COSCED_DB_UPDATE_1_Update1)
        {
            var ths = b1060_ATU_NUMERO_COSCED_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override B1060_ATU_NUMERO_COSCED_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}