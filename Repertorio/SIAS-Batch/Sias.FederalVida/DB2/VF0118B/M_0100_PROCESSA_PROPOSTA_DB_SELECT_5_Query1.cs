using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.FederalVida.DB2.VF0118B
{
    public class M_0100_PROCESSA_PROPOSTA_DB_SELECT_5_Query1 : QueryBasis<M_0100_PROCESSA_PROPOSTA_DB_SELECT_5_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NRTIT,
            PRMTOTPGO,
            PRMVGPGO,
            PRMAPPGO
            INTO :PROPVF-NRTIT,
            :PROPVF-PRMTOTPGO,
            :PROPVF-PRMVGPGO,
            :PROPVF-PRMAPPGO
            FROM SEGUROS.V0PROPOSTAVF
            WHERE NRCERTIF = :PROPVA-NRCERTIF
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NRTIT
							,
											PRMTOTPGO
							,
											PRMVGPGO
							,
											PRMAPPGO
											FROM SEGUROS.V0PROPOSTAVF
											WHERE NRCERTIF = '{this.PROPVA_NRCERTIF}'";

            return query;
        }
        public string PROPVF_NRTIT { get; set; }
        public string PROPVF_PRMTOTPGO { get; set; }
        public string PROPVF_PRMVGPGO { get; set; }
        public string PROPVF_PRMAPPGO { get; set; }
        public string PROPVA_NRCERTIF { get; set; }

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
            dta.PROPVF_NRTIT = result[i++].Value?.ToString();
            dta.PROPVF_PRMTOTPGO = result[i++].Value?.ToString();
            dta.PROPVF_PRMVGPGO = result[i++].Value?.ToString();
            dta.PROPVF_PRMAPPGO = result[i++].Value?.ToString();
            return dta;
        }

    }
}