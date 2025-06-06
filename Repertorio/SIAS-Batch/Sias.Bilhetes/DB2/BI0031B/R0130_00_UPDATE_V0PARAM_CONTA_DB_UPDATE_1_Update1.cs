using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0031B
{
    public class R0130_00_UPDATE_V0PARAM_CONTA_DB_UPDATE_1_Update1 : QueryBasis<R0130_00_UPDATE_V0PARAM_CONTA_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0PARAM_CONTACEF
				SET NSAS =  '{this.V0PARAMC_NSAS}',
				DTMOVTO =  '{this.V1SISTE_DTCURRENT}',
				DTPROX_DEB =  '{this.V0PARAMC_DTPROX_DEB}',
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  TIPO_MOVTOCC =  '{this.V0PARAMC_TIPO_MOVTOCC}'
				AND COD_CONVENIO =  '{this.V0PARAMC_COD_CONVENIO}'
				AND SITUACAO =  '{this.V0PARAMC_SITUACAO}'";

            return query;
        }
        public string V0PARAMC_DTPROX_DEB { get; set; }
        public string V1SISTE_DTCURRENT { get; set; }
        public string V0PARAMC_NSAS { get; set; }
        public string V0PARAMC_TIPO_MOVTOCC { get; set; }
        public string V0PARAMC_COD_CONVENIO { get; set; }
        public string V0PARAMC_SITUACAO { get; set; }

        public static void Execute(R0130_00_UPDATE_V0PARAM_CONTA_DB_UPDATE_1_Update1 r0130_00_UPDATE_V0PARAM_CONTA_DB_UPDATE_1_Update1)
        {
            var ths = r0130_00_UPDATE_V0PARAM_CONTA_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0130_00_UPDATE_V0PARAM_CONTA_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}