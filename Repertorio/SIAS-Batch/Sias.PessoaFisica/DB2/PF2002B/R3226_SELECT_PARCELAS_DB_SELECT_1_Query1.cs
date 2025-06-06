using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF2002B
{
    public class R3226_SELECT_PARCELAS_DB_SELECT_1_Query1 : QueryBasis<R3226_SELECT_PARCELAS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_TITULO
            INTO :PARCELAS-NUM-TITULO
            FROM SEGUROS.PARCELAS
            WHERE NUM_APOLICE = :GE403-NUM-APOLICE
            AND NUM_ENDOSSO = :GE403-NUM-ENDOSSO
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_TITULO
											FROM SEGUROS.PARCELAS
											WHERE NUM_APOLICE = '{this.GE403_NUM_APOLICE}'
											AND NUM_ENDOSSO = '{this.GE403_NUM_ENDOSSO}'
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string PARCELAS_NUM_TITULO { get; set; }
        public string GE403_NUM_APOLICE { get; set; }
        public string GE403_NUM_ENDOSSO { get; set; }

        public static R3226_SELECT_PARCELAS_DB_SELECT_1_Query1 Execute(R3226_SELECT_PARCELAS_DB_SELECT_1_Query1 r3226_SELECT_PARCELAS_DB_SELECT_1_Query1)
        {
            var ths = r3226_SELECT_PARCELAS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3226_SELECT_PARCELAS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3226_SELECT_PARCELAS_DB_SELECT_1_Query1();
            var i = 0;
            dta.PARCELAS_NUM_TITULO = result[i++].Value?.ToString();
            return dta;
        }

    }
}