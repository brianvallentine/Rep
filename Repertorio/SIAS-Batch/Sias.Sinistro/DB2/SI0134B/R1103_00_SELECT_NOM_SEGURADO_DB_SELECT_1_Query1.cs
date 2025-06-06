using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0134B
{
    public class R1103_00_SELECT_NOM_SEGURADO_DB_SELECT_1_Query1 : QueryBasis<R1103_00_SELECT_NOM_SEGURADO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NOME_SEGURADO
            INTO :SINIHAB1-NOME-SEGURADO
            FROM SEGUROS.SINISTRO_HABIT01
            WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NOME_SEGURADO
											FROM SEGUROS.SINISTRO_HABIT01
											WHERE NUM_APOL_SINISTRO = '{this.SINISHIS_NUM_APOL_SINISTRO}'
											WITH UR";

            return query;
        }
        public string SINIHAB1_NOME_SEGURADO { get; set; }
        public string SINISHIS_NUM_APOL_SINISTRO { get; set; }

        public static R1103_00_SELECT_NOM_SEGURADO_DB_SELECT_1_Query1 Execute(R1103_00_SELECT_NOM_SEGURADO_DB_SELECT_1_Query1 r1103_00_SELECT_NOM_SEGURADO_DB_SELECT_1_Query1)
        {
            var ths = r1103_00_SELECT_NOM_SEGURADO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1103_00_SELECT_NOM_SEGURADO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1103_00_SELECT_NOM_SEGURADO_DB_SELECT_1_Query1();
            var i = 0;
            dta.SINIHAB1_NOME_SEGURADO = result[i++].Value?.ToString();
            return dta;
        }

    }
}