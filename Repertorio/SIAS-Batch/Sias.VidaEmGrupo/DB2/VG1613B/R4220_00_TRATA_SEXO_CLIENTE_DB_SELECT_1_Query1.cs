using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1613B
{
    public class R4220_00_TRATA_SEXO_CLIENTE_DB_SELECT_1_Query1 : QueryBasis<R4220_00_TRATA_SEXO_CLIENTE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT IFNULL(IDE_SEXO, ' ' )
            INTO :CLIENTES-IDE-SEXO
            FROM SEGUROS.CLIENTES
            WHERE COD_CLIENTE = :CLIENTES-COD-CLIENTE
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT IFNULL(IDE_SEXO
							, ' ' )
											FROM SEGUROS.CLIENTES
											WHERE COD_CLIENTE = '{this.CLIENTES_COD_CLIENTE}'
											WITH UR";

            return query;
        }
        public string CLIENTES_IDE_SEXO { get; set; }
        public string CLIENTES_COD_CLIENTE { get; set; }

        public static R4220_00_TRATA_SEXO_CLIENTE_DB_SELECT_1_Query1 Execute(R4220_00_TRATA_SEXO_CLIENTE_DB_SELECT_1_Query1 r4220_00_TRATA_SEXO_CLIENTE_DB_SELECT_1_Query1)
        {
            var ths = r4220_00_TRATA_SEXO_CLIENTE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R4220_00_TRATA_SEXO_CLIENTE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R4220_00_TRATA_SEXO_CLIENTE_DB_SELECT_1_Query1();
            var i = 0;
            dta.CLIENTES_IDE_SEXO = result[i++].Value?.ToString();
            return dta;
        }

    }
}