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
    public class FINALIZA_1110_FIM_DB_UPDATE_2_Update1 : QueryBasis<FINALIZA_1110_FIM_DB_UPDATE_2_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0RCAP
				SET NRCERTIF =  '{this.PROPVA_NRCERTIF}'
				WHERE  FONTE =  '{this.V0RCAP_FONTE}'
				AND NRRCAP =  '{this.V0RCAP_NRRCAP}'";

            return query;
        }
        public string PROPVA_NRCERTIF { get; set; }
        public string V0RCAP_NRRCAP { get; set; }
        public string V0RCAP_FONTE { get; set; }

        public static void Execute(FINALIZA_1110_FIM_DB_UPDATE_2_Update1 fINALIZA_1110_FIM_DB_UPDATE_2_Update1)
        {
            var ths = fINALIZA_1110_FIM_DB_UPDATE_2_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override FINALIZA_1110_FIM_DB_UPDATE_2_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}