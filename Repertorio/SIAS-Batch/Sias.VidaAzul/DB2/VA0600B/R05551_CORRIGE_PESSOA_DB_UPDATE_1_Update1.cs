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
    public class R05551_CORRIGE_PESSOA_DB_UPDATE_1_Update1 : QueryBasis<R05551_CORRIGE_PESSOA_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.PESSOA
				SET NOME_PESSOA =  '{this.PESSOA_NOME_PESSOA}'
				WHERE  COD_PESSOA =  '{this.PESSOA_COD_PESSOA}'";

            return query;
        }
        public string PESSOA_NOME_PESSOA { get; set; }
        public string PESSOA_COD_PESSOA { get; set; }

        public static void Execute(R05551_CORRIGE_PESSOA_DB_UPDATE_1_Update1 r05551_CORRIGE_PESSOA_DB_UPDATE_1_Update1)
        {
            var ths = r05551_CORRIGE_PESSOA_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R05551_CORRIGE_PESSOA_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}