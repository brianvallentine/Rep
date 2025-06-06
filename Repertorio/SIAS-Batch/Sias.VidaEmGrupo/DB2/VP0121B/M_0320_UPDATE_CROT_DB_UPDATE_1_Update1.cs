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
    public class M_0320_UPDATE_CROT_DB_UPDATE_1_Update1 : QueryBasis<M_0320_UPDATE_CROT_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0CLIENTE_CROT
				SET BILH_VDAZUL = 'S' ,
				DTMOVABE =  '{this.CLIROT_DTMOVABE}'
				WHERE  CGCCPF =  '{this.CLIENT_CGCCPF}'";

            return query;
        }
        public string CLIROT_DTMOVABE { get; set; }
        public string CLIENT_CGCCPF { get; set; }

        public static void Execute(M_0320_UPDATE_CROT_DB_UPDATE_1_Update1 m_0320_UPDATE_CROT_DB_UPDATE_1_Update1)
        {
            var ths = m_0320_UPDATE_CROT_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_0320_UPDATE_CROT_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}