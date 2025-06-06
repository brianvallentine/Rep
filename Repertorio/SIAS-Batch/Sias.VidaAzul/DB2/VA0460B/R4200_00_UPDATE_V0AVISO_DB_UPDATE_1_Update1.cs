using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0460B
{
    public class R4200_00_UPDATE_V0AVISO_DB_UPDATE_1_Update1 : QueryBasis<R4200_00_UPDATE_V0AVISO_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.AVISOS_SALDOS
				SET SALDO_ATUAL =  '{this.AVISOSAL_SALDO_ATUAL}'
				WHERE  BCO_AVISO =  '{this.AVISOSAL_BCO_AVISO}'
				AND AGE_AVISO =  '{this.AVISOSAL_AGE_AVISO}'
				AND NUM_AVISO_CREDITO =  '{this.AVISOSAL_NUM_AVISO_CREDITO}'";

            return query;
        }
        public string AVISOSAL_SALDO_ATUAL { get; set; }
        public string AVISOSAL_NUM_AVISO_CREDITO { get; set; }
        public string AVISOSAL_BCO_AVISO { get; set; }
        public string AVISOSAL_AGE_AVISO { get; set; }

        public static void Execute(R4200_00_UPDATE_V0AVISO_DB_UPDATE_1_Update1 r4200_00_UPDATE_V0AVISO_DB_UPDATE_1_Update1)
        {
            var ths = r4200_00_UPDATE_V0AVISO_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R4200_00_UPDATE_V0AVISO_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}