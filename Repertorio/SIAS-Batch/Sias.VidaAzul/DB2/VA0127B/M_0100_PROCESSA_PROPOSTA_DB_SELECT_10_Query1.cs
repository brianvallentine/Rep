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
    public class M_0100_PROCESSA_PROPOSTA_DB_SELECT_10_Query1 : QueryBasis<M_0100_PROCESSA_PROPOSTA_DB_SELECT_10_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            VALUE(MAX(OCORR_HISTORICO),0)
            INTO
            :HISCOBPR-OCORR-HISTORICO
            FROM SEGUROS.HIS_COBER_PROPOST
            WHERE NUM_CERTIFICADO = :PROPVA-NRCERTIF
            AND DATA_INIVIGENCIA
            BETWEEN :WS-DATA-INI AND :WS-DATA-FIM
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											VALUE(MAX(OCORR_HISTORICO)
							,0)
											FROM SEGUROS.HIS_COBER_PROPOST
											WHERE NUM_CERTIFICADO = '{this.PROPVA_NRCERTIF}'
											AND DATA_INIVIGENCIA
											BETWEEN '{this.WS_DATA_INI}' AND '{this.WS_DATA_FIM}'";

            return query;
        }
        public string HISCOBPR_OCORR_HISTORICO { get; set; }
        public string PROPVA_NRCERTIF { get; set; }
        public string WS_DATA_INI { get; set; }
        public string WS_DATA_FIM { get; set; }

        public static M_0100_PROCESSA_PROPOSTA_DB_SELECT_10_Query1 Execute(M_0100_PROCESSA_PROPOSTA_DB_SELECT_10_Query1 m_0100_PROCESSA_PROPOSTA_DB_SELECT_10_Query1)
        {
            var ths = m_0100_PROCESSA_PROPOSTA_DB_SELECT_10_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0100_PROCESSA_PROPOSTA_DB_SELECT_10_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0100_PROCESSA_PROPOSTA_DB_SELECT_10_Query1();
            var i = 0;
            dta.HISCOBPR_OCORR_HISTORICO = result[i++].Value?.ToString();
            return dta;
        }

    }
}