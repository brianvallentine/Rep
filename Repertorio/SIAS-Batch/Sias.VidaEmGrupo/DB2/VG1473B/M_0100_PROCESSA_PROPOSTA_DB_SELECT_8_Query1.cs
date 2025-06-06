using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1473B
{
    public class M_0100_PROCESSA_PROPOSTA_DB_SELECT_8_Query1 : QueryBasis<M_0100_PROCESSA_PROPOSTA_DB_SELECT_8_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_PAIS
            INTO :UNIDAFED-COD-PAIS
            FROM SEGUROS.UNIDADE_FEDERACAO
            WHERE SIGLA_UF = :ENDERECO-SIGLA-UF
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_PAIS
											FROM SEGUROS.UNIDADE_FEDERACAO
											WHERE SIGLA_UF = '{this.ENDERECO_SIGLA_UF}'
											WITH UR";

            return query;
        }
        public string UNIDAFED_COD_PAIS { get; set; }
        public string ENDERECO_SIGLA_UF { get; set; }

        public static M_0100_PROCESSA_PROPOSTA_DB_SELECT_8_Query1 Execute(M_0100_PROCESSA_PROPOSTA_DB_SELECT_8_Query1 m_0100_PROCESSA_PROPOSTA_DB_SELECT_8_Query1)
        {
            var ths = m_0100_PROCESSA_PROPOSTA_DB_SELECT_8_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0100_PROCESSA_PROPOSTA_DB_SELECT_8_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0100_PROCESSA_PROPOSTA_DB_SELECT_8_Query1();
            var i = 0;
            dta.UNIDAFED_COD_PAIS = result[i++].Value?.ToString();
            return dta;
        }

    }
}