using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0803B
{
    public class M_510_000_LER_TEMPRESA_DB_SELECT_1_Query1 : QueryBasis<M_510_000_LER_TEMPRESA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NOME_EMPRESA
            INTO :TEMPRESA-NOM-EMP
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
        public string TEMPRESA_NOM_EMP { get; set; }

        public static M_510_000_LER_TEMPRESA_DB_SELECT_1_Query1 Execute(M_510_000_LER_TEMPRESA_DB_SELECT_1_Query1 m_510_000_LER_TEMPRESA_DB_SELECT_1_Query1)
        {
            var ths = m_510_000_LER_TEMPRESA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_510_000_LER_TEMPRESA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_510_000_LER_TEMPRESA_DB_SELECT_1_Query1();
            var i = 0;
            dta.TEMPRESA_NOM_EMP = result[i++].Value?.ToString();
            return dta;
        }

    }
}