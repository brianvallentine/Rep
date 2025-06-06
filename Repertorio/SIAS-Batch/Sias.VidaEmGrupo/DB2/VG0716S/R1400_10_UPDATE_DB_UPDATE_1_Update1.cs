using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0716S
{
    public class R1400_10_UPDATE_DB_UPDATE_1_Update1 : QueryBasis<R1400_10_UPDATE_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.TITULOS_FED_CAP_VA
				SET DATA_INIVIGENCIA =  '{this.TITFEDCA_DATA_INIVIGENCIA}',
				DATA_TERVIGENCIA =  '{this.TITFEDCA_DATA_TERVIGENCIA}'
				WHERE  NRTITFDCAP =  '{this.MOVFEDCA_NRTITFDCAP}'
				AND NUM_CERTIFICADO =  '{this.TITFEDCA_NUM_CERTIFICADO}'
				AND DATA_INIVIGENCIA = '0001-01-01'";

            return query;
        }
        public string TITFEDCA_DATA_INIVIGENCIA { get; set; }
        public string TITFEDCA_DATA_TERVIGENCIA { get; set; }
        public string TITFEDCA_NUM_CERTIFICADO { get; set; }
        public string MOVFEDCA_NRTITFDCAP { get; set; }

        public static void Execute(R1400_10_UPDATE_DB_UPDATE_1_Update1 r1400_10_UPDATE_DB_UPDATE_1_Update1)
        {
            var ths = r1400_10_UPDATE_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1400_10_UPDATE_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}