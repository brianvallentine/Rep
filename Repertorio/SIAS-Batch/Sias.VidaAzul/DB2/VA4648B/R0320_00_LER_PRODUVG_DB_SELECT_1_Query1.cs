using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA4648B
{
    public class R0320_00_LER_PRODUVG_DB_SELECT_1_Query1 : QueryBasis<R0320_00_LER_PRODUVG_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            COD_PRODUTO,
            NOME_PRODUTO
            INTO
            :PRODUVG-COD-PRODUTO,
            :PRODUVG-NOME-PRODUTO
            FROM SEGUROS.PRODUTOS_VG
            WHERE NUM_APOLICE = :PRODUVG-NUM-APOLICE
            AND COD_SUBGRUPO = :PRODUVG-COD-SUBGRUPO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											COD_PRODUTO
							,
											NOME_PRODUTO
											FROM SEGUROS.PRODUTOS_VG
											WHERE NUM_APOLICE = '{this.PRODUVG_NUM_APOLICE}'
											AND COD_SUBGRUPO = '{this.PRODUVG_COD_SUBGRUPO}'";

            return query;
        }
        public string PRODUVG_COD_PRODUTO { get; set; }
        public string PRODUVG_NOME_PRODUTO { get; set; }
        public string PRODUVG_COD_SUBGRUPO { get; set; }
        public string PRODUVG_NUM_APOLICE { get; set; }

        public static R0320_00_LER_PRODUVG_DB_SELECT_1_Query1 Execute(R0320_00_LER_PRODUVG_DB_SELECT_1_Query1 r0320_00_LER_PRODUVG_DB_SELECT_1_Query1)
        {
            var ths = r0320_00_LER_PRODUVG_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0320_00_LER_PRODUVG_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0320_00_LER_PRODUVG_DB_SELECT_1_Query1();
            var i = 0;
            dta.PRODUVG_COD_PRODUTO = result[i++].Value?.ToString();
            dta.PRODUVG_NOME_PRODUTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}