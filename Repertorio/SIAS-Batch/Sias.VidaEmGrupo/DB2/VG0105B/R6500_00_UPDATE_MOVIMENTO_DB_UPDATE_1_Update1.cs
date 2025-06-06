using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0105B
{
    public class R6500_00_UPDATE_MOVIMENTO_DB_UPDATE_1_Update1 : QueryBasis<R6500_00_UPDATE_MOVIMENTO_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE
				SEGUROS.V0MOVIMENTO
				SET DATA_FATURA =  '{this.V0MOVI_DATA_FATURA}'
				WHERE  NUM_APOLICE =  '{this.W1SOLF_NUM_APOL}'
				AND COD_SUBGRUPO >=  '{this.W1SUB_GRUPO}'
				AND COD_SUBGRUPO <=  '{this.W2SUB_GRUPO}'
				AND DATA_INCLUSAO IS NOT NULL
				AND DATA_REFERENCIA =  '{this.V1FATC_DATA_REFER}'";

            return query;
        }
        public string V0MOVI_DATA_FATURA { get; set; }
        public string V1FATC_DATA_REFER { get; set; }
        public string W1SOLF_NUM_APOL { get; set; }
        public string W1SUB_GRUPO { get; set; }
        public string W2SUB_GRUPO { get; set; }

        public static void Execute(R6500_00_UPDATE_MOVIMENTO_DB_UPDATE_1_Update1 r6500_00_UPDATE_MOVIMENTO_DB_UPDATE_1_Update1)
        {
            var ths = r6500_00_UPDATE_MOVIMENTO_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R6500_00_UPDATE_MOVIMENTO_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}