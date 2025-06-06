using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.FederalVida.DB2.VF0813B
{
    public class M_1035_QUITA_PARCELA_DB_SELECT_1_Query1 : QueryBasis<M_1035_QUITA_PARCELA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(MAX(OCORRHISTCTA),0)
            INTO :V0HCTA-OCORHISTCTA
            FROM SEGUROS.V0HISTCONTAVA
            WHERE NRCERTIF = :V0HCTA-NRCERTIF
            AND NRPARCEL = :V0PARC-NRPARCEL
            AND VLPRMTOT = :V0CMPT-VLPRMDIF
            AND SITUACAO = '3'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(MAX(OCORRHISTCTA)
							,0)
											FROM SEGUROS.V0HISTCONTAVA
											WHERE NRCERTIF = '{this.V0HCTA_NRCERTIF}'
											AND NRPARCEL = '{this.V0PARC_NRPARCEL}'
											AND VLPRMTOT = '{this.V0CMPT_VLPRMDIF}'
											AND SITUACAO = '3'";

            return query;
        }
        public string V0HCTA_OCORHISTCTA { get; set; }
        public string V0HCTA_NRCERTIF { get; set; }
        public string V0PARC_NRPARCEL { get; set; }
        public string V0CMPT_VLPRMDIF { get; set; }

        public static M_1035_QUITA_PARCELA_DB_SELECT_1_Query1 Execute(M_1035_QUITA_PARCELA_DB_SELECT_1_Query1 m_1035_QUITA_PARCELA_DB_SELECT_1_Query1)
        {
            var ths = m_1035_QUITA_PARCELA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_1035_QUITA_PARCELA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_1035_QUITA_PARCELA_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0HCTA_OCORHISTCTA = result[i++].Value?.ToString();
            return dta;
        }

    }
}