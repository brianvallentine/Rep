using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0031B
{
    public class R0410_00_UPDATE_V0RELATORIO_DB_UPDATE_1_Update1 : QueryBasis<R0410_00_UPDATE_V0RELATORIO_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE
				SEGUROS.V0RELATORIOS
				SET SITUACAO = '2' ,
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  CODUSU =  '{this.V1REL_COD_USUR}'
				AND CODRELAT =  '{this.V1REL_CODRELAT}'
				AND NUM_APOLICE =  '{this.V1REL_NUM_APOL}'
				AND CODSUBES =  '{this.V1REL_COD_SUBG}'
				AND SITUACAO = '0'";

            return query;
        }
        public string V1REL_COD_USUR { get; set; }
        public string V1REL_CODRELAT { get; set; }
        public string V1REL_NUM_APOL { get; set; }
        public string V1REL_COD_SUBG { get; set; }

        public static void Execute(R0410_00_UPDATE_V0RELATORIO_DB_UPDATE_1_Update1 r0410_00_UPDATE_V0RELATORIO_DB_UPDATE_1_Update1)
        {
            var ths = r0410_00_UPDATE_V0RELATORIO_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0410_00_UPDATE_V0RELATORIO_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}