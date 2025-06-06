using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0127B
{
    public class M_0100_PROCESSA_PROPOSTA_DB_SELECT_5_Query1 : QueryBasis<M_0100_PROCESSA_PROPOSTA_DB_SELECT_5_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            NRPARCEL, DTVENCTO
            INTO
            :V0PARC-NRPARCEL, :V0PARC-DTVENCTO
            FROM
            SEGUROS.V0PARCELVA
            WHERE
            NRCERTIF = :PROPVA-NRCERTIF
            AND DTVENCTO BETWEEN :WS-DATA-INI AND :WS-DATA-FIM
            AND SITUACAO IN ( '0' , '1' , ' ' )
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											NRPARCEL
							, DTVENCTO
											FROM
											SEGUROS.V0PARCELVA
											WHERE
											NRCERTIF = '{this.PROPVA_NRCERTIF}'
											AND DTVENCTO BETWEEN '{this.WS_DATA_INI}' AND '{this.WS_DATA_FIM}'
											AND SITUACAO IN ( '0' 
							, '1' 
							, ' ' )";

            return query;
        }
        public string V0PARC_NRPARCEL { get; set; }
        public string V0PARC_DTVENCTO { get; set; }
        public string PROPVA_NRCERTIF { get; set; }
        public string WS_DATA_INI { get; set; }
        public string WS_DATA_FIM { get; set; }

        public static M_0100_PROCESSA_PROPOSTA_DB_SELECT_5_Query1 Execute(M_0100_PROCESSA_PROPOSTA_DB_SELECT_5_Query1 m_0100_PROCESSA_PROPOSTA_DB_SELECT_5_Query1)
        {
            var ths = m_0100_PROCESSA_PROPOSTA_DB_SELECT_5_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0100_PROCESSA_PROPOSTA_DB_SELECT_5_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0100_PROCESSA_PROPOSTA_DB_SELECT_5_Query1();
            var i = 0;
            dta.V0PARC_NRPARCEL = result[i++].Value?.ToString();
            dta.V0PARC_DTVENCTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}