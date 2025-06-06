using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0140B
{
    public class R0330_00_SELECT_CONDITEC_DB_SELECT_1_Query1 : QueryBasis<R0330_00_SELECT_CONDITEC_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT GARAN_ADIC_IEA
            ,GARAN_ADIC_IPA
            ,GARAN_ADIC_IPD
            INTO :CONDITEC-GARAN-ADIC-IEA
            ,:CONDITEC-GARAN-ADIC-IPA
            ,:CONDITEC-GARAN-ADIC-IPD
            FROM SEGUROS.CONDICOES_TECNICAS
            WHERE NUM_APOLICE = :HISCONPA-NUM-APOLICE
            AND COD_SUBGRUPO = :HISCONPA-COD-SUBGRUPO
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT GARAN_ADIC_IEA
											,GARAN_ADIC_IPA
											,GARAN_ADIC_IPD
											FROM SEGUROS.CONDICOES_TECNICAS
											WHERE NUM_APOLICE = '{this.HISCONPA_NUM_APOLICE}'
											AND COD_SUBGRUPO = '{this.HISCONPA_COD_SUBGRUPO}'
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string CONDITEC_GARAN_ADIC_IEA { get; set; }
        public string CONDITEC_GARAN_ADIC_IPA { get; set; }
        public string CONDITEC_GARAN_ADIC_IPD { get; set; }
        public string HISCONPA_COD_SUBGRUPO { get; set; }
        public string HISCONPA_NUM_APOLICE { get; set; }

        public static R0330_00_SELECT_CONDITEC_DB_SELECT_1_Query1 Execute(R0330_00_SELECT_CONDITEC_DB_SELECT_1_Query1 r0330_00_SELECT_CONDITEC_DB_SELECT_1_Query1)
        {
            var ths = r0330_00_SELECT_CONDITEC_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0330_00_SELECT_CONDITEC_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0330_00_SELECT_CONDITEC_DB_SELECT_1_Query1();
            var i = 0;
            dta.CONDITEC_GARAN_ADIC_IEA = result[i++].Value?.ToString();
            dta.CONDITEC_GARAN_ADIC_IPA = result[i++].Value?.ToString();
            dta.CONDITEC_GARAN_ADIC_IPD = result[i++].Value?.ToString();
            return dta;
        }

    }
}