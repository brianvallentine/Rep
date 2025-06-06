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
    public class R5045_00_UPDATE_AU055_DB_UPDATE_1_Update1 : QueryBasis<R5045_00_UPDATE_AU055_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.AU_HIS_PROP_CONV
				SET IND_OPERACAO =  '{this.AU055_IND_OPERACAO}' ,
				NOM_PROGRAMA =  '{this.AU055_NOM_PROGRAMA}' ,
				DTH_CADASTRAMENTO = CURRENT TIMESTAMP
				WHERE  NUM_PROPOSTA_VC =  '{this.AU055_NUM_PROPOSTA_VC}'
				AND DTH_OPERACAO =  '{this.AU055_DTH_OPERACAO}'
				AND COD_CONGENERE =  '{this.WHOST_CONGENERE}'";

            return query;
        }
        public string AU055_IND_OPERACAO { get; set; }
        public string AU055_NOM_PROGRAMA { get; set; }
        public string AU055_NUM_PROPOSTA_VC { get; set; }
        public string AU055_DTH_OPERACAO { get; set; }
        public string WHOST_CONGENERE { get; set; }

        public static void Execute(R5045_00_UPDATE_AU055_DB_UPDATE_1_Update1 r5045_00_UPDATE_AU055_DB_UPDATE_1_Update1)
        {
            var ths = r5045_00_UPDATE_AU055_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R5045_00_UPDATE_AU055_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}