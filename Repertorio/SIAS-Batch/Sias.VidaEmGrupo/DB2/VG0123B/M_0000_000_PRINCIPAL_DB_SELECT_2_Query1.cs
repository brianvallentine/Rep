using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0123B
{
    public class M_0000_000_PRINCIPAL_DB_SELECT_2_Query1 : QueryBasis<M_0000_000_PRINCIPAL_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT NOME_EMPRESA
            INTO :NOME-EMPRESA
            FROM SEGUROS.V1EMPRESA
            WHERE COD_EMPRESA = 0
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NOME_EMPRESA
											FROM SEGUROS.V1EMPRESA
											WHERE COD_EMPRESA = 0";

            return query;
        }
        public string NOME_EMPRESA { get; set; }

        public static M_0000_000_PRINCIPAL_DB_SELECT_2_Query1 Execute(M_0000_000_PRINCIPAL_DB_SELECT_2_Query1 m_0000_000_PRINCIPAL_DB_SELECT_2_Query1)
        {
            var ths = m_0000_000_PRINCIPAL_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0000_000_PRINCIPAL_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0000_000_PRINCIPAL_DB_SELECT_2_Query1();
            var i = 0;
            dta.NOME_EMPRESA = result[i++].Value?.ToString();
            return dta;
        }

    }
}