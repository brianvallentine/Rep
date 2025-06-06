using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP0020B
{
    public class M_1100_INCLUSAO_DB_SELECT_1_Query1 : QueryBasis<M_1100_INCLUSAO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NOME_UNIDADE
            INTO :SQL-NOME-UNID
            FROM SEGUROS.V0UNIDADECEF
            WHERE COD_SUREG = :SQL-SUREG
            AND COD_UNIDADE = :SQL-UNIDADE
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NOME_UNIDADE
											FROM SEGUROS.V0UNIDADECEF
											WHERE COD_SUREG = '{this.SQL_SUREG}'
											AND COD_UNIDADE = '{this.SQL_UNIDADE}'";

            return query;
        }
        public string SQL_NOME_UNID { get; set; }
        public string SQL_UNIDADE { get; set; }
        public string SQL_SUREG { get; set; }

        public static M_1100_INCLUSAO_DB_SELECT_1_Query1 Execute(M_1100_INCLUSAO_DB_SELECT_1_Query1 m_1100_INCLUSAO_DB_SELECT_1_Query1)
        {
            var ths = m_1100_INCLUSAO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_1100_INCLUSAO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_1100_INCLUSAO_DB_SELECT_1_Query1();
            var i = 0;
            dta.SQL_NOME_UNID = result[i++].Value?.ToString();
            return dta;
        }

    }
}