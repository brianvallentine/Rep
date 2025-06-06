using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB1262B
{
    public class R1100_00_UPDATE_CBAPOVIG_DB_UPDATE_1_Update1 : QueryBasis<R1100_00_UPDATE_CBAPOVIG_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE
				SEGUROS.CB_APOLICE_VIGPROP
				SET
				SITUACAO =  '{this.CBAPOVIG_SITUACAO}',
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE 
				NUM_APOLICE =  '{this.PARCEHIS_NUM_APOLICE}'";

            return query;
        }
        public string CBAPOVIG_SITUACAO { get; set; }
        public string PARCEHIS_NUM_APOLICE { get; set; }

        public static void Execute(R1100_00_UPDATE_CBAPOVIG_DB_UPDATE_1_Update1 r1100_00_UPDATE_CBAPOVIG_DB_UPDATE_1_Update1)
        {
            var ths = r1100_00_UPDATE_CBAPOVIG_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1100_00_UPDATE_CBAPOVIG_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}