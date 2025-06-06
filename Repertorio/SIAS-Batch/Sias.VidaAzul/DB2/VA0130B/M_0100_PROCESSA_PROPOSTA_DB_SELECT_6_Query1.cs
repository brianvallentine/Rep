using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0130B
{
    public class M_0100_PROCESSA_PROPOSTA_DB_SELECT_6_Query1 : QueryBasis<M_0100_PROCESSA_PROPOSTA_DB_SELECT_6_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_NASCIMENTO
            INTO :CLIENT-DTNASC:CLIENT-DTNASC-I
            FROM SEGUROS.V0CLIENTE
            WHERE COD_CLIENTE = :PROPVA-CODCLIEN
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_NASCIMENTO
											FROM SEGUROS.V0CLIENTE
											WHERE COD_CLIENTE = '{this.PROPVA_CODCLIEN}'
											WITH UR";

            return query;
        }
        public string CLIENT_DTNASC { get; set; }
        public string CLIENT_DTNASC_I { get; set; }
        public string PROPVA_CODCLIEN { get; set; }

        public static M_0100_PROCESSA_PROPOSTA_DB_SELECT_6_Query1 Execute(M_0100_PROCESSA_PROPOSTA_DB_SELECT_6_Query1 m_0100_PROCESSA_PROPOSTA_DB_SELECT_6_Query1)
        {
            var ths = m_0100_PROCESSA_PROPOSTA_DB_SELECT_6_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0100_PROCESSA_PROPOSTA_DB_SELECT_6_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0100_PROCESSA_PROPOSTA_DB_SELECT_6_Query1();
            var i = 0;
            dta.CLIENT_DTNASC = result[i++].Value?.ToString();
            dta.CLIENT_DTNASC_I = string.IsNullOrWhiteSpace(dta.CLIENT_DTNASC) ? "-1" : "0";
            return dta;
        }

    }
}