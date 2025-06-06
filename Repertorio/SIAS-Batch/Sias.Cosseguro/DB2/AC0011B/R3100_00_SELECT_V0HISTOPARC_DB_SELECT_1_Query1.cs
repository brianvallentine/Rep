using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0011B
{
    public class R3100_00_SELECT_V0HISTOPARC_DB_SELECT_1_Query1 : QueryBasis<R3100_00_SELECT_V0HISTOPARC_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_APOLICE,
            NRENDOS,
            NRPARCEL,
            OCORHIST,
            OPERACAO,
            DTMOVTO,
            PRM_TARIFARIO,
            VAL_DESCONTO,
            VLADIFRA,
            VLCUSEMI
            INTO :V3HISP-NUM-APOL,
            :V3HISP-NRENDOS,
            :V3HISP-NRPARCEL,
            :V3HISP-OCORHIST,
            :V3HISP-OPERACAO,
            :V3HISP-DTMOVTO,
            :V3HISP-PRM-TAR,
            :V3HISP-VAL-DES,
            :V3HISP-VLADIFRA,
            :V3HISP-VLCUSEMI
            FROM SEGUROS.V1HISTOPARC
            WHERE NUM_APOLICE = :V1HISP-NUM-APOL
            AND NRENDOS = :V1HISP-NRENDOS
            AND NRPARCEL = :V1HISP-NRPARCEL
            AND OCORHIST = 01
            AND OPERACAO < 0200
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_APOLICE
							,
											NRENDOS
							,
											NRPARCEL
							,
											OCORHIST
							,
											OPERACAO
							,
											DTMOVTO
							,
											PRM_TARIFARIO
							,
											VAL_DESCONTO
							,
											VLADIFRA
							,
											VLCUSEMI
											FROM SEGUROS.V1HISTOPARC
											WHERE NUM_APOLICE = '{this.V1HISP_NUM_APOL}'
											AND NRENDOS = '{this.V1HISP_NRENDOS}'
											AND NRPARCEL = '{this.V1HISP_NRPARCEL}'
											AND OCORHIST = 01
											AND OPERACAO < 0200";

            return query;
        }
        public string V3HISP_NUM_APOL { get; set; }
        public string V3HISP_NRENDOS { get; set; }
        public string V3HISP_NRPARCEL { get; set; }
        public string V3HISP_OCORHIST { get; set; }
        public string V3HISP_OPERACAO { get; set; }
        public string V3HISP_DTMOVTO { get; set; }
        public string V3HISP_PRM_TAR { get; set; }
        public string V3HISP_VAL_DES { get; set; }
        public string V3HISP_VLADIFRA { get; set; }
        public string V3HISP_VLCUSEMI { get; set; }
        public string V1HISP_NUM_APOL { get; set; }
        public string V1HISP_NRPARCEL { get; set; }
        public string V1HISP_NRENDOS { get; set; }

        public static R3100_00_SELECT_V0HISTOPARC_DB_SELECT_1_Query1 Execute(R3100_00_SELECT_V0HISTOPARC_DB_SELECT_1_Query1 r3100_00_SELECT_V0HISTOPARC_DB_SELECT_1_Query1)
        {
            var ths = r3100_00_SELECT_V0HISTOPARC_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3100_00_SELECT_V0HISTOPARC_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3100_00_SELECT_V0HISTOPARC_DB_SELECT_1_Query1();
            var i = 0;
            dta.V3HISP_NUM_APOL = result[i++].Value?.ToString();
            dta.V3HISP_NRENDOS = result[i++].Value?.ToString();
            dta.V3HISP_NRPARCEL = result[i++].Value?.ToString();
            dta.V3HISP_OCORHIST = result[i++].Value?.ToString();
            dta.V3HISP_OPERACAO = result[i++].Value?.ToString();
            dta.V3HISP_DTMOVTO = result[i++].Value?.ToString();
            dta.V3HISP_PRM_TAR = result[i++].Value?.ToString();
            dta.V3HISP_VAL_DES = result[i++].Value?.ToString();
            dta.V3HISP_VLADIFRA = result[i++].Value?.ToString();
            dta.V3HISP_VLCUSEMI = result[i++].Value?.ToString();
            return dta;
        }

    }
}