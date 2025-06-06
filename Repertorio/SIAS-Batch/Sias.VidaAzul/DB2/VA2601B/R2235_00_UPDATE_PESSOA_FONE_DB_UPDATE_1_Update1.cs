using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA2601B
{
    public class R2235_00_UPDATE_PESSOA_FONE_DB_UPDATE_1_Update1 : QueryBasis<R2235_00_UPDATE_PESSOA_FONE_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.PESSOA_TELEFONE
				SET SITUACAO_FONE = 'A'
				WHERE  COD_PESSOA =
				 '{this.PROPOFID_COD_PESSOA}'
				AND SITUACAO_FONE = 'P'";

            return query;
        }
        public string PROPOFID_COD_PESSOA { get; set; }

        public static void Execute(R2235_00_UPDATE_PESSOA_FONE_DB_UPDATE_1_Update1 r2235_00_UPDATE_PESSOA_FONE_DB_UPDATE_1_Update1)
        {
            var ths = r2235_00_UPDATE_PESSOA_FONE_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2235_00_UPDATE_PESSOA_FONE_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}