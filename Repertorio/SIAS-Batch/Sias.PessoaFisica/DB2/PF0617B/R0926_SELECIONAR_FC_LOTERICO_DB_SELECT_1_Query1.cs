using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0617B
{
    public class R0926_SELECIONAR_FC_LOTERICO_DB_SELECT_1_Query1 : QueryBasis<R0926_SELECIONAR_FC_LOTERICO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_DV_LOTERICO
            INTO :FCLOTERI-NUM-DV-LOTERICO
            FROM FDRCAP.FC_LOTERICO
            WHERE NUM_LOTERICO = :FCLOTERI-NUM-LOTERICO
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_DV_LOTERICO
											FROM FDRCAP.FC_LOTERICO
											WHERE NUM_LOTERICO = '{this.FCLOTERI_NUM_LOTERICO}'
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string FCLOTERI_NUM_DV_LOTERICO { get; set; }
        public string FCLOTERI_NUM_LOTERICO { get; set; }

        public static R0926_SELECIONAR_FC_LOTERICO_DB_SELECT_1_Query1 Execute(R0926_SELECIONAR_FC_LOTERICO_DB_SELECT_1_Query1 r0926_SELECIONAR_FC_LOTERICO_DB_SELECT_1_Query1)
        {
            var ths = r0926_SELECIONAR_FC_LOTERICO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0926_SELECIONAR_FC_LOTERICO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0926_SELECIONAR_FC_LOTERICO_DB_SELECT_1_Query1();
            var i = 0;
            dta.FCLOTERI_NUM_DV_LOTERICO = result[i++].Value?.ToString();
            return dta;
        }

    }
}