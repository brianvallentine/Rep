using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0202S
{
    public class R8000_SEL_CONTRTE_CONTR_DB_SELECT_1_Query1 : QueryBasis<R8000_SEL_CONTRTE_CONTR_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_PESSOA_CONTRTE
            INTO :EF047-COD-PESSOA-CONTRTE
            FROM SEGUROS.EF_CONTRTE_CONTR
            WHERE NUM_CONTRATO = :EF072-NUM-CONTRATO
            AND COD_PESSOA_CONTRTE =
            (SELECT MAX(B.COD_PESSOA_CONTRTE)
            FROM SEGUROS.EF_CONTRTE_CONTR B
            WHERE B.NUM_CONTRATO = :EF072-NUM-CONTRATO)
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_PESSOA_CONTRTE
											FROM SEGUROS.EF_CONTRTE_CONTR
											WHERE NUM_CONTRATO = '{this.EF072_NUM_CONTRATO}'
											AND COD_PESSOA_CONTRTE =
											(SELECT MAX(B.COD_PESSOA_CONTRTE)
											FROM SEGUROS.EF_CONTRTE_CONTR B
											WHERE B.NUM_CONTRATO = '{this.EF072_NUM_CONTRATO}')
											WITH UR";

            return query;
        }
        public string EF047_COD_PESSOA_CONTRTE { get; set; }
        public string EF072_NUM_CONTRATO { get; set; }

        public static R8000_SEL_CONTRTE_CONTR_DB_SELECT_1_Query1 Execute(R8000_SEL_CONTRTE_CONTR_DB_SELECT_1_Query1 r8000_SEL_CONTRTE_CONTR_DB_SELECT_1_Query1)
        {
            var ths = r8000_SEL_CONTRTE_CONTR_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R8000_SEL_CONTRTE_CONTR_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R8000_SEL_CONTRTE_CONTR_DB_SELECT_1_Query1();
            var i = 0;
            dta.EF047_COD_PESSOA_CONTRTE = result[i++].Value?.ToString();
            return dta;
        }

    }
}