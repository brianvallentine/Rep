using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI2002B
{
    public class R0550_00_UPDATE_RCAPCOMP_DB_UPDATE_1_Update1 : QueryBasis<R0550_00_UPDATE_RCAPCOMP_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE
				SEGUROS.RCAP_COMPLEMENTAR
				SET BCO_AVISO =  '{this.MOVIMCOB_COD_BANCO}'
				,AGE_AVISO =  '{this.MOVIMCOB_COD_AGENCIA}'
				,NUM_AVISO_CREDITO =  '{this.MOVIMCOB_NUM_AVISO}'
				WHERE  COD_FONTE =  '{this.RCAPS_COD_FONTE}'
				AND NUM_RCAP =  '{this.RCAPS_NUM_RCAP}'";

            return query;
        }
        public string MOVIMCOB_COD_AGENCIA { get; set; }
        public string MOVIMCOB_COD_BANCO { get; set; }
        public string MOVIMCOB_NUM_AVISO { get; set; }
        public string RCAPS_COD_FONTE { get; set; }
        public string RCAPS_NUM_RCAP { get; set; }

        public static void Execute(R0550_00_UPDATE_RCAPCOMP_DB_UPDATE_1_Update1 r0550_00_UPDATE_RCAPCOMP_DB_UPDATE_1_Update1)
        {
            var ths = r0550_00_UPDATE_RCAPCOMP_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0550_00_UPDATE_RCAPCOMP_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}