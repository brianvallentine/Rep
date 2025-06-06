using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1613B
{
    public class R4220_00_TRATA_SEXO_CLIENTE_DB_UPDATE_1_Update1 : QueryBasis<R4220_00_TRATA_SEXO_CLIENTE_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.CLIENTES
				SET IDE_SEXO =  '{this.CLIENTES_IDE_SEXO}'
				WHERE  COD_CLIENTE =  '{this.CLIENTES_COD_CLIENTE}'";

            return query;
        }
        public string CLIENTES_IDE_SEXO { get; set; }
        public string CLIENTES_COD_CLIENTE { get; set; }

        public static void Execute(R4220_00_TRATA_SEXO_CLIENTE_DB_UPDATE_1_Update1 r4220_00_TRATA_SEXO_CLIENTE_DB_UPDATE_1_Update1)
        {
            var ths = r4220_00_TRATA_SEXO_CLIENTE_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R4220_00_TRATA_SEXO_CLIENTE_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}