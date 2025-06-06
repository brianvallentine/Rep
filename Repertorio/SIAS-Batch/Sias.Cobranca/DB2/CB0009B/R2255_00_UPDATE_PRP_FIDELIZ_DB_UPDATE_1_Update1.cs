using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0009B
{
    public class R2255_00_UPDATE_PRP_FIDELIZ_DB_UPDATE_1_Update1 : QueryBasis<R2255_00_UPDATE_PRP_FIDELIZ_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.PROPOSTA_FIDELIZ
				SET DTQITBCO =  '{this.V0RCOM_DATARCAP}',
				DATA_CREDITO =  '{this.V0RCOM_DTMOVTO}' ,
				VAL_PAGO =  '{this.VAL_PAGO_FIDELIZ}'
				WHERE  NUM_SICOB =  '{this.V0BILH_NUMBIL}'
				AND DTQITBCO = '0001-01-01'
				AND DATA_CREDITO = '0001-01-01'
				AND VAL_PAGO = 0";

            return query;
        }
        public string VAL_PAGO_FIDELIZ { get; set; }
        public string V0RCOM_DATARCAP { get; set; }
        public string V0RCOM_DTMOVTO { get; set; }
        public string V0BILH_NUMBIL { get; set; }

        public static void Execute(R2255_00_UPDATE_PRP_FIDELIZ_DB_UPDATE_1_Update1 r2255_00_UPDATE_PRP_FIDELIZ_DB_UPDATE_1_Update1)
        {
            var ths = r2255_00_UPDATE_PRP_FIDELIZ_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2255_00_UPDATE_PRP_FIDELIZ_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}