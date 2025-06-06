using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0642B
{
    public class R3320_VERIFICA_EXISTE_RELACION_DB_SELECT_1_Query1 : QueryBasis<R3320_VERIFICA_EXISTE_RELACION_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_PESSOA,
            COD_RELAC
            INTO :DCLR-PESSOA-TIPORELAC.COD-PESSOA,
            :DCLR-PESSOA-TIPORELAC.COD-RELAC
            FROM SEGUROS.R_PESSOA_TIPORELAC
            WHERE COD_PESSOA = :DCLR-PESSOA-TIPORELAC.COD-PESSOA
            AND COD_RELAC = :DCLR-PESSOA-TIPORELAC.COD-RELAC
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_PESSOA
							,
											COD_RELAC
											FROM SEGUROS.R_PESSOA_TIPORELAC
											WHERE COD_PESSOA = '{this.COD_PESSOA}'
											AND COD_RELAC = '{this.COD_RELAC}'
											WITH UR";

            return query;
        }
        public string COD_PESSOA { get; set; }
        public string COD_RELAC { get; set; }

        public static R3320_VERIFICA_EXISTE_RELACION_DB_SELECT_1_Query1 Execute(R3320_VERIFICA_EXISTE_RELACION_DB_SELECT_1_Query1 r3320_VERIFICA_EXISTE_RELACION_DB_SELECT_1_Query1)
        {
            var ths = r3320_VERIFICA_EXISTE_RELACION_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3320_VERIFICA_EXISTE_RELACION_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3320_VERIFICA_EXISTE_RELACION_DB_SELECT_1_Query1();
            var i = 0;
            dta.COD_PESSOA = result[i++].Value?.ToString();
            dta.COD_RELAC = result[i++].Value?.ToString();
            return dta;
        }

    }
}