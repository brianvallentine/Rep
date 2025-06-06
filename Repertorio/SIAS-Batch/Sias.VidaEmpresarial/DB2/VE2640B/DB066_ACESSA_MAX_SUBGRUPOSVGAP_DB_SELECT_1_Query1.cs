using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE2640B
{
    public class DB066_ACESSA_MAX_SUBGRUPOSVGAP_DB_SELECT_1_Query1 : QueryBasis<DB066_ACESSA_MAX_SUBGRUPOSVGAP_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(MAX(COD_SUBGRUPO),0)
            INTO :SUBGVGAP-COD-SUBGRUPO
            FROM SEGUROS.SUBGRUPOS_VGAP
            WHERE NUM_APOLICE = :VGPROSIA-NUM-APOLICE
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(MAX(COD_SUBGRUPO)
							,0)
											FROM SEGUROS.SUBGRUPOS_VGAP
											WHERE NUM_APOLICE = '{this.VGPROSIA_NUM_APOLICE}'";

            return query;
        }
        public string SUBGVGAP_COD_SUBGRUPO { get; set; }
        public string VGPROSIA_NUM_APOLICE { get; set; }

        public static DB066_ACESSA_MAX_SUBGRUPOSVGAP_DB_SELECT_1_Query1 Execute(DB066_ACESSA_MAX_SUBGRUPOSVGAP_DB_SELECT_1_Query1 dB066_ACESSA_MAX_SUBGRUPOSVGAP_DB_SELECT_1_Query1)
        {
            var ths = dB066_ACESSA_MAX_SUBGRUPOSVGAP_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override DB066_ACESSA_MAX_SUBGRUPOSVGAP_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new DB066_ACESSA_MAX_SUBGRUPOSVGAP_DB_SELECT_1_Query1();
            var i = 0;
            dta.SUBGVGAP_COD_SUBGRUPO = result[i++].Value?.ToString();
            return dta;
        }

    }
}