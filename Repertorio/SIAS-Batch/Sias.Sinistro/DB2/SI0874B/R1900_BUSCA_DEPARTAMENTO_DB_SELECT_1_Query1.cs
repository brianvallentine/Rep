using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0874B
{
    public class R1900_BUSCA_DEPARTAMENTO_DB_SELECT_1_Query1 : QueryBasis<R1900_BUSCA_DEPARTAMENTO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DEPARTAMENTO
            INTO :USUARIOS-DEPARTAMENTO
            FROM SEGUROS.USUARIOS
            WHERE COD_USUARIO = :SINISHIS-COD-USUARIO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DEPARTAMENTO
											FROM SEGUROS.USUARIOS
											WHERE COD_USUARIO = '{this.SINISHIS_COD_USUARIO}'
											WITH UR";

            return query;
        }
        public string USUARIOS_DEPARTAMENTO { get; set; }
        public string SINISHIS_COD_USUARIO { get; set; }

        public static R1900_BUSCA_DEPARTAMENTO_DB_SELECT_1_Query1 Execute(R1900_BUSCA_DEPARTAMENTO_DB_SELECT_1_Query1 r1900_BUSCA_DEPARTAMENTO_DB_SELECT_1_Query1)
        {
            var ths = r1900_BUSCA_DEPARTAMENTO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1900_BUSCA_DEPARTAMENTO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1900_BUSCA_DEPARTAMENTO_DB_SELECT_1_Query1();
            var i = 0;
            dta.USUARIOS_DEPARTAMENTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}