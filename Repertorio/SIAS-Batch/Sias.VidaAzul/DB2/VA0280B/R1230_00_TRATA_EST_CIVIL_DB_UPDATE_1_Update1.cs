using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0280B
{
    public class R1230_00_TRATA_EST_CIVIL_DB_UPDATE_1_Update1 : QueryBasis<R1230_00_TRATA_EST_CIVIL_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.CLIENTES
				SET ESTADO_CIVIL =  '{this.CLIENTES_ESTADO_CIVIL}'
				WHERE COD_CLIENTE =  '{this.PROPOVA_COD_CLIENTE}'";

            return query;
        }
        public string CLIENTES_ESTADO_CIVIL { get; set; }
        public string PROPOVA_COD_CLIENTE { get; set; }

        public static void Execute(R1230_00_TRATA_EST_CIVIL_DB_UPDATE_1_Update1 r1230_00_TRATA_EST_CIVIL_DB_UPDATE_1_Update1)
        {
            var ths = r1230_00_TRATA_EST_CIVIL_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1230_00_TRATA_EST_CIVIL_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}