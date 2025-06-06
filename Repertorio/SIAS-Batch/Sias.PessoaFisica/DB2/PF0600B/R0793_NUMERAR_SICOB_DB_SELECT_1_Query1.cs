using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0600B
{
    public class R0793_NUMERAR_SICOB_DB_SELECT_1_Query1 : QueryBasis<R0793_NUMERAR_SICOB_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_TITULO,
            NUM_TITULO_MAX
            INTO :DCLCEDENTE.CEDENTE-NUM-TITULO,
            :DCLCEDENTE.CEDENTE-NUM-TITULO-MAX
            FROM SEGUROS.CEDENTE
            WHERE COD_CEDENTE = :DCLCEDENTE.CEDENTE-COD-CEDENTE
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_TITULO
							,
											NUM_TITULO_MAX
											FROM SEGUROS.CEDENTE
											WHERE COD_CEDENTE = '{this.CEDENTE_COD_CEDENTE}'
											WITH UR";

            return query;
        }
        public string CEDENTE_NUM_TITULO { get; set; }
        public string CEDENTE_NUM_TITULO_MAX { get; set; }
        public string CEDENTE_COD_CEDENTE { get; set; }

        public static R0793_NUMERAR_SICOB_DB_SELECT_1_Query1 Execute(R0793_NUMERAR_SICOB_DB_SELECT_1_Query1 r0793_NUMERAR_SICOB_DB_SELECT_1_Query1)
        {
            var ths = r0793_NUMERAR_SICOB_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0793_NUMERAR_SICOB_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0793_NUMERAR_SICOB_DB_SELECT_1_Query1();
            var i = 0;
            dta.CEDENTE_NUM_TITULO = result[i++].Value?.ToString();
            dta.CEDENTE_NUM_TITULO_MAX = result[i++].Value?.ToString();
            return dta;
        }

    }
}