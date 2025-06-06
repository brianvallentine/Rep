using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI2010B
{
    public class R0640_00_LER_RAZAO_SOCIAL_DB_SELECT_1_Query1 : QueryBasis<R0640_00_LER_RAZAO_SOCIAL_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT T1.NOME_RAZAO
            INTO :CLIENTES-NOME-RAZAO
            FROM SEGUROS.CLIENTES T1
            , SEGUROS.LOTERICO01 T2
            WHERE
            T1.COD_CLIENTE = T2.COD_CLIENTE
            AND T2.NUM_APOLICE = :SINISMES-NUM-APOLICE
            AND T2.DTTERVIG =
            (SELECT MAX(T3.DTTERVIG)
            FROM SEGUROS.LOTERICO01 T3
            WHERE
            T3.COD_CLIENTE = T2.COD_CLIENTE
            AND T2.NUM_APOLICE = T3.NUM_APOLICE )
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT T1.NOME_RAZAO
											FROM SEGUROS.CLIENTES T1
											, SEGUROS.LOTERICO01 T2
											WHERE
											T1.COD_CLIENTE = T2.COD_CLIENTE
											AND T2.NUM_APOLICE = '{this.SINISMES_NUM_APOLICE}'
											AND T2.DTTERVIG =
											(SELECT MAX(T3.DTTERVIG)
											FROM SEGUROS.LOTERICO01 T3
											WHERE
											T3.COD_CLIENTE = T2.COD_CLIENTE
											AND T2.NUM_APOLICE = T3.NUM_APOLICE )
											WITH UR";

            return query;
        }
        public string CLIENTES_NOME_RAZAO { get; set; }
        public string SINISMES_NUM_APOLICE { get; set; }

        public static R0640_00_LER_RAZAO_SOCIAL_DB_SELECT_1_Query1 Execute(R0640_00_LER_RAZAO_SOCIAL_DB_SELECT_1_Query1 r0640_00_LER_RAZAO_SOCIAL_DB_SELECT_1_Query1)
        {
            var ths = r0640_00_LER_RAZAO_SOCIAL_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0640_00_LER_RAZAO_SOCIAL_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0640_00_LER_RAZAO_SOCIAL_DB_SELECT_1_Query1();
            var i = 0;
            dta.CLIENTES_NOME_RAZAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}