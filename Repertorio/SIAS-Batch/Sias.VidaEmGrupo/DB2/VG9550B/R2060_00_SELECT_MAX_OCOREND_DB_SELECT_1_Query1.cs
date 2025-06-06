using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG9550B
{
    public class R2060_00_SELECT_MAX_OCOREND_DB_SELECT_1_Query1 : QueryBasis<R2060_00_SELECT_MAX_OCOREND_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(MAX(OCORR_ENDERECO), 0)
            INTO :WS-MAX-OCOREND
            FROM SEGUROS.ENDERECOS
            WHERE COD_CLIENTE = :SEGURVGA-COD-CLIENTE
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(MAX(OCORR_ENDERECO)
							, 0)
											FROM SEGUROS.ENDERECOS
											WHERE COD_CLIENTE = '{this.SEGURVGA_COD_CLIENTE}'
											WITH UR";

            return query;
        }
        public string WS_MAX_OCOREND { get; set; }
        public string SEGURVGA_COD_CLIENTE { get; set; }

        public static R2060_00_SELECT_MAX_OCOREND_DB_SELECT_1_Query1 Execute(R2060_00_SELECT_MAX_OCOREND_DB_SELECT_1_Query1 r2060_00_SELECT_MAX_OCOREND_DB_SELECT_1_Query1)
        {
            var ths = r2060_00_SELECT_MAX_OCOREND_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2060_00_SELECT_MAX_OCOREND_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2060_00_SELECT_MAX_OCOREND_DB_SELECT_1_Query1();
            var i = 0;
            dta.WS_MAX_OCOREND = result[i++].Value?.ToString();
            return dta;
        }

    }
}