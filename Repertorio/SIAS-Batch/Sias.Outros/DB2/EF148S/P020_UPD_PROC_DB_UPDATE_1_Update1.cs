using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.EF148S
{
    public class P020_UPD_PROC_DB_UPDATE_1_Update1 : QueryBasis<P020_UPD_PROC_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.EF_PROD_ACESSORIO
				SET NUM_RAMO_CONTABIL =  '{this.EF148_NUM_RAMO_CONTABIL}'
				, COD_PRODUTO_ACESS =  '{this.EF148_COD_PRODUTO_ACESS}'
				, COD_COBERTURA_ACESS =  '{this.EF148_COD_COBERTURA_ACESS}'
				, NUM_APOLICE =  '{this.EF148_NUM_APOLICE}'
				, DTH_FIM_VIGENCIA =  {FieldThreatment((this.WS_DTH_FIM_VIGENCIA_NULL?.ToInt() == -1 ? null : $"{this.EF148_DTH_FIM_VIGENCIA}"))}
				WHERE  NUM_CONTRATO_APOL =  '{this.EF148_NUM_CONTRATO_APOL}'
				AND COD_PRODUTO =  '{this.EF148_COD_PRODUTO}'
				AND COD_COBERTURA =  '{this.EF148_COD_COBERTURA}'
				AND DTH_INI_VIGENCIA =  '{this.EF148_DTH_INI_VIGENCIA}'";

            return query;
        }
        public string EF148_DTH_FIM_VIGENCIA { get; set; }
        public string WS_DTH_FIM_VIGENCIA_NULL { get; set; }
        public string EF148_COD_COBERTURA_ACESS { get; set; }
        public string EF148_NUM_RAMO_CONTABIL { get; set; }
        public string EF148_COD_PRODUTO_ACESS { get; set; }
        public string EF148_NUM_APOLICE { get; set; }
        public string EF148_NUM_CONTRATO_APOL { get; set; }
        public string EF148_DTH_INI_VIGENCIA { get; set; }
        public string EF148_COD_COBERTURA { get; set; }
        public string EF148_COD_PRODUTO { get; set; }

        public static void Execute(P020_UPD_PROC_DB_UPDATE_1_Update1 p020_UPD_PROC_DB_UPDATE_1_Update1)
        {
            var ths = p020_UPD_PROC_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override P020_UPD_PROC_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}