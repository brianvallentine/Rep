using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0031B
{
    public class R0151_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1 : QueryBasis<R0151_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0BILHETE
				SET SITUACAO =  '{this.V0BILH_SITUACAO}',
				DIG_CONTA_DEB =  '{this.V0MOVDE_DIG_CONTA_DEB}',
				COD_USUARIO = 'BI0031B' ,
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  NUMBIL =  '{this.V0BILH_NUMBIL}'";

            return query;
        }
        public string V0MOVDE_DIG_CONTA_DEB { get; set; }
        public string V0BILH_SITUACAO { get; set; }
        public string V0BILH_NUMBIL { get; set; }

        public static void Execute(R0151_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1 r0151_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1)
        {
            var ths = r0151_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0151_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}