using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0128B
{
    public class M_0100_PROCESSA_PROPOSTA_DB_SELECT_2_Query1 : QueryBasis<M_0100_PROCESSA_PROPOSTA_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(COUNT(*),0)
            INTO :MOVTO-LIDOS
            FROM SEGUROS.V0MOVIMENTO
            WHERE
            DATA_AVERBACAO IS NOT NULL AND
            DATA_INCLUSAO IS NULL AND
            NUM_CERTIFICADO = :PROPVA-NRCERTIF
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(COUNT(*)
							,0)
											FROM SEGUROS.V0MOVIMENTO
											WHERE
											DATA_AVERBACAO IS NOT NULL AND
											DATA_INCLUSAO IS NULL AND
											NUM_CERTIFICADO = '{this.PROPVA_NRCERTIF}'";

            return query;
        }
        public string MOVTO_LIDOS { get; set; }
        public string PROPVA_NRCERTIF { get; set; }

        public static M_0100_PROCESSA_PROPOSTA_DB_SELECT_2_Query1 Execute(M_0100_PROCESSA_PROPOSTA_DB_SELECT_2_Query1 m_0100_PROCESSA_PROPOSTA_DB_SELECT_2_Query1)
        {
            var ths = m_0100_PROCESSA_PROPOSTA_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0100_PROCESSA_PROPOSTA_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0100_PROCESSA_PROPOSTA_DB_SELECT_2_Query1();
            var i = 0;
            dta.MOVTO_LIDOS = result[i++].Value?.ToString();
            return dta;
        }

    }
}