using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI7028B
{
    public class R2250_00_SELECT_ESTIP_DB_SELECT_1_Query1 : QueryBasis<R2250_00_SELECT_ESTIP_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT B.NOME_RAZAO,
            B.CGCCPF,
            B.TIPO_PESSOA
            INTO :CLIENTES-NOME-RAZAO,
            :CLIENTES-CGCCPF,
            :CLIENTES-TIPO-PESSOA
            FROM SEGUROS.APOLICES A,
            SEGUROS.CLIENTES B
            WHERE A.NUM_APOLICE = :WS-NUM-APOLICE
            AND B.COD_CLIENTE = A.COD_CLIENTE
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT B.NOME_RAZAO
							,
											B.CGCCPF
							,
											B.TIPO_PESSOA
											FROM SEGUROS.APOLICES A
							,
											SEGUROS.CLIENTES B
											WHERE A.NUM_APOLICE = '{this.WS_NUM_APOLICE}'
											AND B.COD_CLIENTE = A.COD_CLIENTE";

            return query;
        }
        public string CLIENTES_NOME_RAZAO { get; set; }
        public string CLIENTES_CGCCPF { get; set; }
        public string CLIENTES_TIPO_PESSOA { get; set; }
        public string WS_NUM_APOLICE { get; set; }

        public static R2250_00_SELECT_ESTIP_DB_SELECT_1_Query1 Execute(R2250_00_SELECT_ESTIP_DB_SELECT_1_Query1 r2250_00_SELECT_ESTIP_DB_SELECT_1_Query1)
        {
            var ths = r2250_00_SELECT_ESTIP_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2250_00_SELECT_ESTIP_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2250_00_SELECT_ESTIP_DB_SELECT_1_Query1();
            var i = 0;
            dta.CLIENTES_NOME_RAZAO = result[i++].Value?.ToString();
            dta.CLIENTES_CGCCPF = result[i++].Value?.ToString();
            dta.CLIENTES_TIPO_PESSOA = result[i++].Value?.ToString();
            return dta;
        }

    }
}