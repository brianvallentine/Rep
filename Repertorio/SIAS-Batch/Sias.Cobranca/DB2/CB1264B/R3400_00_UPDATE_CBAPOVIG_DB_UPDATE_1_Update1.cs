using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB1264B
{
    public class R3400_00_UPDATE_CBAPOVIG_DB_UPDATE_1_Update1 : QueryBasis<R3400_00_UPDATE_CBAPOVIG_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE
				SEGUROS.CB_APOLICE_VIGPROP
				SET
				SITUACAO = '1' ,
				DATA_CANCELAMENTO =  '{this.SISTEMAS_DATA_MOV_ABERTO}'
				WHERE 
				NUM_APOLICE =  '{this.CBAPOVIG_NUM_APOLICE}'";

            return query;
        }
        public string SISTEMAS_DATA_MOV_ABERTO { get; set; }
        public string CBAPOVIG_NUM_APOLICE { get; set; }

        public static void Execute(R3400_00_UPDATE_CBAPOVIG_DB_UPDATE_1_Update1 r3400_00_UPDATE_CBAPOVIG_DB_UPDATE_1_Update1)
        {
            var ths = r3400_00_UPDATE_CBAPOVIG_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3400_00_UPDATE_CBAPOVIG_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}