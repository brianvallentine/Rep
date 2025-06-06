using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0006B
{
    public class R2130_00_UPDATE_V0APOITENSINC_DB_UPDATE_1_Update1 : QueryBasis<R2130_00_UPDATE_V0APOITENSINC_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE
				SEGUROS.V0APOITENSINC
				SET SITUACAO = '1' ,
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  NUM_APOLICE =  '{this.V0ENDO_NUM_APOL}'
				AND NUM_RISCO =  '{this.V1PRIN_NUM_RISCO}'
				AND SUBRIS =  '{this.V1PRIN_SUBRIS}'
				AND NRITEM =  '{this.V1PRIN_NRITEM}'
				AND TIPCOND =  '{this.V1PRIN_TIPCOND}'
				AND TIPO_TAXA =  '{this.V1PRIN_TIPO_TAXA}'
				AND CODCOBINC =  '{this.V1PRIN_CODCOBINC}'
				AND OCORHIST =  '{this.V1APIN_OCORHIST}'
				AND SITUACAO = '0'";

            return query;
        }
        public string V1PRIN_NUM_RISCO { get; set; }
        public string V1PRIN_TIPO_TAXA { get; set; }
        public string V1PRIN_CODCOBINC { get; set; }
        public string V0ENDO_NUM_APOL { get; set; }
        public string V1APIN_OCORHIST { get; set; }
        public string V1PRIN_TIPCOND { get; set; }
        public string V1PRIN_SUBRIS { get; set; }
        public string V1PRIN_NRITEM { get; set; }

        public static void Execute(R2130_00_UPDATE_V0APOITENSINC_DB_UPDATE_1_Update1 r2130_00_UPDATE_V0APOITENSINC_DB_UPDATE_1_Update1)
        {
            var ths = r2130_00_UPDATE_V0APOITENSINC_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2130_00_UPDATE_V0APOITENSINC_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}