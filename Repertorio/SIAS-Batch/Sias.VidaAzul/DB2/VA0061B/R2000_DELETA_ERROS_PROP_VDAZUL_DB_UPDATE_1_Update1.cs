using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0061B
{
    public class R2000_DELETA_ERROS_PROP_VDAZUL_DB_UPDATE_1_Update1 : QueryBasis<R2000_DELETA_ERROS_PROP_VDAZUL_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.PROPOSTAS_VA
				SET SIT_REGISTRO = '0'
				WHERE  NUM_CERTIFICADO =  '{this.ERRPROVI_NUM_CERTIFICADO}'";

            return query;
        }
        public string ERRPROVI_NUM_CERTIFICADO { get; set; }

        public static void Execute(R2000_DELETA_ERROS_PROP_VDAZUL_DB_UPDATE_1_Update1 r2000_DELETA_ERROS_PROP_VDAZUL_DB_UPDATE_1_Update1)
        {
            var ths = r2000_DELETA_ERROS_PROP_VDAZUL_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2000_DELETA_ERROS_PROP_VDAZUL_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}