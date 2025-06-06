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
    public class R1100_00_VERIFICA_FAIXA_DB_SELECT_1_Query1 : QueryBasis<R1100_00_VERIFICA_FAIXA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            COD_INI_FAIXA_CEP,
            COD_FIM_FAIXA_CEP,
            NOM_UNIDADE_OPER ,
            NOM_CENTRALIZADOR
            INTO
            :GE353-COD-INI-FAIXA-CEP,
            :GE353-COD-FIM-FAIXA-CEP,
            :GE353-NOM-UNIDADE-OPER ,
            :GE353-NOM-CENTRALIZADOR
            FROM
            SEGUROS.GE_DNE_TRIAGEM
            WHERE COD_INI_FAIXA_CEP <= :GE332-COD-INI-CEP
            AND COD_FIM_FAIXA_CEP >= :GE332-COD-INI-CEP
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											COD_INI_FAIXA_CEP
							,
											COD_FIM_FAIXA_CEP
							,
											NOM_UNIDADE_OPER 
							,
											NOM_CENTRALIZADOR
											FROM
											SEGUROS.GE_DNE_TRIAGEM
											WHERE COD_INI_FAIXA_CEP <= '{this.GE332_COD_INI_CEP}'
											AND COD_FIM_FAIXA_CEP >= '{this.GE332_COD_INI_CEP}'";

            return query;
        }
        public string GE353_COD_INI_FAIXA_CEP { get; set; }
        public string GE353_COD_FIM_FAIXA_CEP { get; set; }
        public string GE353_NOM_UNIDADE_OPER { get; set; }
        public string GE353_NOM_CENTRALIZADOR { get; set; }
        public string GE332_COD_INI_CEP { get; set; }

        public static R1100_00_VERIFICA_FAIXA_DB_SELECT_1_Query1 Execute(R1100_00_VERIFICA_FAIXA_DB_SELECT_1_Query1 r1100_00_VERIFICA_FAIXA_DB_SELECT_1_Query1)
        {
            var ths = r1100_00_VERIFICA_FAIXA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1100_00_VERIFICA_FAIXA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1100_00_VERIFICA_FAIXA_DB_SELECT_1_Query1();
            var i = 0;
            dta.GE353_COD_INI_FAIXA_CEP = result[i++].Value?.ToString();
            dta.GE353_COD_FIM_FAIXA_CEP = result[i++].Value?.ToString();
            dta.GE353_NOM_UNIDADE_OPER = result[i++].Value?.ToString();
            dta.GE353_NOM_CENTRALIZADOR = result[i++].Value?.ToString();
            return dta;
        }

    }
}