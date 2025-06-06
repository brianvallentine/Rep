using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.RE0002S
{
    public class R1700_SELECT_MR022_DB_SELECT_1_Query1 : QueryBasis<R1700_SELECT_MR022_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT
            VALUE(A.PCT_DESC_COBERTURA,+0),
            VALUE(A.PCT_BONUS_RENOVCAO,+0),
            VALUE(A.PCT_DESC_CORRETOR,+0)
            INTO :MR022-PCT-DESC-COBERTURA,
            :MR022-PCT-BONUS-RENOVCAO,
            :MR022-PCT-DESC-CORRETOR
            FROM SEGUROS.MR_APOL_ITEM_EMPR A
            WHERE A.NUM_APOLICE = :MR022-NUM-APOLICE
            AND A.NUM_ENDOSSO = :MR022-NUM-ENDOSSO
            AND A.NUM_ITEM = :MRAPOITE-NUM-ITEM
            AND A.NUM_SUB_ITEM =
            (SELECT MAX(B.NUM_SUB_ITEM)
            FROM SEGUROS.MR_APOL_ITEM_EMPR B
            WHERE B.NUM_APOLICE = A.NUM_APOLICE
            AND B.NUM_ENDOSSO = A.NUM_ENDOSSO
            AND B.NUM_ITEM = A.NUM_ITEM)
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											VALUE(A.PCT_DESC_COBERTURA
							,+0)
							,
											VALUE(A.PCT_BONUS_RENOVCAO
							,+0)
							,
											VALUE(A.PCT_DESC_CORRETOR
							,+0)
											FROM SEGUROS.MR_APOL_ITEM_EMPR A
											WHERE A.NUM_APOLICE = '{this.MR022_NUM_APOLICE}'
											AND A.NUM_ENDOSSO = '{this.MR022_NUM_ENDOSSO}'
											AND A.NUM_ITEM = '{this.MRAPOITE_NUM_ITEM}'
											AND A.NUM_SUB_ITEM =
											(SELECT MAX(B.NUM_SUB_ITEM)
											FROM SEGUROS.MR_APOL_ITEM_EMPR B
											WHERE B.NUM_APOLICE = A.NUM_APOLICE
											AND B.NUM_ENDOSSO = A.NUM_ENDOSSO
											AND B.NUM_ITEM = A.NUM_ITEM)
											WITH UR";

            return query;
        }
        public string MR022_PCT_DESC_COBERTURA { get; set; }
        public string MR022_PCT_BONUS_RENOVCAO { get; set; }
        public string MR022_PCT_DESC_CORRETOR { get; set; }
        public string MR022_NUM_APOLICE { get; set; }
        public string MR022_NUM_ENDOSSO { get; set; }
        public string MRAPOITE_NUM_ITEM { get; set; }

        public static R1700_SELECT_MR022_DB_SELECT_1_Query1 Execute(R1700_SELECT_MR022_DB_SELECT_1_Query1 r1700_SELECT_MR022_DB_SELECT_1_Query1)
        {
            var ths = r1700_SELECT_MR022_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1700_SELECT_MR022_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1700_SELECT_MR022_DB_SELECT_1_Query1();
            var i = 0;
            dta.MR022_PCT_DESC_COBERTURA = result[i++].Value?.ToString();
            dta.MR022_PCT_BONUS_RENOVCAO = result[i++].Value?.ToString();
            dta.MR022_PCT_DESC_CORRETOR = result[i++].Value?.ToString();
            return dta;
        }

    }
}