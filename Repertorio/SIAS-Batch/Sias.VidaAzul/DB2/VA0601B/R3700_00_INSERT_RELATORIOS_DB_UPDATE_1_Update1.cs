using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0601B
{
    public class R3700_00_INSERT_RELATORIOS_DB_UPDATE_1_Update1 : QueryBasis<R3700_00_INSERT_RELATORIOS_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.RELATORIOS
				SET SIT_REGISTRO = '1'
				WHERE  NUM_CERTIFICADO =
				 '{this.PROPOFID_NUM_PROPOSTA_SIVPF}'
				AND COD_RELATORIO = 'VA0469B'
				AND SIT_REGISTRO = '0'";

            return query;
        }
        public string PROPOFID_NUM_PROPOSTA_SIVPF { get; set; }

        public static void Execute(R3700_00_INSERT_RELATORIOS_DB_UPDATE_1_Update1 r3700_00_INSERT_RELATORIOS_DB_UPDATE_1_Update1)
        {
            var ths = r3700_00_INSERT_RELATORIOS_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3700_00_INSERT_RELATORIOS_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}