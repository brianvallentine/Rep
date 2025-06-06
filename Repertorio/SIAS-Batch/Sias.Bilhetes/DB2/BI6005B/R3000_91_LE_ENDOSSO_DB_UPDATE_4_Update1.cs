using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI6005B
{
    public class R3000_91_LE_ENDOSSO_DB_UPDATE_4_Update1 : QueryBasis<R3000_91_LE_ENDOSSO_DB_UPDATE_4_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0RCAP
				SET SITUACAO = '1' ,
				OPERACAO = 220 ,
				NUM_APOLICE =  '{this.V0APOL_NUM_APOL}' ,
				NRENDOS = 0,
				NRPARCEL = 0,
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  FONTE =  '{this.V0RCAP_FONTE}'
				AND NRRCAP =  '{this.V0RCAP_NRRCAP}'";

            return query;
        }
        public string V0APOL_NUM_APOL { get; set; }
        public string V0RCAP_NRRCAP { get; set; }
        public string V0RCAP_FONTE { get; set; }

        public static void Execute(R3000_91_LE_ENDOSSO_DB_UPDATE_4_Update1 r3000_91_LE_ENDOSSO_DB_UPDATE_4_Update1)
        {
            var ths = r3000_91_LE_ENDOSSO_DB_UPDATE_4_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3000_91_LE_ENDOSSO_DB_UPDATE_4_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}