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
    public class R4300_00_INSERT_ENDERECO_DB_SELECT_1_Query1 : QueryBasis<R4300_00_INSERT_ENDERECO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(MAX(OCORR_ENDERECO),0)
            INTO :ENDERECO-OCORR-ENDERECO
            FROM SEGUROS.ENDERECOS
            WHERE COD_CLIENTE = :CLIENTES-COD-CLIENTE
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(MAX(OCORR_ENDERECO)
							,0)
											FROM SEGUROS.ENDERECOS
											WHERE COD_CLIENTE = '{this.CLIENTES_COD_CLIENTE}'";

            return query;
        }
        public string ENDERECO_OCORR_ENDERECO { get; set; }
        public string CLIENTES_COD_CLIENTE { get; set; }

        public static R4300_00_INSERT_ENDERECO_DB_SELECT_1_Query1 Execute(R4300_00_INSERT_ENDERECO_DB_SELECT_1_Query1 r4300_00_INSERT_ENDERECO_DB_SELECT_1_Query1)
        {
            var ths = r4300_00_INSERT_ENDERECO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R4300_00_INSERT_ENDERECO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R4300_00_INSERT_ENDERECO_DB_SELECT_1_Query1();
            var i = 0;
            dta.ENDERECO_OCORR_ENDERECO = result[i++].Value?.ToString();
            return dta;
        }

    }
}