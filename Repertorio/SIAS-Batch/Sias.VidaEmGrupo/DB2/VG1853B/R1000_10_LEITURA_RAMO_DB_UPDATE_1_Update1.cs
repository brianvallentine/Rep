using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1853B
{
    public class R1000_10_LEITURA_RAMO_DB_UPDATE_1_Update1 : QueryBasis<R1000_10_LEITURA_RAMO_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0PROPOSTAVA
				SET NRPARCE =  '{this.V0PROP_NRPARCEL}',
				SITUACAO =  '{this.V0PROP_SITUACAO}',
				DTVENCTO =  '{this.V0PROP_DTVENCTO}',
				DTPROXVEN =  '{this.V0PROP_DTPROXVEN}',
				NRPRIPARATZ =  '{this.V0PROP_NRPRIPARATZ}',
				QTDPARATZ =  '{this.V0PROP_QTDPARATZ}',
				OCORHIST =  '{this.V0PROP_OCORHIST}',
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  NRCERTIF =  '{this.V0PROP_NRCERTIF}'";

            return query;
        }
        public string V0PROP_NRPRIPARATZ { get; set; }
        public string V0PROP_DTPROXVEN { get; set; }
        public string V0PROP_QTDPARATZ { get; set; }
        public string V0PROP_NRPARCEL { get; set; }
        public string V0PROP_SITUACAO { get; set; }
        public string V0PROP_DTVENCTO { get; set; }
        public string V0PROP_OCORHIST { get; set; }
        public string V0PROP_NRCERTIF { get; set; }

        public static void Execute(R1000_10_LEITURA_RAMO_DB_UPDATE_1_Update1 r1000_10_LEITURA_RAMO_DB_UPDATE_1_Update1)
        {
            var ths = r1000_10_LEITURA_RAMO_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1000_10_LEITURA_RAMO_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}