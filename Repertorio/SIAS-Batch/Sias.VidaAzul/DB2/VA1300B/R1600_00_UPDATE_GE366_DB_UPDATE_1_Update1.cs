using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA1300B
{
    public class R1600_00_UPDATE_GE366_DB_UPDATE_1_Update1 : QueryBasis<R1600_00_UPDATE_GE366_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.GE_MOVIMENTO
				SET IND_EVENTO =  '{this.GE366_IND_EVENTO}'
				WHERE  NUM_OCORR_MOVTO =  '{this.GE366_NUM_OCORR_MOVTO}'";

            return query;
        }
        public string GE366_IND_EVENTO { get; set; }
        public string GE366_NUM_OCORR_MOVTO { get; set; }

        public static void Execute(R1600_00_UPDATE_GE366_DB_UPDATE_1_Update1 r1600_00_UPDATE_GE366_DB_UPDATE_1_Update1)
        {
            var ths = r1600_00_UPDATE_GE366_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1600_00_UPDATE_GE366_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}