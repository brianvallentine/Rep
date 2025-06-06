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
    public class DB140_ALTERA_BANCOS_DB_UPDATE_1_Update1 : QueryBasis<DB140_ALTERA_BANCOS_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.BANCOS
				SET NUM_TITULO =  '{this.BANCOS_NUM_TITULO}',
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  COD_BANCO = 104";

            return query;
        }
        public string BANCOS_NUM_TITULO { get; set; }

        public static void Execute(DB140_ALTERA_BANCOS_DB_UPDATE_1_Update1 dB140_ALTERA_BANCOS_DB_UPDATE_1_Update1)
        {
            var ths = dB140_ALTERA_BANCOS_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override DB140_ALTERA_BANCOS_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}