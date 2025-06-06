using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP0121B
{
    public class M_0100_PROCESSA_PROPOSTA_DB_SELECT_5_Query1 : QueryBasis<M_0100_PROCESSA_PROPOSTA_DB_SELECT_5_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_PROPOSTA
            INTO :PROPVA-NRPROPOS:PROPVA-INRPROPOS
            FROM SEGUROS.V0MOVIMENTO
            WHERE COD_FONTE = :PROPVA-FONTE
            AND NUM_PROPOSTA = :PROPVA-NRPROPOS
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT NUM_PROPOSTA
											FROM SEGUROS.V0MOVIMENTO
											WHERE COD_FONTE = '{this.PROPVA_FONTE}'
											AND NUM_PROPOSTA = '{this.PROPVA_NRPROPOS}'";

            return query;
        }
        public string PROPVA_NRPROPOS { get; set; }
        public string PROPVA_INRPROPOS { get; set; }
        public string PROPVA_FONTE { get; set; }

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
            dta.PROPVA_NRPROPOS = result[i++].Value?.ToString();
            dta.PROPVA_INRPROPOS = string.IsNullOrWhiteSpace(dta.PROPVA_NRPROPOS) ? "-1" : "0";
            return dta;
        }

    }
}