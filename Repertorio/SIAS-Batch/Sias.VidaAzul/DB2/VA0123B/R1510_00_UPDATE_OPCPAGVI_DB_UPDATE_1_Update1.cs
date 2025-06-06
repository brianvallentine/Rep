using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0123B
{
    public class R1510_00_UPDATE_OPCPAGVI_DB_UPDATE_1_Update1 : QueryBasis<R1510_00_UPDATE_OPCPAGVI_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.OPCAO_PAG_VIDAZUL
				SET DATA_TERVIGENCIA =  '{this.SISTEMAS_DATA_MOV_ABERTO_01}'
				WHERE  NUM_CERTIFICADO =  '{this.PROPOVA_NUM_CERTIFICADO}'
				AND DATA_TERVIGENCIA = '9999-12-31'";

            return query;
        }
        public string SISTEMAS_DATA_MOV_ABERTO_01 { get; set; }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }

        public static void Execute(R1510_00_UPDATE_OPCPAGVI_DB_UPDATE_1_Update1 r1510_00_UPDATE_OPCPAGVI_DB_UPDATE_1_Update1)
        {
            var ths = r1510_00_UPDATE_OPCPAGVI_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1510_00_UPDATE_OPCPAGVI_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}