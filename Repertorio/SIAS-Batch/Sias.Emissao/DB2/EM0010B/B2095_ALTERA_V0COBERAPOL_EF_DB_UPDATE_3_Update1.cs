using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0010B
{
    public class B2095_ALTERA_V0COBERAPOL_EF_DB_UPDATE_3_Update1 : QueryBasis<B2095_ALTERA_V0COBERAPOL_EF_DB_UPDATE_3_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V1COBERAPOL A
				SET A.PCT_COBERTURA =  '{this.WS_APOLICOB_PCT_COB_65}'
				, A.PRM_TARIFARIO_IX =  '{this.WS_EF_VLR_CREDITO_65}'
				, A.PRM_TARIFARIO_VAR =  '{this.WS_EF_VLR_CREDITO_65}'
				WHERE  A.NUM_APOLICE =  '{this.ENDO_NUM_APOLICE}'
				AND A.NRENDOS =  '{this.ENDO_NRENDOS}'
				AND A.RAMOFR = 65";

            return query;
        }
        public string WS_APOLICOB_PCT_COB_65 { get; set; }
        public string WS_EF_VLR_CREDITO_65 { get; set; }
        public string ENDO_NUM_APOLICE { get; set; }
        public string ENDO_NRENDOS { get; set; }

        public static void Execute(B2095_ALTERA_V0COBERAPOL_EF_DB_UPDATE_3_Update1 b2095_ALTERA_V0COBERAPOL_EF_DB_UPDATE_3_Update1)
        {
            var ths = b2095_ALTERA_V0COBERAPOL_EF_DB_UPDATE_3_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override B2095_ALTERA_V0COBERAPOL_EF_DB_UPDATE_3_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}