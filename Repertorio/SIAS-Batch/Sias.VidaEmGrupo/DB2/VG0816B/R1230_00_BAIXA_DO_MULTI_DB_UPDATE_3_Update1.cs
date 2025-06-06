using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0816B
{
    public class R1230_00_BAIXA_DO_MULTI_DB_UPDATE_3_Update1 : QueryBasis<R1230_00_BAIXA_DO_MULTI_DB_UPDATE_3_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0PROPOSTAVA
				SET SITUACAO = '0' ,
				DTQITBCO =  '{this.V0MOVC_DTQITBCO}'
				WHERE  NRCERTIF =  '{this.V0HCOB_NRCERTIF}'";

            return query;
        }
        public string V0MOVC_DTQITBCO { get; set; }
        public string V0HCOB_NRCERTIF { get; set; }

        public static void Execute(R1230_00_BAIXA_DO_MULTI_DB_UPDATE_3_Update1 r1230_00_BAIXA_DO_MULTI_DB_UPDATE_3_Update1)
        {
            var ths = r1230_00_BAIXA_DO_MULTI_DB_UPDATE_3_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1230_00_BAIXA_DO_MULTI_DB_UPDATE_3_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}