using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA1139B
{
    public class R1110_00_VERIFICA_RCAP_DB_UPDATE_1_Update1 : QueryBasis<R1110_00_VERIFICA_RCAP_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0RCAP
				SET NRENDOS =  '{this.V0ENDO_NRENDOS}',
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  FONTE =  '{this.V0RCAP_FONTE}'
				AND NRRCAP =  '{this.V0RCAP_NRRCAP}'";

            return query;
        }
        public string V0ENDO_NRENDOS { get; set; }
        public string V0RCAP_NRRCAP { get; set; }
        public string V0RCAP_FONTE { get; set; }

        public static void Execute(R1110_00_VERIFICA_RCAP_DB_UPDATE_1_Update1 r1110_00_VERIFICA_RCAP_DB_UPDATE_1_Update1)
        {
            var ths = r1110_00_VERIFICA_RCAP_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1110_00_VERIFICA_RCAP_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}