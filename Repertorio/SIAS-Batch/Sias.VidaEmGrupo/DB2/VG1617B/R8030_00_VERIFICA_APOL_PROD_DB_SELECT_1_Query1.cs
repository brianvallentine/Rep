using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1617B
{
    public class R8030_00_VERIFICA_APOL_PROD_DB_SELECT_1_Query1 : QueryBasis<R8030_00_VERIFICA_APOL_PROD_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(ESTR_EMISS, ' ' )
            INTO :PRODUVG-ESTR-EMISS
            FROM SEGUROS.PRODUTOS_VG
            WHERE NUM_APOLICE = :PRODUVG-NUM-APOLICE
            ORDER BY COD_SUBGRUPO DESC
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(ESTR_EMISS
							, ' ' )
											FROM SEGUROS.PRODUTOS_VG
											WHERE NUM_APOLICE = '{this.PRODUVG_NUM_APOLICE}'
											ORDER BY COD_SUBGRUPO DESC
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string PRODUVG_ESTR_EMISS { get; set; }
        public string PRODUVG_NUM_APOLICE { get; set; }

        public static R8030_00_VERIFICA_APOL_PROD_DB_SELECT_1_Query1 Execute(R8030_00_VERIFICA_APOL_PROD_DB_SELECT_1_Query1 r8030_00_VERIFICA_APOL_PROD_DB_SELECT_1_Query1)
        {
            var ths = r8030_00_VERIFICA_APOL_PROD_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R8030_00_VERIFICA_APOL_PROD_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R8030_00_VERIFICA_APOL_PROD_DB_SELECT_1_Query1();
            var i = 0;
            dta.PRODUVG_ESTR_EMISS = result[i++].Value?.ToString();
            return dta;
        }

    }
}