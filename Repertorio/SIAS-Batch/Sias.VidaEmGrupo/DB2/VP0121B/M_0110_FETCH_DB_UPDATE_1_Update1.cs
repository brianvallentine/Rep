using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP0121B
{
    public class M_0110_FETCH_DB_UPDATE_1_Update1 : QueryBasis<M_0110_FETCH_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.PROPOSTAS_VA
				SET SIT_REGISTRO = '3'
				WHERE  NUM_CERTIFICADO =  '{this.PROPVA_NRCERTIF}'";

            return query;
        }
        public string PROPVA_NRCERTIF { get; set; }

        public static void Execute(M_0110_FETCH_DB_UPDATE_1_Update1 m_0110_FETCH_DB_UPDATE_1_Update1)
        {
            var ths = m_0110_FETCH_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_0110_FETCH_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}