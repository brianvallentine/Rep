using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0970B
{
    public class R1850_00_SELECT_PRODUVG_DB_SELECT_2_Query1 : QueryBasis<R1850_00_SELECT_PRODUVG_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            T2.COD_PRODUTO,
            T2.DESCR_PRODUTO
            INTO
            :PRODUVG-COD-PRODUTO,
            :PRODUVG-NOME-PRODUTO
            FROM
            SEGUROS.APOLICES T1,
            SEGUROS.PRODUTO T2
            WHERE
            T1.NUM_APOLICE = :SEGURVGA-NUM-APOLICE
            AND T1.COD_PRODUTO = T2.COD_PRODUTO
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT
											T2.COD_PRODUTO
							,
											T2.DESCR_PRODUTO
											FROM
											SEGUROS.APOLICES T1
							,
											SEGUROS.PRODUTO T2
											WHERE
											T1.NUM_APOLICE = '{this.SEGURVGA_NUM_APOLICE}'
											AND T1.COD_PRODUTO = T2.COD_PRODUTO";

            return query;
        }
        public string PRODUVG_COD_PRODUTO { get; set; }
        public string PRODUVG_NOME_PRODUTO { get; set; }
        public string SEGURVGA_NUM_APOLICE { get; set; }

        public static R1850_00_SELECT_PRODUVG_DB_SELECT_2_Query1 Execute(R1850_00_SELECT_PRODUVG_DB_SELECT_2_Query1 r1850_00_SELECT_PRODUVG_DB_SELECT_2_Query1)
        {
            var ths = r1850_00_SELECT_PRODUVG_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1850_00_SELECT_PRODUVG_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1850_00_SELECT_PRODUVG_DB_SELECT_2_Query1();
            var i = 0;
            dta.PRODUVG_COD_PRODUTO = result[i++].Value?.ToString();
            dta.PRODUVG_NOME_PRODUTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}