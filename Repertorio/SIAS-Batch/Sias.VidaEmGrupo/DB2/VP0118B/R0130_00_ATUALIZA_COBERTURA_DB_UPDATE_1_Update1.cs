using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP0118B
{
    public class R0130_00_ATUALIZA_COBERTURA_DB_UPDATE_1_Update1 : QueryBasis<R0130_00_ATUALIZA_COBERTURA_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0COBERPROPVA
				SET
				IMPSEGCDC =  '{this.HOST_IMPSEGCDC_NEW}'
				WHERE  NRCERTIF =  '{this.V0PROP_NRCERTIF}'
				AND OCORHIST =  '{this.HOST_OCORHIST}'";

            return query;
        }
        public string HOST_IMPSEGCDC_NEW { get; set; }
        public string V0PROP_NRCERTIF { get; set; }
        public string HOST_OCORHIST { get; set; }

        public static void Execute(R0130_00_ATUALIZA_COBERTURA_DB_UPDATE_1_Update1 r0130_00_ATUALIZA_COBERTURA_DB_UPDATE_1_Update1)
        {
            var ths = r0130_00_ATUALIZA_COBERTURA_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0130_00_ATUALIZA_COBERTURA_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}