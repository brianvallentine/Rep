using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA4437B
{
    public class R2710_00_SELECT_ESTIP_DB_SELECT_1_Query1 : QueryBasis<R2710_00_SELECT_ESTIP_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT B.NOME_RAZAO
            INTO :CLIENTES-NOME-RAZAO
            FROM SEGUROS.APOLICES A,
            SEGUROS.CLIENTES B
            WHERE A.NUM_APOLICE = :WHOST-NRAPOLICE
            AND B.COD_CLIENTE = A.COD_CLIENTE
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT B.NOME_RAZAO
											FROM SEGUROS.APOLICES A
							,
											SEGUROS.CLIENTES B
											WHERE A.NUM_APOLICE = '{this.WHOST_NRAPOLICE}'
											AND B.COD_CLIENTE = A.COD_CLIENTE";

            return query;
        }
        public string CLIENTES_NOME_RAZAO { get; set; }
        public string WHOST_NRAPOLICE { get; set; }

        public static R2710_00_SELECT_ESTIP_DB_SELECT_1_Query1 Execute(R2710_00_SELECT_ESTIP_DB_SELECT_1_Query1 r2710_00_SELECT_ESTIP_DB_SELECT_1_Query1)
        {
            var ths = r2710_00_SELECT_ESTIP_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2710_00_SELECT_ESTIP_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2710_00_SELECT_ESTIP_DB_SELECT_1_Query1();
            var i = 0;
            dta.CLIENTES_NOME_RAZAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}