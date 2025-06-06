using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA3437B
{
    public class R1800_00_SELECT_CONDITEC_DB_SELECT_1_Query1 : QueryBasis<R1800_00_SELECT_CONDITEC_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT CARREGA_CONJUGE,
            GARAN_ADIC_IEA,
            GARAN_ADIC_IPA,
            GARAN_ADIC_IPD,
            GARAN_ADIC_HD
            INTO :CONDITEC-CARREGA-CONJUGE,
            :CONDITEC-GARAN-ADIC-IEA,
            :CONDITEC-GARAN-ADIC-IPA,
            :CONDITEC-GARAN-ADIC-IPD,
            :CONDITEC-GARAN-ADIC-HD
            FROM SEGUROS.CONDICOES_TECNICAS
            WHERE NUM_APOLICE =
            :WHOST-NRAPOLICE
            AND COD_SUBGRUPO =
            :WHOST-CODSUBES
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT CARREGA_CONJUGE
							,
											GARAN_ADIC_IEA
							,
											GARAN_ADIC_IPA
							,
											GARAN_ADIC_IPD
							,
											GARAN_ADIC_HD
											FROM SEGUROS.CONDICOES_TECNICAS
											WHERE NUM_APOLICE =
											'{this.WHOST_NRAPOLICE}'
											AND COD_SUBGRUPO =
											'{this.WHOST_CODSUBES}'
											WITH UR";

            return query;
        }
        public string CONDITEC_CARREGA_CONJUGE { get; set; }
        public string CONDITEC_GARAN_ADIC_IEA { get; set; }
        public string CONDITEC_GARAN_ADIC_IPA { get; set; }
        public string CONDITEC_GARAN_ADIC_IPD { get; set; }
        public string CONDITEC_GARAN_ADIC_HD { get; set; }
        public string WHOST_NRAPOLICE { get; set; }
        public string WHOST_CODSUBES { get; set; }

        public static R1800_00_SELECT_CONDITEC_DB_SELECT_1_Query1 Execute(R1800_00_SELECT_CONDITEC_DB_SELECT_1_Query1 r1800_00_SELECT_CONDITEC_DB_SELECT_1_Query1)
        {
            var ths = r1800_00_SELECT_CONDITEC_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1800_00_SELECT_CONDITEC_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1800_00_SELECT_CONDITEC_DB_SELECT_1_Query1();
            var i = 0;
            dta.CONDITEC_CARREGA_CONJUGE = result[i++].Value?.ToString();
            dta.CONDITEC_GARAN_ADIC_IEA = result[i++].Value?.ToString();
            dta.CONDITEC_GARAN_ADIC_IPA = result[i++].Value?.ToString();
            dta.CONDITEC_GARAN_ADIC_IPD = result[i++].Value?.ToString();
            dta.CONDITEC_GARAN_ADIC_HD = result[i++].Value?.ToString();
            return dta;
        }

    }
}