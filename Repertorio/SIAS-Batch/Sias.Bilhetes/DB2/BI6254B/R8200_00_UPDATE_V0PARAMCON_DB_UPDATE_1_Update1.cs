using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI6254B
{
    public class R8200_00_UPDATE_V0PARAMCON_DB_UPDATE_1_Update1 : QueryBasis<R8200_00_UPDATE_V0PARAMCON_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.PARAM_CONTACEF
				SET NSAS =  '{this.PARAMCON_NSAS}',
				DATA_MOVIMENTO =  '{this.SISTEMAS_DATA_MOV_ABERTO}',
				DATA_PROXIMO_DEB =  '{this.WSHOST_DTMOVABE20}',
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  TIPO_MOVTO_CC =  '{this.PARAMCON_TIPO_MOVTO_CC}'
				AND COD_PRODUTO =  '{this.PARAMCON_COD_PRODUTO}'
				AND COD_CONVENIO =  '{this.PARAMCON_COD_CONVENIO}'";

            return query;
        }
        public string SISTEMAS_DATA_MOV_ABERTO { get; set; }
        public string WSHOST_DTMOVABE20 { get; set; }
        public string PARAMCON_NSAS { get; set; }
        public string PARAMCON_TIPO_MOVTO_CC { get; set; }
        public string PARAMCON_COD_CONVENIO { get; set; }
        public string PARAMCON_COD_PRODUTO { get; set; }

        public static void Execute(R8200_00_UPDATE_V0PARAMCON_DB_UPDATE_1_Update1 r8200_00_UPDATE_V0PARAMCON_DB_UPDATE_1_Update1)
        {
            var ths = r8200_00_UPDATE_V0PARAMCON_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R8200_00_UPDATE_V0PARAMCON_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}