using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0003B
{
    public class R1500_00_UPDATE_NUMERCOS_DB_UPDATE_1_Update1 : QueryBasis<R1500_00_UPDATE_NUMERCOS_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.NUMERO_COSSEGURO
				SET SEQ_ORD_CEDIDO =  '{this.NUMERCOS_SEQ_ORD_CEDIDO}' ,
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  ORGAO_EMISSOR =  '{this.APOLICES_ORGAO_EMISSOR}'
				AND COD_CONGENERE =  '{this.APOLCOSS_COD_COSSEGURADORA}'";

            return query;
        }
        public string NUMERCOS_SEQ_ORD_CEDIDO { get; set; }
        public string APOLCOSS_COD_COSSEGURADORA { get; set; }
        public string APOLICES_ORGAO_EMISSOR { get; set; }

        public static void Execute(R1500_00_UPDATE_NUMERCOS_DB_UPDATE_1_Update1 r1500_00_UPDATE_NUMERCOS_DB_UPDATE_1_Update1)
        {
            var ths = r1500_00_UPDATE_NUMERCOS_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1500_00_UPDATE_NUMERCOS_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}