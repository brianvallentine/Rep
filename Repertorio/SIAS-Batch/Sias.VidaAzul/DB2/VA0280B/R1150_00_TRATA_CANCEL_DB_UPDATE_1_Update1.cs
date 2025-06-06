using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0280B
{
    public class R1150_00_TRATA_CANCEL_DB_UPDATE_1_Update1 : QueryBasis<R1150_00_TRATA_CANCEL_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.PROPOSTAS_VA
				SET SIT_REGISTRO = '4' ,
				COD_USUARIO = 'VA0280B' ,
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE NUM_CERTIFICADO =  '{this.PROPOVA_NUM_CERTIFICADO}'";

            return query;
        }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }

        public static void Execute(R1150_00_TRATA_CANCEL_DB_UPDATE_1_Update1 r1150_00_TRATA_CANCEL_DB_UPDATE_1_Update1)
        {
            var ths = r1150_00_TRATA_CANCEL_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1150_00_TRATA_CANCEL_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}