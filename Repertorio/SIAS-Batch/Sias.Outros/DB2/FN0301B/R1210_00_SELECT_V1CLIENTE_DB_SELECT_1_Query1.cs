using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.FN0301B
{
    public class R1210_00_SELECT_V1CLIENTE_DB_SELECT_1_Query1 : QueryBasis<R1210_00_SELECT_V1CLIENTE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NOME_RAZAO ,
            TIPO_PESSOA ,
            CGCCPF
            INTO :V1CLIE-NOME ,
            :V1CLIE-TPPESSOA ,
            :V1CLIE-CGCCPF
            FROM SEGUROS.V1CLIENTE
            WHERE COD_CLIENTE = :WHOST-CODCLIEN
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NOME_RAZAO 
							,
											TIPO_PESSOA 
							,
											CGCCPF
											FROM SEGUROS.V1CLIENTE
											WHERE COD_CLIENTE = '{this.WHOST_CODCLIEN}'
											WITH UR";

            return query;
        }
        public string V1CLIE_NOME { get; set; }
        public string V1CLIE_TPPESSOA { get; set; }
        public string V1CLIE_CGCCPF { get; set; }
        public string WHOST_CODCLIEN { get; set; }

        public static R1210_00_SELECT_V1CLIENTE_DB_SELECT_1_Query1 Execute(R1210_00_SELECT_V1CLIENTE_DB_SELECT_1_Query1 r1210_00_SELECT_V1CLIENTE_DB_SELECT_1_Query1)
        {
            var ths = r1210_00_SELECT_V1CLIENTE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1210_00_SELECT_V1CLIENTE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1210_00_SELECT_V1CLIENTE_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1CLIE_NOME = result[i++].Value?.ToString();
            dta.V1CLIE_TPPESSOA = result[i++].Value?.ToString();
            dta.V1CLIE_CGCCPF = result[i++].Value?.ToString();
            return dta;
        }

    }
}