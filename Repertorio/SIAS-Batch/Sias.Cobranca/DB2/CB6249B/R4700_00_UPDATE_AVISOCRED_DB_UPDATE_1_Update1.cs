using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB6249B
{
    public class R4700_00_UPDATE_AVISOCRED_DB_UPDATE_1_Update1 : QueryBasis<R4700_00_UPDATE_AVISOCRED_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.AVISO_CREDITO
				SET VAL_DESPESA =
				 '{this.AVISOCRE_VAL_DESPESA}'
				, PRM_LIQUIDO =
				 '{this.AVISOCRE_PRM_LIQUIDO}'
				, PRM_TOTAL =
				 '{this.AVISOCRE_PRM_TOTAL}'
				WHERE  BCO_AVISO =
				 '{this.AVISOCRE_BCO_AVISO}'
				AND AGE_AVISO =
				 '{this.AVISOCRE_AGE_AVISO}'
				AND NUM_AVISO_CREDITO =
				 '{this.AVISOCRE_NUM_AVISO_CREDITO}'
				AND NUM_SEQUENCIA =
				 '{this.AVISOCRE_NUM_SEQUENCIA}'
				AND DATA_MOVIMENTO =
				 '{this.AVISOCRE_DATA_MOVIMENTO}'
				AND COD_OPERACAO =
				 '{this.AVISOCRE_COD_OPERACAO}'";

            return query;
        }
        public string AVISOCRE_VAL_DESPESA { get; set; }
        public string AVISOCRE_PRM_LIQUIDO { get; set; }
        public string AVISOCRE_PRM_TOTAL { get; set; }
        public string AVISOCRE_NUM_AVISO_CREDITO { get; set; }
        public string AVISOCRE_DATA_MOVIMENTO { get; set; }
        public string AVISOCRE_NUM_SEQUENCIA { get; set; }
        public string AVISOCRE_COD_OPERACAO { get; set; }
        public string AVISOCRE_BCO_AVISO { get; set; }
        public string AVISOCRE_AGE_AVISO { get; set; }

        public static void Execute(R4700_00_UPDATE_AVISOCRED_DB_UPDATE_1_Update1 r4700_00_UPDATE_AVISOCRED_DB_UPDATE_1_Update1)
        {
            var ths = r4700_00_UPDATE_AVISOCRED_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R4700_00_UPDATE_AVISOCRED_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}