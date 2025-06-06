using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Auto.DB2.AU2055B
{
    public class R5050_00_UPDATE_AU057_DB_UPDATE_1_Update1 : QueryBasis<R5050_00_UPDATE_AU057_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.AU_PROP_CONV_VC
				SET COD_FONTE =  '{this.AU057_COD_FONTE}' ,
				NUM_PROPOSTA =  '{this.AU057_NUM_PROPOSTA}' ,
				IND_OPERACAO =  '{this.AU057_IND_OPERACAO}'
				WHERE  NUM_PROPOSTA_VC =  '{this.WHOST_PROPOSTA_VC}'
				AND COD_CONGENERE =  '{this.WHOST_CONGENERE}'";

            return query;
        }
        public string AU057_NUM_PROPOSTA { get; set; }
        public string AU057_IND_OPERACAO { get; set; }
        public string AU057_COD_FONTE { get; set; }
        public string WHOST_PROPOSTA_VC { get; set; }
        public string WHOST_CONGENERE { get; set; }

        public static void Execute(R5050_00_UPDATE_AU057_DB_UPDATE_1_Update1 r5050_00_UPDATE_AU057_DB_UPDATE_1_Update1)
        {
            var ths = r5050_00_UPDATE_AU057_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R5050_00_UPDATE_AU057_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}