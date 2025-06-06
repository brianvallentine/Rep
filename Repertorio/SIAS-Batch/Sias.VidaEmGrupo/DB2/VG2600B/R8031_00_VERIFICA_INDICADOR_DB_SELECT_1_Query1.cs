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
    public class R8031_00_VERIFICA_INDICADOR_DB_SELECT_1_Query1 : QueryBasis<R8031_00_VERIFICA_INDICADOR_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_ANGARIADOR
            INTO :FUNCICEF-COD-ANGARIADOR
            FROM SEGUROS.FUNCIONARIOS_CEF
            WHERE NUM_MATRICULA = :FUNCICEF-NUM-MATRICULA
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_ANGARIADOR
											FROM SEGUROS.FUNCIONARIOS_CEF
											WHERE NUM_MATRICULA = '{this.FUNCICEF_NUM_MATRICULA}'
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string FUNCICEF_COD_ANGARIADOR { get; set; }
        public string FUNCICEF_NUM_MATRICULA { get; set; }

        public static R8031_00_VERIFICA_INDICADOR_DB_SELECT_1_Query1 Execute(R8031_00_VERIFICA_INDICADOR_DB_SELECT_1_Query1 r8031_00_VERIFICA_INDICADOR_DB_SELECT_1_Query1)
        {
            var ths = r8031_00_VERIFICA_INDICADOR_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R8031_00_VERIFICA_INDICADOR_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R8031_00_VERIFICA_INDICADOR_DB_SELECT_1_Query1();
            var i = 0;
            dta.FUNCICEF_COD_ANGARIADOR = result[i++].Value?.ToString();
            return dta;
        }

    }
}