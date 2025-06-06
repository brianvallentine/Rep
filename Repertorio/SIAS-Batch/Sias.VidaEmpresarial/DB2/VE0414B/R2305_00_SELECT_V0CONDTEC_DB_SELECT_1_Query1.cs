using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE0414B
{
    public class R2305_00_SELECT_V0CONDTEC_DB_SELECT_1_Query1 : QueryBasis<R2305_00_SELECT_V0CONDTEC_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT CARREGA_CONJUGE,
            CARREGA_FILHOS,
            GARAN_ADIC_IEA,
            GARAN_ADIC_IPA,
            GARAN_ADIC_IPD
            INTO :CONDITEC-CARREGA-CONJUGE,
            :CONDITEC-CARREGA-FILHOS,
            :CONDITEC-GARAN-ADIC-IEA,
            :CONDITEC-GARAN-ADIC-IPA,
            :CONDITEC-GARAN-ADIC-IPD
            FROM SEGUROS.CONDICOES_TECNICAS
            WHERE NUM_APOLICE =
            :RELATORI-NUM-APOLICE
            AND COD_SUBGRUPO =
            :RELATORI-COD-SUBGRUPO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT CARREGA_CONJUGE
							,
											CARREGA_FILHOS
							,
											GARAN_ADIC_IEA
							,
											GARAN_ADIC_IPA
							,
											GARAN_ADIC_IPD
											FROM SEGUROS.CONDICOES_TECNICAS
											WHERE NUM_APOLICE =
											'{this.RELATORI_NUM_APOLICE}'
											AND COD_SUBGRUPO =
											'{this.RELATORI_COD_SUBGRUPO}'";

            return query;
        }
        public string CONDITEC_CARREGA_CONJUGE { get; set; }
        public string CONDITEC_CARREGA_FILHOS { get; set; }
        public string CONDITEC_GARAN_ADIC_IEA { get; set; }
        public string CONDITEC_GARAN_ADIC_IPA { get; set; }
        public string CONDITEC_GARAN_ADIC_IPD { get; set; }
        public string RELATORI_COD_SUBGRUPO { get; set; }
        public string RELATORI_NUM_APOLICE { get; set; }

        public static R2305_00_SELECT_V0CONDTEC_DB_SELECT_1_Query1 Execute(R2305_00_SELECT_V0CONDTEC_DB_SELECT_1_Query1 r2305_00_SELECT_V0CONDTEC_DB_SELECT_1_Query1)
        {
            var ths = r2305_00_SELECT_V0CONDTEC_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2305_00_SELECT_V0CONDTEC_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2305_00_SELECT_V0CONDTEC_DB_SELECT_1_Query1();
            var i = 0;
            dta.CONDITEC_CARREGA_CONJUGE = result[i++].Value?.ToString();
            dta.CONDITEC_CARREGA_FILHOS = result[i++].Value?.ToString();
            dta.CONDITEC_GARAN_ADIC_IEA = result[i++].Value?.ToString();
            dta.CONDITEC_GARAN_ADIC_IPA = result[i++].Value?.ToString();
            dta.CONDITEC_GARAN_ADIC_IPD = result[i++].Value?.ToString();
            return dta;
        }

    }
}