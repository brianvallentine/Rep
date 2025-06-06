using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.CT0006S
{
    public class R1100_00_VERIFICA_FAIXA_DB_SELECT_2_Query1 : QueryBasis<R1100_00_VERIFICA_FAIXA_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_INI_CEP,
            COD_FIM_CEP
            INTO :GE332-COD-INI-CEP,
            :GE332-COD-FIM-CEP
            FROM SEGUROS.GE_DNE_FAIXA_UF
            WHERE COD_UF = :GE332-COD-UF
            AND COD_INI_CEP <= :GE332-COD-INI-CEP
            AND COD_FIM_CEP >= :GE332-COD-INI-CEP
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_INI_CEP
							,
											COD_FIM_CEP
											FROM SEGUROS.GE_DNE_FAIXA_UF
											WHERE COD_UF = '{this.GE332_COD_UF}'
											AND COD_INI_CEP <= '{this.GE332_COD_INI_CEP}'
											AND COD_FIM_CEP >= '{this.GE332_COD_INI_CEP}'";

            return query;
        }
        public string GE332_COD_INI_CEP { get; set; }
        public string GE332_COD_FIM_CEP { get; set; }
        public string GE332_COD_UF { get; set; }

        public static R1100_00_VERIFICA_FAIXA_DB_SELECT_2_Query1 Execute(R1100_00_VERIFICA_FAIXA_DB_SELECT_2_Query1 r1100_00_VERIFICA_FAIXA_DB_SELECT_2_Query1)
        {
            var ths = r1100_00_VERIFICA_FAIXA_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1100_00_VERIFICA_FAIXA_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1100_00_VERIFICA_FAIXA_DB_SELECT_2_Query1();
            var i = 0;
            dta.GE332_COD_INI_CEP = result[i++].Value?.ToString();
            dta.GE332_COD_FIM_CEP = result[i++].Value?.ToString();
            return dta;
        }

    }
}