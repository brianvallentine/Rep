using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE0031B
{
    public class R6000_10_LOOP_PROPAUTOM_DB_UPDATE_1_Update1 : QueryBasis<R6000_10_LOOP_PROPAUTOM_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.FONTES
				SET ULT_PROP_AUTOMAT =  '{this.FONTES_ULT_PROP_AUTOMAT}',
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  COD_FONTE =  '{this.SEGURVGA_COD_FONTE}'";

            return query;
        }
        public string FONTES_ULT_PROP_AUTOMAT { get; set; }
        public string SEGURVGA_COD_FONTE { get; set; }

        public static void Execute(R6000_10_LOOP_PROPAUTOM_DB_UPDATE_1_Update1 r6000_10_LOOP_PROPAUTOM_DB_UPDATE_1_Update1)
        {
            var ths = r6000_10_LOOP_PROPAUTOM_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R6000_10_LOOP_PROPAUTOM_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}