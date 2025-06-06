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
    public class R0410_00_LER_CBO_DB_SELECT_1_Query1 : QueryBasis<R0410_00_LER_CBO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DISTINCT
            COD_CBO ,
            DESCR_CBO
            INTO
            :DCLCBO.CBO-COD-CBO ,
            :DCLCBO.CBO-DESCR-CBO
            FROM SEGUROS.CBO
            WHERE ABREV_CBO = :DCLCBO.CBO-DESCR-CBO
            AND COD_CBO < 1000
            ORDER BY COD_CBO, DESCR_CBO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DISTINCT
											COD_CBO 
							,
											DESCR_CBO
											FROM SEGUROS.CBO
											WHERE ABREV_CBO = '{this.CBO_DESCR_CBO}'
											AND COD_CBO < 1000
											ORDER BY COD_CBO
							, DESCR_CBO
											WITH UR";

            return query;
        }
        public string CBO_COD_CBO { get; set; }
        public string CBO_DESCR_CBO { get; set; }

        public static R0410_00_LER_CBO_DB_SELECT_1_Query1 Execute(R0410_00_LER_CBO_DB_SELECT_1_Query1 r0410_00_LER_CBO_DB_SELECT_1_Query1)
        {
            var ths = r0410_00_LER_CBO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0410_00_LER_CBO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0410_00_LER_CBO_DB_SELECT_1_Query1();
            var i = 0;
            dta.CBO_COD_CBO = result[i++].Value?.ToString();
            dta.CBO_DESCR_CBO = result[i++].Value?.ToString();
            return dta;
        }

    }
}