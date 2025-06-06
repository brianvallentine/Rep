using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0600B
{
    public class R7000_00_CARREGA_SUBGRUPOS_DB_SELECT_1_Query1 : QueryBasis<R7000_00_CARREGA_SUBGRUPOS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(MAX(DTINIVIG), '0001-01-01' )
            INTO :PLAVAVGA-DTINIVIG
            FROM SEGUROS.PLANOS_VA_VGAP
            WHERE NUM_APOLICE = :PLAVAVGA-NUM-APOLICE
            AND CODSUBES = :PLAVAVGA-CODSUBES
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT VALUE(MAX(DTINIVIG)
							, '0001-01-01' )
											FROM SEGUROS.PLANOS_VA_VGAP
											WHERE NUM_APOLICE = '{this.PLAVAVGA_NUM_APOLICE}'
											AND CODSUBES = '{this.PLAVAVGA_CODSUBES}'
											WITH UR";

            return query;
        }
        public string PLAVAVGA_DTINIVIG { get; set; }
        public string PLAVAVGA_NUM_APOLICE { get; set; }
        public string PLAVAVGA_CODSUBES { get; set; }

        public static R7000_00_CARREGA_SUBGRUPOS_DB_SELECT_1_Query1 Execute(R7000_00_CARREGA_SUBGRUPOS_DB_SELECT_1_Query1 r7000_00_CARREGA_SUBGRUPOS_DB_SELECT_1_Query1)
        {
            var ths = r7000_00_CARREGA_SUBGRUPOS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R7000_00_CARREGA_SUBGRUPOS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R7000_00_CARREGA_SUBGRUPOS_DB_SELECT_1_Query1();
            var i = 0;
            dta.PLAVAVGA_DTINIVIG = result[i++].Value?.ToString();
            return dta;
        }

    }
}