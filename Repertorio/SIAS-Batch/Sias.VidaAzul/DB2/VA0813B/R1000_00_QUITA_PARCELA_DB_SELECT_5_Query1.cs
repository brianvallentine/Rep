using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0813B
{
    public class R1000_00_QUITA_PARCELA_DB_SELECT_5_Query1 : QueryBasis<R1000_00_QUITA_PARCELA_DB_SELECT_5_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_NASCIMENTO,
            CGCCPF,
            TIPO_PESSOA
            INTO :CLIENTES-DATA-NASCIMENTO :VIND-DATSEL,
            :CLIENTES-CGCCPF,
            :CLIENTES-TIPO-PESSOA
            FROM SEGUROS.CLIENTES
            WHERE COD_CLIENTE = :V0PROP-CODCLIEN
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_NASCIMENTO
							,
											CGCCPF
							,
											TIPO_PESSOA
											FROM SEGUROS.CLIENTES
											WHERE COD_CLIENTE = '{this.V0PROP_CODCLIEN}'
											WITH UR";

            return query;
        }
        public string CLIENTES_DATA_NASCIMENTO { get; set; }
        public string VIND_DATSEL { get; set; }
        public string CLIENTES_CGCCPF { get; set; }
        public string CLIENTES_TIPO_PESSOA { get; set; }
        public string V0PROP_CODCLIEN { get; set; }

        public static R1000_00_QUITA_PARCELA_DB_SELECT_5_Query1 Execute(R1000_00_QUITA_PARCELA_DB_SELECT_5_Query1 r1000_00_QUITA_PARCELA_DB_SELECT_5_Query1)
        {
            var ths = r1000_00_QUITA_PARCELA_DB_SELECT_5_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1000_00_QUITA_PARCELA_DB_SELECT_5_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1000_00_QUITA_PARCELA_DB_SELECT_5_Query1();
            var i = 0;
            dta.CLIENTES_DATA_NASCIMENTO = result[i++].Value?.ToString();
            dta.VIND_DATSEL = string.IsNullOrWhiteSpace(dta.CLIENTES_DATA_NASCIMENTO) ? "-1" : "0";
            dta.CLIENTES_CGCCPF = result[i++].Value?.ToString();
            dta.CLIENTES_TIPO_PESSOA = result[i++].Value?.ToString();
            return dta;
        }

    }
}