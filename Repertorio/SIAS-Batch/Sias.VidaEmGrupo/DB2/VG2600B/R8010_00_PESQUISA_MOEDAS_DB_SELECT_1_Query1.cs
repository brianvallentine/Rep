using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG2600B
{
    public class R8010_00_PESQUISA_MOEDAS_DB_SELECT_1_Query1 : QueryBasis<R8010_00_PESQUISA_MOEDAS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(COD_MOEDA, 1)
            INTO :MOEDAS-COD-MOEDA
            FROM SEGUROS.MOEDAS
            WHERE TIPO_MOEDA = '0'
            AND SIT_REGISTRO = '0'
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(COD_MOEDA
							, 1)
											FROM SEGUROS.MOEDAS
											WHERE TIPO_MOEDA = '0'
											AND SIT_REGISTRO = '0'
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string MOEDAS_COD_MOEDA { get; set; }

        public static R8010_00_PESQUISA_MOEDAS_DB_SELECT_1_Query1 Execute(R8010_00_PESQUISA_MOEDAS_DB_SELECT_1_Query1 r8010_00_PESQUISA_MOEDAS_DB_SELECT_1_Query1)
        {
            var ths = r8010_00_PESQUISA_MOEDAS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R8010_00_PESQUISA_MOEDAS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R8010_00_PESQUISA_MOEDAS_DB_SELECT_1_Query1();
            var i = 0;
            dta.MOEDAS_COD_MOEDA = result[i++].Value?.ToString();
            return dta;
        }

    }
}