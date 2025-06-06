using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0600B
{
    public class R0655_LER_TELEFONE_DB_UPDATE_1_Update1 : QueryBasis<R0655_LER_TELEFONE_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.PESSOA_TELEFONE
				SET SITUACAO_FONE = 'P'
				WHERE  COD_PESSOA =  '{this.COD_PESSOA}'
				AND TIPO_FONE =  '{this.TIPO_FONE}'
				AND NUM_FONE =  '{this.NUM_FONE}'
				AND DDD =  '{this.DDD}'";

            return query;
        }
        public string COD_PESSOA { get; set; }
        public string TIPO_FONE { get; set; }
        public string NUM_FONE { get; set; }
        public string DDD { get; set; }

        public static void Execute(R0655_LER_TELEFONE_DB_UPDATE_1_Update1 r0655_LER_TELEFONE_DB_UPDATE_1_Update1)
        {
            var ths = r0655_LER_TELEFONE_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0655_LER_TELEFONE_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}