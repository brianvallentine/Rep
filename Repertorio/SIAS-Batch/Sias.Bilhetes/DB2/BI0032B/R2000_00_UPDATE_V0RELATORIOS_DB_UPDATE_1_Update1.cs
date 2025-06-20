using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0032B
{
    public class R2000_00_UPDATE_V0RELATORIOS_DB_UPDATE_1_Update1 : QueryBasis<R2000_00_UPDATE_V0RELATORIOS_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0RELATORIOS
				SET SITUACAO = '1' ,
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  CODRELAT = 'BI0032B'
				AND SITUACAO = '0'
				AND NRTIT =  '{this.RELATORI_NUM_TITULO}'";

            return query;
        }
        public string RELATORI_NUM_TITULO { get; set; }

        public static void Execute(R2000_00_UPDATE_V0RELATORIOS_DB_UPDATE_1_Update1 r2000_00_UPDATE_V0RELATORIOS_DB_UPDATE_1_Update1)
        {
            var ths = r2000_00_UPDATE_V0RELATORIOS_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2000_00_UPDATE_V0RELATORIOS_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}