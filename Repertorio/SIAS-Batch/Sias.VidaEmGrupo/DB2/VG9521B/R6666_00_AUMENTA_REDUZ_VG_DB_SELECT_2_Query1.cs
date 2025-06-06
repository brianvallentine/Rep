using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG9521B
{
    public class R6666_00_AUMENTA_REDUZ_VG_DB_SELECT_2_Query1 : QueryBasis<R6666_00_AUMENTA_REDUZ_VG_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            COD_CLIENTE,
            COD_FONTE,
            OCORR_ENDERECO
            INTO
            :SUBGVGAP-COD-CLIENTE,
            :SUBGVGAP-COD-FONTE,
            :SUBGVGAP-OCORR-ENDERECO
            FROM SEGUROS.SUBGRUPOS_VGAP
            WHERE
            NUM_APOLICE = :SEGURVGA-NUM-APOLICE
            AND COD_SUBGRUPO = :SEGURVGA-COD-SUBGRUPO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											COD_CLIENTE
							,
											COD_FONTE
							,
											OCORR_ENDERECO
											FROM SEGUROS.SUBGRUPOS_VGAP
											WHERE
											NUM_APOLICE = '{this.SEGURVGA_NUM_APOLICE}'
											AND COD_SUBGRUPO = '{this.SEGURVGA_COD_SUBGRUPO}'";

            return query;
        }
        public string SUBGVGAP_COD_CLIENTE { get; set; }
        public string SUBGVGAP_COD_FONTE { get; set; }
        public string SUBGVGAP_OCORR_ENDERECO { get; set; }
        public string SEGURVGA_COD_SUBGRUPO { get; set; }
        public string SEGURVGA_NUM_APOLICE { get; set; }

        public static R6666_00_AUMENTA_REDUZ_VG_DB_SELECT_2_Query1 Execute(R6666_00_AUMENTA_REDUZ_VG_DB_SELECT_2_Query1 r6666_00_AUMENTA_REDUZ_VG_DB_SELECT_2_Query1)
        {
            var ths = r6666_00_AUMENTA_REDUZ_VG_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R6666_00_AUMENTA_REDUZ_VG_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R6666_00_AUMENTA_REDUZ_VG_DB_SELECT_2_Query1();
            var i = 0;
            dta.SUBGVGAP_COD_CLIENTE = result[i++].Value?.ToString();
            dta.SUBGVGAP_COD_FONTE = result[i++].Value?.ToString();
            dta.SUBGVGAP_OCORR_ENDERECO = result[i++].Value?.ToString();
            return dta;
        }

    }
}