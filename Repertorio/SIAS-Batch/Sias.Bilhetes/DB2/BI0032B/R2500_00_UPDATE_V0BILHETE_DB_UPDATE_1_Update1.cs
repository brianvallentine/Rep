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
    public class R2500_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1 : QueryBasis<R2500_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0BILHETE
				SET SITUACAO = '*' ,
				COD_USUARIO = 'BI0032B'
				WHERE  NUMBIL =  '{this.V1BILH_NUMBIL}'
				AND SITUACAO = '6'";

            return query;
        }
        public string V1BILH_NUMBIL { get; set; }

        public static void Execute(R2500_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1 r2500_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1)
        {
            var ths = r2500_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2500_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}