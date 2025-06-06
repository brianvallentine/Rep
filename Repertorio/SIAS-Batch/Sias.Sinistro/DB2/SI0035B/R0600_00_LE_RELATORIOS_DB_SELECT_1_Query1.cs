using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0035B
{
    public class R0600_00_LE_RELATORIOS_DB_SELECT_1_Query1 : QueryBasis<R0600_00_LE_RELATORIOS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_USUARIO
            INTO :RELATORI-COD-USUARIO
            FROM SEGUROS.RELATORIOS
            WHERE COD_RELATORIO = 'SI0035B'
            AND IDE_SISTEMA = 'SI'
            AND DATA_SOLICITACAO = :SISTEMAS-DATA-MOV-ABERTO
            AND SIT_REGISTRO = '0'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_USUARIO
											FROM SEGUROS.RELATORIOS
											WHERE COD_RELATORIO = 'SI0035B'
											AND IDE_SISTEMA = 'SI'
											AND DATA_SOLICITACAO = '{this.SISTEMAS_DATA_MOV_ABERTO}'
											AND SIT_REGISTRO = '0'";

            return query;
        }
        public string RELATORI_COD_USUARIO { get; set; }
        public string SISTEMAS_DATA_MOV_ABERTO { get; set; }

        public static R0600_00_LE_RELATORIOS_DB_SELECT_1_Query1 Execute(R0600_00_LE_RELATORIOS_DB_SELECT_1_Query1 r0600_00_LE_RELATORIOS_DB_SELECT_1_Query1)
        {
            var ths = r0600_00_LE_RELATORIOS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0600_00_LE_RELATORIOS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0600_00_LE_RELATORIOS_DB_SELECT_1_Query1();
            var i = 0;
            dta.RELATORI_COD_USUARIO = result[i++].Value?.ToString();
            return dta;
        }

    }
}