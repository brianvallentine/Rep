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
    public class M_0100_PROCESSA_PROPOSTA_DB_SELECT_2_Query1 : QueryBasis<M_0100_PROCESSA_PROPOSTA_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_SEGURO
            INTO :V0CONV-CODCONV
            FROM SEGUROS.V0CONVSICOV
            WHERE CODPRODU = :PROPVA-CODPRODU
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT COD_SEGURO
											FROM SEGUROS.V0CONVSICOV
											WHERE CODPRODU = '{this.PROPVA_CODPRODU}'";

            return query;
        }
        public string V0CONV_CODCONV { get; set; }
        public string PROPVA_CODPRODU { get; set; }

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
            dta.V0CONV_CODCONV = result[i++].Value?.ToString();
            return dta;
        }

    }
}