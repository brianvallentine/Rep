using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA1180B
{
    public class R0250_00_PESQUISA_SEGURADO_DB_SELECT_1_Query1 : QueryBasis<R0250_00_PESQUISA_SEGURADO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT SIT_REGISTRO
            INTO :SEGURVGA-SIT-REGISTRO
            FROM SEGUROS.SEGURADOS_VGAP
            WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO
            AND TIPO_SEGURADO = '1'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT SIT_REGISTRO
											FROM SEGUROS.SEGURADOS_VGAP
											WHERE NUM_CERTIFICADO = '{this.PROPOVA_NUM_CERTIFICADO}'
											AND TIPO_SEGURADO = '1'";

            return query;
        }
        public string SEGURVGA_SIT_REGISTRO { get; set; }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }

        public static R0250_00_PESQUISA_SEGURADO_DB_SELECT_1_Query1 Execute(R0250_00_PESQUISA_SEGURADO_DB_SELECT_1_Query1 r0250_00_PESQUISA_SEGURADO_DB_SELECT_1_Query1)
        {
            var ths = r0250_00_PESQUISA_SEGURADO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0250_00_PESQUISA_SEGURADO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0250_00_PESQUISA_SEGURADO_DB_SELECT_1_Query1();
            var i = 0;
            dta.SEGURVGA_SIT_REGISTRO = result[i++].Value?.ToString();
            return dta;
        }

    }
}