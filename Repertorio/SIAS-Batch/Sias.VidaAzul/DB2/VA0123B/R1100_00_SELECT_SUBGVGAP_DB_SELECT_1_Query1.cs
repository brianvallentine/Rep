using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0123B
{
    public class R1100_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1 : QueryBasis<R1100_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT OPCAO_CONJUGE
            INTO :SUBGVGAP-OPCAO-CONJUGE
            FROM SEGUROS.SUBGRUPOS_VGAP
            WHERE NUM_APOLICE = :PROPOVA-NUM-APOLICE
            AND COD_SUBGRUPO = :PROPOVA-COD-SUBGRUPO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT OPCAO_CONJUGE
											FROM SEGUROS.SUBGRUPOS_VGAP
											WHERE NUM_APOLICE = '{this.PROPOVA_NUM_APOLICE}'
											AND COD_SUBGRUPO = '{this.PROPOVA_COD_SUBGRUPO}'
											WITH UR";

            return query;
        }
        public string SUBGVGAP_OPCAO_CONJUGE { get; set; }
        public string PROPOVA_COD_SUBGRUPO { get; set; }
        public string PROPOVA_NUM_APOLICE { get; set; }

        public static R1100_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1 Execute(R1100_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1 r1100_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1)
        {
            var ths = r1100_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1100_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1100_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1();
            var i = 0;
            dta.SUBGVGAP_OPCAO_CONJUGE = result[i++].Value?.ToString();
            return dta;
        }

    }
}