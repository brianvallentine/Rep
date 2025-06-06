using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0852B
{
    public class R1700_00_CANC_PARC_DB_UPDATE_1_Update1 : QueryBasis<R1700_00_CANC_PARC_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.PARCELAS_VIDAZUL
				SET SIT_REGISTRO = '2'
				WHERE  NUM_CERTIFICADO =  '{this.PROPOVA_NUM_CERTIFICADO}'
				AND SIT_REGISTRO <> '1'";

            return query;
        }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }

        public static void Execute(R1700_00_CANC_PARC_DB_UPDATE_1_Update1 r1700_00_CANC_PARC_DB_UPDATE_1_Update1)
        {
            var ths = r1700_00_CANC_PARC_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1700_00_CANC_PARC_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}