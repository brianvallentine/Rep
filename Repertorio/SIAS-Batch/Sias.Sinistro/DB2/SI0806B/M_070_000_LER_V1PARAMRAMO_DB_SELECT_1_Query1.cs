using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0806B
{
    public class M_070_000_LER_V1PARAMRAMO_DB_SELECT_1_Query1 : QueryBasis<M_070_000_LER_V1PARAMRAMO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT RAMO_VGAPC, RAMO_VG, RAMO_AP,
            RAMO_SAUDE, RAMO_EDUCACAO
            INTO :PARAM-RAMO-VGAPC, :PARAM-RAMO-VG, :PARAM-RAMO-AP,
            :PARAM-RAMO-SAUDE, :PARAM-RAMO-EDUCACAO
            FROM SEGUROS.V1PARAMRAMO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT RAMO_VGAPC
							, RAMO_VG
							, RAMO_AP
							,
											RAMO_SAUDE
							, RAMO_EDUCACAO
											FROM SEGUROS.V1PARAMRAMO";

            return query;
        }
        public string PARAM_RAMO_VGAPC { get; set; }
        public string PARAM_RAMO_VG { get; set; }
        public string PARAM_RAMO_AP { get; set; }
        public string PARAM_RAMO_SAUDE { get; set; }
        public string PARAM_RAMO_EDUCACAO { get; set; }

        public static M_070_000_LER_V1PARAMRAMO_DB_SELECT_1_Query1 Execute(M_070_000_LER_V1PARAMRAMO_DB_SELECT_1_Query1 m_070_000_LER_V1PARAMRAMO_DB_SELECT_1_Query1)
        {
            var ths = m_070_000_LER_V1PARAMRAMO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_070_000_LER_V1PARAMRAMO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_070_000_LER_V1PARAMRAMO_DB_SELECT_1_Query1();
            var i = 0;
            dta.PARAM_RAMO_VGAPC = result[i++].Value?.ToString();
            dta.PARAM_RAMO_VG = result[i++].Value?.ToString();
            dta.PARAM_RAMO_AP = result[i++].Value?.ToString();
            dta.PARAM_RAMO_SAUDE = result[i++].Value?.ToString();
            dta.PARAM_RAMO_EDUCACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}