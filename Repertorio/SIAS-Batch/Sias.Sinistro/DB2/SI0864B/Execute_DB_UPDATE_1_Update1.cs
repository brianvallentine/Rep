using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0864B
{
    public class Execute_DB_UPDATE_1_Update1 : QueryBasis<Execute_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.RELATORIOS SET SIT_REGISTRO = '1'
				WHERE  IDE_SISTEMA = 'SI'
				AND COD_RELATORIO = 'SI0864B'
				AND SIT_REGISTRO = '0'";

            return query;
        }

        public static void Execute(Execute_DB_UPDATE_1_Update1 execute_DB_UPDATE_1_Update1)
        {
            var ths = execute_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override Execute_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}