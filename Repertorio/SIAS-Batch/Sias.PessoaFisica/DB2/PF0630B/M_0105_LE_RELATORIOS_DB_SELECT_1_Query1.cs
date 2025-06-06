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
    public class M_0105_LE_RELATORIOS_DB_SELECT_1_Query1 : QueryBasis<M_0105_LE_RELATORIOS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_RELATORIO
            INTO :RELATORI-COD-RELATORIO
            FROM SEGUROS.RELATORIOS
            WHERE IDE_SISTEMA = 'PF'
            AND COD_RELATORIO = :RELATORI-COD-RELATORIO
            AND SIT_REGISTRO = '0'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_RELATORIO
											FROM SEGUROS.RELATORIOS
											WHERE IDE_SISTEMA = 'PF'
											AND COD_RELATORIO = '{this.RELATORI_COD_RELATORIO}'
											AND SIT_REGISTRO = '0'";

            return query;
        }
        public string RELATORI_COD_RELATORIO { get; set; }

        public static M_0105_LE_RELATORIOS_DB_SELECT_1_Query1 Execute(M_0105_LE_RELATORIOS_DB_SELECT_1_Query1 m_0105_LE_RELATORIOS_DB_SELECT_1_Query1)
        {
            var ths = m_0105_LE_RELATORIOS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0105_LE_RELATORIOS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0105_LE_RELATORIOS_DB_SELECT_1_Query1();
            var i = 0;
            dta.RELATORI_COD_RELATORIO = result[i++].Value?.ToString();
            return dta;
        }

    }
}