using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0009B
{
    public class R0610_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1 : QueryBasis<R0610_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_CLIENTE ,
            NOME_RAZAO ,
            DATA_NASCIMENTO
            INTO :V0CLIE-CODCLIEN ,
            :V0CLIE-NOME ,
            :V0CLIE-DTNASC:VIND-DTNASC
            FROM SEGUROS.V0CLIENTE
            WHERE COD_CLIENTE = :V0CLIE-CODCLIEN
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_CLIENTE 
							,
											NOME_RAZAO 
							,
											DATA_NASCIMENTO
											FROM SEGUROS.V0CLIENTE
											WHERE COD_CLIENTE = '{this.V0CLIE_CODCLIEN}'";

            return query;
        }
        public string V0CLIE_CODCLIEN { get; set; }
        public string V0CLIE_NOME { get; set; }
        public string V0CLIE_DTNASC { get; set; }
        public string VIND_DTNASC { get; set; }

        public static R0610_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1 Execute(R0610_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1 r0610_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1)
        {
            var ths = r0610_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0610_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0610_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0CLIE_CODCLIEN = result[i++].Value?.ToString();
            dta.V0CLIE_NOME = result[i++].Value?.ToString();
            dta.V0CLIE_DTNASC = result[i++].Value?.ToString();
            dta.VIND_DTNASC = string.IsNullOrWhiteSpace(dta.V0CLIE_DTNASC) ? "-1" : "0";
            return dta;
        }

    }
}