using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0602B
{
    public class R4300_00_SEL_PROP_FIDELIZ_COMP_DB_SELECT_1_Query1 : QueryBasis<R4300_00_SEL_PROP_FIDELIZ_COMP_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(INFORMACAO_COMPL, ' ' )
            INTO :PROFIDCO-INFORMACAO-COMPL
            FROM SEGUROS.PROP_FIDELIZ_COMP
            WHERE NUM_IDENTIFICACAO =
            :PROFIDCO-NUM-IDENTIFICACAO
            AND IND_TP_INFORMACAO = '4'
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT VALUE(INFORMACAO_COMPL
							, ' ' )
											FROM SEGUROS.PROP_FIDELIZ_COMP
											WHERE NUM_IDENTIFICACAO =
											'{this.PROFIDCO_NUM_IDENTIFICACAO}'
											AND IND_TP_INFORMACAO = '4'
											WITH UR";

            return query;
        }
        public string PROFIDCO_INFORMACAO_COMPL { get; set; }
        public string PROFIDCO_NUM_IDENTIFICACAO { get; set; }

        public static R4300_00_SEL_PROP_FIDELIZ_COMP_DB_SELECT_1_Query1 Execute(R4300_00_SEL_PROP_FIDELIZ_COMP_DB_SELECT_1_Query1 r4300_00_SEL_PROP_FIDELIZ_COMP_DB_SELECT_1_Query1)
        {
            var ths = r4300_00_SEL_PROP_FIDELIZ_COMP_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R4300_00_SEL_PROP_FIDELIZ_COMP_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R4300_00_SEL_PROP_FIDELIZ_COMP_DB_SELECT_1_Query1();
            var i = 0;
            dta.PROFIDCO_INFORMACAO_COMPL = result[i++].Value?.ToString();
            return dta;
        }

    }
}