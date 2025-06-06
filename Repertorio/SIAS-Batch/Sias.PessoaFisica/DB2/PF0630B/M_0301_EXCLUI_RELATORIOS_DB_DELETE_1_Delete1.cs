using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0630B
{
    public class M_0301_EXCLUI_RELATORIOS_DB_DELETE_1_Delete1 : QueryBasis<M_0301_EXCLUI_RELATORIOS_DB_DELETE_1_Delete1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            DELETE
            FROM SEGUROS.RELATORIOS
            WHERE IDE_SISTEMA = 'PF'
            AND COD_RELATORIO = 'PF0630B'
            AND SIT_REGISTRO = '0'
            END-EXEC.
            */
            #endregion
            var query = @$"
				DELETE
				FROM SEGUROS.RELATORIOS
				WHERE IDE_SISTEMA = 'PF'
				AND COD_RELATORIO = 'PF0630B'
				AND SIT_REGISTRO = '0'";

            return query;
        }

        public static void Execute(M_0301_EXCLUI_RELATORIOS_DB_DELETE_1_Delete1 m_0301_EXCLUI_RELATORIOS_DB_DELETE_1_Delete1)
        {
            var ths = m_0301_EXCLUI_RELATORIOS_DB_DELETE_1_Delete1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_0301_EXCLUI_RELATORIOS_DB_DELETE_1_Delete1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}