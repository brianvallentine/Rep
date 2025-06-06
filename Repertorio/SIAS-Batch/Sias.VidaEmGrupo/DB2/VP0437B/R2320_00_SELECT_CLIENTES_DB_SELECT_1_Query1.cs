using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP0437B
{
    public class R2320_00_SELECT_CLIENTES_DB_SELECT_1_Query1 : QueryBasis<R2320_00_SELECT_CLIENTES_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NOME_RAZAO,
            IDE_SEXO
            INTO :CLIENTES-NOME-RAZAO,
            :CLIENTES-IDE-SEXO
            FROM SEGUROS.CLIENTES
            WHERE COD_CLIENTE = :WHOST-CODCLIEN
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NOME_RAZAO
							,
											IDE_SEXO
											FROM SEGUROS.CLIENTES
											WHERE COD_CLIENTE = '{this.WHOST_CODCLIEN}'";

            return query;
        }
        public string CLIENTES_NOME_RAZAO { get; set; }
        public string CLIENTES_IDE_SEXO { get; set; }
        public string WHOST_CODCLIEN { get; set; }

        public static R2320_00_SELECT_CLIENTES_DB_SELECT_1_Query1 Execute(R2320_00_SELECT_CLIENTES_DB_SELECT_1_Query1 r2320_00_SELECT_CLIENTES_DB_SELECT_1_Query1)
        {
            var ths = r2320_00_SELECT_CLIENTES_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2320_00_SELECT_CLIENTES_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2320_00_SELECT_CLIENTES_DB_SELECT_1_Query1();
            var i = 0;
            dta.CLIENTES_NOME_RAZAO = result[i++].Value?.ToString();
            dta.CLIENTES_IDE_SEXO = result[i++].Value?.ToString();
            return dta;
        }

    }
}