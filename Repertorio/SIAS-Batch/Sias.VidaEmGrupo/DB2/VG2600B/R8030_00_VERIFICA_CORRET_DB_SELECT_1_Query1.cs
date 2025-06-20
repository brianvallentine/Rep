using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG2600B
{
    public class R8030_00_VERIFICA_CORRET_DB_SELECT_1_Query1 : QueryBasis<R8030_00_VERIFICA_CORRET_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NOME_PRODUTOR
            INTO :PRODUTOR-NOME-PRODUTOR
            FROM SEGUROS.PRODUTORES
            WHERE COD_PRODUTOR = :PRODUTOR-COD-PRODUTOR
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NOME_PRODUTOR
											FROM SEGUROS.PRODUTORES
											WHERE COD_PRODUTOR = '{this.PRODUTOR_COD_PRODUTOR}'
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string PRODUTOR_NOME_PRODUTOR { get; set; }
        public string PRODUTOR_COD_PRODUTOR { get; set; }

        public static R8030_00_VERIFICA_CORRET_DB_SELECT_1_Query1 Execute(R8030_00_VERIFICA_CORRET_DB_SELECT_1_Query1 r8030_00_VERIFICA_CORRET_DB_SELECT_1_Query1)
        {
            var ths = r8030_00_VERIFICA_CORRET_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R8030_00_VERIFICA_CORRET_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R8030_00_VERIFICA_CORRET_DB_SELECT_1_Query1();
            var i = 0;
            dta.PRODUTOR_NOME_PRODUTOR = result[i++].Value?.ToString();
            return dta;
        }

    }
}