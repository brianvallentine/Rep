using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA1473B
{
    public class M_0100_PROCESSA_PROPOSTA_DB_SELECT_5_Query1 : QueryBasis<M_0100_PROCESSA_PROPOSTA_DB_SELECT_5_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT CGCCPF,
            NOME_RAZAO,
            DATA_NASCIMENTO
            INTO :CLIENTES-CGCCPF,
            :CLIENTES-NOME-RAZAO,
            :CLIENTES-DATA-NASCIMENTO:CLIENT-DTNASC-I
            FROM SEGUROS.CLIENTES
            WHERE COD_CLIENTE = :PROPOVA-COD-CLIENTE
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT CGCCPF
							,
											NOME_RAZAO
							,
											DATA_NASCIMENTO
											FROM SEGUROS.CLIENTES
											WHERE COD_CLIENTE = '{this.PROPOVA_COD_CLIENTE}'";

            return query;
        }
        public string CLIENTES_CGCCPF { get; set; }
        public string CLIENTES_NOME_RAZAO { get; set; }
        public string CLIENTES_DATA_NASCIMENTO { get; set; }
        public string CLIENT_DTNASC_I { get; set; }
        public string PROPOVA_COD_CLIENTE { get; set; }

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
            dta.CLIENTES_CGCCPF = result[i++].Value?.ToString();
            dta.CLIENTES_NOME_RAZAO = result[i++].Value?.ToString();
            dta.CLIENTES_DATA_NASCIMENTO = result[i++].Value?.ToString();
            dta.CLIENT_DTNASC_I = string.IsNullOrWhiteSpace(dta.CLIENTES_DATA_NASCIMENTO) ? "-1" : "0";
            return dta;
        }

    }
}