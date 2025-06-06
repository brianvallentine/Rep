using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0002B
{
    public class R7600_00_UPDATE_V0MOVICOB_DB_UPDATE_1_Update1 : QueryBasis<R7600_00_UPDATE_V0MOVICOB_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0MOVICOB
				SET SITUACAO = '*'
				WHERE BANCO = 104
				AND AGENCIA = 7003
				AND NRAVISO = 804401329
				AND NUM_APOLICE = 104800047007
				AND DTQITBCO = '2005-10-11'
				AND DTMOVTO = '2005-11-04'
				AND NUM_NOSSO_TITULO = 8000100003890510
				AND SITUACAO = ' '";

            return query;
        }

        public static void Execute(R7600_00_UPDATE_V0MOVICOB_DB_UPDATE_1_Update1 r7600_00_UPDATE_V0MOVICOB_DB_UPDATE_1_Update1)
        {
            var ths = r7600_00_UPDATE_V0MOVICOB_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R7600_00_UPDATE_V0MOVICOB_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}