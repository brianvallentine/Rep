using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0623B
{
    public class R1110_00_UPDATE_RELATORIOS_DB_UPDATE_1_Update1 : QueryBasis<R1110_00_UPDATE_RELATORIOS_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.RELATORIOS
				SET DATA_REFERENCIA =  '{this.WHOST_DATA_REFERENCIA}',
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  IDE_SISTEMA = 'PF'
				AND COD_RELATORIO = 'PF0623B'";

            return query;
        }
        public string WHOST_DATA_REFERENCIA { get; set; }

        public static void Execute(R1110_00_UPDATE_RELATORIOS_DB_UPDATE_1_Update1 r1110_00_UPDATE_RELATORIOS_DB_UPDATE_1_Update1)
        {
            var ths = r1110_00_UPDATE_RELATORIOS_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1110_00_UPDATE_RELATORIOS_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}