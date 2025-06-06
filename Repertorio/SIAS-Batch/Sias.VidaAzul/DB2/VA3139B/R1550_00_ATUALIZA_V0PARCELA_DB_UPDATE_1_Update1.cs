using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA3139B
{
    public class R1550_00_ATUALIZA_V0PARCELA_DB_UPDATE_1_Update1 : QueryBasis<R1550_00_ATUALIZA_V0PARCELA_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0PARCELA
				SET SITUACAO = '1' ,
				OCORHIST =  '{this.V0PARC_OCORHIST}'
				WHERE  NUM_APOLICE =  '{this.V0ENDO_NUM_APOLICE}'
				AND NRENDOS =  '{this.V0ENDO_NRENDOS}'
				AND SITUACAO = '0'";

            return query;
        }
        public string V0PARC_OCORHIST { get; set; }
        public string V0ENDO_NUM_APOLICE { get; set; }
        public string V0ENDO_NRENDOS { get; set; }

        public static void Execute(R1550_00_ATUALIZA_V0PARCELA_DB_UPDATE_1_Update1 r1550_00_ATUALIZA_V0PARCELA_DB_UPDATE_1_Update1)
        {
            var ths = r1550_00_ATUALIZA_V0PARCELA_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1550_00_ATUALIZA_V0PARCELA_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}