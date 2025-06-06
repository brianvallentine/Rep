using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0966B
{
    public class R1510_00_SELECT_PRODUVG_DB_SELECT_1_Query1 : QueryBasis<R1510_00_SELECT_PRODUVG_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            RAMO
            INTO
            :PRODUVG-RAMO
            FROM
            SEGUROS.PRODUTOS_VG
            WHERE
            NUM_APOLICE = :SEGURVGA-NUM-APOLICE
            AND COD_SUBGRUPO = :SEGURVGA-COD-SUBGRUPO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											RAMO
											FROM
											SEGUROS.PRODUTOS_VG
											WHERE
											NUM_APOLICE = '{this.SEGURVGA_NUM_APOLICE}'
											AND COD_SUBGRUPO = '{this.SEGURVGA_COD_SUBGRUPO}'";

            return query;
        }
        public string PRODUVG_RAMO { get; set; }
        public string SEGURVGA_COD_SUBGRUPO { get; set; }
        public string SEGURVGA_NUM_APOLICE { get; set; }

        public static R1510_00_SELECT_PRODUVG_DB_SELECT_1_Query1 Execute(R1510_00_SELECT_PRODUVG_DB_SELECT_1_Query1 r1510_00_SELECT_PRODUVG_DB_SELECT_1_Query1)
        {
            var ths = r1510_00_SELECT_PRODUVG_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1510_00_SELECT_PRODUVG_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1510_00_SELECT_PRODUVG_DB_SELECT_1_Query1();
            var i = 0;
            dta.PRODUVG_RAMO = result[i++].Value?.ToString();
            return dta;
        }

    }
}