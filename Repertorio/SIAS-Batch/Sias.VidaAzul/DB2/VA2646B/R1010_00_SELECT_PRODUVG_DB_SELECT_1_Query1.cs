using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA2646B
{
    public class R1010_00_SELECT_PRODUVG_DB_SELECT_1_Query1 : QueryBasis<R1010_00_SELECT_PRODUVG_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            COD_PRODUTO_AZUL
            INTO :PRODUVG-COD-PRODUTO-AZUL
            FROM
            SEGUROS.PRODUTOS_VG
            WHERE
            NUM_APOLICE = :PROPOVA-NUM-APOLICE
            AND COD_SUBGRUPO = :PROPOVA-COD-SUBGRUPO
            AND ORIG_PRODU IN ( 'ESPEC' , 'CEF DEB CC' )
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											COD_PRODUTO_AZUL
											FROM
											SEGUROS.PRODUTOS_VG
											WHERE
											NUM_APOLICE = '{this.PROPOVA_NUM_APOLICE}'
											AND COD_SUBGRUPO = '{this.PROPOVA_COD_SUBGRUPO}'
											AND ORIG_PRODU IN ( 'ESPEC' 
							, 'CEF DEB CC' )";

            return query;
        }
        public string PRODUVG_COD_PRODUTO_AZUL { get; set; }
        public string PROPOVA_COD_SUBGRUPO { get; set; }
        public string PROPOVA_NUM_APOLICE { get; set; }

        public static R1010_00_SELECT_PRODUVG_DB_SELECT_1_Query1 Execute(R1010_00_SELECT_PRODUVG_DB_SELECT_1_Query1 r1010_00_SELECT_PRODUVG_DB_SELECT_1_Query1)
        {
            var ths = r1010_00_SELECT_PRODUVG_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1010_00_SELECT_PRODUVG_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1010_00_SELECT_PRODUVG_DB_SELECT_1_Query1();
            var i = 0;
            dta.PRODUVG_COD_PRODUTO_AZUL = result[i++].Value?.ToString();
            return dta;
        }

    }
}