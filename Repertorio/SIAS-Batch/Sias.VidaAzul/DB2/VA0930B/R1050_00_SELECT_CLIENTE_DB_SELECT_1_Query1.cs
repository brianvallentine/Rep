using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0930B
{
    public class R1050_00_SELECT_CLIENTE_DB_SELECT_1_Query1 : QueryBasis<R1050_00_SELECT_CLIENTE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NOME_RAZAO,
            CGCCPF,
            TIPO_PESSOA,
            DATA_NASCIMENTO
            INTO :V0CLIE-NOME-RAZAO,
            :V0CLIE-CGCCPF,
            :V0CLIE-TIPO-PESSOA,
            :V0CLIE-DATA-NASC:VIND-DATA-NASC
            FROM SEGUROS.V0CLIENTE
            WHERE COD_CLIENTE = :WS-COD-CLIENTE
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NOME_RAZAO
							,
											CGCCPF
							,
											TIPO_PESSOA
							,
											DATA_NASCIMENTO
											FROM SEGUROS.V0CLIENTE
											WHERE COD_CLIENTE = '{this.WS_COD_CLIENTE}'
											WITH UR";

            return query;
        }
        public string V0CLIE_NOME_RAZAO { get; set; }
        public string V0CLIE_CGCCPF { get; set; }
        public string V0CLIE_TIPO_PESSOA { get; set; }
        public string V0CLIE_DATA_NASC { get; set; }
        public string VIND_DATA_NASC { get; set; }
        public string WS_COD_CLIENTE { get; set; }

        public static R1050_00_SELECT_CLIENTE_DB_SELECT_1_Query1 Execute(R1050_00_SELECT_CLIENTE_DB_SELECT_1_Query1 r1050_00_SELECT_CLIENTE_DB_SELECT_1_Query1)
        {
            var ths = r1050_00_SELECT_CLIENTE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1050_00_SELECT_CLIENTE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1050_00_SELECT_CLIENTE_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0CLIE_NOME_RAZAO = result[i++].Value?.ToString();
            dta.V0CLIE_CGCCPF = result[i++].Value?.ToString();
            dta.V0CLIE_TIPO_PESSOA = result[i++].Value?.ToString();
            dta.V0CLIE_DATA_NASC = result[i++].Value?.ToString();
            dta.VIND_DATA_NASC = string.IsNullOrWhiteSpace(dta.V0CLIE_DATA_NASC) ? "-1" : "0";
            return dta;
        }

    }
}