using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE2640B
{
    public class DB014_ALTERA_CLIENTES_RAZAO_DB_UPDATE_1_Update1 : QueryBasis<DB014_ALTERA_CLIENTES_RAZAO_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.CLIENTES
				SET NOME_RAZAO =  '{this.CLIENTES_NOME_RAZAO}'
				WHERE  COD_CLIENTE =  '{this.CLIENTES_COD_CLIENTE}'";

            return query;
        }
        public string CLIENTES_NOME_RAZAO { get; set; }
        public string CLIENTES_COD_CLIENTE { get; set; }

        public static void Execute(DB014_ALTERA_CLIENTES_RAZAO_DB_UPDATE_1_Update1 dB014_ALTERA_CLIENTES_RAZAO_DB_UPDATE_1_Update1)
        {
            var ths = dB014_ALTERA_CLIENTES_RAZAO_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override DB014_ALTERA_CLIENTES_RAZAO_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}