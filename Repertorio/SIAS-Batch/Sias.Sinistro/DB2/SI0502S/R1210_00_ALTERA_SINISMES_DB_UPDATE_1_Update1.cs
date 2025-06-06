using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0502S
{
    public class R1210_00_ALTERA_SINISMES_DB_UPDATE_1_Update1 : QueryBasis<R1210_00_ALTERA_SINISMES_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.SINISTRO_MESTRE
				SET OCORR_HISTORICO =  '{this.SINISMES_OCORR_HISTORICO}'
				WHERE  NUM_APOL_SINISTRO =  '{this.SINISHIS_NUM_APOL_SINISTRO}'";

            return query;
        }
        public string SINISMES_OCORR_HISTORICO { get; set; }
        public string SINISHIS_NUM_APOL_SINISTRO { get; set; }

        public static void Execute(R1210_00_ALTERA_SINISMES_DB_UPDATE_1_Update1 r1210_00_ALTERA_SINISMES_DB_UPDATE_1_Update1)
        {
            var ths = r1210_00_ALTERA_SINISMES_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1210_00_ALTERA_SINISMES_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}