using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GE0550B
{
    public class R0410_00_SELECT_USUARIOS_DB_SELECT_1_Query1 : QueryBasis<R0410_00_SELECT_USUARIOS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_FONTE ,
            VALUE(COD_USUARIO, ' ' )
            INTO :USUARIOS-COD-FONTE ,
            :USUARIOS-COD-USUARIO
            FROM SEGUROS.USUARIOS
            WHERE COD_USUARIO = :USUARIOS-COD-USUARIO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_FONTE 
							,
											VALUE(COD_USUARIO
							, ' ' )
											FROM SEGUROS.USUARIOS
											WHERE COD_USUARIO = '{this.USUARIOS_COD_USUARIO}'";

            return query;
        }
        public string USUARIOS_COD_FONTE { get; set; }
        public string USUARIOS_COD_USUARIO { get; set; }

        public static R0410_00_SELECT_USUARIOS_DB_SELECT_1_Query1 Execute(R0410_00_SELECT_USUARIOS_DB_SELECT_1_Query1 r0410_00_SELECT_USUARIOS_DB_SELECT_1_Query1)
        {
            var ths = r0410_00_SELECT_USUARIOS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0410_00_SELECT_USUARIOS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0410_00_SELECT_USUARIOS_DB_SELECT_1_Query1();
            var i = 0;
            dta.USUARIOS_COD_FONTE = result[i++].Value?.ToString();
            dta.USUARIOS_COD_USUARIO = result[i++].Value?.ToString();
            return dta;
        }

    }
}