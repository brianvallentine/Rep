using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0120B
{
    public class M_0220_200_ACESSA_CLIENTES_DB_SELECT_1_Query1 : QueryBasis<M_0220_200_ACESSA_CLIENTES_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT COD_CLIENTE ,
            NOME_RAZAO ,
            VALUE(CGCCPF, 0)
            INTO :WHOST-COD-CLI ,
            :WHOST-NOME-RAZAO,
            :WHOST-CGC-CPF
            FROM SEGUROS.V1CLIENTE
            WHERE COD_CLIENTE = :SEGURAVG-COD-CLI
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_CLIENTE 
							,
											NOME_RAZAO 
							,
											VALUE(CGCCPF
							, 0)
											FROM SEGUROS.V1CLIENTE
											WHERE COD_CLIENTE = '{this.SEGURAVG_COD_CLI}'";

            return query;
        }
        public string WHOST_COD_CLI { get; set; }
        public string WHOST_NOME_RAZAO { get; set; }
        public string WHOST_CGC_CPF { get; set; }
        public string SEGURAVG_COD_CLI { get; set; }

        public static M_0220_200_ACESSA_CLIENTES_DB_SELECT_1_Query1 Execute(M_0220_200_ACESSA_CLIENTES_DB_SELECT_1_Query1 m_0220_200_ACESSA_CLIENTES_DB_SELECT_1_Query1)
        {
            var ths = m_0220_200_ACESSA_CLIENTES_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0220_200_ACESSA_CLIENTES_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0220_200_ACESSA_CLIENTES_DB_SELECT_1_Query1();
            var i = 0;
            dta.WHOST_COD_CLI = result[i++].Value?.ToString();
            dta.WHOST_NOME_RAZAO = result[i++].Value?.ToString();
            dta.WHOST_CGC_CPF = result[i++].Value?.ToString();
            return dta;
        }

    }
}