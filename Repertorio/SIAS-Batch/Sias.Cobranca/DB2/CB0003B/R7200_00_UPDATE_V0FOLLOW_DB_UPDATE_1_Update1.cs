using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0003B
{
    public class R7200_00_UPDATE_V0FOLLOW_DB_UPDATE_1_Update1 : QueryBasis<R7200_00_UPDATE_V0FOLLOW_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0FOLLOWUP
				SET NUM_APOLICE = 0104800188097,
				NRENDOS = 2 ,
				NRPARCEL = 2 ,
				DTLIBER = '2007-06-19' ,
				SITUACAO = '1' ,
				OPERACAO = 201
				WHERE  NUM_APOLICE = 0104800188097
				AND NRENDOS = 2
				AND NRPARCEL = 1
				AND BCOAVISO = 104
				AND AGEAVISO = 7003
				AND NRAVISO = 804401735
				AND SITUACAO = '0'
				AND VLPREMIO = 191.82";

            return query;
        }

        public static void Execute(R7200_00_UPDATE_V0FOLLOW_DB_UPDATE_1_Update1 r7200_00_UPDATE_V0FOLLOW_DB_UPDATE_1_Update1)
        {
            var ths = r7200_00_UPDATE_V0FOLLOW_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R7200_00_UPDATE_V0FOLLOW_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}