using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0075B
{
    public class R1440_00_CANCELA_BILHETE_DB_UPDATE_1_Update1 : QueryBasis<R1440_00_CANCELA_BILHETE_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0BILHETE
				SET SITUACAO =  '{this.V0BILH_SITUACAO}',
				TIP_CANCELAMENTO = '3' ,
				DTCANCEL =  '{this.V1SIST_DTMOVABE}',
				COD_USUARIO = 'BI0075B' ,
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  NUMBIL =  '{this.V0BILH_NUMBIL}'";

            return query;
        }
        public string V0BILH_SITUACAO { get; set; }
        public string V1SIST_DTMOVABE { get; set; }
        public string V0BILH_NUMBIL { get; set; }

        public static void Execute(R1440_00_CANCELA_BILHETE_DB_UPDATE_1_Update1 r1440_00_CANCELA_BILHETE_DB_UPDATE_1_Update1)
        {
            var ths = r1440_00_CANCELA_BILHETE_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1440_00_CANCELA_BILHETE_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}