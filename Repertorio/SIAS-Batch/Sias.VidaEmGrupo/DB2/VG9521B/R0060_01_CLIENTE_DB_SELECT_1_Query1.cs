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
    public class R0060_01_CLIENTE_DB_SELECT_1_Query1 : QueryBasis<R0060_01_CLIENTE_DB_SELECT_1_Query1>
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

        public static R0060_01_CLIENTE_DB_SELECT_1_Query1 Execute(R0060_01_CLIENTE_DB_SELECT_1_Query1 r0060_01_CLIENTE_DB_SELECT_1_Query1)
        {
            var ths = r0060_01_CLIENTE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0060_01_CLIENTE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0060_01_CLIENTE_DB_SELECT_1_Query1();
            var i = 0;
            dta.SUBGVGAP_COD_CLIENTE = result[i++].Value?.ToString();
            dta.SUBGVGAP_COD_FONTE = result[i++].Value?.ToString();
            dta.SUBGVGAP_OCORR_ENDERECO = result[i++].Value?.ToString();
            return dta;
        }

    }
}