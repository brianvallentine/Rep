using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0030B
{
    public class B3160_ALTERA_V0PARCELA_DB_UPDATE_1_Update1 : QueryBasis<B3160_ALTERA_V0PARCELA_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE
				SEGUROS.V0PARCELA
				SET OCORHIST = 1,
				SITUACAO = '0'
				WHERE  NUM_APOLICE =  '{this.PARC_NUM_APOLICE}'
				AND NRENDOS =  '{this.PARC_NRENDOS}'
				AND NRPARCEL =  '{this.PARC_NRPARCEL}'";

            return query;
        }
        public string PARC_NUM_APOLICE { get; set; }
        public string PARC_NRPARCEL { get; set; }
        public string PARC_NRENDOS { get; set; }

        public static void Execute(B3160_ALTERA_V0PARCELA_DB_UPDATE_1_Update1 b3160_ALTERA_V0PARCELA_DB_UPDATE_1_Update1)
        {
            var ths = b3160_ALTERA_V0PARCELA_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override B3160_ALTERA_V0PARCELA_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}