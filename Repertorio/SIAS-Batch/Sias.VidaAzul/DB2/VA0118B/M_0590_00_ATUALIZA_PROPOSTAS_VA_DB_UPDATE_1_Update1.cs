using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0118B
{
    public class M_0590_00_ATUALIZA_PROPOSTAS_VA_DB_UPDATE_1_Update1 : QueryBasis<M_0590_00_ATUALIZA_PROPOSTAS_VA_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.PROPOSTAS_VA
				SET SIT_REGISTRO =  '{this.PROPVA_SITUACAO}'
				, COD_USUARIO = 'VA0118B'
				, DTA_DECLINIO =  '{this.SISTEMA_DTMOVABE}'
				WHERE  NUM_CERTIFICADO =  '{this.PROPVA_NRCERTIF}'";

            return query;
        }
        public string SISTEMA_DTMOVABE { get; set; }
        public string PROPVA_SITUACAO { get; set; }
        public string PROPVA_NRCERTIF { get; set; }

        public static void Execute(M_0590_00_ATUALIZA_PROPOSTAS_VA_DB_UPDATE_1_Update1 m_0590_00_ATUALIZA_PROPOSTAS_VA_DB_UPDATE_1_Update1)
        {
            var ths = m_0590_00_ATUALIZA_PROPOSTAS_VA_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_0590_00_ATUALIZA_PROPOSTAS_VA_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}