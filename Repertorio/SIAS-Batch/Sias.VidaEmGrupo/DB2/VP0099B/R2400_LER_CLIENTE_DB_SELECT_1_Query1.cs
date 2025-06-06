using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP0099B
{
    public class R2400_LER_CLIENTE_DB_SELECT_1_Query1 : QueryBasis<R2400_LER_CLIENTE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NOME_RAZAO,
            CGCCPF,
            DATA_NASCIMENTO
            INTO :CLIENTES-NOME-RAZAO
            ,:CLIENTES-CGCCPF
            ,:CLIENTES-DATA-NASCIMENTO :WS-I-DT-NASCIMENTO
            FROM SEGUROS.CLIENTES
            WHERE COD_CLIENTE = :CLIENTES-COD-CLIENTE
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT NOME_RAZAO
							,
											CGCCPF
							,
											DATA_NASCIMENTO
											FROM SEGUROS.CLIENTES
											WHERE COD_CLIENTE = '{this.CLIENTES_COD_CLIENTE}'
											WITH UR";

            return query;
        }
        public string CLIENTES_NOME_RAZAO { get; set; }
        public string CLIENTES_CGCCPF { get; set; }
        public string CLIENTES_DATA_NASCIMENTO { get; set; }
        public string WS_I_DT_NASCIMENTO { get; set; }
        public string CLIENTES_COD_CLIENTE { get; set; }

        public static R2400_LER_CLIENTE_DB_SELECT_1_Query1 Execute(R2400_LER_CLIENTE_DB_SELECT_1_Query1 r2400_LER_CLIENTE_DB_SELECT_1_Query1)
        {
            var ths = r2400_LER_CLIENTE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2400_LER_CLIENTE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2400_LER_CLIENTE_DB_SELECT_1_Query1();
            var i = 0;
            dta.CLIENTES_NOME_RAZAO = result[i++].Value?.ToString();
            dta.CLIENTES_CGCCPF = result[i++].Value?.ToString();
            dta.CLIENTES_DATA_NASCIMENTO = result[i++].Value?.ToString();
            dta.WS_I_DT_NASCIMENTO = string.IsNullOrWhiteSpace(dta.CLIENTES_DATA_NASCIMENTO) ? "-1" : "0";
            return dta;
        }

    }
}