using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0078B
{
    public class M_400_SELECT_SINISTRO_HAB_DB_SELECT_1_Query1 : QueryBasis<M_400_SELECT_SINISTRO_HAB_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_CONTRATO,
            COD_COBERTURA,
            NOME_SEGURADO
            INTO :V0HAB01-NUM-CONTRATO,
            :V0HAB01-COD-COBERTURA,
            :V0HAB01-NOME-SEGURADO
            FROM SEGUROS.V0SINISTRO_HABIT01
            WHERE NUM_APOL_SINISTRO =
            :V0HISTSINI-NUM-APOL-SINISTRO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_CONTRATO
							,
											COD_COBERTURA
							,
											NOME_SEGURADO
											FROM SEGUROS.V0SINISTRO_HABIT01
											WHERE NUM_APOL_SINISTRO =
											'{this.V0HISTSINI_NUM_APOL_SINISTRO}'";

            return query;
        }
        public string V0HAB01_NUM_CONTRATO { get; set; }
        public string V0HAB01_COD_COBERTURA { get; set; }
        public string V0HAB01_NOME_SEGURADO { get; set; }
        public string V0HISTSINI_NUM_APOL_SINISTRO { get; set; }

        public static M_400_SELECT_SINISTRO_HAB_DB_SELECT_1_Query1 Execute(M_400_SELECT_SINISTRO_HAB_DB_SELECT_1_Query1 m_400_SELECT_SINISTRO_HAB_DB_SELECT_1_Query1)
        {
            var ths = m_400_SELECT_SINISTRO_HAB_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_400_SELECT_SINISTRO_HAB_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_400_SELECT_SINISTRO_HAB_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0HAB01_NUM_CONTRATO = result[i++].Value?.ToString();
            dta.V0HAB01_COD_COBERTURA = result[i++].Value?.ToString();
            dta.V0HAB01_NOME_SEGURADO = result[i++].Value?.ToString();
            return dta;
        }

    }
}