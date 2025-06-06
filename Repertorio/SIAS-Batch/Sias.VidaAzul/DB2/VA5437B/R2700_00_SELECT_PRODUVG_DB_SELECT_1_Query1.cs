using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA5437B
{
    public class R2700_00_SELECT_PRODUVG_DB_SELECT_1_Query1 : QueryBasis<R2700_00_SELECT_PRODUVG_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NOME_PRODUTO,
            COD_PRODUTO
            INTO :PRODUVG-NOME-PRODUTO,
            :PRODUVG-COD-PRODUTO
            FROM SEGUROS.PRODUTOS_VG
            WHERE NUM_APOLICE = :WHOST-NRAPOLICE
            AND COD_SUBGRUPO = :WHOST-CODSUBES
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NOME_PRODUTO
							,
											COD_PRODUTO
											FROM SEGUROS.PRODUTOS_VG
											WHERE NUM_APOLICE = '{this.WHOST_NRAPOLICE}'
											AND COD_SUBGRUPO = '{this.WHOST_CODSUBES}'
											WITH UR";

            return query;
        }
        public string PRODUVG_NOME_PRODUTO { get; set; }
        public string PRODUVG_COD_PRODUTO { get; set; }
        public string WHOST_NRAPOLICE { get; set; }
        public string WHOST_CODSUBES { get; set; }

        public static R2700_00_SELECT_PRODUVG_DB_SELECT_1_Query1 Execute(R2700_00_SELECT_PRODUVG_DB_SELECT_1_Query1 r2700_00_SELECT_PRODUVG_DB_SELECT_1_Query1)
        {
            var ths = r2700_00_SELECT_PRODUVG_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2700_00_SELECT_PRODUVG_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2700_00_SELECT_PRODUVG_DB_SELECT_1_Query1();
            var i = 0;
            dta.PRODUVG_NOME_PRODUTO = result[i++].Value?.ToString();
            dta.PRODUVG_COD_PRODUTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}