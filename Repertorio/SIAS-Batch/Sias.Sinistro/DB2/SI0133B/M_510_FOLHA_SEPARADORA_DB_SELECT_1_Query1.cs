using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0133B
{
    public class M_510_FOLHA_SEPARADORA_DB_SELECT_1_Query1 : QueryBasis<M_510_FOLHA_SEPARADORA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NOME_USUARIO
            INTO :USUARIOS-NOME-USUARIO
            FROM SEGUROS.USUARIOS
            WHERE COD_USUARIO = :RELSIN-CODUSU
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT NOME_USUARIO
											FROM SEGUROS.USUARIOS
											WHERE COD_USUARIO = '{this.RELSIN_CODUSU}'
											WITH UR";

            return query;
        }
        public string USUARIOS_NOME_USUARIO { get; set; }
        public string RELSIN_CODUSU { get; set; }

        public static M_510_FOLHA_SEPARADORA_DB_SELECT_1_Query1 Execute(M_510_FOLHA_SEPARADORA_DB_SELECT_1_Query1 m_510_FOLHA_SEPARADORA_DB_SELECT_1_Query1)
        {
            var ths = m_510_FOLHA_SEPARADORA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_510_FOLHA_SEPARADORA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_510_FOLHA_SEPARADORA_DB_SELECT_1_Query1();
            var i = 0;
            dta.USUARIOS_NOME_USUARIO = result[i++].Value?.ToString();
            return dta;
        }

    }
}