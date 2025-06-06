using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA4437B
{
    public class R2800_00_SELECT_SEGURVGA_DB_SELECT_1_Query1 : QueryBasis<R2800_00_SELECT_SEGURVGA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_APOLICE,
            COD_SUBGRUPO,
            NUM_ITEM,
            OCORR_HISTORICO
            INTO :SEGURVGA-NUM-APOLICE,
            :SEGURVGA-COD-SUBGRUPO,
            :SEGURVGA-NUM-ITEM,
            :SEGURVGA-OCORR-HISTORICO
            FROM SEGUROS.SEGURADOS_VGAP
            WHERE NUM_CERTIFICADO = :WHOST-NRCERTIF
            AND TIPO_SEGURADO = '1'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_APOLICE
							,
											COD_SUBGRUPO
							,
											NUM_ITEM
							,
											OCORR_HISTORICO
											FROM SEGUROS.SEGURADOS_VGAP
											WHERE NUM_CERTIFICADO = '{this.WHOST_NRCERTIF}'
											AND TIPO_SEGURADO = '1'";

            return query;
        }
        public string SEGURVGA_NUM_APOLICE { get; set; }
        public string SEGURVGA_COD_SUBGRUPO { get; set; }
        public string SEGURVGA_NUM_ITEM { get; set; }
        public string SEGURVGA_OCORR_HISTORICO { get; set; }
        public string WHOST_NRCERTIF { get; set; }

        public static R2800_00_SELECT_SEGURVGA_DB_SELECT_1_Query1 Execute(R2800_00_SELECT_SEGURVGA_DB_SELECT_1_Query1 r2800_00_SELECT_SEGURVGA_DB_SELECT_1_Query1)
        {
            var ths = r2800_00_SELECT_SEGURVGA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2800_00_SELECT_SEGURVGA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2800_00_SELECT_SEGURVGA_DB_SELECT_1_Query1();
            var i = 0;
            dta.SEGURVGA_NUM_APOLICE = result[i++].Value?.ToString();
            dta.SEGURVGA_COD_SUBGRUPO = result[i++].Value?.ToString();
            dta.SEGURVGA_NUM_ITEM = result[i++].Value?.ToString();
            dta.SEGURVGA_OCORR_HISTORICO = result[i++].Value?.ToString();
            return dta;
        }

    }
}