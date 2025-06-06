using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI3605B
{
    public class R0006_00_OBTER_RELATORI_DB_SELECT_1_Query1 : QueryBasis<R0006_00_OBTER_RELATORI_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_SOLICITACAO + 1 DAY
            INTO :RELATORI-DATA-SOLICITACAO
            FROM SEGUROS.RELATORIOS
            WHERE COD_USUARIO = :RELATORI-COD-USUARIO
            AND COD_RELATORIO = :RELATORI-COD-RELATORIO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_SOLICITACAO + 1 DAY
											FROM SEGUROS.RELATORIOS
											WHERE COD_USUARIO = '{this.RELATORI_COD_USUARIO}'
											AND COD_RELATORIO = '{this.RELATORI_COD_RELATORIO}'";

            return query;
        }
        public string RELATORI_DATA_SOLICITACAO { get; set; }
        public string RELATORI_COD_RELATORIO { get; set; }
        public string RELATORI_COD_USUARIO { get; set; }

        public static R0006_00_OBTER_RELATORI_DB_SELECT_1_Query1 Execute(R0006_00_OBTER_RELATORI_DB_SELECT_1_Query1 r0006_00_OBTER_RELATORI_DB_SELECT_1_Query1)
        {
            var ths = r0006_00_OBTER_RELATORI_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0006_00_OBTER_RELATORI_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0006_00_OBTER_RELATORI_DB_SELECT_1_Query1();
            var i = 0;
            dta.RELATORI_DATA_SOLICITACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}