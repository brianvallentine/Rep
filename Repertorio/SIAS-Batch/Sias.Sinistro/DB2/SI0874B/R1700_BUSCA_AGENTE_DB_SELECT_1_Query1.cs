using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0874B
{
    public class R1700_BUSCA_AGENTE_DB_SELECT_1_Query1 : QueryBasis<R1700_BUSCA_AGENTE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_SUBESTIP_EMIS, COD_AGENTE_EMIS
            INTO :SIEPEMHB-COD-SUBESTIP-EMIS,
            :SIEPEMHB-COD-AGENTE-EMIS
            FROM SEGUROS.SI_ESTIP_EMIS_HAB
            WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO
            AND OCORR_HISTORICO = :SINISHIS-OCORR-HISTORICO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_SUBESTIP_EMIS
							, COD_AGENTE_EMIS
											FROM SEGUROS.SI_ESTIP_EMIS_HAB
											WHERE NUM_APOL_SINISTRO = '{this.SINISHIS_NUM_APOL_SINISTRO}'
											AND OCORR_HISTORICO = '{this.SINISHIS_OCORR_HISTORICO}'
											WITH UR";

            return query;
        }
        public string SIEPEMHB_COD_SUBESTIP_EMIS { get; set; }
        public string SIEPEMHB_COD_AGENTE_EMIS { get; set; }
        public string SINISHIS_NUM_APOL_SINISTRO { get; set; }
        public string SINISHIS_OCORR_HISTORICO { get; set; }

        public static R1700_BUSCA_AGENTE_DB_SELECT_1_Query1 Execute(R1700_BUSCA_AGENTE_DB_SELECT_1_Query1 r1700_BUSCA_AGENTE_DB_SELECT_1_Query1)
        {
            var ths = r1700_BUSCA_AGENTE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1700_BUSCA_AGENTE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1700_BUSCA_AGENTE_DB_SELECT_1_Query1();
            var i = 0;
            dta.SIEPEMHB_COD_SUBESTIP_EMIS = result[i++].Value?.ToString();
            dta.SIEPEMHB_COD_AGENTE_EMIS = result[i++].Value?.ToString();
            return dta;
        }

    }
}