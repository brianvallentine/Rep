using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0015B
{
    public class R0150_00_UPDATE_V0EMISDIARIA_DB_UPDATE_1_Update1 : QueryBasis<R0150_00_UPDATE_V0EMISDIARIA_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0EMISDIARIA
				SET SITUACAO =  '{this.V0EMISD_SITUACAO}'
				WHERE  CODRELAT =  '{this.V0EMISD_CODRELAT}'
				AND NUM_APOLICE =  '{this.V0EMISD_NUM_APOLICE}'
				AND NRENDOS =  '{this.V0EMISD_NRENDOS}'
				AND NRPARCEL =  '{this.V0EMISD_NRPARCEL}'";

            return query;
        }
        public string V0EMISD_SITUACAO { get; set; }
        public string V0EMISD_NUM_APOLICE { get; set; }
        public string V0EMISD_CODRELAT { get; set; }
        public string V0EMISD_NRPARCEL { get; set; }
        public string V0EMISD_NRENDOS { get; set; }

        public static void Execute(R0150_00_UPDATE_V0EMISDIARIA_DB_UPDATE_1_Update1 r0150_00_UPDATE_V0EMISDIARIA_DB_UPDATE_1_Update1)
        {
            var ths = r0150_00_UPDATE_V0EMISDIARIA_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0150_00_UPDATE_V0EMISDIARIA_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}