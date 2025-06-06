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
    public class R2250_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1 : QueryBasis<R2250_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0BILHETE
				SET OPC_COBERTURA =  '{this.V0BCOB_CODOPCAO}' ,
				DTQITBCO =  '{this.V0RCOM_DATARCAP}' ,
				DATA_VENDA =  '{this.V0RCOM_DATARCAP}' ,
				VLRCAP =  '{this.V0BCOB_VLPRMTOT}' ,
				DTMOVTO =  '{this.V0SIST_DTMOVABE}' ,
				TIMESTAMP = CURRENT TIMESTAMP,
				COD_USUARIO = 'CB0009B'
				WHERE  NUMBIL =  '{this.V0BILH_NUMBIL}'";

            return query;
        }
        public string V0BCOB_CODOPCAO { get; set; }
        public string V0RCOM_DATARCAP { get; set; }
        public string V0BCOB_VLPRMTOT { get; set; }
        public string V0SIST_DTMOVABE { get; set; }
        public string V0BILH_NUMBIL { get; set; }

        public static void Execute(R2250_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1 r2250_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1)
        {
            var ths = r2250_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2250_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}