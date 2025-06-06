using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB2005B
{
    public class R3000_91_LE_ENDOSSO_DB_UPDATE_2_Update1 : QueryBasis<R3000_91_LE_ENDOSSO_DB_UPDATE_2_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0BILHETE
				SET NUM_APOLICE =  '{this.V0APOL_NUM_APOL}',
				SITUACAO =  '{this.V0BILH_SITUACAO}',
				COD_USUARIO = 'CB2005B' ,
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  NUMBIL =  '{this.V0BILH_NUMBIL}'";

            return query;
        }
        public string V0APOL_NUM_APOL { get; set; }
        public string V0BILH_SITUACAO { get; set; }
        public string V0BILH_NUMBIL { get; set; }

        public static void Execute(R3000_91_LE_ENDOSSO_DB_UPDATE_2_Update1 r3000_91_LE_ENDOSSO_DB_UPDATE_2_Update1)
        {
            var ths = r3000_91_LE_ENDOSSO_DB_UPDATE_2_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3000_91_LE_ENDOSSO_DB_UPDATE_2_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}