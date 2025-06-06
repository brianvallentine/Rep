using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0612B
{
    public class R0610_00_SEGURAVG_DB_SELECT_1_Query1 : QueryBasis<R0610_00_SEGURAVG_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            DATA_NASCIMENTO
            INTO
            :SEGVGAP-DATA-NASCIMENTO
            FROM SEGUROS.SEGURADOS_VGAP
            WHERE NUM_CERTIFICADO =
            :SEGVGAP-NUM-CERTIFICADO
            AND TIPO_SEGURADO =
            :SEGVGAP-TIPO-SEGURADO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											DATA_NASCIMENTO
											FROM SEGUROS.SEGURADOS_VGAP
											WHERE NUM_CERTIFICADO =
											'{this.SEGVGAP_NUM_CERTIFICADO}'
											AND TIPO_SEGURADO =
											'{this.SEGVGAP_TIPO_SEGURADO}'
											WITH UR";

            return query;
        }
        public string SEGVGAP_DATA_NASCIMENTO { get; set; }
        public string SEGVGAP_NUM_CERTIFICADO { get; set; }
        public string SEGVGAP_TIPO_SEGURADO { get; set; }

        public static R0610_00_SEGURAVG_DB_SELECT_1_Query1 Execute(R0610_00_SEGURAVG_DB_SELECT_1_Query1 r0610_00_SEGURAVG_DB_SELECT_1_Query1)
        {
            var ths = r0610_00_SEGURAVG_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0610_00_SEGURAVG_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0610_00_SEGURAVG_DB_SELECT_1_Query1();
            var i = 0;
            dta.SEGVGAP_DATA_NASCIMENTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}