using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0097B
{
    public class R4000_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1 : QueryBasis<R4000_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE
				SEGUROS.BILHETE
				SET SITUACAO =
				 '{this.BILHETE_SITUACAO}'
				,TIP_CANCELAMENTO =
				 '{this.BILHETE_TIP_CANCELAMENTO}'
				,COD_USUARIO = 'BI0097B'
				,DATA_CANCELAMENTO =
				 {FieldThreatment((this.VIND_NULL01?.ToInt() == -1 ? null : $"{this.BILHETE_DATA_CANCELAMENTO}"))}
				WHERE  NUM_BILHETE =  '{this.APOLICES_NUM_BILHETE}'";

            return query;
        }
        public string BILHETE_DATA_CANCELAMENTO { get; set; }
        public string VIND_NULL01 { get; set; }
        public string BILHETE_TIP_CANCELAMENTO { get; set; }
        public string BILHETE_SITUACAO { get; set; }
        public string APOLICES_NUM_BILHETE { get; set; }

        public static void Execute(R4000_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1 r4000_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1)
        {
            var ths = r4000_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R4000_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}