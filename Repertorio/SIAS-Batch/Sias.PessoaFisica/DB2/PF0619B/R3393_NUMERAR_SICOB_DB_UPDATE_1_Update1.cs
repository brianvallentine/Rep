using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0619B
{
    public class R3393_NUMERAR_SICOB_DB_UPDATE_1_Update1 : QueryBasis<R3393_NUMERAR_SICOB_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.CEDENTE
				SET NUM_TITULO =  '{this.CEDENTE_NUM_TITULO}'
				WHERE  COD_CEDENTE =  '{this.CEDENTE_COD_CEDENTE}'";

            return query;
        }
        public string CEDENTE_NUM_TITULO { get; set; }
        public string CEDENTE_COD_CEDENTE { get; set; }

        public static void Execute(R3393_NUMERAR_SICOB_DB_UPDATE_1_Update1 r3393_NUMERAR_SICOB_DB_UPDATE_1_Update1)
        {
            var ths = r3393_NUMERAR_SICOB_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3393_NUMERAR_SICOB_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}