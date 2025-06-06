using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0005B
{
    public class R3209_00_ALTERA_NRPROPOS_DB_UPDATE_1_Update1 : QueryBasis<R3209_00_ALTERA_NRPROPOS_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE
				SEGUROS.V0ENDOSSO
				SET NRPROPOS = 900000000 + NRPROPOS
				WHERE  FONTE =  '{this.V0ENDO_FONTE}'
				AND NRPROPOS =  '{this.V0ENDO_NRPROPOS}'";

            return query;
        }
        public string V0ENDO_NRPROPOS { get; set; }
        public string V0ENDO_FONTE { get; set; }

        public static void Execute(R3209_00_ALTERA_NRPROPOS_DB_UPDATE_1_Update1 r3209_00_ALTERA_NRPROPOS_DB_UPDATE_1_Update1)
        {
            var ths = r3209_00_ALTERA_NRPROPOS_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3209_00_ALTERA_NRPROPOS_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}