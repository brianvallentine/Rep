using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0648B
{
    public class R0740_00_UPDATE_RELATORIOS_DB_UPDATE_1_Update1 : QueryBasis<R0740_00_UPDATE_RELATORIOS_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.RELATORIOS
				SET SIT_REGISTRO = '1' ,
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  IDE_SISTEMA = 'PF'
				AND COD_RELATORIO = 'PF0648B'
				AND NUM_CERTIFICADO =
				 '{this.NUM_PROPOSTA_SIVPF}'
				AND SIT_REGISTRO = '0'";

            return query;
        }
        public string NUM_PROPOSTA_SIVPF { get; set; }

        public static void Execute(R0740_00_UPDATE_RELATORIOS_DB_UPDATE_1_Update1 r0740_00_UPDATE_RELATORIOS_DB_UPDATE_1_Update1)
        {
            var ths = r0740_00_UPDATE_RELATORIOS_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0740_00_UPDATE_RELATORIOS_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}