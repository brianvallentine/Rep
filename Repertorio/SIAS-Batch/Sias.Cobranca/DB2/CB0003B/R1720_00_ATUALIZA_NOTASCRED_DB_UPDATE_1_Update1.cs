using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0003B
{
    public class R1720_00_ATUALIZA_NOTASCRED_DB_UPDATE_1_Update1 : QueryBasis<R1720_00_ATUALIZA_NOTASCRED_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0NOTASCRED
				SET SITUACAO = '1' ,
				OCORHIST =  '{this.HNOTCRE_OCORHIST}',
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  NUM_APOLICE =  '{this.V1PARC_NUM_APOL}'
				AND NRENDOSC =  '{this.V1PARC_NRENDOS}'
				AND NRPARCELC =  '{this.V1PARC_NRPARCEL}'
				AND NRENDOSR =  '{this.V1NOTA_NRENDOSR}'
				AND NRPARCELR =  '{this.V1NOTA_NRPARCELR}'";

            return query;
        }
        public string HNOTCRE_OCORHIST { get; set; }
        public string V1NOTA_NRPARCELR { get; set; }
        public string V1PARC_NUM_APOL { get; set; }
        public string V1PARC_NRPARCEL { get; set; }
        public string V1NOTA_NRENDOSR { get; set; }
        public string V1PARC_NRENDOS { get; set; }

        public static void Execute(R1720_00_ATUALIZA_NOTASCRED_DB_UPDATE_1_Update1 r1720_00_ATUALIZA_NOTASCRED_DB_UPDATE_1_Update1)
        {
            var ths = r1720_00_ATUALIZA_NOTASCRED_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1720_00_ATUALIZA_NOTASCRED_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}