using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0601B
{
    public class R2304_00_VERIFICA_ESPACO_NOME_DB_SELECT_1_Query1 : QueryBasis<R2304_00_VERIFICA_ESPACO_NOME_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT LENGTH(TRIM(NOME_RAZAO)) -
            LENGTH(REPLACE(TRIM(NOME_RAZAO), ' ' , '' )),
            NOME_RAZAO
            INTO :WHOST-CONT-ESPACO,
            :WHOST-NOME-CLIENTE
            FROM SEGUROS.CLIENTES
            WHERE COD_CLIENTE = :DCLCLIENTES.COD-CLIENTE
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT LENGTH(TRIM(NOME_RAZAO)) -
											LENGTH(REPLACE(TRIM(NOME_RAZAO)
							, ' ' 
							, '' ))
							,
											NOME_RAZAO
											FROM SEGUROS.CLIENTES
											WHERE COD_CLIENTE = '{this.COD_CLIENTE}'";

            return query;
        }
        public string WHOST_CONT_ESPACO { get; set; }
        public string WHOST_NOME_CLIENTE { get; set; }
        public string COD_CLIENTE { get; set; }

        public static R2304_00_VERIFICA_ESPACO_NOME_DB_SELECT_1_Query1 Execute(R2304_00_VERIFICA_ESPACO_NOME_DB_SELECT_1_Query1 r2304_00_VERIFICA_ESPACO_NOME_DB_SELECT_1_Query1)
        {
            var ths = r2304_00_VERIFICA_ESPACO_NOME_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2304_00_VERIFICA_ESPACO_NOME_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2304_00_VERIFICA_ESPACO_NOME_DB_SELECT_1_Query1();
            var i = 0;
            dta.WHOST_CONT_ESPACO = result[i++].Value?.ToString();
            dta.WHOST_NOME_CLIENTE = result[i++].Value?.ToString();
            return dta;
        }

    }
}