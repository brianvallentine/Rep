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
    public class B2094_ALTERA_V0COBERAPOL_DB_UPDATE_1_Update1 : QueryBasis<B2094_ALTERA_V0COBERAPOL_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE
				SEGUROS.V1COBERAPOL
				SET PRM_TARIFARIO_VAR =  '{this.WS_VL_COB}',
				PRM_TARIFARIO_IX =  '{this.WS_VL_COB}',
				PCT_COBERTURA = 100
				WHERE  NUM_APOLICE =  '{this.ENDO_NUM_APOLICE}'
				AND NRENDOS =  '{this.ENDO_NRENDOS}'";

            return query;
        }
        public string WS_VL_COB { get; set; }
        public string ENDO_NUM_APOLICE { get; set; }
        public string ENDO_NRENDOS { get; set; }

        public static void Execute(B2094_ALTERA_V0COBERAPOL_DB_UPDATE_1_Update1 b2094_ALTERA_V0COBERAPOL_DB_UPDATE_1_Update1)
        {
            var ths = b2094_ALTERA_V0COBERAPOL_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override B2094_ALTERA_V0COBERAPOL_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}