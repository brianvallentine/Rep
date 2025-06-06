using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0111B
{
    public class R1100_00_UPDATE_PARAMCON_DB_UPDATE_1_Update1 : QueryBasis<R1100_00_UPDATE_PARAMCON_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.PARAM_CONTACEF
				SET NSAS =  '{this.PARAMCON_NSAS}'
				, DATA_MOVIMENTO =  '{this.PARAMCON_DATA_MOVIMENTO}'
				, DATA_PROXIMO_DEB =  '{this.PARAMCON_DATA_PROXIMO_DEB}'
				WHERE  TIPO_MOVTO_CC =  '{this.PARAMCON_TIPO_MOVTO_CC}'
				AND COD_PRODUTO =  '{this.PARAMCON_COD_PRODUTO}'
				AND COD_CONVENIO =  '{this.PARAMCON_COD_CONVENIO}'";

            return query;
        }
        public string PARAMCON_DATA_PROXIMO_DEB { get; set; }
        public string PARAMCON_DATA_MOVIMENTO { get; set; }
        public string PARAMCON_NSAS { get; set; }
        public string PARAMCON_TIPO_MOVTO_CC { get; set; }
        public string PARAMCON_COD_CONVENIO { get; set; }
        public string PARAMCON_COD_PRODUTO { get; set; }

        public static void Execute(R1100_00_UPDATE_PARAMCON_DB_UPDATE_1_Update1 r1100_00_UPDATE_PARAMCON_DB_UPDATE_1_Update1)
        {
            var ths = r1100_00_UPDATE_PARAMCON_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1100_00_UPDATE_PARAMCON_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}