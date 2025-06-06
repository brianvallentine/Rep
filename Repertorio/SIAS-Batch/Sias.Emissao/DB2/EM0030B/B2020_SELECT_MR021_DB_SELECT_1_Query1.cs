using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0030B
{
    public class B2020_SELECT_MR021_DB_SELECT_1_Query1 : QueryBasis<B2020_SELECT_MR021_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(A.PCT_DESC_COBERTURA,0),
            VALUE(A.PCT_BONUS_RENOVCAO,0),
            VALUE(A.PCT_DESC_CORRETOR,0)
            INTO :MR021-PCT-DESC-COBERTURA,
            :MR021-PCT-BONUS-RENOVCAO,
            :MR021-PCT-DESC-CORRETOR
            FROM SEGUROS.MR_APOL_ITEM_COND A
            WHERE A.NUM_APOLICE = :ENDO-NUM-APOLICE
            AND A.NUM_ENDOSSO = :ENDO-NRENDOS
            AND A.NUM_ITEM =
            (SELECT MAX(B.NUM_ITEM)
            FROM SEGUROS.MR_APOL_ITEM_COND B
            WHERE B.NUM_APOLICE = A.NUM_APOLICE
            AND B.NUM_ENDOSSO = A.NUM_ENDOSSO)
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(A.PCT_DESC_COBERTURA
							,0)
							,
											VALUE(A.PCT_BONUS_RENOVCAO
							,0)
							,
											VALUE(A.PCT_DESC_CORRETOR
							,0)
											FROM SEGUROS.MR_APOL_ITEM_COND A
											WHERE A.NUM_APOLICE = '{this.ENDO_NUM_APOLICE}'
											AND A.NUM_ENDOSSO = '{this.ENDO_NRENDOS}'
											AND A.NUM_ITEM =
											(SELECT MAX(B.NUM_ITEM)
											FROM SEGUROS.MR_APOL_ITEM_COND B
											WHERE B.NUM_APOLICE = A.NUM_APOLICE
											AND B.NUM_ENDOSSO = A.NUM_ENDOSSO)
											WITH UR";

            return query;
        }
        public string MR021_PCT_DESC_COBERTURA { get; set; }
        public string MR021_PCT_BONUS_RENOVCAO { get; set; }
        public string MR021_PCT_DESC_CORRETOR { get; set; }
        public string ENDO_NUM_APOLICE { get; set; }
        public string ENDO_NRENDOS { get; set; }

        public static B2020_SELECT_MR021_DB_SELECT_1_Query1 Execute(B2020_SELECT_MR021_DB_SELECT_1_Query1 b2020_SELECT_MR021_DB_SELECT_1_Query1)
        {
            var ths = b2020_SELECT_MR021_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override B2020_SELECT_MR021_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new B2020_SELECT_MR021_DB_SELECT_1_Query1();
            var i = 0;
            dta.MR021_PCT_DESC_COBERTURA = result[i++].Value?.ToString();
            dta.MR021_PCT_BONUS_RENOVCAO = result[i++].Value?.ToString();
            dta.MR021_PCT_DESC_CORRETOR = result[i++].Value?.ToString();
            return dta;
        }

    }
}