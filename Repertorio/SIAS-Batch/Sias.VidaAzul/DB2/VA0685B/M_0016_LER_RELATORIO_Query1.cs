using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0685B
{
    public class M_0016_LER_RELATORIO_Query1 : QueryBasis<M_0016_LER_RELATORIO_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT PERI_INICIAL
            INTO :RELATORI-PERI-INICIAL
            FROM SEGUROS.RELATORIOS
            WHERE COD_USUARIO = 'VA0685B'
            AND COD_RELATORIO = 'VA0685B'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT PERI_INICIAL
											FROM SEGUROS.RELATORIOS
											WHERE COD_USUARIO = 'VA0685B'
											AND COD_RELATORIO = 'VA0685B'";

            return query;
        }
        public string RELATORI_PERI_INICIAL { get; set; }

        public static M_0016_LER_RELATORIO_Query1 Execute(M_0016_LER_RELATORIO_Query1 m_0016_LER_RELATORIO_Query1)
        {
            var ths = m_0016_LER_RELATORIO_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0016_LER_RELATORIO_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0016_LER_RELATORIO_Query1();
            var i = 0;
            dta.RELATORI_PERI_INICIAL = result[i++].Value?.ToString();
            return dta;
        }

    }
}