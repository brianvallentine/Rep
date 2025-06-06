using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0001B
{
    public class M_6000_UPDATE_SIT_PROPOSTA_DB_UPDATE_1_Update1 : QueryBasis<M_6000_UPDATE_SIT_PROPOSTA_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.PROPOSTAS_VA
				SET SIT_REGISTRO =  '{this.PROPOVA_SIT_REGISTRO}'
				WHERE  NUM_CERTIFICADO =  '{this.PROPOVA_NUM_CERTIFICADO}'";

            return query;
        }
        public string PROPOVA_SIT_REGISTRO { get; set; }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }

        public static void Execute(M_6000_UPDATE_SIT_PROPOSTA_DB_UPDATE_1_Update1 m_6000_UPDATE_SIT_PROPOSTA_DB_UPDATE_1_Update1)
        {
            var ths = m_6000_UPDATE_SIT_PROPOSTA_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_6000_UPDATE_SIT_PROPOSTA_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}