using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0706B
{
    public class R0350_00_UPDATE_RELATORIOS_DB_UPDATE_1_Update1 : QueryBasis<R0350_00_UPDATE_RELATORIOS_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.RELATORIOS
				SET DATA_REFERENCIA =
				 '{this.RELATORI_DATA_REFERENCIA}',
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  IDE_SISTEMA = 'PF'
				AND COD_RELATORIO = 'PF0706B'";

            return query;
        }
        public string RELATORI_DATA_REFERENCIA { get; set; }

        public static void Execute(R0350_00_UPDATE_RELATORIOS_DB_UPDATE_1_Update1 r0350_00_UPDATE_RELATORIOS_DB_UPDATE_1_Update1)
        {
            var ths = r0350_00_UPDATE_RELATORIOS_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0350_00_UPDATE_RELATORIOS_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}