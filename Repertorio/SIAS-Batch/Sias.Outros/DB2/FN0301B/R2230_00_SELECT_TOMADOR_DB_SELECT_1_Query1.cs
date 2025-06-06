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
    public class R2230_00_SELECT_TOMADOR_DB_SELECT_1_Query1 : QueryBasis<R2230_00_SELECT_TOMADOR_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT T.COD_FONTE ,
            T.NUM_PROPOSTA ,
            T.COD_CLIENTE ,
            C.NOME_RAZAO
            INTO :TOMADOR-COD-FONTE ,
            :TOMADOR-NUM-PROPOSTA ,
            :TOMADOR-COD-CLIENTE ,
            :CLIENTES-NOME-RAZAO
            FROM SEGUROS.TOMADOR T ,
            SEGUROS.CLIENTES C
            WHERE T.COD_FONTE = :TOMADOR-COD-FONTE
            AND T.NUM_PROPOSTA = :TOMADOR-NUM-PROPOSTA
            AND C.COD_CLIENTE = T.COD_CLIENTE
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT T.COD_FONTE 
							,
											T.NUM_PROPOSTA 
							,
											T.COD_CLIENTE 
							,
											C.NOME_RAZAO
											FROM SEGUROS.TOMADOR T 
							,
											SEGUROS.CLIENTES C
											WHERE T.COD_FONTE = '{this.TOMADOR_COD_FONTE}'
											AND T.NUM_PROPOSTA = '{this.TOMADOR_NUM_PROPOSTA}'
											AND C.COD_CLIENTE = T.COD_CLIENTE
											WITH UR";

            return query;
        }
        public string TOMADOR_COD_FONTE { get; set; }
        public string TOMADOR_NUM_PROPOSTA { get; set; }
        public string TOMADOR_COD_CLIENTE { get; set; }
        public string CLIENTES_NOME_RAZAO { get; set; }

        public static R2230_00_SELECT_TOMADOR_DB_SELECT_1_Query1 Execute(R2230_00_SELECT_TOMADOR_DB_SELECT_1_Query1 r2230_00_SELECT_TOMADOR_DB_SELECT_1_Query1)
        {
            var ths = r2230_00_SELECT_TOMADOR_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2230_00_SELECT_TOMADOR_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2230_00_SELECT_TOMADOR_DB_SELECT_1_Query1();
            var i = 0;
            dta.TOMADOR_COD_FONTE = result[i++].Value?.ToString();
            dta.TOMADOR_NUM_PROPOSTA = result[i++].Value?.ToString();
            dta.TOMADOR_COD_CLIENTE = result[i++].Value?.ToString();
            dta.CLIENTES_NOME_RAZAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}