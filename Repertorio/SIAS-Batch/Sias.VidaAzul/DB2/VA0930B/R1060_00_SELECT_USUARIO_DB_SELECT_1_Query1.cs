using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0930B
{
    public class R1060_00_SELECT_USUARIO_DB_SELECT_1_Query1 : QueryBasis<R1060_00_SELECT_USUARIO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NOMUSU
            INTO :V0USUA-NOMUSU
            FROM SEGUROS.V0USUARIOS
            WHERE CODUSU = :RELATORI-COD-USUARIO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NOMUSU
											FROM SEGUROS.V0USUARIOS
											WHERE CODUSU = '{this.RELATORI_COD_USUARIO}'
											WITH UR";

            return query;
        }
        public string V0USUA_NOMUSU { get; set; }
        public string RELATORI_COD_USUARIO { get; set; }

        public static R1060_00_SELECT_USUARIO_DB_SELECT_1_Query1 Execute(R1060_00_SELECT_USUARIO_DB_SELECT_1_Query1 r1060_00_SELECT_USUARIO_DB_SELECT_1_Query1)
        {
            var ths = r1060_00_SELECT_USUARIO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1060_00_SELECT_USUARIO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1060_00_SELECT_USUARIO_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0USUA_NOMUSU = result[i++].Value?.ToString();
            return dta;
        }

    }
}