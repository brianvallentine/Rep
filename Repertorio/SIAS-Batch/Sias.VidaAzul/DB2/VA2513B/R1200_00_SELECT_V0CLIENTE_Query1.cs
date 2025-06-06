using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA2513B
{
    public class R1200_00_SELECT_V0CLIENTE_Query1 : QueryBasis<R1200_00_SELECT_V0CLIENTE_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NOME_RAZAO,
            CGCCPF,
            DATA_NASCIMENTO
            INTO :V0CLIE-NOME-RAZAO,
            :V0CLIE-CPF,
            :V0CLIE-DTNASC:V0CLIE-IDTNASC
            FROM SEGUROS.V0CLIENTE
            WHERE COD_CLIENTE = :V0HIST-CDCLIENTE
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NOME_RAZAO
							,
											CGCCPF
							,
											DATA_NASCIMENTO
											FROM SEGUROS.V0CLIENTE
											WHERE COD_CLIENTE = '{this.V0HIST_CDCLIENTE}'";

            return query;
        }
        public string V0CLIE_NOME_RAZAO { get; set; }
        public string V0CLIE_CPF { get; set; }
        public string V0CLIE_DTNASC { get; set; }
        public string V0CLIE_IDTNASC { get; set; }
        public string V0HIST_CDCLIENTE { get; set; }

        public static R1200_00_SELECT_V0CLIENTE_Query1 Execute(R1200_00_SELECT_V0CLIENTE_Query1 r1200_00_SELECT_V0CLIENTE_Query1)
        {
            var ths = r1200_00_SELECT_V0CLIENTE_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1200_00_SELECT_V0CLIENTE_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1200_00_SELECT_V0CLIENTE_Query1();
            var i = 0;
            dta.V0CLIE_NOME_RAZAO = result[i++].Value?.ToString();
            dta.V0CLIE_CPF = result[i++].Value?.ToString();
            dta.V0CLIE_DTNASC = result[i++].Value?.ToString();
            dta.V0CLIE_IDTNASC = string.IsNullOrWhiteSpace(dta.V0CLIE_DTNASC) ? "-1" : "0";
            return dta;
        }

    }
}