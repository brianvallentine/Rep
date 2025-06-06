using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GE0503B
{
    public class R010_CRITICA_INCLUSAO_DB_SELECT_1_Query1 : QueryBasis<R010_CRITICA_INCLUSAO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_BANCO,
            COD_AGENCIA
            INTO :AGENCIAS-COD-BANCO,
            :AGENCIAS-COD-AGENCIA
            FROM SEGUROS.AGENCIAS
            WHERE COD_BANCO = :AGENCIAS-COD-BANCO
            AND COD_AGENCIA = :AGENCIAS-COD-AGENCIA
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_BANCO
							,
											COD_AGENCIA
											FROM SEGUROS.AGENCIAS
											WHERE COD_BANCO = '{this.AGENCIAS_COD_BANCO}'
											AND COD_AGENCIA = '{this.AGENCIAS_COD_AGENCIA}'
											WITH UR";

            return query;
        }
        public string AGENCIAS_COD_BANCO { get; set; }
        public string AGENCIAS_COD_AGENCIA { get; set; }

        public static R010_CRITICA_INCLUSAO_DB_SELECT_1_Query1 Execute(R010_CRITICA_INCLUSAO_DB_SELECT_1_Query1 r010_CRITICA_INCLUSAO_DB_SELECT_1_Query1)
        {
            var ths = r010_CRITICA_INCLUSAO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R010_CRITICA_INCLUSAO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R010_CRITICA_INCLUSAO_DB_SELECT_1_Query1();
            var i = 0;
            dta.AGENCIAS_COD_BANCO = result[i++].Value?.ToString();
            dta.AGENCIAS_COD_AGENCIA = result[i++].Value?.ToString();
            return dta;
        }

    }
}