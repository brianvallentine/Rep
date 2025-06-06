using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0344B
{
    public class M_9000_FINALIZA_DB_UPDATE_1_Update1 : QueryBasis<M_9000_FINALIZA_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0CONVSUCOV
				SET NSA_CONVENIO =  '{this.PARM_NSA}'
				WHERE  COD_CONVENIO = 6088";

            return query;
        }
        public string PARM_NSA { get; set; }

        public static void Execute(M_9000_FINALIZA_DB_UPDATE_1_Update1 m_9000_FINALIZA_DB_UPDATE_1_Update1)
        {
            var ths = m_9000_FINALIZA_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_9000_FINALIZA_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}