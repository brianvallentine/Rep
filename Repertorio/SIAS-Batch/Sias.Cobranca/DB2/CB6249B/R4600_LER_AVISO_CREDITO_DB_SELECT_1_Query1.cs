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
    public class R4600_LER_AVISO_CREDITO_DB_SELECT_1_Query1 : QueryBasis<R4600_LER_AVISO_CREDITO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VAL_DESPESA
            , PRM_LIQUIDO
            , PRM_TOTAL
            INTO :AVISOCRE-VAL-DESPESA
            ,:AVISOCRE-PRM-LIQUIDO
            ,:AVISOCRE-PRM-TOTAL
            FROM SEGUROS.AVISO_CREDITO
            WHERE BCO_AVISO =
            :AVISOCRE-BCO-AVISO
            AND AGE_AVISO =
            :AVISOCRE-AGE-AVISO
            AND NUM_AVISO_CREDITO =
            :AVISOCRE-NUM-AVISO-CREDITO
            AND NUM_SEQUENCIA =
            :AVISOCRE-NUM-SEQUENCIA
            AND DATA_MOVIMENTO =
            :AVISOCRE-DATA-MOVIMENTO
            AND COD_OPERACAO =
            :AVISOCRE-COD-OPERACAO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VAL_DESPESA
											, PRM_LIQUIDO
											, PRM_TOTAL
											FROM SEGUROS.AVISO_CREDITO
											WHERE BCO_AVISO =
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
											'{this.AVISOCRE_COD_OPERACAO}'
											WITH UR";

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

        public static R4600_LER_AVISO_CREDITO_DB_SELECT_1_Query1 Execute(R4600_LER_AVISO_CREDITO_DB_SELECT_1_Query1 r4600_LER_AVISO_CREDITO_DB_SELECT_1_Query1)
        {
            var ths = r4600_LER_AVISO_CREDITO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R4600_LER_AVISO_CREDITO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R4600_LER_AVISO_CREDITO_DB_SELECT_1_Query1();
            var i = 0;
            dta.AVISOCRE_VAL_DESPESA = result[i++].Value?.ToString();
            dta.AVISOCRE_PRM_LIQUIDO = result[i++].Value?.ToString();
            dta.AVISOCRE_PRM_TOTAL = result[i++].Value?.ToString();
            return dta;
        }

    }
}