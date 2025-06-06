using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.FederalVida.DB2.VF0813B
{
    public class M_1036_BAIXA_HISTCTA_DB_UPDATE_1_Update1 : QueryBasis<M_1036_BAIXA_HISTCTA_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0HISTCONTAVA
				SET SITUACAO = '1' ,
				NSAC =  '{this.V0FTCF_NSAC}',
				CODRET = 0,
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  CODCONV =  '{this.WHOST_CODCONV}'
				AND NSAS =  '{this.V0HCTA_NSAS}'
				AND NSL =  '{this.V0HCTA_NSL}'";

            return query;
        }
        public string V0FTCF_NSAC { get; set; }
        public string WHOST_CODCONV { get; set; }
        public string V0HCTA_NSAS { get; set; }
        public string V0HCTA_NSL { get; set; }

        public static void Execute(M_1036_BAIXA_HISTCTA_DB_UPDATE_1_Update1 m_1036_BAIXA_HISTCTA_DB_UPDATE_1_Update1)
        {
            var ths = m_1036_BAIXA_HISTCTA_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_1036_BAIXA_HISTCTA_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}