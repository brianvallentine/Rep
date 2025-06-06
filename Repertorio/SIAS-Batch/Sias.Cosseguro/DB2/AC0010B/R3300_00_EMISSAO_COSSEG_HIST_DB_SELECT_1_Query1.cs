using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0010B
{
    public class R3300_00_EMISSAO_COSSEG_HIST_DB_SELECT_1_Query1 : QueryBasis<R3300_00_EMISSAO_COSSEG_HIST_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT PRM_TARIFARIO,
            VAL_DESCONTO,
            VLADIFRA,
            VLCOMIS
            INTO :V3CHIS-PRM-TAR,
            :V3CHIS-VAL-DES,
            :V3CHIS-VLADIFRA,
            :V3CHIS-VLCOMIS
            FROM SEGUROS.V1COSSEG_HISTPRE
            WHERE CONGENER = :V1APCD-CODCOSS
            AND NUM_APOLICE = :V1HISP-NUM-APOL
            AND NRENDOS = :V1HISP-NRENDOS
            AND NRPARCEL = :V1HISP-NRPARCEL
            AND OCORHIST = 01
            AND OPERACAO < 0200
            AND TIPSGU = '1'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT PRM_TARIFARIO
							,
											VAL_DESCONTO
							,
											VLADIFRA
							,
											VLCOMIS
											FROM SEGUROS.V1COSSEG_HISTPRE
											WHERE CONGENER = '{this.V1APCD_CODCOSS}'
											AND NUM_APOLICE = '{this.V1HISP_NUM_APOL}'
											AND NRENDOS = '{this.V1HISP_NRENDOS}'
											AND NRPARCEL = '{this.V1HISP_NRPARCEL}'
											AND OCORHIST = 01
											AND OPERACAO < 0200
											AND TIPSGU = '1'";

            return query;
        }
        public string V3CHIS_PRM_TAR { get; set; }
        public string V3CHIS_VAL_DES { get; set; }
        public string V3CHIS_VLADIFRA { get; set; }
        public string V3CHIS_VLCOMIS { get; set; }
        public string V1HISP_NUM_APOL { get; set; }
        public string V1HISP_NRPARCEL { get; set; }
        public string V1APCD_CODCOSS { get; set; }
        public string V1HISP_NRENDOS { get; set; }

        public static R3300_00_EMISSAO_COSSEG_HIST_DB_SELECT_1_Query1 Execute(R3300_00_EMISSAO_COSSEG_HIST_DB_SELECT_1_Query1 r3300_00_EMISSAO_COSSEG_HIST_DB_SELECT_1_Query1)
        {
            var ths = r3300_00_EMISSAO_COSSEG_HIST_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3300_00_EMISSAO_COSSEG_HIST_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3300_00_EMISSAO_COSSEG_HIST_DB_SELECT_1_Query1();
            var i = 0;
            dta.V3CHIS_PRM_TAR = result[i++].Value?.ToString();
            dta.V3CHIS_VAL_DES = result[i++].Value?.ToString();
            dta.V3CHIS_VLADIFRA = result[i++].Value?.ToString();
            dta.V3CHIS_VLCOMIS = result[i++].Value?.ToString();
            return dta;
        }

    }
}