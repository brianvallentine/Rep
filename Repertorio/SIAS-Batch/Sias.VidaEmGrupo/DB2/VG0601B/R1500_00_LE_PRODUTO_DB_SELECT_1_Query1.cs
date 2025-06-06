using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0601B
{
    public class R1500_00_LE_PRODUTO_DB_SELECT_1_Query1 : QueryBasis<R1500_00_LE_PRODUTO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NOME_PRODUTO, ORIG_PRODU
            INTO :PRODUVG-NOME-PRODUTO, :PRODUVG-ORIG-PRODU
            FROM SEGUROS.PRODUTOS_VG
            WHERE NUM_APOLICE = :PROPOVA-NUM-APOLICE
            AND COD_SUBGRUPO = :PROPOVA-COD-SUBGRUPO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NOME_PRODUTO
							, ORIG_PRODU
											FROM SEGUROS.PRODUTOS_VG
											WHERE NUM_APOLICE = '{this.PROPOVA_NUM_APOLICE}'
											AND COD_SUBGRUPO = '{this.PROPOVA_COD_SUBGRUPO}'";

            return query;
        }
        public string PRODUVG_NOME_PRODUTO { get; set; }
        public string PRODUVG_ORIG_PRODU { get; set; }
        public string PROPOVA_COD_SUBGRUPO { get; set; }
        public string PROPOVA_NUM_APOLICE { get; set; }

        public static R1500_00_LE_PRODUTO_DB_SELECT_1_Query1 Execute(R1500_00_LE_PRODUTO_DB_SELECT_1_Query1 r1500_00_LE_PRODUTO_DB_SELECT_1_Query1)
        {
            var ths = r1500_00_LE_PRODUTO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1500_00_LE_PRODUTO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1500_00_LE_PRODUTO_DB_SELECT_1_Query1();
            var i = 0;
            dta.PRODUVG_NOME_PRODUTO = result[i++].Value?.ToString();
            dta.PRODUVG_ORIG_PRODU = result[i++].Value?.ToString();
            return dta;
        }

    }
}