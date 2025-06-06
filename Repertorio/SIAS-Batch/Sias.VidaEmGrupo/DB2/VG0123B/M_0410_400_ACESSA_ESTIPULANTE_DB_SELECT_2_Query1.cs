using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0123B
{
    public class M_0410_400_ACESSA_ESTIPULANTE_DB_SELECT_2_Query1 : QueryBasis<M_0410_400_ACESSA_ESTIPULANTE_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT COD_CLIENTE ,
            NOME_RAZAO ,
            CGCCPF
            INTO :CLIENTE-COD-CLI ,
            :CLIENTE-NOME-RAZAO,
            :CLIENTE-CGC-CPF
            FROM SEGUROS.V1CLIENTE
            WHERE COD_CLIENTE = :SUBGRUPO-COD-CLI
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_CLIENTE 
							,
											NOME_RAZAO 
							,
											CGCCPF
											FROM SEGUROS.V1CLIENTE
											WHERE COD_CLIENTE = '{this.SUBGRUPO_COD_CLI}'";

            return query;
        }
        public string CLIENTE_COD_CLI { get; set; }
        public string CLIENTE_NOME_RAZAO { get; set; }
        public string CLIENTE_CGC_CPF { get; set; }
        public string SUBGRUPO_COD_CLI { get; set; }

        public static M_0410_400_ACESSA_ESTIPULANTE_DB_SELECT_2_Query1 Execute(M_0410_400_ACESSA_ESTIPULANTE_DB_SELECT_2_Query1 m_0410_400_ACESSA_ESTIPULANTE_DB_SELECT_2_Query1)
        {
            var ths = m_0410_400_ACESSA_ESTIPULANTE_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0410_400_ACESSA_ESTIPULANTE_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0410_400_ACESSA_ESTIPULANTE_DB_SELECT_2_Query1();
            var i = 0;
            dta.CLIENTE_COD_CLI = result[i++].Value?.ToString();
            dta.CLIENTE_NOME_RAZAO = result[i++].Value?.ToString();
            dta.CLIENTE_CGC_CPF = result[i++].Value?.ToString();
            return dta;
        }

    }
}