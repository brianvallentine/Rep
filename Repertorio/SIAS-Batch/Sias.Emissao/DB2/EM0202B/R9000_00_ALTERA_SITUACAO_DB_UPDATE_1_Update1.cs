using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0202B
{
    public class R9000_00_ALTERA_SITUACAO_DB_UPDATE_1_Update1 : QueryBasis<R9000_00_ALTERA_SITUACAO_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.EMISSAO_DIARIA
				SET SIT_REGISTRO = '1'
				WHERE  COD_RELATORIO IN ( 'EM0202B1' , 'EM0202B2' )
				AND SIT_REGISTRO = '0'";

            return query;
        }

        public static void Execute(R9000_00_ALTERA_SITUACAO_DB_UPDATE_1_Update1 r9000_00_ALTERA_SITUACAO_DB_UPDATE_1_Update1)
        {
            var ths = r9000_00_ALTERA_SITUACAO_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R9000_00_ALTERA_SITUACAO_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}