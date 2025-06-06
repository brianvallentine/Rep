using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0120B
{
    public class R3100_00_ACUMULA_PREMIOS_DB_SELECT_1_Query1 : QueryBasis<R3100_00_ACUMULA_PREMIOS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT PRM_TARIFARIO ,
            VAL_DESCONTO ,
            VLPRMLIQ ,
            VLADIFRA ,
            VLCUSEMI ,
            VLIOCC ,
            VLPRMTOT ,
            VLPREMIO
            INTO :WP-PRM-TAR ,
            :WP-VAL-DESC ,
            :WP-VLPRMLIQ ,
            :WP-VLADIFRA ,
            :WP-VLCUSEMI ,
            :WP-VLIOCC ,
            :WP-VLPRMTOT ,
            :WP-VLPREMIO
            FROM SEGUROS.V1HISTOPARC
            WHERE NUM_APOLICE = :V1PARC-NUM-APOL
            AND NRENDOS = :V1PARC-NRENDOS
            AND NRPARCEL = :V0HISP-NRPARCEL
            AND OPERACAO = 0101
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT PRM_TARIFARIO 
							,
											VAL_DESCONTO 
							,
											VLPRMLIQ 
							,
											VLADIFRA 
							,
											VLCUSEMI 
							,
											VLIOCC 
							,
											VLPRMTOT 
							,
											VLPREMIO
											FROM SEGUROS.V1HISTOPARC
											WHERE NUM_APOLICE = '{this.V1PARC_NUM_APOL}'
											AND NRENDOS = '{this.V1PARC_NRENDOS}'
											AND NRPARCEL = '{this.V0HISP_NRPARCEL}'
											AND OPERACAO = 0101";

            return query;
        }
        public string WP_PRM_TAR { get; set; }
        public string WP_VAL_DESC { get; set; }
        public string WP_VLPRMLIQ { get; set; }
        public string WP_VLADIFRA { get; set; }
        public string WP_VLCUSEMI { get; set; }
        public string WP_VLIOCC { get; set; }
        public string WP_VLPRMTOT { get; set; }
        public string WP_VLPREMIO { get; set; }
        public string V1PARC_NUM_APOL { get; set; }
        public string V0HISP_NRPARCEL { get; set; }
        public string V1PARC_NRENDOS { get; set; }

        public static R3100_00_ACUMULA_PREMIOS_DB_SELECT_1_Query1 Execute(R3100_00_ACUMULA_PREMIOS_DB_SELECT_1_Query1 r3100_00_ACUMULA_PREMIOS_DB_SELECT_1_Query1)
        {
            var ths = r3100_00_ACUMULA_PREMIOS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3100_00_ACUMULA_PREMIOS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3100_00_ACUMULA_PREMIOS_DB_SELECT_1_Query1();
            var i = 0;
            dta.WP_PRM_TAR = result[i++].Value?.ToString();
            dta.WP_VAL_DESC = result[i++].Value?.ToString();
            dta.WP_VLPRMLIQ = result[i++].Value?.ToString();
            dta.WP_VLADIFRA = result[i++].Value?.ToString();
            dta.WP_VLCUSEMI = result[i++].Value?.ToString();
            dta.WP_VLIOCC = result[i++].Value?.ToString();
            dta.WP_VLPRMTOT = result[i++].Value?.ToString();
            dta.WP_VLPREMIO = result[i++].Value?.ToString();
            return dta;
        }

    }
}