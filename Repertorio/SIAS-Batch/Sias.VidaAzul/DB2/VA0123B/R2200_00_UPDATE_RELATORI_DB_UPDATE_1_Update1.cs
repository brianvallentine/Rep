using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0123B
{
    public class R2200_00_UPDATE_RELATORI_DB_UPDATE_1_Update1 : QueryBasis<R2200_00_UPDATE_RELATORI_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.RELATORIOS
				SET DATA_REFERENCIA =  '{this.RELATORI_DATA_REFERENCIA}'
				WHERE  COD_RELATORIO = 'VA0123B'";

            return query;
        }
        public string RELATORI_DATA_REFERENCIA { get; set; }

        public static void Execute(R2200_00_UPDATE_RELATORI_DB_UPDATE_1_Update1 r2200_00_UPDATE_RELATORI_DB_UPDATE_1_Update1)
        {
            var ths = r2200_00_UPDATE_RELATORI_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2200_00_UPDATE_RELATORI_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}