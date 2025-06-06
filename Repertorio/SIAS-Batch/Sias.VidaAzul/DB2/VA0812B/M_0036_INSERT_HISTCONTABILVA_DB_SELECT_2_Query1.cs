using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0812B
{
    public class M_0036_INSERT_HISTCONTABILVA_DB_SELECT_2_Query1 : QueryBasis<M_0036_INSERT_HISTCONTABILVA_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_NASCIMENTO ,
            CGCCPF
            INTO :CLIENTES-DATA-NASCIMENTO:VIND-DTNASC,
            :CLIENTES-CGCCPF
            FROM SEGUROS.CLIENTES
            WHERE COD_CLIENTE = :PROP-CODCLIEN
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_NASCIMENTO 
							,
											CGCCPF
											FROM SEGUROS.CLIENTES
											WHERE COD_CLIENTE = '{this.PROP_CODCLIEN}'
											WITH UR";

            return query;
        }
        public string CLIENTES_DATA_NASCIMENTO { get; set; }
        public string VIND_DTNASC { get; set; }
        public string CLIENTES_CGCCPF { get; set; }
        public string PROP_CODCLIEN { get; set; }

        public static M_0036_INSERT_HISTCONTABILVA_DB_SELECT_2_Query1 Execute(M_0036_INSERT_HISTCONTABILVA_DB_SELECT_2_Query1 m_0036_INSERT_HISTCONTABILVA_DB_SELECT_2_Query1)
        {
            var ths = m_0036_INSERT_HISTCONTABILVA_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0036_INSERT_HISTCONTABILVA_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0036_INSERT_HISTCONTABILVA_DB_SELECT_2_Query1();
            var i = 0;
            dta.CLIENTES_DATA_NASCIMENTO = result[i++].Value?.ToString();
            dta.VIND_DTNASC = string.IsNullOrWhiteSpace(dta.CLIENTES_DATA_NASCIMENTO) ? "-1" : "0";
            dta.CLIENTES_CGCCPF = result[i++].Value?.ToString();
            return dta;
        }

    }
}