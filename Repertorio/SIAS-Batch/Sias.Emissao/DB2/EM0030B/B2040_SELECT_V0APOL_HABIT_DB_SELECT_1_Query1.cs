using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0030B
{
    public class B2040_SELECT_V0APOL_HABIT_DB_SELECT_1_Query1 : QueryBasis<B2040_SELECT_V0APOL_HABIT_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT A.CODCLIEN
            INTO :V0PRHA-CODCLIEN
            FROM SEGUROS.V0APOLICE A,
            SEGUROS.V0APOLICE_HABIT B
            WHERE B.NUM_APOLICE = :ENDO-NUM-APOLICE
            AND B.NUM_APOLICE = A.NUM_APOLICE
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT A.CODCLIEN
											FROM SEGUROS.V0APOLICE A
							,
											SEGUROS.V0APOLICE_HABIT B
											WHERE B.NUM_APOLICE = '{this.ENDO_NUM_APOLICE}'
											AND B.NUM_APOLICE = A.NUM_APOLICE
											WITH UR";

            return query;
        }
        public string V0PRHA_CODCLIEN { get; set; }
        public string ENDO_NUM_APOLICE { get; set; }

        public static B2040_SELECT_V0APOL_HABIT_DB_SELECT_1_Query1 Execute(B2040_SELECT_V0APOL_HABIT_DB_SELECT_1_Query1 b2040_SELECT_V0APOL_HABIT_DB_SELECT_1_Query1)
        {
            var ths = b2040_SELECT_V0APOL_HABIT_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override B2040_SELECT_V0APOL_HABIT_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new B2040_SELECT_V0APOL_HABIT_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0PRHA_CODCLIEN = result[i++].Value?.ToString();
            return dta;
        }

    }
}